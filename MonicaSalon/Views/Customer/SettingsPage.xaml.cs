using MonicaSalon.ViewModels.Customer;
namespace MonicaSalon.Views.Customer;
public partial class SettingsPage : ContentPage
{
    private readonly SettingsViewModel _vm = new();

    public SettingsPage()
    {
        InitializeComponent();
        BindingContext = _vm;
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("profile");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.Refresh();
    }

    private async void OnBrowseStyles(object sender, EventArgs e)
    {
        Services.BookingContext.HairstyleReturnTo = "settings";
        await Shell.Current.GoToAsync("hairstyle-book");
    }

    private async void OnStub(object sender, EventArgs e)
    {
        await Task.CompletedTask;
    }

    private void OnLogout(object sender, EventArgs e) => _vm.ShowLogout();

    private async void OnConfirmLogout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("login");
    }

    private void OnStay(object sender, EventArgs e) => _vm.HideLogout();
}
