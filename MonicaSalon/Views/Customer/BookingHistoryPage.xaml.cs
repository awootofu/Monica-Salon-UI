using MonicaSalon.ViewModels;
namespace MonicaSalon.Views.Customer;
public partial class BookingHistoryPage : ContentPage
{
    public BookingHistoryPage()
    {
        InitializeComponent();
        BindingContext = new BookingHistoryViewModel();
        StatusPicker.SelectedIndex = 0;
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;
        ((CollectionView)sender).SelectedItem = null;
        await Shell.Current.GoToAsync("booking-details");
    }

    private async void OnHome(object sender, EventArgs e) => await Shell.Current.GoToAsync("home");
    private async void OnCatalogue(object sender, EventArgs e) => await Shell.Current.GoToAsync("catalogue");
    private async void OnBooking(object sender, EventArgs e) => await Shell.Current.GoToAsync("schedule");
    private async void OnHistory(object sender, EventArgs e) => await Shell.Current.GoToAsync("history");
    private async void OnProfile(object sender, EventArgs e) => await Shell.Current.GoToAsync("profile");
}
