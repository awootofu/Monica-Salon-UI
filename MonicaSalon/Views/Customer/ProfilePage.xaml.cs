namespace MonicaSalon.Views.Customer;
public partial class ProfilePage : ContentPage
{
    private bool _editing;

    public ProfilePage() => InitializeComponent();

    private async void OnEdit(object sender, EventArgs e)
    {
        _editing = !_editing;
        NameEntry.IsEnabled = _editing;
        PhoneEntry.IsEnabled = _editing;
        EmailEntry.IsEnabled = _editing;
        EditButton.Text = _editing ? "Simpan" : "Edit";
        await Task.CompletedTask;
    }

    private async void OnHistoryShortcut(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("history");
    }

    private async void OnSettingsShortcut(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("settings");
    }

    private async void OnLogout(object sender, EventArgs e)
    {
        LogoutConfirm.IsVisible = true;
        await Task.CompletedTask;
    }

    private async void OnConfirmLogout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("login");
    }

    private async void OnStay(object sender, EventArgs e)
    {
        LogoutConfirm.IsVisible = false;
        await Task.CompletedTask;
    }

    private async void OnHome(object sender, EventArgs e) => await Shell.Current.GoToAsync("home");
    private async void OnCatalogue(object sender, EventArgs e) => await Shell.Current.GoToAsync("catalogue");
    private async void OnBooking(object sender, EventArgs e) => await Shell.Current.GoToAsync("schedule");
    private async void OnHistory(object sender, EventArgs e) => await Shell.Current.GoToAsync("history");
    private async void OnProfile(object sender, EventArgs e) => await Shell.Current.GoToAsync("profile");
}
