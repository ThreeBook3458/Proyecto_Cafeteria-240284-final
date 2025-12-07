using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Cafeteria_240284.Data;
using Proyecto_Cafeteria_240284.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// Proyecto Cafetería - Aaron Huerta Rodriguez - Matrícula: 240284
namespace Proyecto_Cafeteria_240284.Controllers
{
    public class ProductosController : Controller
    {
        private readonly CafeteriaContext _context;

        public ProductosController(CafeteriaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var usuario = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(usuario))
            {
                return RedirectToAction("Login", "Account");
            }

            var productos = await _context.Productos.ToListAsync();
            return View(productos);
        }

        // Método para generar imágenes SVG por defecto
        private static string GenerarImagenSVG(string emoji, string colorFondo)
        {
            string svg = $@"
                <svg xmlns='http://www.w3.org/2000/svg' width='400' height='400'>
                    <rect width='400' height='400' fill='{colorFondo}'/>
                    <text x='50%' y='50%' font-size='120' text-anchor='middle' dy='.3em'>{emoji}</text>
                </svg>";

            byte[] svgBytes = System.Text.Encoding.UTF8.GetBytes(svg);
            string base64 = Convert.ToBase64String(svgBytes);
            return $"data:image/svg+xml;base64,{base64}";
        }

        // Método para guardar o actualizar
        [HttpPost]
        public async Task<JsonResult> Guardar(Productos producto)
        {
            try
            {
                // Procesar imagen si se subió
                if (producto.ImagenArchivo != null && producto.ImagenArchivo.Length > 0)
                {
                    producto.ImagenBase64 = await ConvertirImagenABase64(producto.ImagenArchivo);
                }

                if (producto.Id == 0)
                {
                    // Crear nuevo producto
                    // Si no tiene imagen, asignar una por defecto
                    if (string.IsNullOrEmpty(producto.ImagenBase64))
                    {
                        producto.ImagenBase64 = GenerarImagenSVG("📦", "#808080");
                    }

                    _context.Productos.Add(producto);
                }
                else
                {
                    // Editar producto existente
                    var existente = await _context.Productos.FindAsync(producto.Id);
                    if (existente != null)
                    {
                        existente.Nombre = producto.Nombre;
                        existente.Descripcion = producto.Descripcion;
                        existente.Precio = producto.Precio;
                        existente.Stock = producto.Stock;

                        // Solo actualizar imagen si se subió una nueva
                        if (!string.IsNullOrEmpty(producto.ImagenBase64))
                        {
                            existente.ImagenBase64 = producto.ImagenBase64;
                        }
                    }
                }

                await _context.SaveChangesAsync();
                var lista = await _context.Productos.ToListAsync();

                return Json(new { success = true, lista = lista });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Eliminar(int Id)
        {
            var producto = await _context.Productos.FindAsync(Id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
                return Json(new { success = true, mensaje = $"Se eliminó correctamente el producto '{producto.Nombre}'." });
            }
            return Json(new { success = false, mensaje = "No se encontró el producto a eliminar." });
        }

        // Método auxiliar para convertir imagen a Base64
        private async Task<string> ConvertirImagenABase64(IFormFile archivo)
        {
            // Validar que sea una imagen
            if (!archivo.ContentType.StartsWith("image/"))
            {
                throw new Exception("El archivo debe ser una imagen");
            }

            // Validar tamaño (máximo 5MB)
            if (archivo.Length > 5 * 1024 * 1024)
            {
                throw new Exception("La imagen es muy grande. Máximo 5MB");
            }

            using (var memoryStream = new MemoryStream())
            {
                await archivo.CopyToAsync(memoryStream);
                byte[] bytes = memoryStream.ToArray();
                string base64 = Convert.ToBase64String(bytes);

                return $"data:{archivo.ContentType};base64,{base64}";
            }
        }

        // Método para obtener un producto por ID (para editar)
        [HttpGet]
        public async Task<JsonResult> ObtenerProducto(int Id)
        {
            var producto = await _context.Productos.FindAsync(Id);
            if (producto != null)
            {
                return Json(new { success = true, producto = producto });
            }
            return Json(new { success = false, mensaje = "Producto no encontrado" });
        }

        // Método para reiniciar datos a valores por defecto
        public async Task<JsonResult> ReiniciarDatos()
        {
            // Eliminar todos los productos existentes
            _context.Productos.RemoveRange(_context.Productos);

            // Agregar productos por defecto
            var productosDefault = new List<Productos>
            {
                new Productos { Nombre = "Café Americano", Descripcion = "Café espresso diluido con agua caliente", Precio = 35.00M, Stock = 100, ImagenUrl ="/images/CafeAmericano.jpg" },
                new Productos { Nombre = "Cappuccino", Descripcion = "Espresso con leche vaporizada y espuma", Precio = 45.00M, Stock = 80, ImagenUrl ="/images/cappuccinoAmericano.jpg" },
                new Productos { Nombre = "Latte", Descripcion = "Café espresso con abundante leche", Precio = 48.00M, Stock = 75, ImagenUrl ="/images/Latte.jpg" },
                new Productos { Nombre = "Moka", Descripcion = "Mezcla de café, chocolate y leche", Precio = 52.00M, Stock = 60, ImagenUrl ="/images/Moka.jpg" },
                new Productos { Nombre = "Matcha", Descripcion = "Té de hierbas verdes con hielos", Precio = 120, Stock = 25, ImagenUrl = "/images/Matcha.jpg"}
            };

            _context.Productos.AddRange(productosDefault);
            await _context.SaveChangesAsync();

            var lista = await _context.Productos.ToListAsync();
            return Json(new { success = true, mensaje = "Datos reiniciados correctamente", lista = lista });
        }
    }
}