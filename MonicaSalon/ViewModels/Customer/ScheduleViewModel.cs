using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class ScheduleViewModel : BaseViewModel
{
    private string _selectedDate = string.Empty;
    private string _selectedTime = string.Empty;

    private string _summary = "Pilih tanggal dan jam dahulu.";
    public string Summary
    {
        get => _summary;
        private set => SetProperty(ref _summary, value);
    }

    private string _hairstyleText = "Belum ada gaya dipilih.";
    public string HairstyleText
    {
        get => _hairstyleText;
        private set => SetProperty(ref _hairstyleText, value);
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

    public void SelectDate(string date)
    {
        _selectedDate = date;
        UpdateSummary();
    }

    public void SelectTime(string time)
    {
        _selectedTime = time;
        UpdateSummary();
    }

    public void Refresh()
    {
        RefreshHairstyle();
        UpdateSummary();
    }

    public void ClearHairstyle()
    {
        BookingContext.ClearHairstyle();
        RefreshHairstyle();
    }

    public void RefreshHairstyle()
    {
        var h = BookingContext.SelectedHairstyle;
        if (h == null)
        {
            HairstyleText = "Belum ada gaya dipilih.";
            HasHairstyle = false;
        }
        else
        {
            HairstyleText = $"{h.Name} • {h.Category}";
            HairstyleImage = h.Image;
            HasHairstyle = true;
        }
    }

    private void UpdateSummary()
    {
        Summary = !string.IsNullOrEmpty(_selectedDate) && !string.IsNullOrEmpty(_selectedTime)
            ? $"Dipilih: {_selectedDate} Oktober 2026 • {_selectedTime} WIB • Pewarnaan Rambut Rp 200.000"
            : "Pilih tanggal dan jam dahulu.";
    }
}
