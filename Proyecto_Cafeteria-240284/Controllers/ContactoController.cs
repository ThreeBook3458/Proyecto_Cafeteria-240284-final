using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Cafeteria_240284.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            var usuario = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(usuario))
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
