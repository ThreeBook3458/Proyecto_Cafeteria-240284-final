using Microsoft.AspNetCore.Mvc;
using Proyecto_Cafeteria_240284.Models;

namespace Proyecto_Cafeteria_240284.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == "admin" && model.Password == "1234")
                {
                    HttpContext.Session.SetString("User", model.Username);
                    return RedirectToAction("Index", "Productos");
                }

                ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
