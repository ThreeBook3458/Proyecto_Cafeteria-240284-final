using Microsoft.EntityFrameworkCore;
using Proyecto_Cafeteria_240284.Models;

namespace Proyecto_Cafeteria_240284.Data
{
    public class CafeteriaContext : DbContext
    {
        public CafeteriaContext(DbContextOptions<CafeteriaContext> options)
            : base(options)
        {
        }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Productos
            modelBuilder.Entity<Productos>(entity =>
            {
                entity.Property(p => p.Precio)
                    .HasColumnType("decimal(18,2)");
            });

            // Datos iniciales - Usuario administrador
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Username = "Aaronh",
                    Password = "huerta12.Ar" // CAMBIA ESTO por una contraseña segura
                }
            );

            // Datos iniciales - Productos
            modelBuilder.Entity<Productos>().HasData(
                new Productos
                {
                    Id = 1,
                    Nombre = "Café Americano",
                    Descripcion = "Café espresso diluido con agua caliente",
                    Precio = 35.00M,
                    Stock = 100,
                    ImagenUrl = "/images/CafeAmericano.jpg"
                },
                new Productos
                {
                    Id = 2,
                    Nombre = "Cappuccino",
                    Descripcion = "Espresso con leche vaporizada y espuma",
                    Precio = 45.00M,
                    Stock = 80,
                    ImagenUrl = "/images/cappuccinoAmericano.jpg"
                },
                new Productos
                {
                    Id = 3,
                    Nombre = "Latte",
                    Descripcion = "Café espresso con abundante leche",
                    Precio = 48.00M,
                    Stock = 75,
                    ImagenUrl = "/images/Latte.jpg"
                },
                new Productos
                {
                    Id = 4,
                    Nombre = "Moka",
                    Descripcion = "Mezcla de café, chocolate y leche",
                    Precio = 52.00M,
                    Stock = 60,
                    ImagenUrl = "/images/Moka.jpg"
                },
                new Productos
                {
                    Id = 5,
                    Nombre = "Matcha",
                    Descripcion = "Té de hierbas verdes con hielos",
                    Precio = 120M,
                    Stock = 25,
                    ImagenUrl = "/images/Matcha.jpg"
                }
            );
        }
    }
}