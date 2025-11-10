namespace WebBaseBackend.Models
{
    public class RefershTokenRequestDto
    {
        public Guid UserId { get; set; }
        public required string  RefreshToken { get; set; }
    }
}
