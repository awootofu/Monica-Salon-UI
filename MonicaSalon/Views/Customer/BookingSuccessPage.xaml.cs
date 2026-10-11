namespace MonicaSalon.Views.Customer;
public partial class BookingSuccessPage : ContentPage
{
    public BookingSuccessPage() => InitializeComponent();

    private async void OnViewBookings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("history");
    }

    private async void OnReturnHome(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("home");
    }
}
