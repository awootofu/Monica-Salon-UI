namespace MonicaSalon.Views.Admin;
public partial class EditInventoryPage : ContentPage
{
    public EditInventoryPage()
    {
        InitializeComponent();
        CategoryPicker.ItemsSource = new List<string> { "Retail", "Treatment", "Coloring" };
        CategoryPicker.SelectedItem = "Retail";
        UnitPicker.ItemsSource = new List<string> { "botol", "tube", "jar", "sachet" };
        UnitPicker.SelectedItem = "botol";
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory-details");
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-inventory-details");
    }
}
