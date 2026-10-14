using MonicaSalon.Models;
using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class TransactionHistoryPageViewModel : BaseViewModel
{
    private string _query = string.Empty;
    public string Query
    {
        get => _query;
        set
        {
            if (SetProperty(ref _query, value ?? string.Empty))
                ApplyFilter();
        }
    }

    private List<TransactionItem> _transactions = new();
    public List<TransactionItem> Transactions
    {
        get => _transactions;
        private set => SetProperty(ref _transactions, value);
    }

    private string _summary = string.Empty;
    public string Summary
    {
        get => _summary;
        private set => SetProperty(ref _summary, value);
    }

    public TransactionHistoryPageViewModel() => ApplyFilter();

    private void ApplyFilter()
    {
        IEnumerable<TransactionItem> q = MockDataService.Transactions;
        if (!string.IsNullOrWhiteSpace(_query))
            q = q.Where(t => t.Ref.Contains(_query, StringComparison.OrdinalIgnoreCase)
                || t.Customer.Contains(_query, StringComparison.OrdinalIgnoreCase)
                || t.Items.Contains(_query, StringComparison.OrdinalIgnoreCase)
                || t.Method.Contains(_query, StringComparison.OrdinalIgnoreCase));
        var list = q.ToList();
        Transactions = list;
        Summary = $"{list.Count} transaksi • Total Rp 617.000";
    }
}
