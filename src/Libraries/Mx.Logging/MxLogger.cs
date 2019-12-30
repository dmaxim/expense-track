using Microsoft.Extensions.Logging;

namespace Mx.Logging
{
	public class MxLogger
	{
		private readonly ILogger _logger;
		private readonly bool _diagnosticsEnabled;

		public MxLogger(ILogger logger, bool diagnosticsEnabled)
		{
			_logger = logger;
			_diagnosticsEnabled = diagnosticsEnabled;
		}

		public void WritePerformanceEntry(LogDetail logDetail)
		{
			_logger.LogInformation(logDetail.Message, logDetail);
		}

		public void WriteUsage(LogDetail logDetail)
		{
			_logger.LogInformation(logDetail.Message, logDetail);
		}


		public void WriteError(LogDetail logDetail)
		{
			_logger.LogError(logDetail.Message, logDetail);
		}


		public void WriteDiagnostic(LogDetail logDetail)
		{
			if (!_diagnosticsEnabled)
			{
				return;
			}

			_logger.LogInformation(logDetail.Message, logDetail);
		}
	}
}
