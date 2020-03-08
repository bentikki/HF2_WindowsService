using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowsService
{
    public static class Library
    {
        public static string Path { get; } = AppDomain.CurrentDomain.BaseDirectory + @"\Log\";
        public static string FilePath { get; } = Path + "Logfile.txt";

        public static void WriteErrorLog(Exception ex)
        {
            try
            {

                string message = $"{ ex.Source.ToString().Trim() }; { ex.Message.ToString().Trim()}";
                WriteErrorLog(message);
            }
            catch 
            {

                throw;
            }
        }

        public static void WriteErrorLog(string Message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(FilePath, true);
                string text = Cipher.Encrypt($"{DateTime.Now.ToString()}: {Message}");
                sw.WriteLine(text);
                sw.Flush();
                sw.Close();
            }
            catch
            {

                throw;
            }
        }
    }
}
