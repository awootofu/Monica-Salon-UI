using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class FinanceOverviewPage : ContentPage
{
    public FinanceOverviewPage()
    {
        InitializeComponent();
        BindingContext = new FinanceOverviewViewModel();
    }
    private async void OnAddIncome(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-add-income");
    private async void OnAddExpense(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-add-expense");
    private async void OnIncomeDetails(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-financial-records");
    private async void OnExpenseDetails(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-financial-records");
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
    private void OnPeriodChanged(object? sender, DateChangedEventArgs e)
    {
        var start = StartPicker.Date ?? new DateTime(2026, 10, 8);
        var end = EndPicker.Date ?? new DateTime(2026, 10, 14);
        if (start > end)
        {
            if (sender == StartPicker)
                EndPicker.Date = end = start;
            else
                StartPicker.Date = start = end;
        }
        var id = new System.Globalization.CultureInfo("id-ID");
        PeriodLabel.Text = $"{start.ToString("d MMM", id)}–{end.ToString("d MMM yyyy", id)}";
    }
    private async void OnViewAll(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-financial-records");
    private async void OnExport(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-export-config");
    private async void OnNavDashboard(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-dashboard");
    private async void OnNavBookings(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-bookings");
    private async void OnNavCashier(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-cashier");
    private async void OnNavInventory(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-inventory");
    private async void OnNavMore(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
}
