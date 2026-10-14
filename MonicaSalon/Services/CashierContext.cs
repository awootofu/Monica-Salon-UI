namespace MonicaSalon.Services;
public static class CashierContext
{
    public static Dictionary<string, int> Cart { get; set; } = new();
    public static string BookingRef { get; set; } = "MON-261014-028";
    public static string CustomerName { get; set; } = "Bella Anisa";
    public static string BookingWhen { get; set; } = "14 Okt 11.00";
}
