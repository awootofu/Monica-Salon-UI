namespace MonicaSalon.Views.Admin;

public partial class TransactionSuccessPage : ContentPage
{
    public TransactionSuccessPage() => InitializeComponent();

    private async void OnViewHistory(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-transactions");
    private async void OnViewFinancial(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-financial-records");
    private async void OnDashboard(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-dashboard");
}
