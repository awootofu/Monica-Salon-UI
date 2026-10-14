using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class StockInPage : ContentPage
{
    private StockInViewModel Vm => (StockInViewModel)BindingContext;
    public StockInPage()
    {
        InitializeComponent();
        BindingContext = new StockInViewModel();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory-details");
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        Vm.Save();
    }

    private async void OnViewInventoryClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory");
    }
}
