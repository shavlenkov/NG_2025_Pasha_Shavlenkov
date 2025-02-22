using Microsoft.AspNetCore.Mvc;
using Task_1.Models;

namespace Task_1.Controllers;

public class LoginController : Controller
{
    private readonly List<UserModel> _users = new()
    {
        new UserModel { Id = 1, Username = "Pasha", Password = "8Qs25Ymj3NLp", IsAdmin = false },
        new UserModel { Id = 2, Username = "Admin", Password = "L9wq0tC3u8Px", IsAdmin = true }
    };
    
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("isAdmin") != null) 
        {
            return RedirectToAction("Index", "Home");
        }
        
        return View();
    }
    
    [HttpPost]
    public IActionResult Verify(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ViewBag.ErrorMessage = "Username and password are required!";
            
            return View("Index");
        }

        var user = _users.FirstOrDefault(user => user.Username == username && user.Password == password);
        
        if (user == null)
        {
            ViewBag.ErrorMessage = "Invalid username or password!";
            
            return View("Index");
        }
        
        HttpContext.Session.SetInt32("isAdmin", Convert.ToInt32(user.IsAdmin));
        
        return RedirectToAction("Index", "Home");
    }
}