namespace MonicaSalon.Views.Admin;
public partial class ProductFormPage : ContentPage
{
    public ProductFormPage() => InitializeComponent();
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-products");
    private async void OnCategory(object sender, EventArgs e)
    {
        var b = (Button)sender;
        foreach (var child in ((Grid)b.Parent).Children)
            if (child is Button btn)
                btn.Style = btn == b ? (Style)Application.Current.Resources["PrimaryButton"] : (Style)Application.Current.Resources["SecondaryButton"];
        await Task.CompletedTask;
    }
    private async void OnLinkOption(object sender, EventArgs e)
    {
        var b = (Button)sender;
        foreach (var child in ((Grid)b.Parent).Children)
            if (child is Button btn)
                btn.Style = btn == b ? (Style)Application.Current.Resources["PrimaryButton"] : (Style)Application.Current.Resources["SecondaryButton"];
        await Task.CompletedTask;
    }
    private async void OnSave(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-products");
}
