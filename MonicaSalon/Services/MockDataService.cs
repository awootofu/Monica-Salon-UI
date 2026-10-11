using MonicaSalon.Models;
namespace MonicaSalon.Services;
public static class MockDataService
{
    public static List<ServiceItem> Services { get; } = new()
    {
        new() { Name="Potong Rambut", Price="Rp 50.000", PriceValue=50000, Duration="45 menit", Category="Haircut", Image="haircut.jpg" },
        new() { Name="Smoothing", Price="Rp 250.000", PriceValue=250000, Duration="2-3 jam", Category="Treatment", Image="styling.jpg" },
        new() { Name="Rebonding", Price="Rp 300.000", PriceValue=300000, Duration="3-4 jam", Category="Treatment", Image="styling.jpg" },
        new() { Name="Creambath", Price="Rp 80.000", PriceValue=80000, Duration="45 menit", Category="Treatment", Image="treatment.jpg" },
        new() { Name="Masker Rambut", Price="Rp 70.000", PriceValue=70000, Duration="40 menit", Category="Treatment", Image="treatment.jpg" },
        new() { Name="Cuci Catok", Price="Rp 65.000", PriceValue=65000, Duration="45 menit", Category="Styling", Image="styling.jpg" },
        new() { Name="Cuci Blow", Price="Rp 55.000", PriceValue=55000, Duration="35 menit", Category="Styling", Image="styling.jpg" },
        new() { Name="Pewarnaan Rambut", Price="Rp 200.000", PriceValue=200000, Duration="2-3 jam", Category="Coloring", Image="color.jpg" },
        new() { Name="Facial", Price="Rp 120.000", PriceValue=120000, Duration="60 menit", Category="Facial", Image="facial.jpg" },
    };
    public static List<BookingItem> BookingHistory { get; } = new()
    {
        new() { Ref="MON-261014-028", Service="Pewarnaan Rambut", Date="14 Okt 2026", Time="11.00", Price="Rp 200.000", Status="Menunggu Konfirmasi", Image="color.jpg", Customer="Bella Anisa" },
        new() { Ref="MON-260928-019", Service="Creambath", Date="28 Sep 2026", Time="10.00", Price="Rp 80.000", Status="Dikonfirmasi", Image="treatment.jpg", Customer="Bella Anisa" },
        new() { Ref="MON-260812-011", Service="Potong Rambut", Date="12 Agu 2026", Time="13.30", Price="Rp 50.000", Status="Selesai", Image="haircut.jpg", Customer="Bella Anisa" },
        new() { Ref="MON-260705-006", Service="Cuci Blow", Date="5 Jul 2026", Time="16.00", Price="Rp 55.000", Status="Dibatalkan", Image="styling.jpg", Customer="Bella Anisa" },
    };
    public static List<BookingItem> AdminBookings { get; } = new()
    {
        new() { Ref="MON-261014-028", Customer="Bella Anisa", Service="Pewarnaan Rambut", Date="14 Okt", Time="11.00", Status="Menunggu Konfirmasi" },
        new() { Ref="MON-261014-027", Customer="Siti Anisa", Service="Potong Rambut", Date="14 Okt", Time="09.00", Status="Dikonfirmasi" },
        new() { Ref="MON-261014-024", Customer="Rachel Putri", Service="Creambath", Date="14 Okt", Time="10.30", Status="Dikonfirmasi" },
        new() { Ref="MON-261013-021", Customer="Maria Dewi", Service="Cuci Blow", Date="13 Okt", Time="15.00", Status="Selesai" },
        new() { Ref="MON-261012-018", Customer="Lina Aulia", Service="Smoothing", Date="12 Okt", Time="13.00", Status="Dibatalkan" },
    };
    public static List<SaleItem> SaleItems { get; } = new()
    {
        new() { Id="coloring", Name="Pewarnaan Rambut", Price=200000, Type="service", Meta="2-3 jam" },
        new() { Id="haircut", Name="Potong Rambut", Price=50000, Type="service", Meta="45 mnt" },
        new() { Id="creambath", Name="Creambath", Price=80000, Type="service", Meta="45 mnt" },
        new() { Id="smoothing", Name="Smoothing", Price=250000, Type="service", Meta="2-3 jam" },
        new() { Id="shampoo", Name="Sampo Premium", Price=79000, Type="product", Meta="Stok 8" },
        new() { Id="hairoil", Name="Nourishing Hair Oil", Price=129000, Type="product", Meta="Stok 5" },
        new() { Id="mask", Name="Hair Mask", Price=95000, Type="product", Meta="Stok 12" },
        new() { Id="serum", Name="Anti-Frizz Serum", Price=115000, Type="product", Meta="Stok 7" },
    };
    public static List<TransactionItem> Transactions { get; } = new()
    {
        new() { Ref="TRX-261014-083", Date="14 Okt 14.42", Customer="Bella Anisa", Items="Coloring + 1 produk", Total="Rp 279.000", Method="Cash", Status="Paid" },
        new() { Ref="TRX-261014-082", Date="14 Okt 13.18", Customer="Siti Anisa", Items="Potong Rambut", Total="Rp 50.000", Method="QRIS", Status="Paid" },
        new() { Ref="TRX-261014-081", Date="14 Okt 11.05", Customer="Rachel Putri", Items="Creambath", Total="Rp 80.000", Method="Transfer", Status="Paid" },
        new() { Ref="TRX-261013-076", Date="13 Okt 17.30", Customer="Walk-in", Items="2 retail", Total="Rp 208.000", Method="Cash", Status="Refunded" },
    };
    public static List<InventoryItem> Inventory { get; } = new()
    {
        new() { Id="INV-RET-001", Name="Sampo Premium", Category="Retail", Quantity=8, Unit="botol", Minimum=5, Kind="retail" },
        new() { Id="INV-RET-002", Name="Conditioner Repair", Category="Retail", Quantity=4, Unit="botol", Minimum=5, Kind="retail" },
        new() { Id="INV-MAT-003", Name="Hair Dye Mocha", Category="Coloring", Quantity=12, Unit="tube", Minimum=6, Kind="material" },
        new() { Id="INV-MAT-004", Name="Hair Mask Keratin", Category="Treatment", Quantity=3, Unit="jar", Minimum=4, Kind="material" },
        new() { Id="INV-MAT-005", Name="Developer Peroxide", Category="Coloring", Quantity=2, Unit="botol", Minimum=3, Kind="material" },
        new() { Id="INV-MAT-006", Name="Creambath Avocado", Category="Treatment", Quantity=15, Unit="sachet", Minimum=8, Kind="material" },
    };
    public static List<MovementItem> Movements { get; } = new()
    {
        new() { Item="Sampo Premium", Type="Retail Sale", Qty="-1 botol", Date="14 Okt 14.42", Reason="Retail product sold", Related="TRX-261014-083" },
        new() { Item="Hair Dye Mocha", Type="Stock-Out", Qty="-2 tube", Date="14 Okt 14.30", Reason="Actual material usage", Related="MON-261014-028" },
        new() { Item="Conditioner Repair", Type="Stock-In", Qty="+10 botol", Date="14 Okt 09.12", Reason="Supplier delivery", Related="INV-RCV-044" },
        new() { Item="Hair Mask Keratin", Type="Stock-Out", Qty="-1 jar", Date="13 Okt 16.05", Reason="Damaged packaging", Related="Manual adjustment" },
        new() { Item="Developer Peroxide", Type="Stock-In", Qty="+6 botol", Date="12 Okt 10.20", Reason="Supplier delivery", Related="INV-RCV-042" },
    };
    public static List<FinancialRecord> FinancialRecords { get; } = new()
    {
        new() { Id="FIN-261014-083", Type="income", Date="14 Okt", Category="Service & Retail Sale", Amount=279000, Description="Pewarnaan + Sampo", Reference="TRX-261014-083", Source="cashier" },
        new() { Id="FIN-261014-082", Type="income", Date="14 Okt", Category="Service Revenue", Amount=50000, Description="Potong - Siti", Reference="TRX-261014-082", Source="cashier" },
        new() { Id="FIN-261013-079", Type="income", Date="13 Okt", Category="Service Revenue", Amount=450000, Description="Smoothing Walk-in", Reference="TRX-261013-079", Source="cashier" },
        new() { Id="FIN-261012-015", Type="income", Date="12 Okt", Category="Other Income", Amount=130000, Description="Styling consultation", Reference="MAN-INC-015", Source="manual" },
        new() { Id="FIN-261014-044", Type="expense", Date="14 Okt", Category="Inventory Purchase", Amount=240000, Description="Restock conditioner/mask", Reference="INV-RCV-044", Source="manual" },
        new() { Id="FIN-261013-043", Type="expense", Date="13 Okt", Category="Utilities", Amount=180000, Description="Listrik", Reference="MAN-EXP-043", Source="manual" },
        new() { Id="FIN-261011-041", Type="expense", Date="11 Okt", Category="Operations", Amount=120000, Description="Laundry", Reference="MAN-EXP-041", Source="manual" },
    };
    public static string FormatRupiah(int v) => $"Rp {v:N0}".Replace(",", ".");
}
