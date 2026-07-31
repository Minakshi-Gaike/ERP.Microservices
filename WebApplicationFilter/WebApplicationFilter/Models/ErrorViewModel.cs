namespace WebApplicationFilter.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string? ControllerName { get; set; }//2
        public string ActionName { get; set; }
        public string? Message { get; set; }
    }
}
