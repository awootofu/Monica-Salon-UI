namespace MonicaSalon.Models;
public class FinancialRecord
{
    public string Id { get; set; } = string.Empty;
    public string Type { get; set; } = "income";
    public string Date { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    public string Source { get; set; } = "manual";
}
