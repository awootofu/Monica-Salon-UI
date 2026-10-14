using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;

public partial class TransactionHistoryPage : ContentPage
{
    public TransactionHistoryPage()
    {
        InitializeComponent();
        BindingContext = new TransactionHistoryPageViewModel();
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;
        ((CollectionView)sender).SelectedItem = null;
        await Shell.Current.GoToAsync("admin-transaction-details");
    }

    private async void OnNavDashboard(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-dashboard");
    private async void OnNavBookings(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-bookings");
    private async void OnNavCashier(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-cashier");
    private async void OnNavInventory(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-inventory");
    private async void OnNavMore(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
}
