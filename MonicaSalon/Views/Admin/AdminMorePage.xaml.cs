namespace MonicaSalon.Views.Admin;
public partial class AdminMorePage : ContentPage
{
    public AdminMorePage() => InitializeComponent();
    private async void OnServices(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-services");
    private async void OnProducts(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-products");
    private async void OnSalonSettings(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-salon-settings");
    private async void OnUsers(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-users");
    private async void OnSalonProfile(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-salon-profile");
    private async void OnFinance(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-finance");
    private async void OnExport(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-export-config");
    private async void OnHelp(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-help");
    private void OnLogout(object sender, EventArgs e) => LogoutConfirm.IsVisible = true;
    private async void OnConfirmLogout(object sender, EventArgs e) => await Shell.Current.GoToAsync("login");
    private void OnCancelLogout(object sender, EventArgs e) => LogoutConfirm.IsVisible = false;
    private async void OnNavDashboard(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-dashboard");
    private async void OnNavBookings(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-bookings");
    private async void OnNavCashier(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-cashier");
    private async void OnNavInventory(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-inventory");
    private async void OnNavMore(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
}
