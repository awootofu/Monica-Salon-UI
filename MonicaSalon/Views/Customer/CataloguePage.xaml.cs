using MonicaSalon.ViewModels.Customer;
namespace MonicaSalon.Views.Customer;
public partial class CataloguePage : ContentPage
{
    public CataloguePage()
    {
        InitializeComponent();
        BindingContext = new CatalogueViewModel();
    }

    private async void OnServiceSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;
        ((CollectionView)sender).SelectedItem = null;
        await Shell.Current.GoToAsync("details");
    }

    private async void OnNavHome(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("home");
    }

    private async void OnNavServices(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("catalogue");
    }

    private async void OnNavBooking(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("schedule");
    }

    private async void OnNavHistory(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("history");
    }

    private async void OnNavProfile(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("profile");
    }
}
