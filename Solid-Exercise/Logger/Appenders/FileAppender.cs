using Logger.Enums;
using Logger.Interfaces;
using Logger.Loggers;

namespace Logger.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile LogFile)
        {
            this.Layout = layout;
            this.LogFile = LogFile;
        }
        public ILayout Layout { get; }
        public ILogFile LogFile { get; }

        public void Append(string DateTime, ReportLevel LogLevel, string message)
        {
            string formatedMessage = string.Format(this.Layout.Format, DateTime, LogLevel, message);
            this.LogFile.Write(formatedMessage);           
        }
    }
}
