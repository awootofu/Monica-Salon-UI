using MonicaSalon.Models;
using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class AdminBookingsPageViewModel : BaseViewModel
{
    public List<string> Statuses { get; } = new()
        { "Semua", "Menunggu Konfirmasi", "Dikonfirmasi", "Selesai", "Dibatalkan" };

    private string _selectedStatus = "Semua";
    public string SelectedStatus
    {
        get => _selectedStatus;
        set
        {
            if (SetProperty(ref _selectedStatus, value ?? "Semua"))
                ApplyFilter();
        }
    }

    private string _query = string.Empty;
    public string Query
    {
        get => _query;
        set
        {
            if (SetProperty(ref _query, value ?? string.Empty))
                ApplyFilter();
        }
    }

    private List<BookingItem> _bookings = new();
    public List<BookingItem> Bookings
    {
        get => _bookings;
        private set => SetProperty(ref _bookings, value);
    }

    public AdminBookingsPageViewModel() => ApplyFilter();

    private void ApplyFilter()
    {
        var list = MockDataService.AdminBookings.AsEnumerable();
        if (_selectedStatus != "Semua")
            list = list.Where(x => x.Status == _selectedStatus);
        if (!string.IsNullOrWhiteSpace(_query))
        {
            var q = _query.ToLowerInvariant();
            list = list.Where(x => x.Customer.ToLowerInvariant().Contains(q)
                || x.Ref.ToLowerInvariant().Contains(q)
                || x.Service.ToLowerInvariant().Contains(q));
        }
        Bookings = list.ToList();
    }
}
