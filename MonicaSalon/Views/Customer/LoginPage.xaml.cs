namespace MonicaSalon.Views.Customer;
public partial class LoginPage : ContentPage
{
    public LoginPage() => InitializeComponent();

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//welcome");
    }

    private async void OnLogin(object sender, EventArgs e)
    {
        var email = EmailEntry.Text?.Trim() ?? string.Empty;
        var pass = PasswordEntry.Text ?? string.Empty;
        if (string.IsNullOrWhiteSpace(email))
        {
            ShowError("Email / no. HP wajib diisi.");
            return;
        }
        if (pass.Length < 6)
        {
            ShowError("Password minimal 6 karakter.");
            return;
        }
        ErrorLabel.IsVisible = false;
        await Shell.Current.GoToAsync("//home");
    }

    private void OnForgot(object sender, EventArgs e)
    {
        ShowError("Tautan reset password telah dikirim (demo).");
    }

    private async void OnGoRegister(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//register");
    }

    private void ShowError(string msg)
    {
        ErrorLabel.Text = msg;
        ErrorLabel.IsVisible = true;
    }
}
