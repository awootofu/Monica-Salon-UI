using MonicaSalon.Services;
namespace MonicaSalon.Views.Admin;

public partial class TransactionHistoryPage : ContentPage
{
    public TransactionHistoryPage()
    {
        InitializeComponent();
        HistoryList.ItemsSource = MockDataService.Transactions;
    }

    private async void OnSearchChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue ?? string.Empty;
        if (string.IsNullOrWhiteSpace(q))
            HistoryList.ItemsSource = MockDataService.Transactions;
        else
            HistoryList.ItemsSource = MockDataService.Transactions
                .Where(t => t.Ref.Contains(q, StringComparison.OrdinalIgnoreCase)
                    || t.Customer.Contains(q, StringComparison.OrdinalIgnoreCase)
                    || t.Items.Contains(q, StringComparison.OrdinalIgnoreCase)
                    || t.Method.Contains(q, StringComparison.OrdinalIgnoreCase))
                .ToList();
        int count = ((System.Collections.IEnumerable)HistoryList.ItemsSource).Cast<object>().Count();
        SummaryLabel.Text = $"{count} transaksi • Total Rp 617.000";
        await Task.CompletedTask;
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;
        ((CollectionView)sender).SelectedItem = null;
        await Shell.Current.GoToAsync("//admin-transaction-details");
    }

    private async void OnNavDashboard(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-dashboard");
    private async void OnNavBookings(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-bookings");
    private async void OnNavCashier(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-cashier");
    private async void OnNavInventory(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-inventory");
    private async void OnNavMore(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-more");
}
