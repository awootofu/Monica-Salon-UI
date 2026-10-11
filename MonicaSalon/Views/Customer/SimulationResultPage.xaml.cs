namespace MonicaSalon.Views.Customer;
public partial class SimulationResultPage : ContentPage
{
    private bool _saved;

    public SimulationResultPage() => InitializeComponent();

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("hair-editor");
    }

    private void OnSaveClicked(object? sender, EventArgs e)
    {
        _saved = !_saved;
        SavedLabel.IsVisible = _saved;
        SavedLabel.Text = _saved ? "Saved." : string.Empty;
    }

    private async void OnReturnToEditingClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("hair-editor");
    }

    private async void OnDeleteClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("photo-selection");
    }

    private async void OnHomeClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("home");
    }
}
