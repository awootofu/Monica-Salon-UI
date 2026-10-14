using MonicaSalon.Models;
using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class BookingHistoryViewModel : BaseViewModel
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

    private List<BookingItem> _bookings = new();
    public List<BookingItem> Bookings
    {
        get => _bookings;
        private set => SetProperty(ref _bookings, value);
    }

    public BookingHistoryViewModel() => ApplyFilter();

    public void Refresh() => ApplyFilter();

    private void ApplyFilter()
    {
        Bookings = _selectedStatus == "Semua"
            ? MockDataService.BookingHistory.ToList()
            : MockDataService.BookingHistory.Where(x => x.Status == _selectedStatus).ToList();
    }
}
