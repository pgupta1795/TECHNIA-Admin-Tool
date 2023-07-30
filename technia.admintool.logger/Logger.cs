using System.Diagnostics;

namespace technia.admintool.settings
{
    public static class Logger
    {
        private static readonly string LogPath = "C:\\temp\\log.txt";

        public static void Info(string message)
        {
            using StreamWriter writer = new StreamWriter(LogPath, true);
            writer.WriteLine($"{DateTime.Now} : [INFO] : {message}");
            Trace.WriteLine($"{DateTime.Now} : [INFO] : {message}");
        }

        public static void Error(string message)
        {
            using StreamWriter writer = new StreamWriter(LogPath, true);
            writer.WriteLine($"{DateTime.Now} : [ERROR] : {message}");
            Trace.WriteLine($"{DateTime.Now} : [ERROR] : {message}");
        }
    }
}
