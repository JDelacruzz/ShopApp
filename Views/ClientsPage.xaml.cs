using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ClientsPage : ContentPage
{
    public ClientsPage()
    {
        InitializeComponent();

        var dbContext = new ShopDbContext();

        foreach (var cliente in dbContext.Clients)
        {
            container.Children.Add(new Label { Text = cliente.Nombre });
        }
    }
}
