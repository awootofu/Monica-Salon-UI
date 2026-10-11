namespace MonicaSalon.Models;
public class InventoryItem
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public double Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public double Minimum { get; set; }
    public string Kind { get; set; } = "retail";
    public bool IsLow => Quantity <= Minimum;
}
