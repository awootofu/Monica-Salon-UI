using System.Collections.ObjectModel;
using MonicaSalon.Services;
namespace MonicaSalon.Views.Admin;
public partial class ServiceManagementPage : ContentPage
{
    public class ServiceRow
    {
        public string Name { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string ToggleText => IsActive ? "Deactivate" : "Activate";
        public string StatusText => IsActive ? "Active" : "Inactive";
    }
    private ObservableCollection<ServiceRow> _rows = new();
    public ServiceManagementPage()
    {
        InitializeComponent();
        _rows = new ObservableCollection<ServiceRow>(MockDataService.Services.Select(s => new ServiceRow
        {
            Name = s.Name,
            Subtitle = $"{s.Price} • {s.Duration}",
            Category = s.Category,
            IsActive = true
        }));
        ServicesList.ItemsSource = _rows;
        CountLabel.Text = $"{_rows.Count} services";
    }
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
    private async void OnAddService(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-service-form");
    private async void OnEdit(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-service-form");
    private async void OnToggleActive(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        if (btn.BindingContext is ServiceRow row)
        {
            row.IsActive = !row.IsActive;
            btn.Text = row.ToggleText;
        }
        await Task.CompletedTask;
    }
    private async void OnSearchChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue?.ToLowerInvariant() ?? string.Empty;
        var all = MockDataService.Services.Select(s => new ServiceRow
        {
            Name = s.Name,
            Subtitle = $"{s.Price} • {s.Duration}",
            Category = s.Category,
            IsActive = _rows.FirstOrDefault(r => r.Name == s.Name)?.IsActive ?? true
        }).Where(r => r.Name.ToLowerInvariant().Contains(q)).ToList();
        ServicesList.ItemsSource = all;
        CountLabel.Text = $"{all.Count} services";
        await Task.CompletedTask;
    }
}
