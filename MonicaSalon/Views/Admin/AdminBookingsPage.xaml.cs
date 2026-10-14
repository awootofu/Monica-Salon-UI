using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class AdminBookingsPage : ContentPage
{
    public AdminBookingsPage()
    {
        InitializeComponent();
        BindingContext = new AdminBookingsPageViewModel();
    }

    private async void OnDateSelected(object sender, EventArgs e)
    {
        await DisplayAlert("Tanggal", "Menampilkan booking tanggal 14 Okt 2026.", "OK");
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;
        ((CollectionView)sender).SelectedItem = null;
        await Shell.Current.GoToAsync("admin-booking-details");
    }

    private async void OnAdd(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-create-booking");

    private async void OnNavDashboard(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-dashboard");
    private async void OnNavBookings(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-bookings");
    private async void OnNavCashier(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-cashier");
    private async void OnNavInventory(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-inventory");
    private async void OnNavMore(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
}
