using System.ComponentModel.DataAnnotations;

namespace WebBaseBackend.Models
{
    public class UserDto
    {
        [Required] 
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MinLength(8)] 
        public string PasswordHash { get; set; } = string.Empty;
    }
}
