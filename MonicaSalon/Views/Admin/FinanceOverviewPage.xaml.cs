using MonicaSalon.Services;
namespace MonicaSalon.Views.Admin;
public partial class FinanceOverviewPage : ContentPage
{
    public FinanceOverviewPage()
    {
        InitializeComponent();
        var records = MockDataService.FinancialRecords;
        int income = records.Where(r => r.Type == "income").Sum(r => r.Amount);
        int expense = records.Where(r => r.Type == "expense").Sum(r => r.Amount);
        IncomeLabel.Text = MockDataService.FormatRupiah(income);
        ExpenseLabel.Text = MockDataService.FormatRupiah(expense);
        BalanceLabel.Text = MockDataService.FormatRupiah(income - expense);
        LatestList.ItemsSource = records.TakeLast(3).Reverse().Select(r => new
        {
            r.Description,
            Subtitle = $"{r.Date} • {r.Category}",
            r.Reference,
            DisplayAmount = (r.Type == "income" ? "+" : "-") + MockDataService.FormatRupiah(r.Amount)
        }).ToList();
    }
    private async void OnAddIncome(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-add-income");
    private async void OnAddExpense(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-add-expense");
    private async void OnIncomeDetails(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-financial-records");
    private async void OnExpenseDetails(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-financial-records");
    private async void OnViewAll(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-financial-records");
    private async void OnExport(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-export-config");
    private async void OnNavDashboard(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-dashboard");
    private async void OnNavBookings(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-bookings");
    private async void OnNavCashier(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-cashier");
    private async void OnNavInventory(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-inventory");
    private async void OnNavMore(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-more");
}
