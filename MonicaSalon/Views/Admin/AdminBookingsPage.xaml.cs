using MonicaSalon.Services;
namespace MonicaSalon.Views.Admin;
public partial class AdminBookingsPage : ContentPage
{
    private string _filter = "Semua";
    private string _query = string.Empty;

    public AdminBookingsPage()
    {
        InitializeComponent();
        StatusPicker.ItemsSource = new List<string> { "Semua", "Menunggu Konfirmasi", "Dikonfirmasi", "Selesai", "Dibatalkan" };
        StatusPicker.SelectedIndex = 0;
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        var list = MockDataService.AdminBookings.AsEnumerable();
        if (_filter != "Semua")
            list = list.Where(x => x.Status == _filter);
        if (!string.IsNullOrWhiteSpace(_query))
        {
            var q = _query.ToLowerInvariant();
            list = list.Where(x => x.Customer.ToLowerInvariant().Contains(q)
                || x.Ref.ToLowerInvariant().Contains(q)
                || x.Service.ToLowerInvariant().Contains(q));
        }
        BookingsList.ItemsSource = list.ToList();
    }

    private async void OnSearch(object sender, TextChangedEventArgs e)
    {
        _query = e.NewTextValue ?? string.Empty;
        ApplyFilter();
        await Task.CompletedTask;
    }

    private void OnStatusChanged(object sender, EventArgs e)
    {
        _filter = StatusPicker.SelectedItem?.ToString() ?? "Semua";
        ApplyFilter();
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
