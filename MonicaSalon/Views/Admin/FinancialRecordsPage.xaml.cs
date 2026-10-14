using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class FinancialRecordsPage : ContentPage
{
    public FinancialRecordsPage()
    {
        InitializeComponent();
        BindingContext = new FinancialRecordsPageViewModel();
    }
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-finance");
    private void OnRangeChanged(object? sender, DateChangedEventArgs e)
    {
        var start = StartPicker.Date ?? new DateTime(2026, 10, 8);
        var end = EndPicker.Date ?? new DateTime(2026, 10, 14);
        if (start > end)
        {
            if (sender == StartPicker)
                EndPicker.Date = end = start;
            else
                StartPicker.Date = start = end;
        }
        var id = new System.Globalization.CultureInfo("id-ID");
        RangeLabel.Text = $"{start.ToString("d MMM", id)}–{end.ToString("d MMM yyyy", id)}";
    }
    private async void OnRecordSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;
        ((CollectionView)sender).SelectedItem = null;
        await Shell.Current.GoToAsync("admin-financial-details");
    }
}
