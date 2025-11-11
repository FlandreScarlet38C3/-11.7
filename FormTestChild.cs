using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace 测试系统_10._31
{
    public partial class FormTestChild:Form
    {
        // 串口管理器实例
        private SerialPortManager serialPortManager;

        public FormTestChild()
        {
            InitializeComponent();
            InitializeSerialPortManager();
        }

        /// <summary>
        /// 初始化串口管理器
        /// </summary>
        private void InitializeSerialPortManager()
        {
            // 获取单例实例
            serialPortManager = SerialPortManager.Instance;

            // 订阅事件
            if (serialPortManager != null)
            {
                serialPortManager.DataReceived += OnDataReceived;
                serialPortManager.StatusChanged += OnStatusChanged;
                serialPortManager.ErrorOccurred += OnErrorOccurred;
            }
        }

        /// <summary>
        /// 表单加载事件
        /// </summary>
        private void FormTestChild_Load(object sender, EventArgs e)
        {
            // 设置默认参数
            ComboBoxForPotterValue.SelectedItem = "9600";
            ComboBoxForDataSet.SelectedItem = "8";
            ComboBoxForStopBit.SelectedItem = "1";
            ComboBoxForCheck.SelectedItem = "None";
            ComboBoxForControl.SelectedItem = "None";

            // 更新连接状态
            UpdateConnectionStatus();
        }

        /// <summary>
        /// 表单关闭事件
        /// </summary>
        private void FormTestChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 确保关闭串口
            if (serialPortManager != null)
            {
                serialPortManager.ClosePort();
            }
        }

        /// <summary>
        /// 串口号下拉框展开事件
        /// </summary>
        private void ComboBoxForPort_DropDown(object sender, EventArgs e)
        {
            ComboBoxForPort.Items.Clear();

            try
            {
                // 获取所有可用的串口
                var ports = serialPortManager.GetAvailablePorts();

                if (ports.Count > 0)
                {
                    // 添加到下拉框
                    foreach (var port in ports)
                    {
                        ComboBoxForPort.Items.Add(port);
                    }

                    // 选择第一个串口
                    ComboBoxForPort.SelectedIndex = 0;
                }
                else
                {
                    // 没有找到串口
                    ComboBoxForPort.Items.Add("没有可用串口");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"扫描串口失败: {ex.Message}");
                ComboBoxForPort.Items.Add("扫描失败");
            }
        }




        /// <summary>
        /// 打开串口按钮点击事件
        /// </summary>
        private void ButtonForOpenPort_Click(object sender, EventArgs e)
        {
            try
            {
                // 检查是否选择了有效的串口
                if (ComboBoxForPort.SelectedItem == null || ComboBoxForPort.Text == "没有可用串口" || ComboBoxForPort.Text == "扫描失败")
                {
                    ShowErrorMessage("请先选择有效的串口号");
                    return;
                }

                // 获取串口名称
                string portName = "";
                if (ComboBoxForPort.SelectedItem is SerialPortInfo portInfo)
                {
                    portName = portInfo.PortName;
                }
                else if (!string.IsNullOrEmpty(ComboBoxForPort.Text))
                {
                    portName = ComboBoxForPort.Text;
                }
                else
                {
                    ShowErrorMessage("串口号无效");
                    return;
                }
                

                // 获取串口参数
                string baudRateStr = ComboBoxForPotterValue.SelectedItem?.ToString() ?? string.Empty;
                string dataBitsStr = ComboBoxForDataSet.SelectedItem?.ToString() ?? string.Empty;
                string stopBitsStr = ComboBoxForStopBit.SelectedItem?.ToString() ?? string.Empty;
                string parityStr = ComboBoxForCheck.SelectedItem?.ToString() ?? string.Empty;
                string flowControlStr = ComboBoxForControl.SelectedItem?.ToString() ?? string.Empty;

                // 参数验证
                if (string.IsNullOrEmpty(baudRateStr) || string.IsNullOrEmpty(dataBitsStr) ||
                    string.IsNullOrEmpty(stopBitsStr) || string.IsNullOrEmpty(parityStr) ||
                    string.IsNullOrEmpty(flowControlStr))
                {
                    ShowErrorMessage("请选择完整的串口参数");
                    return;
                }

                int baudRate = int.Parse(baudRateStr);
                int dataBits = int.Parse(dataBitsStr);
                StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBitsStr);
                Parity parity = (Parity)Enum.Parse(typeof(Parity), parityStr);
                Handshake handshake = (Handshake)Enum.Parse(typeof(Handshake), flowControlStr);

                // 更新串口配置
                serialPortManager.UpdatePortSettings(portName, baudRate, dataBits, stopBits, parity, handshake);

                // 打开串口
                bool success = serialPortManager.OpenPort();
                if (success)
                {
                    // 更新UI状态
                    UpdateUIForPortOpen();
                    UpdateConnectionStatus();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"打开串口失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 关闭串口按钮点击事件
        /// </summary>
        private void buttonClosePort_Click(object sender, EventArgs e)
        {
            try
            {
                // 关闭串口
                serialPortManager.ClosePort();

                // 更新UI状态
                UpdateUIForPortClose();
                UpdateConnectionStatus();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"关闭串口失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 发送按钮点击事件
        /// </summary>
        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                // 检查是否有数据要发送
                if (string.IsNullOrEmpty(RichBoxSend.Text))
                {
                    ShowErrorMessage("请输入要发送的数据");
                    return;
                }

                // 发送数据
                bool success = serialPortManager.SendData(RichBoxSend.Text, CheckBoxHexSend.Checked);
                if (success)
                {
                    // 更新发送字节计数
                    UpdateBytesCount();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"发送数据失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 清空发送按钮点击事件
        /// </summary>
        private void buttonClearSend_Click(object sender, EventArgs e)
        {
            RichBoxSend.Clear();
        }

        /// <summary>
        /// 清空接收按钮点击事件
        /// </summary>
        private void buttonClearReceive_Click(object sender, EventArgs e)
        {
            RichBoxReceive.Clear();
            // 重置接收计数
            serialPortManager.ResetCounters();
            UpdateBytesCount();
        }

        /// <summary>
        /// 数据接收事件处理
        /// </summary>
        private void OnDataReceived(object sender, byte[] data)
        {
            // 在UI线程上更新接收框
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    if (data == null || data.Length == 0)
                        return;

                    string displayText = string.Empty;

                    // 检查是否需要显示时间戳
                    if (CheckBoxTime.Checked)
                    {
                        displayText += $"[{DateTime.Now.ToString("HH:mm:ss.fff")}] ";
                    }

                    // 根据显示模式处理数据
                    if (CheckBoxHexSend.Checked)
                    {
                        // 十六进制显示
                        StringBuilder hexBuilder = new StringBuilder();
                        foreach (byte b in data)
                        {
                            hexBuilder.Append($"{b:X2} ");
                        }
                        displayText += hexBuilder.ToString().Trim();
                    }
                    else
                    {
                        // ASCII显示
                        try
                        {
                            displayText += Encoding.UTF8.GetString(data);
                        }
                        catch
                        {
                            // 如果UTF8解码失败，使用ASCII
                            displayText += Encoding.ASCII.GetString(data);
                        }
                    }

                    // 添加到接收框
                    AppendToReceiveBox(displayText + Environment.NewLine);

                    // 更新接收字节计数
                    UpdateBytesCount();
                }
                catch (Exception ex)
                {
                    ShowErrorMessage($"处理接收数据失败: {ex.Message}");
                }
            });
        }

        /// <summary>
        /// 状态改变事件处理
        /// </summary>
        private void OnStatusChanged(object sender, string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
               // labelStatusInfo.Text = message ?? string.Empty;
                UpdateBytesCount();
            });
        }

        /// <summary>
        /// 错误事件处理
        /// </summary>
        private void OnErrorOccurred(object? sender, Exception ex)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (ex != null)
                {
                    ShowErrorMessage(ex.Message);
                }
                UpdateConnectionStatus();
            });
        }

        /// <summary>
        /// 向接收框添加文本
        /// </summary>
        private void AppendToReceiveBox(string text)
        {
            // 检查是否需要清空旧内容（防止文本过长）
            if (RichBoxReceive.TextLength > 100000)
            {
                RichBoxReceive.Clear();
            }

            // 添加新内容
            RichBoxReceive.AppendText(text);
            RichBoxReceive.ScrollToCaret();
        }

        /// <summary>
        /// 更新连接状态显示
        /// </summary>
        private void UpdateConnectionStatus()
        {
            if (serialPortManager.IsPortOpen)
            {
                MessageBox.Show("串口已连接", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //labelConnectionStatus.Text = $"已连接: {serialPortManager.CurrentPortName}";
                //labelConnectionStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                MessageBox.Show("串口未连接", "信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //labelConnectionStatus.Text = "未连接";
               // labelConnectionStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// 更新字节计数显示
        /// </summary>
        private void UpdateBytesCount()
        {
           // labelBytesReceived.Text = $"接收字节: {serialPortManager.BytesReceived}";
           // labelBytesSent.Text = $"发送字节: {serialPortManager.BytesSent}";
        }

        /// <summary>
        /// 串口打开时更新UI状态
        /// </summary>
        ///  
        
        private void UpdateUIForPortOpen()
        {
            // 禁用参数修改
            ComboBoxForPort.Enabled = false;
            ComboBoxForPotterValue.Enabled = false;
            ComboBoxForDataSet.Enabled = false;
            ComboBoxForStopBit.Enabled = false;
            ComboBoxForCheck.Enabled = false;
            ComboBoxForControl.Enabled = false;

            // 禁用打开按钮，启用关闭按钮
            ButtonForOpenPort.Enabled = false;
            ButtonForClosePort.Enabled = true;

            // 启用发送功能
            ButtonSend.Enabled = true;
        }

        /// <summary>
        /// 串口关闭时更新UI状态
        /// </summary>
        private void UpdateUIForPortClose()
        {
            // 启用参数修改
            ComboBoxForPort.Enabled = true;
            ComboBoxForPotterValue.Enabled = true;
            ComboBoxForDataSet.Enabled = true;
            ComboBoxForStopBit.Enabled = true;
            ComboBoxForCheck.Enabled = true;
            ComboBoxForControl.Enabled = true;

            // 启用打开按钮，禁用关闭按钮
            ButtonForOpenPort.Enabled = true;
            ButtonForClosePort.Enabled = false;

            // 禁用发送功能
            ButtonSend.Enabled = false;
        }

        /// <summary>
        /// 显示错误消息
        /// </summary>
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
           // labelStatusInfo.Text = $"错误: {message}";
        }

        private void FormTestChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

      

       
    }
}





