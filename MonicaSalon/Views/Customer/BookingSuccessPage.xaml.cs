namespace MonicaSalon.Views.Customer;
public partial class BookingSuccessPage : ContentPage
{
    public BookingSuccessPage() => InitializeComponent();

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var h = Services.BookingContext.SelectedHairstyle;
        HairstyleRefLabel.Text = h == null
            ? "Referensi gaya: tanpa referensi"
            : $"Referensi gaya: {h.Name} • {h.Category}";
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
