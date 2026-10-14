using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class BookingSuccessViewModel : BaseViewModel
{
    private string _servicesSummary = string.Empty;
    public string ServicesSummary
    {
        get => _servicesSummary;
        private set => SetProperty(ref _servicesSummary, value);
    }

    private string _bookingWhenText = string.Empty;
    public string BookingWhenText
    {
        get => _bookingWhenText;
        private set => SetProperty(ref _bookingWhenText, value);
    }

    private string _servicesTotalText = string.Empty;
    public string ServicesTotalText
    {
        get => _servicesTotalText;
        private set => SetProperty(ref _servicesTotalText, value);
    }

    private string _hairstyleRefText = "Referensi gaya: -";
    public string HairstyleRefText
    {
        get => _hairstyleRefText;
        private set => SetProperty(ref _hairstyleRefText, value);
    }

    public void Refresh()
    {
        ServicesSummary = BookingContext.ServicesSummary;
        ServicesTotalText = BookingContext.ServicesTotalText;
        BookingWhenText = string.IsNullOrEmpty(BookingContext.SelectedTime)
            ? BookingContext.SelectedDateShort
            : $"{BookingContext.SelectedDateShort} • {BookingContext.SelectedTime} WIB";
        var h = BookingContext.SelectedHairstyle;
        HairstyleRefText = h == null
            ? "Referensi gaya: tanpa referensi"
            : $"Referensi gaya: {h.Name} • {h.Category}";
    }
}
