using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;

public partial class TransactionReviewPage : ContentPage
{
    private TransactionReviewViewModel Vm => (TransactionReviewViewModel)BindingContext;

    public TransactionReviewPage()
    {
        InitializeComponent();
        BindingContext = new TransactionReviewViewModel();
    }

    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-cashier");

    private async void OnPlus(object? sender, EventArgs e)
    {
        if (sender is not Button b || b.CommandParameter is not string id) return;
        Vm.Increase(id);
        await Task.CompletedTask;
    }

    private async void OnMinus(object? sender, EventArgs e)
    {
        if (sender is not Button b || b.CommandParameter is not string id) return;
        Vm.Decrease(id);
        await Task.CompletedTask;
    }

    private async void OnTrash(object? sender, EventArgs e)
    {
        if (sender is not Button b || b.CommandParameter is not string id) return;
        Vm.RemoveItem(id);
        await Task.CompletedTask;
    }

    private async void OnContinue(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-payment");
}
