namespace MonicaSalon.Views.Customer;
public partial class SettingsPage : ContentPage
{
    public SettingsPage() => InitializeComponent();

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("profile");
    }

    private async void OnDeletePhoto(object sender, EventArgs e)
    {
        PhotoStatusLabel.Text = "Photo Deleted";
        DeletePhotoButton.IsEnabled = false;
        await Task.CompletedTask;
    }

    private async void OnStub(object sender, EventArgs e)
    {
        await Task.CompletedTask;
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
}
