using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace JwtAuthsApi.Models
{
    public class UserRegister:IdentityUser
    {
        [Required(ErrorMessage = "First Name is required"), StringLength(20,ErrorMessage = "First name should not greater than 20",MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required,StringLength(20,ErrorMessage = "Last name should not greater than 20",MinimumLength = 5)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email{ get; set; }
        [Required(ErrorMessage = "Password is required"),DataType(DataType.Password)]
        public string Password{ get; set; }
        [Required(ErrorMessage = "Confirm Password is required"), DataType(DataType.Password),Compare("Password",ErrorMessage = "Password and Confirm Password did not matched ")]
        public string ConfirmPassword{ get; set; }
    }
}
