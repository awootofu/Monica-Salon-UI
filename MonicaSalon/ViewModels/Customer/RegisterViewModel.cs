using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class RegisterViewModel : BaseViewModel
{
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value ?? string.Empty);
    }

    private string _phone = string.Empty;
    public string Phone
    {
        get => _phone;
        set => SetProperty(ref _phone, value ?? string.Empty);
    }

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

    private string _confirm = string.Empty;
    public string Confirm
    {
        get => _confirm;
        set => SetProperty(ref _confirm, value ?? string.Empty);
    }

    private bool _acceptedTerms;
    public bool AcceptedTerms
    {
        get => _acceptedTerms;
        set => SetProperty(ref _acceptedTerms, value);
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
    public string? TryRegister()
    {
        var name = Name.Trim();
        var phone = Phone.Trim();
        var email = Email.Trim();
        var pass = Password;
        var confirm = Confirm;

        if (string.IsNullOrWhiteSpace(name))
            return Fail("Nama wajib diisi.");
        if (string.IsNullOrWhiteSpace(phone))
            return Fail("Nomor HP wajib diisi.");
        if (!email.Contains("@"))
            return Fail("Email tidak valid.");
        if (pass.Length < 6)
            return Fail("Password minimal 6 karakter.");
        if (pass != confirm)
            return Fail("Konfirmasi password tidak cocok.");
        if (!AcceptedTerms)
            return Fail("Centang persetujuan syarat & ketentuan.");
        ErrorMessage = string.Empty;
        HasError = false;
        return "home";
    }
}
