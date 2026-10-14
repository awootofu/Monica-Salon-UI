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
        FileNameLabel.Text = $"Monica_Salon_Report_{end:yyyy-MM-dd}.xlsx";
    }
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-finance");
    private async void OnDatasetToggled(object sender, ToggledEventArgs e)
    {
        UpdateCount();
        await Task.CompletedTask;
    }
    private async void OnExport(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-export-result");
}
