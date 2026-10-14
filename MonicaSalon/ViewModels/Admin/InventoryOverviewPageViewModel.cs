using MonicaSalon.Models;
using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class InventoryOverviewPageViewModel : BaseViewModel
{
    public List<string> Categories { get; } = new()
        { "Semua", "Retail", "Coloring", "Treatment" };

    private string _selectedCategory = "Semua";
    public string SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (SetProperty(ref _selectedCategory, value ?? "Semua"))
                ApplyFilter();
        }
    }

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

    private bool _showLowOnly;
    public bool ShowLowOnly
    {
        get => _showLowOnly;
        set
        {
            if (SetProperty(ref _showLowOnly, value))
                ApplyFilter();
        }
    }

    private List<InventoryItem> _items = new();
    public List<InventoryItem> Items
    {
        get => _items;
        private set => SetProperty(ref _items, value);
    }

    public InventoryOverviewPageViewModel() => ApplyFilter();

    private void ApplyFilter()
    {
        var q = MockDataService.Inventory.AsEnumerable();
        if (_selectedCategory != "Semua")
            q = q.Where(i => i.Category == _selectedCategory);
        if (!string.IsNullOrWhiteSpace(_query))
            q = q.Where(i => i.Name.Contains(_query, StringComparison.OrdinalIgnoreCase));
        if (_showLowOnly)
            q = q.Where(i => i.IsLow);
        Items = q.ToList();
    }
}
