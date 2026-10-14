using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class InventoryHistoryPage : ContentPage
{
    public InventoryHistoryPage()
    {
        InitializeComponent();
        BindingContext = new InventoryHistoryPageViewModel();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory");
    }
}
