using System.Globalization;
namespace MonicaSalon.Converters;
public class StatusColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var s = value?.ToString() ?? "";
        return s switch
        {
            "Dikonfirmasi" or "Selesai" or "Paid" or "Active" or "Aman" => Color.FromArgb("#4F7157"),
            "Menunggu Konfirmasi" or "Pending" => Color.FromArgb("#A56D1C"),
            "Dibatalkan" or "Refunded" or "Inactive" => Color.FromArgb("#A65854"),
            _ => Color.FromArgb("#536F7A"),
        };
    }
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
}
