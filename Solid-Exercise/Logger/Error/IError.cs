using Logger.Enums;
using System;

namespace Logger.Error
{
   public interface IError
    {
        ReportLevel ReportLevel { get; }
        DateTime DateTime { get; }
        String Message { get; }
    }
}
