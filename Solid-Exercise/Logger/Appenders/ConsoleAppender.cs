using Logger.Enums;
using Logger.Interfaces;
using System;

namespace Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }

        public void Append(string DateTime, ReportLevel LogLevel, string message)
        {
            Console.WriteLine(this.Layout.Format, DateTime, LogLevel, message);
        }
    }
}
