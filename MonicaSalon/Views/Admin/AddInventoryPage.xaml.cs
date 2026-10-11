namespace MonicaSalon.Views.Admin;
public partial class AddInventoryPage : ContentPage
{
    public AddInventoryPage()
    {
        InitializeComponent();
        CategoryPicker.ItemsSource = new List<string> { "Retail", "Treatment", "Coloring" };
        CategoryPicker.SelectedIndex = 0;
        UnitPicker.ItemsSource = new List<string> { "botol", "tube", "jar", "sachet" };
        UnitPicker.SelectedIndex = 0;
    }

    private void OnNameChanged(object sender, TextChangedEventArgs e)
    {
        SaveButton.IsEnabled = !string.IsNullOrWhiteSpace(e.NewTextValue);
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory");
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory");
    }
}
