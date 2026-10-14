using MonicaSalon.Models;
using MonicaSalon.Services;
namespace MonicaSalon.ViewModels;
public class HairstyleBookViewModel : BaseViewModel
{
    public List<string> Categories { get; } = new()
        { "Semua", "Bob", "Layer", "Panjang", "Pendek", "Keriting" };

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

    private List<HairstyleItem> _styles = new();
    public List<HairstyleItem> Styles
    {
        get => _styles;
        private set => SetProperty(ref _styles, value);
    }

    private string _countText = string.Empty;
    public string CountText
    {
        get => _countText;
        private set => SetProperty(ref _countText, value);
    }

    public HairstyleBookViewModel() => ApplyFilter();

    public void Refresh() => ApplyFilter();

    private void ApplyFilter()
    {
        IEnumerable<HairstyleItem> q = MockDataService.Hairstyles;
        if (_selectedCategory != "Semua")
            q = q.Where(s => s.Category == _selectedCategory);
        if (!string.IsNullOrWhiteSpace(_query))
            q = q.Where(s => s.Name.Contains(_query, StringComparison.OrdinalIgnoreCase)
                || s.Description.Contains(_query, StringComparison.OrdinalIgnoreCase));
        var list = q.ToList();
        Styles = list;
        CountText = $"{list.Count} gaya";
    }
}
