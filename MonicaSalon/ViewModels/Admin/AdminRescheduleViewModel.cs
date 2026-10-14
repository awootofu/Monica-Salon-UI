using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class AdminRescheduleViewModel : BaseViewModel
{
    public DateTime MinDate { get; } = new(2026, 10, 12);
    public DateTime MaxDate { get; } = new(2026, 12, 31);

    private DateTime _selectedDate = new(2026, 10, 15);
    public DateTime SelectedDate
    {
        get => _selectedDate;
        private set
        {
            if (SetProperty(ref _selectedDate, value))
                OnPropertyChanged(nameof(SelectedDateText));
        }
    }

    public string SelectedDateText =>
        _selectedDate.ToString("dddd, d MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));

    private string _selectedTime = string.Empty;
    public string SelectedTime
    {
        get => _selectedTime;
        private set => SetProperty(ref _selectedTime, value ?? string.Empty);
    }

    private string _conflictText = "Pilih tanggal dan jam baru.";
    public string ConflictText
    {
        get => _conflictText;
        private set => SetProperty(ref _conflictText, value);
    }

    private bool _isConflict;
    public bool IsConflict
    {
        get => _isConflict;
        private set => SetProperty(ref _isConflict, value);
    }

    private bool _isReady;
    public bool IsReady
    {
        get => _isReady;
        private set => SetProperty(ref _isReady, value);
    }

    private bool _canSave = true;
    public bool CanSave
    {
        get => _canSave;
        private set => SetProperty(ref _canSave, value);
    }

    private bool _isSaved;
    public bool IsSaved
    {
        get => _isSaved;
        private set => SetProperty(ref _isSaved, value);
    }

    public AdminRescheduleViewModel() => UpdateState();

    public void SelectDate(DateTime date)
    {
        SelectedDate = date.Date;
        UpdateState();
    }

    // Kompatibilitas lama (tombol tanggal "15 Kam", ...).
    public void SelectDate(string? buttonText)
    {
        var day = new string((buttonText ?? string.Empty).TakeWhile(char.IsDigit).ToArray());
        if (int.TryParse(day, out var d))
        {
            try { SelectDate(new DateTime(SelectedDate.Year, SelectedDate.Month, d)); return; }
            catch (ArgumentOutOfRangeException) { }
        }
        UpdateState();
    }

    public void SelectTime(string? buttonText)
    {
        SelectedTime = buttonText ?? string.Empty;
        UpdateState();
    }

    public void Save() => IsSaved = true;

    private void UpdateState()
    {
        if (_selectedTime == "10.00")
        {
            ConflictText = "Jadwal bentrok, pilih jam lain.";
            IsConflict = true;
            IsReady = false;
            CanSave = false;
        }
        else if (!string.IsNullOrEmpty(_selectedTime))
        {
            ConflictText = $"Slot tersedia: {SelectedDateText} • {_selectedTime} WIB.";
            IsConflict = false;
            IsReady = true;
            CanSave = true;
        }
        else
        {
            ConflictText = "Pilih tanggal dan jam baru.";
            IsConflict = false;
            IsReady = false;
            CanSave = true;
        }
    }
}
