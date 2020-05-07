
using System;
using log4net.Core;

namespace Mx.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {

        private readonly LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public string Level => _loggingEvent.Level.DisplayName;

        public DateTime TimeStamp => _loggingEvent.TimeStamp;

        public string LoggerName => _loggingEvent.LoggerName;

        public LocationInfo LocationInformation => _loggingEvent.LocationInformation;

        public object Message => _loggingEvent.MessageObject;

        public string Exception
        {
            get
            {
                if (null == _loggingEvent.ExceptionObject)
                {
                    return string.Empty;
                }
                else
                {
                    return _loggingEvent.ExceptionObject.ToString();
                }
            }
        }

        public string RenderedMessage => _loggingEvent.RenderedMessage;
    }
}
