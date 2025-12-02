namespace Proyecto_Cafeteria_240284.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public IFormFile ImagenArchivo { get; set; }
        public string ImagenBase64 { get; set; }
        public string? ImagenUrl { get; set; }
    }
}
