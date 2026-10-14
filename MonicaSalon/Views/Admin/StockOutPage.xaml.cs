using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class StockOutPage : ContentPage
{
    private StockOutViewModel Vm => (StockOutViewModel)BindingContext;
    public StockOutPage()
    {
        InitializeComponent();
        BindingContext = new StockOutViewModel();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory-details");
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        Vm.TrySave();
    }

    private async void OnViewInventoryClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory");
    }
}
