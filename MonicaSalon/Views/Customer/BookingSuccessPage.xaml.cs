using MonicaSalon.ViewModels.Customer;
namespace MonicaSalon.Views.Customer;
public partial class BookingSuccessPage : ContentPage
{
    private readonly BookingSuccessViewModel _vm = new();

    public BookingSuccessPage()
    {
        InitializeComponent();
        BindingContext = _vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.Refresh();
    }

    private async void OnViewBookings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("history");
    }

    private async void OnReturnHome(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("home");
    }
}
