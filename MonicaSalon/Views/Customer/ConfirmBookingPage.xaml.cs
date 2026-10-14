using MonicaSalon.Services;
using MonicaSalon.ViewModels.Customer;
namespace MonicaSalon.Views.Customer;
public partial class ConfirmBookingPage : ContentPage
{
    private readonly ConfirmBookingViewModel _vm = new();

    public ConfirmBookingPage()
    {
        InitializeComponent();
        BindingContext = _vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.Refresh();
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("schedule");
    }

    private async void OnChangeStyle(object sender, EventArgs e)
    {
        BookingContext.HairstyleReturnTo = "schedule";
        await Shell.Current.GoToAsync("hairstyle-book");
    }

    private async void OnSubmit(object sender, EventArgs e)
    {
        var services = BookingContext.SelectedServices.ToList();
        if (services.Count > 0)
        {
            var stamp = BookingContext.SelectedDate.ToString("yyMMdd");
            var number = Random.Shared.Next(100, 1000);
            var item = new Models.BookingItem
            {
                Ref = $"MON-{stamp}-{number}",
                Service = BookingContext.ServicesSummary,
                Date = BookingContext.SelectedDateShort,
                Time = BookingContext.SelectedTime,
                Price = BookingContext.ServicesTotalText,
                Status = "Menunggu Konfirmasi",
                Image = services[0].Image,
                Customer = "Bella Anisa",
            };
            MockDataService.BookingHistory.Insert(0, item);
            MockDataService.AdminBookings.Insert(0, new Models.BookingItem
            {
                Ref = item.Ref,
                Customer = "Bella Anisa",
                Service = item.Service,
                Date = item.Date,
                Time = item.Time,
                Status = item.Status,
            });
        }
        await Shell.Current.GoToAsync("booking-success");
    }
}
