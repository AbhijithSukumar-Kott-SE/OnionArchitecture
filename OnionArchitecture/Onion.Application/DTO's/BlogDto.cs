namespace OnionArchitecture.Application.DTOs
{
    public class BlogDto
    {
        public string? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
    }
}
