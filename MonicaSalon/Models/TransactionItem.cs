namespace MonicaSalon.Models;
public class TransactionItem
{
    public string Ref { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Customer { get; set; } = string.Empty;
    public string Items { get; set; } = string.Empty;
    public string Total { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public string Status { get; set; } = "Paid";
}
