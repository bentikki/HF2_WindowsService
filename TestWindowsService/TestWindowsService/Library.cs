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
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logfile.txt", true);
                sw.WriteLine($"{DateTime.Now.ToString()}: {Message}");
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
