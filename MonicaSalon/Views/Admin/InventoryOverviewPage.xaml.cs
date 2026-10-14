using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class InventoryOverviewPage : ContentPage
{
    public InventoryOverviewPage()
    {
        InitializeComponent();
        BindingContext = new InventoryOverviewPageViewModel();
    }

    private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;
        ((CollectionView)sender).SelectedItem = null;
        await Shell.Current.GoToAsync("admin-inventory-details");
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory-add");
    }

    private async void OnStockInClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-stock-in");
    }

    private async void OnStockOutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-stock-out");
    }

    private async void OnHistoryClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory-history");
    }

    private async void OnNavDashboard(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-dashboard");
    }

    private async void OnNavBookings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-bookings");
    }

    private async void OnNavCashier(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-cashier");
    }

    private async void OnNavInventory(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory");
    }

    private async void OnNavMore(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-more");
    }
}
