namespace MonicaSalon.Views.Customer;
public partial class SimulationIntroPage : ContentPage
{
    public SimulationIntroPage() => InitializeComponent();

    private async void OnStartClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//photo-selection");
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//home");
    }
}
