using System.Collections.ObjectModel;
using System.Globalization;
using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class ScheduleViewModel : BaseViewModel
{
    private static readonly CultureInfo Id = new("id-ID");

    public DateTime MinDate { get; } = new(2026, 10, 12);
    public DateTime MaxDate { get; } = new(2026, 12, 31);

    private DateTime _selectedDate = new(2026, 10, 14);
    public DateTime SelectedDate
    {
        get => _selectedDate;
        set
        {
            if (SetProperty(ref _selectedDate, value))
            {
                BookingContext.SelectedDate = value;
                OnPropertyChanged(nameof(MonthLabel));
                OnPropertyChanged(nameof(SelectedDateText));
                UpdateSummary();
            }
        }
    }

    public string MonthLabel => SelectedDate.ToString("MMMM yyyy", Id);
    public string SelectedDateText => SelectedDate.ToString("dddd, d MMMM yyyy", Id);

    private string _selectedTime = string.Empty;

    private string _summary = "Pilih tanggal dan jam dahulu.";
    public string Summary
    {
        get => _summary;
        private set => SetProperty(ref _summary, value);
    }

    public ObservableCollection<ServiceOption> ServiceOptions { get; } = new();

    private string _servicesTotalText = string.Empty;
    public string ServicesTotalText
    {
        get => _servicesTotalText;
        private set => SetProperty(ref _servicesTotalText, value);
    }

    private string _servicesCountText = string.Empty;
    public string ServicesCountText
    {
        get => _servicesCountText;
        private set => SetProperty(ref _servicesCountText, value);
    }

    public bool HasServices => ServiceOptions.Any(o => o.IsSelected);

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

    public ScheduleViewModel()
    {
        foreach (var s in MockDataService.Services)
        {
            var option = new ServiceOption(s, BookingContext.SelectedServices.Any(x => x.Name == s.Name));
            option.PropertyChanged += OnServiceOptionChanged;
            ServiceOptions.Add(option);
        }
        _selectedDate = BookingContext.SelectedDate;
        _selectedTime = BookingContext.SelectedTime;
        UpdateServiceTotals();
        UpdateSummary();
    }

    private void OnServiceOptionChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(ServiceOption.IsSelected))
            return;
        BookingContext.SetServices(ServiceOptions.Where(o => o.IsSelected).Select(o => o.Service));
        UpdateServiceTotals();
        UpdateSummary();
    }

    public void SelectDate(DateTime date)
    {
        SelectedDate = date.Date;
    }

    // Kompatibilitas lama (tombol tanggal "14", "15", ...).
    public void SelectDate(string date)
    {
        if (int.TryParse(date.Trim(), out var day))
        {
            try { SelectedDate = new DateTime(SelectedDate.Year, SelectedDate.Month, day); return; }
            catch (ArgumentOutOfRangeException) { }
        }
        UpdateSummary();
    }

    public void SelectTime(string time)
    {
        _selectedTime = time;
        BookingContext.SelectedTime = time;
        UpdateSummary();
    }

    public void Refresh()
    {
        foreach (var o in ServiceOptions)
            o.IsSelected = BookingContext.SelectedServices.Any(x => x.Name == o.Service.Name);
        RefreshHairstyle();
        UpdateServiceTotals();
        UpdateSummary();
        OnPropertyChanged(nameof(MonthLabel));
        OnPropertyChanged(nameof(SelectedDateText));
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

    private void UpdateServiceTotals()
    {
        ServicesTotalText = BookingContext.ServicesTotalText;
        ServicesCountText = BookingContext.ServicesCountText;
        OnPropertyChanged(nameof(HasServices));
    }

    private void UpdateSummary()
    {
        if (!HasServices)
            Summary = "Pilih minimal 1 layanan dahulu.";
        else if (string.IsNullOrEmpty(_selectedTime))
            Summary = $"{BookingContext.ServicesSummary} ({BookingContext.ServicesTotalText}) • {SelectedDateText} • pilih jam dahulu.";
        else
            Summary = $"Dipilih: {BookingContext.ServicesSummary} • {SelectedDateText} • {_selectedTime} WIB • {BookingContext.ServicesTotalText}";
    }
}
