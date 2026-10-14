using MonicaSalon.ViewModels.Customer;
namespace MonicaSalon.Views.Customer;
public partial class RegisterPage : ContentPage
{
    private readonly RegisterViewModel _vm = new();

    public RegisterPage()
    {
        InitializeComponent();
        BindingContext = _vm;
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("welcome");
    }

    private async void OnRegister(object sender, EventArgs e)
    {
        var route = _vm.TryRegister();
        if (route != null)
            await Shell.Current.GoToAsync(route);
    }

    private async void OnGoLogin(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("login");
    }
}
