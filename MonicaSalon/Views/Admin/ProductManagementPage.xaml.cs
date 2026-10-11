using MonicaSalon.Services;
namespace MonicaSalon.Views.Admin;
public partial class ProductManagementPage : ContentPage
{
    public class ProductRow
    {
        public string Name { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string ToggleText => IsActive ? "Deactivate" : "Activate";
        public string StatusText => IsActive ? "Active" : "Inactive";
    }
    private List<ProductRow> _all = new();
    public ProductManagementPage()
    {
        InitializeComponent();
        _all = MockDataService.Inventory.Take(5).Select(i => new ProductRow
        {
            Name = i.Name,
            Subtitle = $"{MockDataService.FormatRupiah(79000)} • Stok {i.Quantity} {i.Unit}",
            IsActive = true
        }).ToList();
        ProductsList.ItemsSource = _all;
        CountLabel.Text = $"{_all.Count} products";
    }
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-more");
    private async void OnAddProduct(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-product-form");
    private async void OnEdit(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-product-form");
    private async void OnToggleActive(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        if (btn.BindingContext is ProductRow row)
        {
            row.IsActive = !row.IsActive;
            btn.Text = row.ToggleText;
        }
        await Task.CompletedTask;
    }
    private async void OnSearchChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue?.ToLowerInvariant() ?? string.Empty;
        var filtered = _all.Where(r => r.Name.ToLowerInvariant().Contains(q)).ToList();
        ProductsList.ItemsSource = filtered;
        CountLabel.Text = $"{filtered.Count} products";
        await Task.CompletedTask;
    }
}
