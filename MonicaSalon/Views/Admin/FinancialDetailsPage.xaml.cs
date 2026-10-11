namespace MonicaSalon.Views.Admin;
public partial class FinancialDetailsPage : ContentPage
{
    public FinancialDetailsPage() => InitializeComponent();
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-financial-records");
    private async void OnEdit(object sender, EventArgs e)
    {
        DescEntry.IsEnabled = true;
        CatEntry.IsEnabled = true;
        RefEntry.IsEnabled = true;
        EditActions.IsVisible = true;
        EditBtn.IsVisible = false;
        await Task.CompletedTask;
    }
    private async void OnSave(object sender, EventArgs e)
    {
        DescEntry.IsEnabled = false;
        CatEntry.IsEnabled = false;
        RefEntry.IsEnabled = false;
        EditActions.IsVisible = false;
        EditBtn.IsVisible = true;
        await Task.CompletedTask;
    }
    private async void OnCancel(object sender, EventArgs e)
    {
        DescEntry.IsEnabled = false;
        CatEntry.IsEnabled = false;
        RefEntry.IsEnabled = false;
        EditActions.IsVisible = false;
        EditBtn.IsVisible = true;
        await Task.CompletedTask;
    }
    private async void OnExport(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-export-config");
    private async void OnDelete(object sender, EventArgs e) => await Task.CompletedTask;
}
