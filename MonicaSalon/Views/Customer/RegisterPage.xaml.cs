namespace MonicaSalon.Views.Customer;
public partial class RegisterPage : ContentPage
{
    public RegisterPage() => InitializeComponent();

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//welcome");
    }

    private async void OnRegister(object sender, EventArgs e)
    {
        var name = NameEntry.Text?.Trim() ?? string.Empty;
        var phone = PhoneEntry.Text?.Trim() ?? string.Empty;
        var email = EmailEntry.Text?.Trim() ?? string.Empty;
        var pass = PasswordEntry.Text ?? string.Empty;
        var confirm = ConfirmEntry.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(name))
        {
            ShowError("Nama wajib diisi.");
            return;
        }
        if (string.IsNullOrWhiteSpace(phone))
        {
            ShowError("Nomor HP wajib diisi.");
            return;
        }
        if (!email.Contains("@"))
        {
            ShowError("Email tidak valid.");
            return;
        }
        if (pass.Length < 6)
        {
            ShowError("Password minimal 6 karakter.");
            return;
        }
        if (pass != confirm)
        {
            ShowError("Konfirmasi password tidak cocok.");
            return;
        }
        if (!TermsCheck.IsChecked)
        {
            ShowError("Centang persetujuan syarat & ketentuan.");
            return;
        }
        ErrorLabel.IsVisible = false;
        await Shell.Current.GoToAsync("//home");
    }

    private async void OnGoLogin(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//login");
    }

    private void ShowError(string msg)
    {
        ErrorLabel.Text = msg;
        ErrorLabel.IsVisible = true;
    }
}
