namespace MonicaSalon.Models;
public class BookingItem
{
    public string Ref { get; set; } = string.Empty;
    public string Service { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Image { get; set; } = "color.jpg";
    public string Customer { get; set; } = string.Empty;
}
