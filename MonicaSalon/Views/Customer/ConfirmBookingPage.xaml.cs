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
        await Shell.Current.GoToAsync("booking-success");
    }
}
