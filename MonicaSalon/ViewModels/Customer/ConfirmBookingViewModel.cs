using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class ConfirmBookingViewModel : BaseViewModel
{
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
