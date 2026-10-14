using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class CashierViewModel : BaseViewModel
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

    private string _selectedTab = "service";
    public string SelectedTab
    {
        get => _selectedTab;
        private set
        {
            if (SetProperty(ref _selectedTab, value ?? "service"))
            {
                OnPropertyChanged(nameof(IsServiceTab));
                Refresh();
            }
        }
    }
    public bool IsServiceTab => _selectedTab == "service";

    private string _selectedOrigin = "booking";
    public string SelectedOrigin
    {
        get => _selectedOrigin;
        private set
        {
            if (SetProperty(ref _selectedOrigin, value ?? "booking"))
            {
                OnPropertyChanged(nameof(IsBookingOrigin));
                Refresh();
            }
        }
    }
    public bool IsBookingOrigin => _selectedOrigin == "booking";

    private string _query = string.Empty;
    public string Query
    {
        get => _query;
        set
        {
            if (SetProperty(ref _query, value ?? string.Empty))
                Refresh();
        }
    }

    private List<CatalogRow> _catalogRows = new();
    public List<CatalogRow> CatalogRows
    {
        get => _catalogRows;
        private set => SetProperty(ref _catalogRows, value);
    }

    private List<CartLine> _cartLines = new();
    public List<CartLine> CartLines
    {
        get => _cartLines;
        private set => SetProperty(ref _cartLines, value);
    }

    private string _originText = "Booking: MON-261014-028 • Bella Anisa";
    public string OriginText
    {
        get => _originText;
        private set => SetProperty(ref _originText, value);
    }

    private string _totalText = "Total: Rp 0";
    public string TotalText
    {
        get => _totalText;
        private set => SetProperty(ref _totalText, value);
    }

    private bool _isCartEmpty = true;
    public bool IsCartEmpty
    {
        get => _isCartEmpty;
        private set => SetProperty(ref _isCartEmpty, value);
    }

    private bool _canProceed;
    public bool CanProceed
    {
        get => _canProceed;
        private set => SetProperty(ref _canProceed, value);
    }

    private bool _isDraftSaved;
    public bool IsDraftSaved
    {
        get => _isDraftSaved;
        private set => SetProperty(ref _isDraftSaved, value);
    }

    public CashierViewModel() => Refresh();

    public void SelectOrigin(string? buttonText) =>
        SelectedOrigin = (buttonText ?? string.Empty).Contains("Walk", StringComparison.OrdinalIgnoreCase)
            ? "walkin"
            : "booking";

    public void SelectTab(string? buttonText) =>
        SelectedTab = (buttonText ?? string.Empty).Contains("Produk", StringComparison.OrdinalIgnoreCase)
            ? "product"
            : "service";

    public void AddItem(string? id)
    {
        if (string.IsNullOrEmpty(id)) return;
        _qty[id] = _qty.TryGetValue(id, out var q) ? q + 1 : 1;
        IsDraftSaved = false;
        Refresh();
    }

    public void RemoveItem(string? id)
    {
        if (string.IsNullOrEmpty(id)) return;
        _qty.Remove(id);
        Refresh();
    }

    public void SaveDraft() => IsDraftSaved = true;

    private void Refresh()
    {
        CatalogRows = MockDataService.SaleItems
            .Where(x => x.Type == _selectedTab)
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
        CartLines = lines;
        OriginText = _selectedOrigin == "booking"
            ? "Booking: MON-261014-028 • Bella Anisa"
            : "Walk-in customer";
        TotalText = $"Total: {MockDataService.FormatRupiah(total)}";
        IsCartEmpty = lines.Count == 0;
        CanProceed = lines.Count > 0;
    }
}
