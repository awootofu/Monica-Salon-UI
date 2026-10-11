using MonicaSalon.Services;
namespace MonicaSalon.Views.Customer;
public partial class BookingHistoryPage : ContentPage
{
    public BookingHistoryPage()
    {
        InitializeComponent();
        HistoryList.ItemsSource = MockDataService.BookingHistory;
    }

    private async void OnFilter(object sender, EventArgs e)
    {
        if (sender is not Button b) return;
        string f = b.Text;
        if (f == "Semua")
            HistoryList.ItemsSource = MockDataService.BookingHistory;
        else
            HistoryList.ItemsSource = MockDataService.BookingHistory.Where(x => x.Status == f).ToList();
        await Task.CompletedTask;
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;
        ((CollectionView)sender).SelectedItem = null;
        await Shell.Current.GoToAsync("//booking-details");
    }

    private async void OnHome(object sender, EventArgs e) => await Shell.Current.GoToAsync("//home");
    private async void OnCatalogue(object sender, EventArgs e) => await Shell.Current.GoToAsync("//catalogue");
    private async void OnBooking(object sender, EventArgs e) => await Shell.Current.GoToAsync("//schedule");
    private async void OnHistory(object sender, EventArgs e) => await Shell.Current.GoToAsync("//history");
    private async void OnProfile(object sender, EventArgs e) => await Shell.Current.GoToAsync("//profile");
}
