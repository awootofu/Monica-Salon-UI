using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class PaymentViewModel : BaseViewModel
{
    public const int Total = 279000;

    private string _method = "Cash";
    public string Method
    {
        get => _method;
        private set
        {
            if (SetProperty(ref _method, value ?? "Cash"))
            {
                OnPropertyChanged(nameof(IsCash));
                OnPropertyChanged(nameof(IsNonCash));
                Refresh();
            }
        }
    }

    public bool IsCash => _method == "Cash";
    public bool IsNonCash => _method != "Cash";

    private string _cashText = string.Empty;
    public string CashText
    {
        get => _cashText;
        set
        {
            if (SetProperty(ref _cashText, value ?? string.Empty))
                Refresh();
        }
    }

    private string _referenceText = string.Empty;
    public string ReferenceText
    {
        get => _referenceText;
        set => SetProperty(ref _referenceText, value ?? string.Empty);
    }

    private string _cashStatusText = "Masukkan nominal ≥ total.";
    public string CashStatusText
    {
        get => _cashStatusText;
        private set => SetProperty(ref _cashStatusText, value);
    }

    private bool _canPay;
    public bool CanPay
    {
        get => _canPay;
        private set => SetProperty(ref _canPay, value);
    }

    public PaymentViewModel() => Refresh();

    public void SelectMethod(string? buttonText) => Method = buttonText ?? "Cash";

    public void SetQuickCash(string? amount) => CashText = amount ?? string.Empty;

    private void Refresh()
    {
        if (_method != "Cash")
        {
            CanPay = true;
            return;
        }
        int received = ParseAmount(_cashText);
        if (received >= Total && received > 0)
        {
            CashStatusText = $"Kembalian {MockDataService.FormatRupiah(received - Total)}";
            CanPay = true;
        }
        else
        {
            int due = Total - received;
            CashStatusText = received <= 0
                ? "Masukkan nominal ≥ total."
                : $"Kurang {MockDataService.FormatRupiah(due)}";
            CanPay = false;
        }
    }

    private static int ParseAmount(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        var digits = new string(text.Where(char.IsDigit).ToArray());
        return int.TryParse(digits, out var v) ? v : 0;
    }
}
