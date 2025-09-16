
namespace TransflowerPortal.Controllers;

using CatalogEntities;
using CatalogServices;

using Microsoft.AspNetCore.Mvc;

//it provides enum, classes, interfaces,
//delegates, events for building ASP.NET Core applications.

public class AuthController : Controller
{


    //Dependency Injection for ICustomerService, CustomerService
    
    public AuthController()
    {

    }


    [HttpGet]   //attribute , Decorator, Annotation, Metadata
                //Action Filter
    public IActionResult Login()
    {

        return View();
    }


    [HttpPost]
     public IActionResult Login(string email, string password)
    {

        if (email == "ravi.tambade@transflower.in" && password == "seed")
        {
           // this.Response.Redirect("/home/index");
            this.Response.Redirect("/products/index");
        }
         
        return View();
    }


[HttpGet] 
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
     public IActionResult Register(string firstname, string lastname, string email, string password)
    {
            List<Register> registerList = _registerService.GetAllUser().ToList();
            Register reg = new Register();
            reg.firstname = firstname;
            reg.lastname = lastname;
            reg.email = email;
            reg.password = password;
            registerList.add(reg);
            _registerService.SaveRegistrationData(registerList);
            return Redirect("/home/index");
    }

}