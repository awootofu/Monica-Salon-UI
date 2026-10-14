using MonicaSalon.ViewModels;
namespace MonicaSalon.Views.Customer;
public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel _vm = new();

    public LoginPage()
    {
        InitializeComponent();
        BindingContext = _vm;
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("welcome");
    }

    private async void OnLogin(object sender, EventArgs e)
    {
        var route = _vm.TryLogin();
        if (route != null)
            await Shell.Current.GoToAsync(route);
    }

    private void OnForgot(object sender, EventArgs e) => _vm.ForgotPassword();

    private async void OnGoRegister(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("register");
    }
}
