using System.ComponentModel;

namespace ShopApp.Views;

public partial class HelpSupportPage : ContentPage
{
    public HelpSupportPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var dataObject = Resources["data"] as HelpSupportData;
        dataObject.VisitasPendientes = 30;
    }
}

public class HelpSupportData : INotifyPropertyChanged
{
    private int _visitasPendientes;

    public int VisitasPendientes
    {
        get => _visitasPendientes;
        set
        {
            _visitasPendientes = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VisitasPendientes)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
