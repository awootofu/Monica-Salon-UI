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

    private List<string> _bookingOptions = new();
    public List<string> BookingOptions
    {
        get => _bookingOptions;
        private set => SetProperty(ref _bookingOptions, value);
    }

    private string _selectedBookingOption = string.Empty;
    public string SelectedBookingOption
    {
        get => _selectedBookingOption;
        set
        {
            if (SetProperty(ref _selectedBookingOption, value ?? string.Empty))
                SelectBooking(_selectedBookingOption);
        }
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

    public CashierViewModel()
    {
        RefreshBookings();
        Refresh();
    }

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
        Refresh();
    }

    public void RemoveItem(string? id)
    {
        if (string.IsNullOrEmpty(id)) return;
        _qty.Remove(id);
        Refresh();
    }

    public void RefreshBookings()
    {
        BookingOptions = MockDataService.AdminBookings
            .Select(b => $"{b.Ref} • {b.Customer} • {b.Service}")
            .ToList();
        if (!string.IsNullOrEmpty(_selectedBookingOption) && !BookingOptions.Contains(_selectedBookingOption))
            SelectedBookingOption = string.Empty;
    }

    public void SelectBooking(string? option)
    {
        var booking = FindBooking(option);
        if (booking is null) return;
        _qty.Clear();
        foreach (var part in booking.Service.Split('+', StringSplitOptions.TrimEntries))
        {
            var saleId = MapServiceToSaleId(part);
            if (saleId is not null)
                _qty[saleId] = 1;
        }
        CashierContext.BookingRef = booking.Ref;
        CashierContext.CustomerName = booking.Customer;
        CashierContext.BookingWhen = $"{booking.Date} {booking.Time}";
        Refresh();
    }

    private static Models.BookingItem? FindBooking(string? option)
    {
        var refPart = (option ?? string.Empty).Split('•')[0].Trim();
        return MockDataService.AdminBookings.FirstOrDefault(b => b.Ref == refPart);
    }

    private static string? MapServiceToSaleId(string name)
    {
        var services = MockDataService.SaleItems.Where(x => x.Type == "service").ToList();
        return services.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase))?.Id
            ?? services.FirstOrDefault(x => name.Contains(x.Name, StringComparison.OrdinalIgnoreCase)
                || x.Name.Contains(name, StringComparison.OrdinalIgnoreCase))?.Id;
    }

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
        if (_selectedOrigin == "booking" && FindBooking(_selectedBookingOption) is { } sel)
        {
            OriginText = $"Booking: {sel.Ref} • {sel.Customer}";
            CashierContext.BookingRef = sel.Ref;
            CashierContext.CustomerName = sel.Customer;
            CashierContext.BookingWhen = $"{sel.Date} {sel.Time}";
        }
        else if (_selectedOrigin == "walkin")
        {
            OriginText = "Walk-in customer";
            CashierContext.BookingRef = "Walk-in";
            CashierContext.CustomerName = "Walk-in";
            CashierContext.BookingWhen = string.Empty;
        }
        else
        {
            OriginText = "Pilih customer dahulu.";
        }
        CashierContext.Cart = _qty.ToDictionary(kv => kv.Key, kv => kv.Value);
        TotalText = $"Total: {MockDataService.FormatRupiah(total)}";
        IsCartEmpty = lines.Count == 0;
        CanProceed = lines.Count > 0;
    }
}
