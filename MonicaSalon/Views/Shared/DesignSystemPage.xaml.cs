namespace MonicaSalon.Views.Shared;
public partial class DesignSystemPage : ContentPage
{
    public DesignSystemPage() => InitializeComponent();

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("cover");
    }
}
