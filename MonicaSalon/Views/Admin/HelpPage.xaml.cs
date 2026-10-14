namespace MonicaSalon.Views.Admin;
public partial class HelpPage : ContentPage
{
    public HelpPage() => InitializeComponent();
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
    private async void OnToggleBooking(object sender, EventArgs e) { BookingBody.IsVisible = !BookingBody.IsVisible; await Task.CompletedTask; }
    private async void OnToggleCashier(object sender, EventArgs e) { CashierBody.IsVisible = !CashierBody.IsVisible; await Task.CompletedTask; }
    private async void OnToggleInventory(object sender, EventArgs e) { InventoryBody.IsVisible = !InventoryBody.IsVisible; await Task.CompletedTask; }
    private async void OnToggleExport(object sender, EventArgs e) { ExportBody.IsVisible = !ExportBody.IsVisible; await Task.CompletedTask; }
}
