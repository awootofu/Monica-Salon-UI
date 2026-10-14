using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class FinancialRecordsPageViewModel : BaseViewModel
{
    public List<string> Categories { get; } = new()
        { "All", "Belanja Stok" };

    public List<string> Types { get; } = new()
        { "All", "Pemasukan", "Pengeluaran" };

    private string _selectedCategory = "All";
    public string SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (SetProperty(ref _selectedCategory, value ?? "All"))
                ApplyFilter();
        }
    }

    private string _selectedType = "All";
    public string SelectedType
    {
        get => _selectedType;
        set
        {
            if (SetProperty(ref _selectedType, value ?? "All"))
                ApplyFilter();
        }
    }

    private List<FinancialRecordRow> _records = new();
    public List<FinancialRecordRow> Records
    {
        get => _records;
        private set => SetProperty(ref _records, value);
    }

    public FinancialRecordsPageViewModel() => ApplyFilter();

    private void ApplyFilter()
    {
        var q = MockDataService.FinancialRecords.AsEnumerable();
        if (_selectedCategory == "Belanja Stok" || _selectedCategory == "Inventory Purchase")
            q = q.Where(r => r.Category == "Inventory Purchase");
        if (_selectedType == "Pemasukan" || _selectedType == "Income")
            q = q.Where(r => r.Type == "income");
        else if (_selectedType == "Pengeluaran" || _selectedType == "Expense")
            q = q.Where(r => r.Type == "expense");
        Records = q.Select(r => new FinancialRecordRow
        {
            Date = r.Date,
            Category = r.Category,
            Description = r.Description,
            Reference = r.Reference,
            DisplayAmount = (r.Type == "income" ? "+" : "-") + MockDataService.FormatRupiah(r.Amount)
        }).ToList();
    }

    public class FinancialRecordRow
    {
        public string Date { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public string DisplayAmount { get; set; } = string.Empty;
    }
}
