using MonicaSalon.Services;
namespace MonicaSalon.ViewModels;
public class LoginViewModel : BaseViewModel
{
    private string _email = string.Empty;
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value ?? string.Empty);
    }

    private string _password = string.Empty;
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value ?? string.Empty);
    }

    private string _errorMessage = string.Empty;
    public string ErrorMessage
    {
        get => _errorMessage;
        private set => SetProperty(ref _errorMessage, value);
    }

    private bool _hasError;
    public bool HasError
    {
        get => _hasError;
        private set => SetProperty(ref _hasError, value);
    }

    private string? Fail(string msg)
    {
        ErrorMessage = msg;
        HasError = true;
        return null;
    }

    /// <returns>Route tujuan, atau null bila validasi gagal.</returns>
    public string? TryLogin()
    {
        var email = Email.Trim();
        if (string.IsNullOrWhiteSpace(email))
            return Fail("Email wajib diisi.");
        if (Password.Length < 6)
            return Fail("Password minimal 6 karakter.");
        if (DemoAccounts.IsOwner(email))
        {
            ErrorMessage = string.Empty;
            HasError = false;
            return "admin-dashboard";
        }
        if (!DemoAccounts.IsCustomer(email))
            return Fail("Akun tidak dikenal. Gunakan customer@email.com.");
        ErrorMessage = string.Empty;
        HasError = false;
        return "home";
    }

    public void ForgotPassword() => Fail("Tautan reset password telah dikirim (demo).");
}
