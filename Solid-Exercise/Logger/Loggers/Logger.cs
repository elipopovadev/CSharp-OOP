using Logger.Appenders;
using System;
using Logger.Enums;

namespace Logger.Loggers
{
    public class Logger : ILogger
    {
        IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IAppender[] Appenders
        {
            get => appenders;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(appenders), "Value can not be null");
                }

                appenders = value;
            }
        }

        public void Fatal(string dateTime,string message)
        {
            Append(dateTime, message, ReportLevel.Fatal);
        }

        public void Critical(string dateTime, string message)
        {
            Append(dateTime, message, ReportLevel.Critical);
        }

        public void Error(string dateTime, string message)
        {
            Append(dateTime, message, ReportLevel.Error);
        }

        public void Warning(string dateTime, string message)
        {
            Append(dateTime, message, ReportLevel.Warning);
        }

        public void Info(string dateTime, string message)
        {
            Append(dateTime, message, ReportLevel.Info);
        }

        private void Append(string dateTime, string message, ReportLevel reportLevel)
        {
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }
    }
}
