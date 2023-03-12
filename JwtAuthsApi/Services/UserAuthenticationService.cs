using JwtAuthsApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthsApi.Services;

public class UserAuthenticationService : Exception, IUserAuthentication
{
    private readonly SignInManager<Login> _signInManager;
    private readonly UserManager<UserRegister> _userManager;

    public UserAuthenticationService(SignInManager<Login> signInManager,
        UserManager<UserRegister> userManager, ApplicationDbContext? applicationDbContext)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult Login(Login loginUser)
    {
        var user = new Login
        {
            UserName = loginUser.UserName,
            Password = loginUser.Password
        };
        var userFind = _signInManager.UserManager.FindByNameAsync(user.UserName).Result;
        if (userFind == null)
            return new BadRequestObjectResult(new
                { Status = "Error", Message = "User Not Found Please Register First !" });
        

            var result = _signInManager.PasswordSignInAsync(user, user.Password, false, false).Result;
            if (result.Succeeded)
                return new OkObjectResult(new { Status = "Success", Message = "User Login Successfully", loginUser });
            

        return new BadRequestObjectResult(new { Status = "Error", Message = "User Not Found Please Register First !" });
        

    }

    public IActionResult Register(UserRegister register)
    {
        var user = new UserRegister
        {
            UserName = register.UserName,
            Email = register.Email,
            FirstName = register.FirstName,
            LastName = register.LastName,
            Password = register.Password
        };
        var result = _userManager.CreateAsync(user, register.Password).Result;
        if (result.Succeeded)
            return new OkObjectResult(new { Status = "Success", Message = "User Created Successfully", register });
        return new BadRequestObjectResult(new { Status = "Error", Message = "User Creation Failed", register });
    }
}