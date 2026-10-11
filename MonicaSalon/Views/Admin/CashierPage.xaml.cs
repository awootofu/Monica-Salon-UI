using MonicaSalon.Services;
namespace MonicaSalon.Views.Admin;

public partial class CashierPage : ContentPage
{
    public class CatalogRow
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Meta { get; set; } = string.Empty;
        public string Type { get; set; } = "service";
        public int Price { get; set; }
        public string PriceText { get; set; } = string.Empty;
    }

    public class CartLine
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LineText { get; set; } = string.Empty;
    }

    private readonly Dictionary<string, int> _qty = new();
    private string _tab = "service";
    private string _origin = "booking";
    private string _query = string.Empty;

    public CashierPage()
    {
        InitializeComponent();
        RefreshCatalog();
        RefreshCart();
    }

    private void RefreshCatalog()
    {
        var rows = MockDataService.SaleItems
            .Where(x => x.Type == _tab)
            .Where(x => string.IsNullOrWhiteSpace(_query) || x.Name.Contains(_query, StringComparison.OrdinalIgnoreCase))
            .Select(x => new CatalogRow
            {
                Id = x.Id,
                Name = x.Name,
                Meta = x.Meta,
                Type = x.Type,
                Price = x.Price,
                PriceText = MockDataService.FormatRupiah(x.Price)
            })
            .ToList();
        CatalogList.ItemsSource = rows;
    }

    private void RefreshCart()
    {
        var lines = new List<CartLine>();
        int total = 0;
        foreach (var kv in _qty.Where(kv => kv.Value > 0))
        {
            var item = MockDataService.SaleItems.FirstOrDefault(x => x.Id == kv.Key);
            if (item is null) continue;
            total += item.Price * kv.Value;
            lines.Add(new CartLine
            {
                Id = item.Id,
                Name = item.Name,
                LineText = $"{kv.Value} x {MockDataService.FormatRupiah(item.Price)} = {MockDataService.FormatRupiah(item.Price * kv.Value)}"
            });
        }
        CartList.ItemsSource = lines;
        EmptyCartLabel.IsVisible = lines.Count == 0;
        TotalLabel.Text = $"Total: {MockDataService.FormatRupiah(total)}";
        ProceedBtn.IsEnabled = lines.Count > 0;
    }

    private void PaintToggle(Button active, Button inactive)
    {
        if (Application.Current?.Resources.TryGetValue("PrimaryButton", out var p) == true && p is Style ps)
            active.Style = ps;
        if (Application.Current?.Resources.TryGetValue("SecondaryButton", out var s) == true && s is Style ss)
            inactive.Style = ss;
    }

    private async void OnOriginSelected(object sender, EventArgs e)
    {
        if (sender is not Button b) return;
        _origin = b.Text.Contains("Walk", StringComparison.OrdinalIgnoreCase) ? "walkin" : "booking";
        if (_origin == "booking")
        {
            PaintToggle(OriginBookingBtn, OriginWalkinBtn);
            OriginLabel.Text = "Booking: MON-261014-028 • Bella Anisa";
        }
        else
        {
            PaintToggle(OriginWalkinBtn, OriginBookingBtn);
            OriginLabel.Text = "Walk-in customer";
        }
        await Task.CompletedTask;
    }

    private async void OnTabSelected(object sender, EventArgs e)
    {
        if (sender is not Button b) return;
        _tab = b.Text.Contains("Produk", StringComparison.OrdinalIgnoreCase) ? "product" : "service";
        if (_tab == "service")
            PaintToggle(TabServiceBtn, TabProductBtn);
        else
            PaintToggle(TabProductBtn, TabServiceBtn);
        RefreshCatalog();
        await Task.CompletedTask;
    }

    private async void OnSearchChanged(object sender, TextChangedEventArgs e)
    {
        _query = e.NewTextValue ?? string.Empty;
        RefreshCatalog();
        await Task.CompletedTask;
    }

    private async void OnAddClicked(object? sender, EventArgs e)
    {
        if (sender is not Button b || b.CommandParameter is not string id) return;
        _qty[id] = _qty.TryGetValue(id, out var q) ? q + 1 : 1;
        DraftLabel.IsVisible = false;
        RefreshCart();
        await Task.CompletedTask;
    }

    private async void OnRemoveClicked(object? sender, EventArgs e)
    {
        if (sender is not Button b || b.CommandParameter is not string id) return;
        _qty.Remove(id);
        RefreshCart();
        await Task.CompletedTask;
    }

    private async void OnSaveDraft(object sender, EventArgs e)
    {
        DraftLabel.IsVisible = true;
        await Task.CompletedTask;
    }

    private async void OnProceed(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-transaction-review");
    }

    private async void OnNavDashboard(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-dashboard");
    private async void OnNavBookings(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-bookings");
    private async void OnNavCashier(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-cashier");
    private async void OnNavInventory(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-inventory");
    private async void OnNavMore(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-more");
}
