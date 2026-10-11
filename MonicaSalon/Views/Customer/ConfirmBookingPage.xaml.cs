namespace MonicaSalon.Views.Customer;
public partial class ConfirmBookingPage : ContentPage
{
    public ConfirmBookingPage() => InitializeComponent();

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("schedule");
    }

    private async void OnSubmit(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("booking-success");
    }
}
