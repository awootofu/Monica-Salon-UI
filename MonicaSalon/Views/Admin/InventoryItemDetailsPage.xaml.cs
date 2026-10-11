using MonicaSalon.Services;
namespace MonicaSalon.Views.Admin;
public partial class InventoryItemDetailsPage : ContentPage
{
    public InventoryItemDetailsPage()
    {
        InitializeComponent();
        RecentList.ItemsSource = MockDataService.Movements.Take(3).ToList();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory");
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory-edit");
    }

    private async void OnViewAllClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory-history");
    }

    private async void OnStockInClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-stock-in");
    }

    private async void OnStockOutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-stock-out");
    }
}
