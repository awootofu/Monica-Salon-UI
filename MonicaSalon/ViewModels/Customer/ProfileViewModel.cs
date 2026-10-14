using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class ProfileViewModel : BaseViewModel
{
    private string _name = "Bella Anisa";
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value ?? string.Empty);
    }

    private string _phone = "+62 812-3456-7890";
    public string Phone
    {
        get => _phone;
        set => SetProperty(ref _phone, value ?? string.Empty);
    }

    private string _email = "bella@example.com";
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value ?? string.Empty);
    }

    private bool _isEditing;
    public bool IsEditing
    {
        get => _isEditing;
        private set
        {
            if (SetProperty(ref _isEditing, value))
                OnPropertyChanged(nameof(EditButtonText));
        }
    }

    public string EditButtonText => IsEditing ? "Simpan" : "Edit";

    private bool _isLogoutVisible;
    public bool IsLogoutVisible
    {
        get => _isLogoutVisible;
        private set => SetProperty(ref _isLogoutVisible, value);
    }

    public void ToggleEdit() => IsEditing = !IsEditing;

    public void ShowLogout() => IsLogoutVisible = true;

    public void HideLogout() => IsLogoutVisible = false;
}
