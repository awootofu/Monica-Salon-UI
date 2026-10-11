namespace MonicaSalon.Views.Customer;
public partial class ServiceDetailPage : ContentPage
{
    public ServiceDetailPage() => InitializeComponent();

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("catalogue");
    }

    private async void OnBook(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("schedule");
    }
}
