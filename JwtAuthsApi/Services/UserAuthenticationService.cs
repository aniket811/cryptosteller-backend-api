using System.Web.Http.ModelBinding;
using JwtAuthsApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthsApi.Services;

public class UserAuthenticationService :  IUserAuthentication
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public UserAuthenticationService(SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager )
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
   
    public  IActionResult Login(Login loginUser)
    {
        var logins =  _userManager.FindByNameAsync(loginUser.UserName).Result;
      if (logins == null)
      {
            return new UnauthorizedObjectResult(new { Status = "Error", Message = "User is not registered " });
      } 
      var result =  _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, false).Result;
      if (result.Succeeded)
      {
            return new OkObjectResult(new { Status = "Success", Message = "User Logged In Successfully", loginUser });
      }
      return new BadRequestObjectResult(new { Status = "Error", Message = "User Login Failed", loginUser });
    }

    public IActionResult Register(UserRegister register)
    {
        try
        {
            var user = new UserRegister
            {
                UserName = register.UserName,
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Password = register.Password
            };
            if (user.UserName == null)
            {
                return new BadRequestObjectResult(new { Status = "Error", Message = "User cannot be null here " });
            }

            var checkuserAlreadyRegistered = _signInManager.UserManager.FindByNameAsync(user.UserName).Result;
            if (checkuserAlreadyRegistered != null)
            {
                return new UnauthorizedObjectResult(new
                    { Status = "Error", Message = "User is already registered ", user.UserName });
            }

            var result = _userManager.CreateAsync(user, register.Password).Result;
            if (result.Succeeded)
                return new OkObjectResult(new { Status = "Success", Message = "User Created Successfully", register });
            return new BadRequestObjectResult(new { Status = "Error", Message = "User Creation Failed", register,result });
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}