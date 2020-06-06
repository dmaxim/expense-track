
using System.IO;
using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;

namespace Mx.Logging.Log4Net
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
         
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            writer.WriteLine(JsonConvert.SerializeObject(new SerializableLogEvent(loggingEvent)));
        }
    }
}
