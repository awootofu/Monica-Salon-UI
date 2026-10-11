namespace MonicaSalon.Views.Admin;
public partial class StockInPage : ContentPage
{
    private const int CurrentStock = 4;
    private const string Unit = "botol";

    public StockInPage()
    {
        InitializeComponent();
        ReasonPicker.ItemsSource = new List<string> { "Supplier delivery", "Return", "Stock correction" };
        ReasonPicker.SelectedIndex = 0;
    }

    private void OnQtyChanged(object sender, TextChangedEventArgs e)
    {
        if (int.TryParse(e.NewTextValue, out var qty) && qty > 0)
            PreviewLabel.Text = $"Stok akhir: {CurrentStock + qty} {Unit}";
        else
            PreviewLabel.Text = $"Stok akhir: {CurrentStock} {Unit}";
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-inventory-details");
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        var qty = 0;
        int.TryParse(QtyEntry.Text, out qty);
        var finalStock = CurrentStock + Math.Max(0, qty);
        SavedDetailLabel.Text = $"Stok akhir: {finalStock} {Unit}.";
        PreviewLabel.Text = SavedDetailLabel.Text;
        SavedBox.IsVisible = true;
    }

    private async void OnViewInventoryClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-inventory");
    }
}
