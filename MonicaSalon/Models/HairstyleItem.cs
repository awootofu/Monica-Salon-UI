namespace MonicaSalon.Models;
public class HairstyleItem
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Length { get; set; } = string.Empty;
    public string FaceShape { get; set; } = string.Empty;
    public string Maintenance { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = "haircut.jpg";
    public string DurationHint { get; set; } = string.Empty;
    public string PriceHint { get; set; } = string.Empty;
    public string SuitableNote => $"Cocok: {FaceShape}";
}
