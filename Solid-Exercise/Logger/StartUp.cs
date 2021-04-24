using Logger.Appenders;
using Logger.Interfaces;
using Logger.Layouts;
using Logger.Loggers;
using Logger.Models;
using System;

namespace Logger
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            ILayout jsonLayout = new JsonLayout();
            ILogFile logFile = new LogFile();
            IAppender fileAppender = new FileAppender(jsonLayout, logFile);
            var logger = new Loggers.Logger(fileAppender);

            logger.Info("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");
        }
    }
}
