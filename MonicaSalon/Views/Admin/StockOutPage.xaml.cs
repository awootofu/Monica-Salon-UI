namespace MonicaSalon.Views.Admin;
public partial class StockOutPage : ContentPage
{
    private const int CurrentStock = 12;
    private const string Unit = "tube";

    public StockOutPage()
    {
        InitializeComponent();
        ReasonPicker.ItemsSource = new List<string> { "Material usage", "Damaged", "Stock correction" };
        ReasonPicker.SelectedIndex = 0;
        RelatedBox.IsVisible = true;
    }

    private void OnQtyChanged(object sender, TextChangedEventArgs e)
    {
        if (int.TryParse(e.NewTextValue, out var qty) && qty > 0 && qty <= CurrentStock)
        {
            PreviewLabel.Text = $"Sisa: {CurrentStock - qty} {Unit}";
            ErrorLabel.IsVisible = false;
        }
        else
        {
            PreviewLabel.Text = $"Sisa: {CurrentStock} {Unit}";
            ErrorLabel.IsVisible = !string.IsNullOrWhiteSpace(e.NewTextValue);
        }
    }

    private void OnReasonChanged(object sender, EventArgs e)
    {
        RelatedBox.IsVisible = ReasonPicker.SelectedItem?.ToString() == "Material usage";
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-inventory-details");
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        if (!int.TryParse(QtyEntry.Text, out var qty) || qty <= 0 || qty > CurrentStock)
        {
            ErrorLabel.IsVisible = true;
            SavedBox.IsVisible = false;
            return;
        }
        ErrorLabel.IsVisible = false;
        SavedDetailLabel.Text = $"Sisa stok: {CurrentStock - qty} {Unit}.";
        PreviewLabel.Text = SavedDetailLabel.Text;
        SavedBox.IsVisible = true;
    }

    private async void OnViewInventoryClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-inventory");
    }
}
