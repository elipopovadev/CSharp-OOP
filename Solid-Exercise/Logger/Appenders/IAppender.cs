using Logger.Enums;
using Logger.Error;
using Logger.Interfaces;

namespace Logger.Appenders
{
    public interface IAppender
    {
        public ILayout Layout {get;}
        void Append(string DateTime, ReportLevel LogLevel, string message);
    }
}
