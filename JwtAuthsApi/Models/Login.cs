using System.ComponentModel.DataAnnotations;

namespace JwtAuthsApi.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
