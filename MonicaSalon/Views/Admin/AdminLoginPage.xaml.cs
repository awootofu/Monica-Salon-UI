namespace MonicaSalon.Views.Admin;
public partial class AdminLoginPage : ContentPage
{
    public AdminLoginPage() => InitializeComponent();

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//roles");
    }

    private async void OnLogin(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text?.Trim() ?? string.Empty;
        var pass = PasswordEntry.Text ?? string.Empty;
        if (string.IsNullOrWhiteSpace(username))
        {
            ShowError("Username wajib diisi.");
            return;
        }
        if (pass.Length < 6)
        {
            ShowError("Password minimal 6 karakter.");
            return;
        }
        ErrorLabel.IsVisible = false;
        await Shell.Current.GoToAsync("//admin-dashboard");
    }

    private void ShowError(string msg)
    {
        ErrorLabel.Text = msg;
        ErrorLabel.IsVisible = true;
    }
}
