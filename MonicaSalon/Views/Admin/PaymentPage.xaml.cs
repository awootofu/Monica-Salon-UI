using MonicaSalon.Services;
namespace MonicaSalon.Views.Admin;

public partial class PaymentPage : ContentPage
{
    private const int Total = 279000;
    private string _method = "Cash";

    public PaymentPage()
    {
        InitializeComponent();
        Refresh();
    }

    private void Refresh()
    {
        CashBox.IsVisible = _method == "Cash";
        RefBox.IsVisible = _method != "Cash";
        PaintMethod(CashBtn, _method == "Cash");
        PaintMethod(TransferBtn, _method == "Transfer");
        PaintMethod(QrisBtn, _method == "QRIS");
        Validate();
    }

    private void PaintMethod(Button b, bool active)
    {
        if (Application.Current?.Resources.TryGetValue(active ? "PrimaryButton" : "SecondaryButton", out var s) == true && s is Style st)
            b.Style = st;
    }

    private static int ParseAmount(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        var digits = new string(text.Where(char.IsDigit).ToArray());
        return int.TryParse(digits, out var v) ? v : 0;
    }

    private void Validate()
    {
        if (_method != "Cash")
        {
            PayBtn.IsEnabled = true;
            return;
        }
        int received = ParseAmount(CashEntry?.Text);
        if (received >= Total && received > 0)
        {
            CashStatusLabel.Text = $"Kembalian {MockDataService.FormatRupiah(received - Total)}";
            PayBtn.IsEnabled = true;
        }
        else
        {
            int due = Total - received;
            CashStatusLabel.Text = received <= 0
                ? "Masukkan nominal ≥ total."
                : $"Kurang {MockDataService.FormatRupiah(due)}";
            PayBtn.IsEnabled = false;
        }
    }

    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-transaction-review");

    private async void OnMethodSelected(object sender, EventArgs e)
    {
        if (sender is not Button b) return;
        _method = b.Text;
        Refresh();
        await Task.CompletedTask;
    }

    private async void OnQuickCash(object? sender, EventArgs e)
    {
        if (sender is not Button b || b.CommandParameter is not string amount) return;
        CashEntry.Text = amount;
        Validate();
        await Task.CompletedTask;
    }

    private async void OnCashChanged(object sender, TextChangedEventArgs e)
    {
        Validate();
        await Task.CompletedTask;
    }

    private async void OnComplete(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-transaction-success");
}
