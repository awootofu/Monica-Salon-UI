using MonicaSalon.Services;
namespace MonicaSalon.Views.Admin;

public partial class TransactionReviewPage : ContentPage
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

    public TransactionReviewPage()
    {
        InitializeComponent();
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
        ItemsList.ItemsSource = lines;
        ServiceSubtotalLabel.Text = MockDataService.FormatRupiah(serviceSub);
        ProductSubtotalLabel.Text = MockDataService.FormatRupiah(productSub);
        GrandTotalLabel.Text = MockDataService.FormatRupiah(serviceSub + productSub);
        EmptyLabel.IsVisible = lines.Count == 0;
        ContinueBtn.IsEnabled = lines.Count > 0;
    }

    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-cashier");

    private async void OnPlus(object? sender, EventArgs e)
    {
        if (sender is not Button b || b.CommandParameter is not string id) return;
        _qty[id] = _qty.TryGetValue(id, out var q) ? q + 1 : 1;
        Refresh();
        await Task.CompletedTask;
    }

    private async void OnMinus(object? sender, EventArgs e)
    {
        if (sender is not Button b || b.CommandParameter is not string id) return;
        _qty[id] = Math.Max(0, _qty.TryGetValue(id, out var q) ? q - 1 : 0);
        Refresh();
        await Task.CompletedTask;
    }

    private async void OnTrash(object? sender, EventArgs e)
    {
        if (sender is not Button b || b.CommandParameter is not string id) return;
        _qty[id] = 0;
        Refresh();
        await Task.CompletedTask;
    }

    private async void OnContinue(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-payment");
}
