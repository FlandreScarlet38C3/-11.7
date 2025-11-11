using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 测试系统_10._31
{
    /// <summary>
    /// 串口信息类，存储串口的详细信息
    /// </summary>
    public class SerialPortInfo
    {
        public string PortName { get; set; } = string.Empty;
        public string DeviceName { get; set; } = string.Empty;
        public string Vid { get; set; } = string.Empty;
        public string Pid { get; set; } = string.Empty;
        public string Channel { get; set; } = string.Empty;
        public string DeviceId { get; set; } = string.Empty;
        public string[] HardwareIds { get; set; } = Array.Empty<string>();

        public override string ToString()
        {
            return $"{PortName} ({DeviceName})";
        }
    }

    /// <summary>
    /// 串口管理器类，封装所有串口操作，使用单例模式
    /// </summary>
    public class SerialPortManager : IDisposable
    {
        // 单例实例
        private static readonly SerialPortManager _instance = new SerialPortManager();

        // 当前的串口对象
        private SerialPort _serialPort;

        // 串口状态变量
        private bool _isPortOpen;

        // 接收和发送的字节计数
        private int _bytesReceived;
        private int _bytesSent;

        // 缓存相关变量
        private List<SerialPortInfo> _cachedPorts = new List<SerialPortInfo>();
        private DateTime _lastCacheTime = DateTime.MinValue;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromSeconds(2);
        private readonly object _cacheLock = new object();

        // 事件定义
        public event EventHandler<byte[]> DataReceived;
        public event EventHandler<string> StatusChanged;
        public event EventHandler<Exception> ErrorOccurred;

        // 私有构造函数，防止外部实例化
        private SerialPortManager()
        {
            InitializeSerialPort();
        }

        // 单例访问器
        public static SerialPortManager Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// 初始化串口对象
        /// </summary>
        private void InitializeSerialPort()
        {
            _serialPort = new SerialPort
            {
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
                Handshake = Handshake.None,
                Encoding = Encoding.UTF8,
                ReadTimeout = 500,
                WriteTimeout = 500
            };

            _serialPort.DataReceived += OnDataReceived;
            _serialPort.ErrorReceived += OnErrorReceived;
        }

        /// <summary>
        /// 获取所有可用的串口列表
        /// </summary>
        public List<SerialPortInfo> GetAvailablePorts()
        {
            lock (_cacheLock)
            {
                // 检查缓存是否有效
                if (DateTime.Now - _lastCacheTime < _cacheExpiration && _cachedPorts.Count > 0)
                {
                    return new List<SerialPortInfo>(_cachedPorts);
                }

                // 缓存过期或无缓存，重新查询
                var result = GetSerialPortsWithDetails();
                _cachedPorts = result;
                _lastCacheTime = DateTime.Now;
                return new List<SerialPortInfo>(result);
            }
        }

        /// <summary>
        /// 获取包含详细信息的串口列表
        /// </summary>
        private List<SerialPortInfo> GetSerialPortsWithDetails()
        {
            var serialPorts = new List<SerialPortInfo>();

            try
            {
                // 使用WMI查询获取串口信息
                var searcher = new ManagementObjectSearcher(
                    "SELECT DeviceID, Name, Caption, HardwareID FROM Win32_PnPEntity " +
                    "WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\" OR ClassGuid=\"{86e0d1e0-8089-11d0-9ce4-08003e301f73}\""
                );

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string deviceId = queryObj["DeviceID"]?.ToString() ?? "";
                    string name = queryObj["Name"]?.ToString() ?? "";
                    string[] hardwareIds = queryObj["HardwareID"] as string[] ?? new string[0];

                    // 提取COM端口号
                    var comMatch = Regex.Match(name, @"\(COM(\d+)\)", RegexOptions.IgnoreCase);
                    if (comMatch.Success)
                    {
                        string comPort = "COM" + comMatch.Groups[1].Value;

                        // 提取PID和VID
                        var (vid, pid) = ExtractPidVid(deviceId, hardwareIds);

                        serialPorts.Add(new SerialPortInfo
                        {
                            PortName = comPort,
                            DeviceName = name,
                            Vid = vid,
                            Pid = pid,
                            DeviceId = deviceId,
                            HardwareIds = hardwareIds
                        });
                    }
                }

                // 如果WMI查询失败或无结果，使用基础方法获取串口
                if (serialPorts.Count == 0)
                {
                    foreach (string portName in SerialPort.GetPortNames())
                    {
                        serialPorts.Add(new SerialPortInfo
                        {
                            PortName = portName,
                            DeviceName = portName,
                            Vid = "0000",
                            Pid = "0000"
                        });
                    }
                }

                return serialPorts;
            }
            catch (Exception ex)
            {
                // 如果WMI查询失败，使用基础方法
                OnErrorOccurred(new Exception("获取串口信息失败，使用基础方法", ex));
                
                foreach (string portName in SerialPort.GetPortNames())
                {
                    serialPorts.Add(new SerialPortInfo
                    {
                        PortName = portName,
                        DeviceName = portName,
                        Vid = "0000",
                        Pid = "0000"
                    });
                }
                
                return serialPorts;
            }
        }

        /// <summary>
        /// 从设备信息中提取PID和VID
        /// </summary>
        private (string Vid, string Pid) ExtractPidVid(string deviceId, string[] hardwareIds)
        {            // 从DeviceID中提取
            var (vid1, pid1) = ExtractFromDeviceId(deviceId);
            if (!string.IsNullOrEmpty(vid1) && !string.IsNullOrEmpty(pid1))
                return (vid1, pid1);

            // 从HardwareID中提取
            foreach (var hardwareId in hardwareIds)
            {
                var (vid2, pid2) = ExtractFromDeviceId(hardwareId);
                if (!string.IsNullOrEmpty(vid2) && !string.IsNullOrEmpty(pid2))
                    return (vid2, pid2);
            }

            return ("0000", "0000");
        }

        /// <summary>
        /// 从字符串中提取VID和PID
        /// </summary>
        private (string Vid, string Pid) ExtractFromDeviceId(string id)
        {            var vidMatch = Regex.Match(id, @"VID_([0-9A-Fa-f]{4})", RegexOptions.IgnoreCase);
            var pidMatch = Regex.Match(id, @"PID_([0-9A-Fa-f]{4})", RegexOptions.IgnoreCase);

            string vid = vidMatch.Success ? vidMatch.Groups[1].Value.ToUpper() : string.Empty;
            string pid = pidMatch.Success ? pidMatch.Groups[1].Value.ToUpper() : string.Empty;

            return (vid, pid);
        }

        /// <summary>
        /// 更新串口配置
        /// </summary>
        public void UpdatePortSettings(string portName, int baudRate, int dataBits, StopBits stopBits, Parity parity, Handshake handshake)
        {
            try
            {
                bool wasOpen = _isPortOpen;

                // 如果串口已打开，先关闭
                if (wasOpen)
                {
                    ClosePort();
                }

                // 更新串口配置
                _serialPort.PortName = portName;
                _serialPort.BaudRate = baudRate;
                _serialPort.DataBits = dataBits;
                _serialPort.StopBits = stopBits;
                _serialPort.Parity = parity;
                _serialPort.Handshake = handshake;

                // 如果之前是打开的，重新打开
                if (wasOpen)
                {
                    OpenPort();
                }

                OnStatusChanged("串口配置已更新");
            }
            catch (Exception ex)
            {
                OnErrorOccurred(new Exception("更新串口配置失败", ex));
            }
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        public bool OpenPort()
        {
            try
            {
                if (!_isPortOpen && !string.IsNullOrEmpty(_serialPort.PortName))
                {
                    _serialPort.Open();
                    _isPortOpen = true;
                    _bytesReceived = 0;
                    _bytesSent = 0;
                    OnStatusChanged($"串口 {_serialPort.PortName} 已打开");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                OnErrorOccurred(new Exception($"打开串口 {_serialPort.PortName} 失败", ex));
                return false;
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void ClosePort()
        {
            try
            {
                if (_isPortOpen && _serialPort != null)
                {
                    _serialPort.Close();
                    _isPortOpen = false;
                    OnStatusChanged($"串口 {_serialPort.PortName} 已关闭");
                }
            }
            catch (Exception ex)
            {
                OnErrorOccurred(new Exception("关闭串口失败", ex));
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        public bool SendData(string data, bool isHex = false)
        {
            try
            {
                if (!_isPortOpen || _serialPort == null)
                {
                    OnErrorOccurred(new Exception("串口未打开，无法发送数据"));
                    return false;
                }

                byte[] bytesToSend;
                
                if (isHex)
                {
                    // 清理十六进制字符串
                    data = Regex.Replace(data, @"[^0-9A-Fa-f]", "");
                    
                    if (data.Length % 2 != 0)
                    {
                        OnErrorOccurred(new Exception("十六进制数据长度必须为偶数"));
                        return false;
                    }

                    // 转换为字节数组
                    bytesToSend = new byte[data.Length / 2];
                    for (int i = 0; i < data.Length; i += 2)
                    {
                        bytesToSend[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
                    }
                }
                else
                {
                    // 直接发送字符串
                    bytesToSend = _serialPort.Encoding.GetBytes(data);
                }

                // 发送数据
                _serialPort.Write(bytesToSend, 0, bytesToSend.Length);
                _bytesSent += bytesToSend.Length;
                
                OnStatusChanged($"已发送 {bytesToSend.Length} 字节");
                return true;
            }
            catch (Exception ex)
            {
                OnErrorOccurred(new Exception("发送数据失败", ex));
                return false;
            }
        }

        /// <summary>
        /// 数据接收事件处理
        /// </summary>
        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!_isPortOpen || _serialPort == null)
                    return;

                int bytesToRead = _serialPort.BytesToRead;
                if (bytesToRead > 0)
                {
                    byte[] buffer = new byte[bytesToRead];
                    int bytesRead = _serialPort.Read(buffer, 0, bytesToRead);
                    
                    if (bytesRead > 0)
                    {
                        _bytesReceived += bytesRead;
                        DataReceived?.Invoke(this, buffer);
                    }
                }
            }
            catch (Exception ex)
            {
                OnErrorOccurred(new Exception("接收数据错误", ex));
            }
        }

        /// <summary>
        /// 错误接收事件处理
        /// </summary>
        private void OnErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            OnErrorOccurred(new Exception($"串口错误: {e.EventType}"));
        }

        /// <summary>
        /// 触发状态改变事件
        /// </summary>
        private void OnStatusChanged(string message)
        {
            StatusChanged?.Invoke(this, message);
        }

        /// <summary>
        /// 触发错误事件
        /// </summary>
        private void OnErrorOccurred(Exception ex)
        {
            ErrorOccurred?.Invoke(this, ex);
        }

        /// <summary>
        /// 获取当前串口状态
        /// </summary>
        public bool IsPortOpen
        {
            get { return _isPortOpen; }
        }

        /// <summary>
        /// 获取接收的字节数
        /// </summary>
        public int BytesReceived
        {
            get { return _bytesReceived; }
        }

        /// <summary>
        /// 获取发送的字节数
        /// </summary>
        public int BytesSent
        {
            get { return _bytesSent; }
        }

        /// <summary>
        /// 获取当前使用的串口名称
        /// </summary>
        public string CurrentPortName
        {
            get { return _serialPort?.PortName ?? string.Empty; }
        }

        /// <summary>
        /// 重置计数
        /// </summary>
        public void ResetCounters()
        {
            _bytesReceived = 0;
            _bytesSent = 0;
            OnStatusChanged("计数器已重置");
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            ClosePort();
            if (_serialPort != null)
            {
                _serialPort.Dispose();
                _serialPort = null;
            }
        }
    }
}