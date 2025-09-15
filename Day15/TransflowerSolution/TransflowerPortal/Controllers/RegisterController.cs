
namespace TransflowerPortal.Controllers;

using CatalogEntities;
using CatalogServices;
using Microsoft.AspNetCore.Mvc;

//it provides enum, classes, interfaces,
//delegates, events for building ASP.NET Core applications.

public class RegisterController : Controller
{
    private readonly IRegisterService _registerService;

    // Dependency Injection via constructor
    public RegisterController(IRegisterService registerService)
    {
        _registerService = registerService;
    }

    // GET: /Register
    public IActionResult Index()
    {
        var register = _registerService.GetAllUser();
        //return ViewResults as JSON for testing
        return View(register);


    }

    // GET: /Register/Details/5
    public IActionResult Details(string email)
    {
        var register = _registerService.GetUserByEmailId(email);
        if (register == null)
        {
            return NotFound();
        }

        ViewData["theProduct"] = register;

        return View();
    }

    // GET: /Register/Create
    public IActionResult Create()
    {

        TempData["Message"] = "Create New Product";
        
        return View();
    }

    // POST: /Register/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Register register)
    {
        if (ModelState.IsValid)
        {
            _registerService.AddUser(register);
            return RedirectToAction(nameof(Index));
        }
        return View(register);
    }

    // GET: /Register/Edit/5
    public IActionResult Edit(string email)
    {
        var register = _registerService.GetUserByEmailId(email);
        if (register == null)
        {
            return NotFound();
        }
        return View(register);
    }

    // POST: /Register/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(string email, Register register)
    {
        if (email != register.email)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            _registerService.UpdateUser(register);
            return RedirectToAction(nameof(Index));
        }
        return View(register);
    }

    // GET: /Register/Delete/5
    public IActionResult Delete(string email)
    {
        var register = _registerService.GetUserByEmailId(email);
        if (register == null)
        {
            return NotFound();
        }
        return View(register);
    }

    // POST: /Register/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(string email)
    {
        _registerService.DeleteUser(email);
        return RedirectToAction(nameof(Index));
    }
}

