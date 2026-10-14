using MonicaSalon.Models;
namespace MonicaSalon.Services;
public static class BookingContext
{
    public static HairstyleItem? SelectedHairstyle { get; set; }
    public static string HairstyleReturnTo { get; set; } = "home";
    public static string SelectedHairstyleName => SelectedHairstyle?.Name ?? string.Empty;
    public static bool HasHairstyle => SelectedHairstyle != null;
    public static void ClearHairstyle() => SelectedHairstyle = null;
}
