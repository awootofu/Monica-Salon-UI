using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class ProductManagementViewModel : BaseViewModel
{
    public class ProductRow : BaseViewModel
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value ?? string.Empty);
        }

        private string _subtitle = string.Empty;
        public string Subtitle
        {
            get => _subtitle;
            set => SetProperty(ref _subtitle, value ?? string.Empty);
        }

        private bool _isActive = true;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (SetProperty(ref _isActive, value))
                {
                    OnPropertyChanged(nameof(ToggleText));
                    OnPropertyChanged(nameof(StatusText));
                }
            }
        }

        public string ToggleText => IsActive ? "Deactivate" : "Activate";
        public string StatusText => IsActive ? "Active" : "Inactive";
    }

    private readonly List<ProductRow> _all = new();

    private string _query = string.Empty;
    public string Query
    {
        get => _query;
        set
        {
            if (SetProperty(ref _query, value ?? string.Empty))
                ApplyFilter();
        }
    }

    private List<ProductRow> _filteredProducts = new();
    public List<ProductRow> FilteredProducts
    {
        get => _filteredProducts;
        private set => SetProperty(ref _filteredProducts, value);
    }

    private string _countText = string.Empty;
    public string CountText
    {
        get => _countText;
        private set => SetProperty(ref _countText, value ?? string.Empty);
    }

    public ProductManagementViewModel()
    {
        _all.AddRange(MockDataService.Inventory.Take(5).Select(i => new ProductRow
        {
            Name = i.Name,
            Subtitle = $"{MockDataService.FormatRupiah(79000)} • Stok {i.Quantity} {i.Unit}",
            IsActive = true
        }));
        ApplyFilter();
    }

    public void ToggleActive(ProductRow? row)
    {
        if (row is null) return;
        row.IsActive = !row.IsActive;
    }

    private void ApplyFilter()
    {
        string q = (_query ?? string.Empty).ToLowerInvariant();
        var filtered = _all.Where(r => (r.Name ?? string.Empty).ToLowerInvariant().Contains(q)).ToList();
        FilteredProducts = filtered;
        CountText = $"{filtered.Count} products";
    }
}
