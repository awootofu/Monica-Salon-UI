namespace MonicaSalon.Views.Customer;
public partial class SettingsPage : ContentPage
{
    public SettingsPage() => InitializeComponent();

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("profile");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var h = Services.BookingContext.SelectedHairstyle;
        HairstyleStatusLabel.Text = h == null
            ? "Belum ada gaya favorit dipilih."
            : $"Favorit: {h.Name} • {h.Category}";
    }

    private async void OnBrowseStyles(object sender, EventArgs e)
    {
        Services.BookingContext.HairstyleReturnTo = "settings";
        await Shell.Current.GoToAsync("hairstyle-book");
    }

    private async void OnStub(object sender, EventArgs e)
    {
        await Task.CompletedTask;
    }

    private async void OnLogout(object sender, EventArgs e)
    {
        LogoutConfirm.IsVisible = true;
        await Task.CompletedTask;
    }

    private async void OnConfirmLogout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("login");
    }

    private async void OnStay(object sender, EventArgs e)
    {
        LogoutConfirm.IsVisible = false;
        await Task.CompletedTask;
    }
}
