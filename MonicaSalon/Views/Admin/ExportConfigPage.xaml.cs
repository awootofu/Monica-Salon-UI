namespace MonicaSalon.Views.Admin;
public partial class ExportConfigPage : ContentPage
{
    public ExportConfigPage()
    {
        InitializeComponent();
        UpdateCount();
    }
    private void UpdateCount()
    {
        int n = 0;
        if (CashierSwitch.IsToggled) n++;
        if (FinancialSwitch.IsToggled) n++;
        if (InventorySwitch.IsToggled) n++;
        if (BookingSwitch.IsToggled) n++;
        CountLabel.Text = $"{n} datasets selected";
        ExportBtn.Text = $"Export {n} Datasets";
    }
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-finance");
    private async void OnDatasetToggled(object sender, ToggledEventArgs e)
    {
        UpdateCount();
        await Task.CompletedTask;
    }
    private async void OnExport(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-export-result");
}
