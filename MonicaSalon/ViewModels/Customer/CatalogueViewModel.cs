using MonicaSalon.Models;
using MonicaSalon.Services;
namespace MonicaSalon.ViewModels;
public class CatalogueViewModel : BaseViewModel
{
    public List<string> Categories { get; } = new()
        { "Semua", "Haircut", "Treatment", "Styling", "Coloring", "Facial" };

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

    private List<ServiceItem> _services = new();
    public List<ServiceItem> Services
    {
        get => _services;
        private set => SetProperty(ref _services, value);
    }

    public CatalogueViewModel() => ApplyFilter();

    private void ApplyFilter()
    {
        IEnumerable<ServiceItem> q = MockDataService.Services;
        if (_selectedCategory != "Semua")
            q = q.Where(s => s.Category == _selectedCategory);
        if (!string.IsNullOrWhiteSpace(_query))
            q = q.Where(s => s.Name.Contains(_query, StringComparison.OrdinalIgnoreCase));
        Services = q.ToList();
    }
}
