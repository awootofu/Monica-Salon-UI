namespace MonicaSalon.Views.Admin;
public partial class SalonSettingsPage : ContentPage
{
    private int _chairs = 6;
    public SalonSettingsPage() => InitializeComponent();
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
    private async void OnEditHours(object sender, EventArgs e) => await Task.CompletedTask;
    private async void OnMinus(object sender, EventArgs e)
    {
        if (_chairs > 1) _chairs--;
        ChairsLabel.Text = _chairs.ToString();
        await Task.CompletedTask;
    }
    private async void OnPlus(object sender, EventArgs e)
    {
        _chairs++;
        ChairsLabel.Text = _chairs.ToString();
        await Task.CompletedTask;
    }
    private async void OnRemoveHaircut(object sender, EventArgs e) { ChipHaircut.IsVisible = false; await Task.CompletedTask; }
    private async void OnRemoveColor(object sender, EventArgs e) { ChipColor.IsVisible = false; await Task.CompletedTask; }
    private async void OnAddCategory(object sender, EventArgs e) => await Task.CompletedTask;
    private async void OnStubToggled(object sender, ToggledEventArgs e) => await Task.CompletedTask;
    private async void OnSave(object sender, EventArgs e) => await Task.CompletedTask;
}
