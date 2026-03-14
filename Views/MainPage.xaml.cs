using Microsoft.EntityFrameworkCore;
using ShopApp.DataAcces;

namespace ShopApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly ShopDbContext _dbContext;

        public MainPage(ShopDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            CargarDatos();
        }

        private void CargarDatos()
        {
            var productosComputadoras = _dbContext.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Nombre == "Computadoras")
                .ToList();

            var productosMayor1000 = _dbContext.Products
                .Where(p => p.Precio > 1000)
                .ToList();

            var categoriaMasCara = _dbContext.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Precio)
                .Select(p => p.Category)
                .FirstOrDefault();

            lblComputadoras.Text = string.Join("\n", productosComputadoras
                .Select(p => $"• {p.Nombre} - ${p.Precio}"));

            lblMayor1000.Text = string.Join("\n", productosMayor1000
                .Select(p => $"• {p.Nombre} - ${p.Precio}"));

            lblCategoriaCara.Text = categoriaMasCara?.Nombre ?? "No encontrada";

        }
    }
}
