using GYM.Interface;
using System;
using System.IO;
using System.Web;

namespace GYM.Controllers.Service
{
    public class Serv_LogWriter : ILogWriter
    {
        #region Log Writer
        public void WriteErrorLog(string messageType, Exception exception, string function)
        {
            try
            {
                string SubFileName = DateTime.Now.ToString("dd-MM-yyyy");
                string LogPath = HttpRuntime.AppDomainAppPath + "/Error_LOG";
                if (!Directory.Exists(LogPath))
                {
                    Directory.CreateDirectory(LogPath);
                }
                LogPath = LogPath + "/Log_" + SubFileName + ".txt";
                if (!System.IO.File.Exists(LogPath))
                {
                    var myFile = File.Create(LogPath);
                    myFile.Close();
                    using (StreamWriter writer = new StreamWriter(LogPath, append: true))
                    {
                        writer.WriteLine("   Date   |  Time  | Log Type | Function | Message");
                        writer.Close();
                    }
                }
                using (StreamWriter writer = new StreamWriter(LogPath, append: true))
                {
                    string date = DateTime.Now.ToString("dd-MMM-yyyy");
                    string time = DateTime.Now.ToString("hh:mm ss");
                    writer.WriteLine(date + " | " + time + " | " + messageType + " | " + function + " | " + exception.ToString());
                    writer.WriteLine(Environment.NewLine);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void WriteRecordLog(string messageType, string message, string function)
        {
            try
            {
                string SubFileName = DateTime.Now.ToString("dd-MM-yyyy");
                string LogPath = HttpRuntime.AppDomainAppPath + "/Record_LOG";
                if (!Directory.Exists(LogPath))
                {
                    Directory.CreateDirectory(LogPath);
                }
                LogPath = LogPath + "/Log_" + SubFileName + ".txt";
                if (!System.IO.File.Exists(LogPath))
                {
                    var myFile = File.Create(LogPath);
                    myFile.Close();
                    using (StreamWriter writer = new StreamWriter(LogPath, append: true))
                    {
                        writer.WriteLine("   Date   |  Time  | Log Type | Function | Message");
                        writer.Close();
                    }
                }
                using (StreamWriter writer = new StreamWriter(LogPath, append: true))
                {
                    string date = DateTime.Now.ToString("dd-MMM-yyyy");
                    string time = DateTime.Now.ToString("hh:mm ss");
                    writer.WriteLine(date + " | " + time + " | " + messageType + " | " + function + " | " + message);
                    writer.WriteLine(Environment.NewLine);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}