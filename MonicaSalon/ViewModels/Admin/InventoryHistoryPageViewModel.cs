using MonicaSalon.Models;
using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class InventoryHistoryPageViewModel : BaseViewModel
{
    public List<string> Types { get; } = new()
        { "Semua", "Stok Masuk", "Stok Keluar", "Retail Sale" };

    private string _selectedType = "Semua";
    public string SelectedType
    {
        get => _selectedType;
        set
        {
            if (SetProperty(ref _selectedType, value ?? "Semua"))
                ApplyFilter();
        }
    }

    private List<MovementItem> _movements = new();
    public List<MovementItem> Movements
    {
        get => _movements;
        private set => SetProperty(ref _movements, value);
    }

    public InventoryHistoryPageViewModel() => ApplyFilter();

    private void ApplyFilter()
    {
        var q = MockDataService.Movements.AsEnumerable();
        if (_selectedType != "Semua")
        {
            var mapped = _selectedType switch
            {
                "Stok Masuk" => "Stock-In",
                "Stok Keluar" => "Stock-Out",
                _ => _selectedType
            };
            q = q.Where(m => m.Type == _selectedType || m.Type == mapped);
        }
        Movements = q.ToList();
    }
}
