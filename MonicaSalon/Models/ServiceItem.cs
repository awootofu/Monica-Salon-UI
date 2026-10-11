namespace MonicaSalon.Models;
public class ServiceItem
{
    public string Name { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public int PriceValue { get; set; }
    public string Duration { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = "welcome.jpg";
}
