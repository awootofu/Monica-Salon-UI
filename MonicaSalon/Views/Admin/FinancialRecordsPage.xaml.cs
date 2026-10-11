using MonicaSalon.Services;
namespace MonicaSalon.Views.Admin;
public partial class FinancialRecordsPage : ContentPage
{
    private string _categoryFilter = "All";
    private string _typeFilter = "All";
    public FinancialRecordsPage()
    {
        InitializeComponent();
        ApplyFilter();
    }
    private void ApplyFilter()
    {
        var q = MockDataService.FinancialRecords.AsEnumerable();
        if (_categoryFilter == "Inventory Purchase")
            q = q.Where(r => r.Category == "Inventory Purchase");
        if (_typeFilter == "Income")
            q = q.Where(r => r.Type == "income");
        else if (_typeFilter == "Expense")
            q = q.Where(r => r.Type == "expense");
        RecordsList.ItemsSource = q.Select(r => new
        {
            r.Date,
            r.Category,
            r.Description,
            r.Reference,
            DisplayAmount = (r.Type == "income" ? "+" : "-") + MockDataService.FormatRupiah(r.Amount)
        }).ToList();
    }
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-finance");
    private async void OnCategoryAll(object sender, EventArgs e)
    {
        _categoryFilter = "All";
        CatAllBtn.Style = (Style)Application.Current.Resources["PrimaryButton"];
        CatInvBtn.Style = (Style)Application.Current.Resources["SecondaryButton"];
        ApplyFilter();
        await Task.CompletedTask;
    }
    private async void OnCategoryInv(object sender, EventArgs e)
    {
        _categoryFilter = "Inventory Purchase";
        CatInvBtn.Style = (Style)Application.Current.Resources["PrimaryButton"];
        CatAllBtn.Style = (Style)Application.Current.Resources["SecondaryButton"];
        ApplyFilter();
        await Task.CompletedTask;
    }
    private async void OnTypeAll(object sender, EventArgs e)
    {
        _typeFilter = "All";
        TypeAllBtn.Style = (Style)Application.Current.Resources["PrimaryButton"];
        TypeIncomeBtn.Style = (Style)Application.Current.Resources["SecondaryButton"];
        TypeExpenseBtn.Style = (Style)Application.Current.Resources["SecondaryButton"];
        ApplyFilter();
        await Task.CompletedTask;
    }
    private async void OnTypeIncome(object sender, EventArgs e)
    {
        _typeFilter = "Income";
        TypeIncomeBtn.Style = (Style)Application.Current.Resources["PrimaryButton"];
        TypeAllBtn.Style = (Style)Application.Current.Resources["SecondaryButton"];
        TypeExpenseBtn.Style = (Style)Application.Current.Resources["SecondaryButton"];
        ApplyFilter();
        await Task.CompletedTask;
    }
    private async void OnTypeExpense(object sender, EventArgs e)
    {
        _typeFilter = "Expense";
        TypeExpenseBtn.Style = (Style)Application.Current.Resources["PrimaryButton"];
        TypeAllBtn.Style = (Style)Application.Current.Resources["SecondaryButton"];
        TypeIncomeBtn.Style = (Style)Application.Current.Resources["SecondaryButton"];
        ApplyFilter();
        await Task.CompletedTask;
    }
    private async void OnRecordSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;
        ((CollectionView)sender).SelectedItem = null;
        await Shell.Current.GoToAsync("//admin-financial-details");
    }
}
