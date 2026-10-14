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
    private async void OnRecordSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;
        ((CollectionView)sender).SelectedItem = null;
        await Shell.Current.GoToAsync("admin-financial-details");
    }
}
