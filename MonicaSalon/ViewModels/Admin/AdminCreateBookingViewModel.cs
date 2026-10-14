using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class AdminCreateBookingViewModel : BaseViewModel
{
    private string _customer = "Siti Anisa";
    public string Customer
    {
        get => _customer;
        private set => SetProperty(ref _customer, value ?? "Siti Anisa");
    }

    private string _service = "Potong Rambut";
    public string Service
    {
        get => _service;
        private set => SetProperty(ref _service, value ?? "Potong Rambut");
    }

    private string _price = "Rp 50.000";
    public string Price
    {
        get => _price;
        private set => SetProperty(ref _price, value ?? "Rp 50.000");
    }

    private string _slot = "09.00";
    public string Slot
    {
        get => _slot;
        private set => SetProperty(ref _slot, value ?? "09.00");
    }

    private string? _selectedCustomer;
    public string? SelectedCustomer
    {
        get => _selectedCustomer;
        private set => SetProperty(ref _selectedCustomer, value);
    }

    private string? _selectedServiceKey;
    public string? SelectedServiceKey
    {
        get => _selectedServiceKey;
        private set => SetProperty(ref _selectedServiceKey, value);
    }

    private string? _selectedSlot;
    public string? SelectedSlot
    {
        get => _selectedSlot;
        private set => SetProperty(ref _selectedSlot, value);
    }

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
                OnPropertyChanged(nameof(SelectedDateText));
                Refresh();
            }
        }
    }

    public string SelectedDateText =>
        _selectedDate.ToString("dddd, d MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));

    private string _newName = string.Empty;
    public string NewName
    {
        get => _newName;
        set => SetProperty(ref _newName, value ?? string.Empty);
    }

    private string _newPhone = string.Empty;
    public string NewPhone
    {
        get => _newPhone;
        set => SetProperty(ref _newPhone, value ?? string.Empty);
    }

    private string _notes = string.Empty;
    public string Notes
    {
        get => _notes;
        set => SetProperty(ref _notes, value ?? string.Empty);
    }

    private string _summaryText = string.Empty;
    public string SummaryText
    {
        get => _summaryText;
        private set => SetProperty(ref _summaryText, value);
    }

    private bool _isNewCustomer;
    public bool IsNewCustomer
    {
        get => _isNewCustomer;
        private set => SetProperty(ref _isNewCustomer, value);
    }

    public AdminCreateBookingViewModel() => Refresh();

    public void SelectCustomer(string? buttonText)
    {
        Customer = buttonText ?? "Siti Anisa";
        SelectedCustomer = buttonText;
        Refresh();
    }

    public void SelectService(string? key)
    {
        if (key == "cream") { Service = "Creambath"; Price = "Rp 80.000"; }
        else if (key == "color") { Service = "Pewarnaan Rambut"; Price = "Rp 200.000"; }
        else { Service = "Potong Rambut"; Price = "Rp 50.000"; }
        SelectedServiceKey = key;
        Refresh();
    }

    public void SelectSlot(string? buttonText)
    {
        Slot = buttonText ?? string.Empty;
        SelectedSlot = buttonText;
        Refresh();
    }

    public void SelectDate(DateTime date)
    {
        SelectedDate = date.Date;
    }

    private void Refresh()
    {
        SummaryText = $"{_customer} • {_service} {_price} • {_selectedDate.ToString("d MMM", new System.Globalization.CultureInfo("id-ID"))} {_slot}";
        IsNewCustomer = _customer == "Pelanggan baru";
    }
}
