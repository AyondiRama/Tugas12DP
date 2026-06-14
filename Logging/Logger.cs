using System;
using System.IO;

namespace Applications_Image_Filter.Logging
{
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private readonly string _logFilePath;

        private Logger()
        {
            _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "activity.log");
            Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath));
        }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        public void Log(string message)
        {
            try
            {
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }
        }
    }
}
