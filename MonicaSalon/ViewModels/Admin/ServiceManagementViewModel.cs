using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class ServiceManagementViewModel : BaseViewModel
{
    public class ServiceRow : BaseViewModel
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value ?? string.Empty);
        }

        private string _subtitle = string.Empty;
        public string Subtitle
        {
            get => _subtitle;
            set => SetProperty(ref _subtitle, value ?? string.Empty);
        }

        private string _category = string.Empty;
        public string Category
        {
            get => _category;
            set => SetProperty(ref _category, value ?? string.Empty);
        }

        private bool _isActive = true;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (SetProperty(ref _isActive, value))
                {
                    OnPropertyChanged(nameof(ToggleText));
                    OnPropertyChanged(nameof(StatusText));
                }
            }
        }

        public string ToggleText => IsActive ? "Deactivate" : "Activate";
        public string StatusText => IsActive ? "Active" : "Inactive";
    }

    private readonly List<ServiceRow> _all = new();

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

    private List<ServiceRow> _filteredServices = new();
    public List<ServiceRow> FilteredServices
    {
        get => _filteredServices;
        private set => SetProperty(ref _filteredServices, value);
    }

    private string _countText = string.Empty;
    public string CountText
    {
        get => _countText;
        private set => SetProperty(ref _countText, value ?? string.Empty);
    }

    public ServiceManagementViewModel()
    {
        _all.AddRange(MockDataService.Services.Select(s => new ServiceRow
        {
            Name = s.Name,
            Subtitle = $"{s.Price} • {s.Duration}",
            Category = s.Category,
            IsActive = true
        }));
        ApplyFilter();
    }

    public void ToggleActive(ServiceRow? row)
    {
        if (row is null) return;
        row.IsActive = !row.IsActive;
    }

    private void ApplyFilter()
    {
        string q = (_query ?? string.Empty).ToLowerInvariant();
        var filtered = _all.Where(r => (r.Name ?? string.Empty).ToLowerInvariant().Contains(q)).ToList();
        FilteredServices = filtered;
        CountText = $"{filtered.Count} services";
    }
}
