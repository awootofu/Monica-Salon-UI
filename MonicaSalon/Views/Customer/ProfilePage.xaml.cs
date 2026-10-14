using MonicaSalon.ViewModels.Customer;
namespace MonicaSalon.Views.Customer;
public partial class ProfilePage : ContentPage
{
    private readonly ProfileViewModel _vm = new();

    public ProfilePage()
    {
        InitializeComponent();
        BindingContext = _vm;
    }

    private void OnEdit(object sender, EventArgs e) => _vm.ToggleEdit();

    private async void OnHistoryShortcut(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("history");
    }

    private async void OnSettingsShortcut(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("settings");
    }

    private void OnLogout(object sender, EventArgs e) => _vm.ShowLogout();

    private async void OnConfirmLogout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("login");
    }

    private void OnStay(object sender, EventArgs e) => _vm.HideLogout();

    private async void OnHome(object sender, EventArgs e) => await Shell.Current.GoToAsync("home");
    private async void OnCatalogue(object sender, EventArgs e) => await Shell.Current.GoToAsync("catalogue");
    private async void OnBooking(object sender, EventArgs e) => await Shell.Current.GoToAsync("schedule");
    private async void OnHistory(object sender, EventArgs e) => await Shell.Current.GoToAsync("history");
    private async void OnProfile(object sender, EventArgs e) => await Shell.Current.GoToAsync("profile");
}
