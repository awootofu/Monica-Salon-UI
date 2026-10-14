using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class TransactionReviewViewModel : BaseViewModel
{
    public class ReviewLine
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string PriceText { get; set; } = string.Empty;
        public int Qty { get; set; }
        public string LineTotalText { get; set; } = string.Empty;
    }

    private readonly Dictionary<string, int> _qty = new()
    {
        ["coloring"] = 1,
        ["shampoo"] = 1,
    };

    private List<ReviewLine> _lines = new();
    public List<ReviewLine> Lines
    {
        get => _lines;
        private set => SetProperty(ref _lines, value);
    }

    private string _serviceSubtotalText = string.Empty;
    public string ServiceSubtotalText
    {
        get => _serviceSubtotalText;
        private set => SetProperty(ref _serviceSubtotalText, value);
    }

    private string _productSubtotalText = string.Empty;
    public string ProductSubtotalText
    {
        get => _productSubtotalText;
        private set => SetProperty(ref _productSubtotalText, value);
    }

    private string _grandTotalText = string.Empty;
    public string GrandTotalText
    {
        get => _grandTotalText;
        private set => SetProperty(ref _grandTotalText, value);
    }

    private bool _isEmpty;
    public bool IsEmpty
    {
        get => _isEmpty;
        private set => SetProperty(ref _isEmpty, value);
    }

    private bool _canContinue;
    public bool CanContinue
    {
        get => _canContinue;
        private set => SetProperty(ref _canContinue, value);
    }

    public TransactionReviewViewModel() => Refresh();

    public void Increase(string? id)
    {
        if (string.IsNullOrEmpty(id)) return;
        _qty[id] = _qty.TryGetValue(id, out var q) ? q + 1 : 1;
        Refresh();
    }

    public void Decrease(string? id)
    {
        if (string.IsNullOrEmpty(id)) return;
        _qty[id] = Math.Max(0, _qty.TryGetValue(id, out var q) ? q - 1 : 0);
        Refresh();
    }

    public void RemoveItem(string? id)
    {
        if (string.IsNullOrEmpty(id)) return;
        _qty[id] = 0;
        Refresh();
    }

    private void Refresh()
    {
        var lines = new List<ReviewLine>();
        int serviceSub = 0, productSub = 0;
        foreach (var kv in _qty.Where(kv => kv.Value > 0))
        {
            var item = MockDataService.SaleItems.FirstOrDefault(x => x.Id == kv.Key);
            if (item is null) continue;
            int line = item.Price * kv.Value;
            if (item.Type == "service") serviceSub += line;
            else productSub += line;
            string name = item.Id == "coloring" ? "Pewarnaan" : item.Name;
            lines.Add(new ReviewLine
            {
                Id = item.Id,
                Name = $"{name} x{kv.Value}",
                PriceText = MockDataService.FormatRupiah(item.Price),
                Qty = kv.Value,
                LineTotalText = MockDataService.FormatRupiah(line)
            });
        }
        Lines = lines;
        ServiceSubtotalText = MockDataService.FormatRupiah(serviceSub);
        ProductSubtotalText = MockDataService.FormatRupiah(productSub);
        GrandTotalText = MockDataService.FormatRupiah(serviceSub + productSub);
        IsEmpty = lines.Count == 0;
        CanContinue = lines.Count > 0;
    }
}
