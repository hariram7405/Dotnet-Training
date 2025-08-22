namespace HostelManagement.Core.DTOs
{
    public class ErrorResponseDTO
    {
        public string CorrelationId { get; set; } = Guid.NewGuid().ToString();
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}