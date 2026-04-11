using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ProductDetailPage : ContentPage, IQueryAttributable
{
    public ProductDetailPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var dbContext = new ShopDbContext();
        var id = int.Parse(query["id"].ToString());
        var producto = dbContext.Products.First(x => x.Id == id);

        BindingContext = producto;
    }
}
