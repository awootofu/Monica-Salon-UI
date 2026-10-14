using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class SettingsViewModel : BaseViewModel
{
    private string _hairstyleStatusText = "Belum ada gaya favorit dipilih.";
    public string HairstyleStatusText
    {
        get => _hairstyleStatusText;
        private set => SetProperty(ref _hairstyleStatusText, value);
    }

    private bool _isLogoutVisible;
    public bool IsLogoutVisible
    {
        get => _isLogoutVisible;
        private set => SetProperty(ref _isLogoutVisible, value);
    }

    public void Refresh()
    {
        var h = BookingContext.SelectedHairstyle;
        HairstyleStatusText = h == null
            ? "Belum ada gaya favorit dipilih."
            : $"Favorit: {h.Name} • {h.Category}";
    }

    public void ShowLogout() => IsLogoutVisible = true;

    public void HideLogout() => IsLogoutVisible = false;
}
