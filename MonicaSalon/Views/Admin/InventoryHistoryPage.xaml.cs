using MonicaSalon.Services;
namespace MonicaSalon.Views.Admin;
public partial class InventoryHistoryPage : ContentPage
{
    private string _type = "Semua";

    public InventoryHistoryPage()
    {
        InitializeComponent();
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        var q = MockDataService.Movements.AsEnumerable();
        if (_type != "Semua")
            q = q.Where(m => m.Type == _type);
        MovementList.ItemsSource = q.ToList();
    }

    private void OnTypeClicked(object sender, EventArgs e)
    {
        if (sender is Button b)
            _type = b.Text;
        ApplyFilter();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-inventory");
    }
}
