using Microsoft.Maui.Controls;
using ShopApp.DataAcces;
using ShopApp.Views;
using System.Linq;

namespace ShopApp.Handlers
{
    public class ProductoBusquedaHandler : SearchHandler
    {
        ShopDbContext dbContext;

        public ProductoBusquedaHandler()
        {
            this.dbContext = new ShopDbContext();
        }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
                return;
            }

            var resultados = dbContext.Products
                .Where(p => p.Nombre.ToLowerInvariant()
                .Contains(newValue.ToLowerInvariant()));

            ItemsSource = resultados;
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            if (item == null) return;

            var producto = (Product)item;
            await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?id={producto.Id}");
        }
    }
}
