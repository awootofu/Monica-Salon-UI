using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class BookingSuccessViewModel : BaseViewModel
{
    private string _hairstyleRefText = "Referensi gaya: -";
    public string HairstyleRefText
    {
        get => _hairstyleRefText;
        private set => SetProperty(ref _hairstyleRefText, value);
    }

    public void Refresh()
    {
        var h = BookingContext.SelectedHairstyle;
        HairstyleRefText = h == null
            ? "Referensi gaya: tanpa referensi"
            : $"Referensi gaya: {h.Name} • {h.Category}";
    }
}
