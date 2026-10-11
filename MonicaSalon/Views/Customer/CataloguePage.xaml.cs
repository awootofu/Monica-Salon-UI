using MonicaSalon.Models;
using MonicaSalon.Services;
namespace MonicaSalon.Views.Customer;
public partial class CataloguePage : ContentPage
{
    private string _filter = "Semua";
    private string _query = string.Empty;

    public CataloguePage()
    {
        InitializeComponent();
        ApplyFilter();
    }

    private void OnSearchChanged(object sender, TextChangedEventArgs e)
    {
        _query = e.NewTextValue ?? string.Empty;
        ApplyFilter();
    }

    private void OnFilter(object sender, EventArgs e)
    {
        if (sender is Button b && b.CommandParameter is string c)
            _filter = c;
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        IEnumerable<ServiceItem> q = MockDataService.Services;
        if (_filter != "Semua")
            q = q.Where(s => s.Category == _filter);
        if (!string.IsNullOrWhiteSpace(_query))
            q = q.Where(s => s.Name.Contains(_query, StringComparison.OrdinalIgnoreCase));
        ServiceList.ItemsSource = q.ToList();
    }

    private async void OnServiceSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;
        ((CollectionView)sender).SelectedItem = null;
        await Shell.Current.GoToAsync("//details");
    }

    private async void OnNavHome(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//home");
    }

    private async void OnNavServices(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//catalogue");
    }

    private async void OnNavBooking(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//schedule");
    }

    private async void OnNavHistory(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//history");
    }

    private async void OnNavProfile(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//profile");
    }
}
