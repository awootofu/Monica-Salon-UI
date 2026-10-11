using MonicaSalon.Services;
namespace MonicaSalon.Views.Admin;
public partial class InventoryOverviewPage : ContentPage
{
    private string _category = "Semua";
    private string _search = string.Empty;
    private bool _lowOnly;

    public InventoryOverviewPage()
    {
        InitializeComponent();
        ApplyFilters();
    }

    private void ApplyFilters()
    {
        var q = MockDataService.Inventory.AsEnumerable();
        if (_category != "Semua")
            q = q.Where(i => i.Category == _category);
        if (!string.IsNullOrWhiteSpace(_search))
            q = q.Where(i => i.Name.Contains(_search, StringComparison.OrdinalIgnoreCase));
        if (_lowOnly)
            q = q.Where(i => i.IsLow);
        InventoryList.ItemsSource = q.ToList();
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        _search = e.NewTextValue ?? string.Empty;
        ApplyFilters();
    }

    private void OnCategoryClicked(object sender, EventArgs e)
    {
        if (sender is Button b)
            _category = b.Text;
        ApplyFilters();
    }

    private void OnLowStockToggled(object sender, ToggledEventArgs e)
    {
        _lowOnly = e.Value;
        ApplyFilters();
    }

    private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;
        ((CollectionView)sender).SelectedItem = null;
        await Shell.Current.GoToAsync("//admin-inventory-details");
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-inventory-add");
    }

    private async void OnStockInClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-stock-in");
    }

    private async void OnStockOutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-stock-out");
    }

    private async void OnHistoryClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-inventory-history");
    }

    private async void OnNavDashboard(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-dashboard");
    }

    private async void OnNavBookings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-bookings");
    }

    private async void OnNavCashier(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-cashier");
    }

    private async void OnNavInventory(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-inventory");
    }

    private async void OnNavMore(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-more");
    }
}
