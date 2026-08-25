using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes_API.Database;
using Notes_API.Entities;
using Notes_API.Services;
using Notes_API.Interfaces;
using Notes_API.Models;
using Notes_API.Models.Login;
using Notes_API.Models.Register;

namespace Notes_API.Controllers;

public class AuthController : Controller
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: Auth/Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _userService.CreateUser(model.Email, model.Password);

        return RedirectToAction("Login");
    }

    // GET: Auth/Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userService.GetUserByCredentialsAsync(model.Email, model.Password);

        if (user == null)
        {
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        return RedirectToAction("List", "Note");
    }
}