using System.Globalization;
using MonicaSalon.Models;
namespace MonicaSalon.Services;
public static class BookingContext
{
    private static readonly CultureInfo Id = new("id-ID");

    static BookingContext()
    {
        _selectedServices = MockDataService.Services
            .Where(s => s.Name == "Pewarnaan Rambut").ToList();
    }

    public static HairstyleItem? SelectedHairstyle { get; set; }
    public static string HairstyleReturnTo { get; set; } = "home";
    public static string SelectedHairstyleName => SelectedHairstyle?.Name ?? string.Empty;
    public static bool HasHairstyle => SelectedHairstyle != null;
    public static void ClearHairstyle() => SelectedHairstyle = null;

    // Multi-service booking state.
    private static List<ServiceItem> _selectedServices;
    public static IReadOnlyList<ServiceItem> SelectedServices => _selectedServices.AsReadOnly();

    public static void SetServices(IEnumerable<ServiceItem> services) =>
        _selectedServices = services.ToList();

    public static void EnsureService(ServiceItem service)
    {
        if (!_selectedServices.Any(s => s.Name == service.Name))
            _selectedServices.Add(service);
    }

    public static void ClearServices() => _selectedServices.Clear();

    public static string ServicesSummary => _selectedServices.Count == 0
        ? "Belum ada layanan dipilih"
        : string.Join(" + ", _selectedServices.Select(s => s.Name));

    public static string ServicesCountText => _selectedServices.Count switch
    {
        0 => "Belum ada layanan",
        1 => "1 layanan dipilih",
        _ => $"{_selectedServices.Count} layanan dipilih"
    };

    public static int ServicesTotal => _selectedServices.Sum(s => s.PriceValue);
    public static string ServicesTotalText => MockDataService.FormatRupiah(ServicesTotal);

    // Jadwal booking state.
    private static DateTime _selectedDate = new(2026, 10, 14);
    public static DateTime SelectedDate
    {
        get => _selectedDate;
        set => _selectedDate = value.Date;
    }

    public static string SelectedTime { get; set; } = string.Empty;

    public static string SelectedDateLong => _selectedDate.ToString("dddd, d MMMM yyyy", Id);
    public static string SelectedDateShort => _selectedDate.ToString("d MMM yyyy", Id);
}
