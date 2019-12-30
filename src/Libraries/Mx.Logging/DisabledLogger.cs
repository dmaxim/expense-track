
namespace Mx.Logging
{
	public class DisabledLogger : IDiagnosticLogger
	{
		public DisabledLogger()
		{

		}
		
		public void Log(LogDetail logDetail)
		{
			return;
		}
	}
}
