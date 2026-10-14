using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;

public partial class CashierPage : ContentPage
{
    private CashierViewModel Vm => (CashierViewModel)BindingContext;

    public CashierPage()
    {
        InitializeComponent();
        BindingContext = new CashierViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Vm.RefreshBookings();
    }

    private void PaintToggle(Button active, Button inactive)
    {
        if (Application.Current?.Resources.TryGetValue("PrimaryButton", out var p) == true && p is Style ps)
            active.Style = ps;
        if (Application.Current?.Resources.TryGetValue("SecondaryButton", out var s) == true && s is Style ss)
            inactive.Style = ss;
    }

    private void RepaintToggles()
    {
        if (Vm.IsBookingOrigin)
            PaintToggle(OriginBookingBtn, OriginWalkinBtn);
        else
            PaintToggle(OriginWalkinBtn, OriginBookingBtn);
        if (Vm.IsServiceTab)
            PaintToggle(TabServiceBtn, TabProductBtn);
        else
            PaintToggle(TabProductBtn, TabServiceBtn);
    }

    private async void OnOriginSelected(object sender, EventArgs e)
    {
        if (sender is not Button b) return;
        Vm.SelectOrigin(b.Text);
        RepaintToggles();
        await Task.CompletedTask;
    }

    private async void OnTabSelected(object sender, EventArgs e)
    {
        if (sender is not Button b) return;
        Vm.SelectTab(b.Text);
        RepaintToggles();
        await Task.CompletedTask;
    }

    private async void OnAddClicked(object? sender, EventArgs e)
    {
        if (sender is not Button b || b.CommandParameter is not string id) return;
        Vm.AddItem(id);
        await Task.CompletedTask;
    }

    private async void OnRemoveClicked(object? sender, EventArgs e)
    {
        if (sender is not Button b || b.CommandParameter is not string id) return;
        Vm.RemoveItem(id);
        await Task.CompletedTask;
    }

    private async void OnProceed(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-transaction-review");
    }

    private async void OnNavDashboard(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-dashboard");
    private async void OnNavBookings(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-bookings");
    private async void OnNavCashier(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-cashier");
    private async void OnNavInventory(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-inventory");
    private async void OnNavMore(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
}
