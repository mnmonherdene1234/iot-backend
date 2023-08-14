using System.ComponentModel.DataAnnotations;

namespace IOTBackend.Dto
{
    public class SignUpDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
