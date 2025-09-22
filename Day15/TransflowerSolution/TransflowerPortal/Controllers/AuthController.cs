
namespace TransflowerPortal.Controllers;
using System.Collections.Generic;
using CatalogEntities;
using CatalogServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using TransflowerPortal.Services;
using System.Security.Claims;

//it provides enum, classes, interfaces,
//delegates, events for building ASP.NET Core applications.

public class AuthController : Controller
{

    private readonly IRegisterService _registerService;
    private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }
    //Dependency Injection for ICustomerService, CustomerServiceate
    
    // public AuthController(IRegisterService registerService)
    // {
    //     _registerService = registerService;
    // }


    [HttpGet]   //attribute , Decorator, Annotation, Metadata
                //Action Filter
    public IActionResult Login()
    {

        return View();
    }


    [HttpPost]
     public async Task<IActionResult> Login(string email, string password)
    {

        var user = _userService.Validate(email,password);

        // if (email == "ravi.tambade@transflower.in" && password == "seed")
        // {
        //    // this.Response.Redirect("/home/index");
        //     this.Response.Redirect("/products/index");
        // }
        if (user != null)
            {
                // Create a claims identity
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, email)
                    };


                var claimsIdentity = new ClaimsIdentity(claims, 
                                                        CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Sign in the user
               await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                             claimsPrincipal);

                return RedirectToAction("Welcome", "Home");
            } 
        return View();
    }

public async Task<IActionResult> Logout()
        {   
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

[HttpGet] 
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
     public IActionResult Register(string firstname, string lastname, string email, string password)
    {
            //List<Register> regList = _registerService.GetAllUser().ToList();
            Register reg = new Register();
            reg.firstname = firstname;
            reg.lastname = lastname;
            reg.email = email;
            reg.password = password;
            //regList.add(reg);
            Console.WriteLine("auth controller:::"+reg.firstname);
            _registerService.UpdateUser(reg);
            return View();
    }

}