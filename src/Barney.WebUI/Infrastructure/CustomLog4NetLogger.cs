using System;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Repository.Hierarchy;

namespace Barney.WebUI.Infrastructure
{
    public static class CustomLog4NetLogger
    {
        private const string LogConfigFile = @"log4net.config";

        private static readonly log4net.ILog _log = GetLogger(typeof(Logger));


        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }


        public static void Debug(object message)
        {
            SetLog4NetConfiguration();
            _log.Debug(message);
            _log.Error(message);
        }


        public static void SetLog4NetConfiguration()
        {
            var log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(LogConfigFile));

            var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

        }
    }
}
