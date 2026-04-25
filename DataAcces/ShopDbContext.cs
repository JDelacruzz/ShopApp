using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAcces
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Compra> Compras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ShopComputer");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Electronicos"),
                new Category(2, "Computadoras"),
                new Category(3, "Telefonos Moviles"),
                new Category(4, "Dispositivos de Escritorio"),
                new Category(5, "Microfonos y Audio"),
                new Category(6, "Artefactos del Hogar"),
                new Category(7, "Juguetes y Juegos")
            );

            modelBuilder.Entity<Product>().HasData(
    new Product(1, "Radio Digital", "Es una radio de banda ancha", 100, 1,
        "https://pplx-res.cloudinary.com/image/upload/pplx_search_images/619238bc179636256666f8bf424be4a7a1b753af.jpg"),
    new Product(2, "Reloj electrónico", "Reloj digital sumergible", 50, 1,
        "https://m.media-amazon.com/images/I/61wc0aHAizL._AC_UF894,1000_QL80_.jpg"),
    new Product(3, "Laptop HP", "Laptop Escritorio", 900, 2,
        "https://pplx-res.cloudinary.com/image/upload/pplx_search_images/cfb3019d586043e8a9af8f66c0132cb7d41a9661.jpg"),
    new Product(4, "Laptop Acer", "Laptop Gamer", 1200, 2,
        "https://pplx-res.cloudinary.com/image/upload/pplx_search_images/004b49f2dd4a5c9bc59d648365b5ed358d2a3c12.jpg"),
    new Product(5, "Macbook Apple", "Gran Capacidad", 1500, 2,
        "https://pplx-res.cloudinary.com/image/upload/pplx_search_images/48d8d56f5ea7d84beb607cd3fbfa0d96de87a8d2.jpg"),
    new Product(6, "Samsung Galaxy", "Smartphone 5G", 1800, 3,
        "https://pplx-res.cloudinary.com/image/upload/pplx_search_images/0d3e828d163b4240012a7861443d8eaa06821742.jpg"),
    new Product(7, "Iphone 14", "Apple disp", 1500, 3,
        "https://pplx-res.cloudinary.com/image/upload/pplx_search_images/af14f0d499f827590043eb8ae019b57d151e89dd.jpg")
);

            modelBuilder.Entity<Client>().HasData(
                new Client(1, "Jose Martinez", "Carrera 1 54 12"),
                new Client(2, "Ronaldo Nazario", "Calle 44 12 32")
            );
        }
    }

    public record Category(int Id, string Nombre);
    public record Product(int Id, string Nombre, string Descripcion, decimal Precio, int CategoryId, string ImagenUrl = "")
    {
        public Category Category { get; set; }
    }

    public record Client(int Id, string Nombre, string Direccion);

    public record Compra(int ClientId, int ProductId, int Cantidad);
}