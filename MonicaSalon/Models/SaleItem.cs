namespace MonicaSalon.Models;
public class SaleItem
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Type { get; set; } = "service";
    public string Meta { get; set; } = string.Empty;
}
