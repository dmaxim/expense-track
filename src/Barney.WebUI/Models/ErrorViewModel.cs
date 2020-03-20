
namespace Barney.WebUI.Models
{
    public class ErrorViewModel
    {

        public ErrorViewModel(int statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            Message = errorMessage;
        }

        public int StatusCode { get; }
        public string Message { get; }
    }
}
