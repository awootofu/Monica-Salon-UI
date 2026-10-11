namespace MonicaSalon.Views.Customer;
public partial class BookingDetailsPage : ContentPage
{
    public BookingDetailsPage() => InitializeComponent();

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//history");
    }

    private async void OnReschedule(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//booking-feedback");
    }

    private async void OnCancel(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//booking-feedback");
    }
}
