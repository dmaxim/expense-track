
using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;

namespace Mx.Logging.Log4Net
{
    public static class LoggingConfiguration
    {

        public static ConsoleAppender ConfigureConsoleAppender()
        {
            var layout = new SimpleLayout();
            layout.ActivateOptions();

            var appender = new ConsoleAppender {Layout = layout};
            appender.ActivateOptions();
            return appender;
        }

        public static void ConfigureRootLogger(ILoggerRepository loggerRepository)
        {
            
            var logger =((Hierarchy)loggerRepository).Root;

            logger.Level = log4net.Core.Level.All;

        }
    }
}
