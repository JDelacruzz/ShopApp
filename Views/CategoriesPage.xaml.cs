using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class CategoriesPage : ContentPage
{
    public CategoriesPage()
    {
        InitializeComponent();

        var dbContext = new ShopDbContext();

        foreach (var categoria in dbContext.Categories)
        {
            container.Children.Add(new Label { Text = categoria.Nombre });
        }
    }
}
