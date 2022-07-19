using System;
namespace GYM.Interface
{
    internal interface ILogWriter
    {
        void WriteErrorLog(string messageType, Exception exception, string function);
        void WriteRecordLog(string messageType, string message, string function);
    }
}
