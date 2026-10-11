namespace MonicaSalon.Views.Shared;
public partial class RoleSelectPage : ContentPage
{
    private bool _isCustomer = true;

    public RoleSelectPage()
    {
        InitializeComponent();
    }

    private void OnSelectCustomer(object sender, EventArgs e)
    {
        _isCustomer = true;
        CustomerCard.Stroke = (Color)Application.Current!.Resources["DustyRose"];
        OwnerCard.Stroke = Color.FromArgb("#E7DDD6");
    }

    private void OnSelectOwner(object sender, EventArgs e)
    {
        _isCustomer = false;
        OwnerCard.Stroke = (Color)Application.Current!.Resources["DustyRose"];
        CustomerCard.Stroke = Color.FromArgb("#E7DDD6");
    }

    private async void OnContinue(object sender, EventArgs e)
    {
        if (_isCustomer)
            await Shell.Current.GoToAsync("welcome");
        else
            await Shell.Current.GoToAsync("admin-login");
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("cover");
    }
}
