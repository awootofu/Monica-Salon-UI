using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class FinanceOverviewViewModel : BaseViewModel
{
    private string _incomeText = string.Empty;
    public string IncomeText
    {
        get => _incomeText;
        private set => SetProperty(ref _incomeText, value ?? string.Empty);
    }

    private string _expenseText = string.Empty;
    public string ExpenseText
    {
        get => _expenseText;
        private set => SetProperty(ref _expenseText, value ?? string.Empty);
    }

    private string _balanceText = string.Empty;
    public string BalanceText
    {
        get => _balanceText;
        private set => SetProperty(ref _balanceText, value ?? string.Empty);
    }

    public class FinanceRow
    {
        public string Description { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public string DisplayAmount { get; set; } = string.Empty;
    }

    private List<FinanceRow> _latestRecords = new();
    public List<FinanceRow> LatestRecords
    {
        get => _latestRecords;
        private set => SetProperty(ref _latestRecords, value);
    }

    public FinanceOverviewViewModel()
    {
        var records = MockDataService.FinancialRecords;
        int income = records.Where(r => r.Type == "income").Sum(r => r.Amount);
        int expense = records.Where(r => r.Type == "expense").Sum(r => r.Amount);
        IncomeText = MockDataService.FormatRupiah(income);
        ExpenseText = MockDataService.FormatRupiah(expense);
        BalanceText = MockDataService.FormatRupiah(income - expense);
        LatestRecords = records.TakeLast(3).Reverse().Select(r => new FinanceRow
        {
            Description = r.Description,
            Subtitle = $"{r.Date} • {r.Category}",
            Reference = r.Reference,
            DisplayAmount = (r.Type == "income" ? "+" : "-") + MockDataService.FormatRupiah(r.Amount)
        }).ToList();
    }
}
