using Microsoft.AspNetCore.Mvc;

namespace Task_1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("isAdmin") == null)
        {
            return RedirectToAction("Index", "Login");
        }
        
        ViewBag.Message = HttpContext.Session.GetInt32("isAdmin") == 1 ?
            "You're an admin" : "You're not an admin";
        
        return View();
    }
}