namespace MonicaSalon.Views.Shared;
public partial class CoverPage : ContentPage
{
    public CoverPage() => InitializeComponent();

    private async void OnContinue(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//roles");
    }
}
