namespace MonicaSalon.Views.Customer;
public partial class WelcomePage : ContentPage
{
    public WelcomePage() => InitializeComponent();

    private async void OnGetStarted(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("register");
    }

    private async void OnLogin(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("login");
    }
}
