using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;

public partial class PaymentPage : ContentPage
{
    private PaymentViewModel Vm => (PaymentViewModel)BindingContext;

    public PaymentPage()
    {
        InitializeComponent();
        BindingContext = new PaymentViewModel();
    }

    private void PaintMethod(Button b, bool active)
    {
        if (Application.Current?.Resources.TryGetValue(active ? "PrimaryButton" : "SecondaryButton", out var s) == true && s is Style st)
            b.Style = st;
    }

    private void RepaintMethods()
    {
        PaintMethod(CashBtn, Vm.Method == "Cash");
        PaintMethod(TransferBtn, Vm.Method == "Transfer");
        PaintMethod(QrisBtn, Vm.Method == "QRIS");
    }

    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-transaction-review");

    private async void OnMethodSelected(object sender, EventArgs e)
    {
        if (sender is not Button b) return;
        Vm.SelectMethod(b.Text);
        RepaintMethods();
        await Task.CompletedTask;
    }

    private async void OnQuickCash(object? sender, EventArgs e)
    {
        if (sender is not Button b || b.CommandParameter is not string amount) return;
        Vm.SetQuickCash(amount);
        await Task.CompletedTask;
    }

    private async void OnComplete(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-transaction-success");
}
