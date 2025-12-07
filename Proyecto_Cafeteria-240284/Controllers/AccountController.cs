using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Cafeteria_240284.Data;
using Proyecto_Cafeteria_240284.Models;

namespace Proyecto_Cafeteria_240284.Controllers
{
    public class AccountController : Controller
    {
        private readonly CafeteriaContext _context;

        public AccountController(CafeteriaContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                // Buscar usuario en la base de datos
                var usuario = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

                if (usuario != null)
                {
                    HttpContext.Session.SetString("User", usuario.Username);
                    return RedirectToAction("Index", "Productos");
                }

                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}