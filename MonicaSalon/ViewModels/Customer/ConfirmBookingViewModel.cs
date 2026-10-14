using MonicaSalon.Models;
using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class ConfirmBookingViewModel : BaseViewModel
{
    private List<ServiceItem> _services = new();
    public List<ServiceItem> Services
    {
        get => _services;
        private set => SetProperty(ref _services, value);
    }

    private string _servicesSummary = string.Empty;
    public string ServicesSummary
    {
        get => _servicesSummary;
        private set => SetProperty(ref _servicesSummary, value);
    }

    private string _servicesCountText = string.Empty;
    public string ServicesCountText
    {
        get => _servicesCountText;
        private set => SetProperty(ref _servicesCountText, value);
    }

    private string _servicesTotalText = string.Empty;
    public string ServicesTotalText
    {
        get => _servicesTotalText;
        private set => SetProperty(ref _servicesTotalText, value);
    }

    private string _bookingDateText = string.Empty;
    public string BookingDateText
    {
        get => _bookingDateText;
        private set => SetProperty(ref _bookingDateText, value);
    }

    private string _bookingTimeText = string.Empty;
    public string BookingTimeText
    {
        get => _bookingTimeText;
        private set => SetProperty(ref _bookingTimeText, value);
    }

    private string _hairstyleName = "Tanpa referensi gaya";
    public string HairstyleName
    {
        get => _hairstyleName;
        private set => SetProperty(ref _hairstyleName, value);
    }

    private string _hairstyleNote = "Konsultasikan langsung dengan stylist.";
    public string HairstyleNote
    {
        get => _hairstyleNote;
        private set => SetProperty(ref _hairstyleNote, value);
    }

    private string _hairstyleImage = "haircut.jpg";
    public string HairstyleImage
    {
        get => _hairstyleImage;
        private set => SetProperty(ref _hairstyleImage, value);
    }

    private bool _hasHairstyle;
    public bool HasHairstyle
    {
        get => _hasHairstyle;
        private set => SetProperty(ref _hasHairstyle, value);
    }

    public void Refresh()
    {
        Services = BookingContext.SelectedServices.ToList();
        ServicesSummary = BookingContext.ServicesSummary;
        ServicesCountText = BookingContext.ServicesCountText;
        ServicesTotalText = BookingContext.ServicesTotalText;
        BookingDateText = BookingContext.SelectedDateLong;
        BookingTimeText = string.IsNullOrEmpty(BookingContext.SelectedTime)
            ? "Belum pilih jam"
            : $"{BookingContext.SelectedTime} WIB";

        var h = BookingContext.SelectedHairstyle;
        if (h == null)
        {
            HairstyleName = "Tanpa referensi gaya";
            HairstyleNote = "Konsultasikan langsung dengan stylist.";
            HasHairstyle = false;
        }
        else
        {
            HairstyleName = $"{h.Name} • {h.Category}";
            HairstyleNote = $"Cocok: {h.FaceShape} • Tunjukkan ke stylist.";
            HairstyleImage = h.Image;
            HasHairstyle = true;
        }
    }
}
