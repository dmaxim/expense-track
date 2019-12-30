using Microsoft.Extensions.Logging;

namespace Mx.Logging
{
	public class DiagnosticLogger : IDiagnosticLogger
	{
		private readonly ILogger<DiagnosticLogger> _logger;
		
		public DiagnosticLogger(ILogger<DiagnosticLogger> logger)
		{
			_logger = logger;
			
		}
		public void Log(LogDetail logDetail)
		{
			_logger.LogWarning(logDetail.Message, new {LogDetail = logDetail});
		}
	}
}
