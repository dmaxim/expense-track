using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Microsoft.Extensions.Logging;


namespace Mx.Logging
{
	public class PerformanceTracker
	{
		private readonly Stopwatch _stopWatch;
		private readonly LogDetail _logDetail;
		private readonly ILogger _logger;


		public PerformanceTracker(LogDetail logDetail, ILogger logger)
		{
			_stopWatch = Stopwatch.StartNew();
			_logDetail = logDetail;
			_logger = logger;

			var beginTime = DateTime.Now;
			if (_logDetail.AdditionalInfo == null)
			{
				_logDetail.AdditionalInfo = new Dictionary<string, object>()
				{
					{"Started", beginTime.ToString(CultureInfo.InvariantCulture)}
				};
			}
			else
			{

				_logDetail.AdditionalInfo.Add(
					"Started", beginTime.ToString(CultureInfo.InvariantCulture));
			}

		}

		public PerformanceTracker(ILogger logger, string name, string userId, string location, string application)
		{
			_logger = logger;
			_stopWatch = Stopwatch.StartNew();
			_logDetail = new LogDetail
			{
				Message = name,
				UserId = userId,
				Application =  application,
				Location = location,
				Hostname = Environment.MachineName
			};

			var beginTime = DateTime.Now;
			_logDetail.AdditionalInfo = new Dictionary<string, object>
			{
				{ "Started", beginTime.ToString(CultureInfo.InvariantCulture) }
			};
		}

		public PerformanceTracker(ILogger logger, string name, string userId, string location, string application, Dictionary<string, object> performanceParameters) : this(logger, name, userId, location, application)
		{
			foreach (var performanceParameter in performanceParameters)
			{
				_logDetail.AdditionalInfo.Add($"input-{performanceParameter.Key}", performanceParameter.Value);
			}
		}

		public void Stop()
		{
			_stopWatch.Stop();
			_logDetail.ElapsedMilliseconds =_stopWatch.ElapsedMilliseconds;
			_logger.LogInformation(_logDetail.Message + " with @LogDetail", _logDetail);
		}
	}
}
