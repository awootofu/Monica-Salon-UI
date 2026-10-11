namespace MonicaSalon.Views.Customer;
public partial class PhotoSelectionPage : ContentPage
{
    private bool _photoSelected;

    public PhotoSelectionPage() => InitializeComponent();

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//simulation-intro");
    }

    private void OnTakePhotoClicked(object? sender, EventArgs e)
    {
        _photoSelected = true;
        PreviewImage.IsVisible = true;
        EmptyLabel.IsVisible = false;
        UpdateContinueState();
    }

    private void OnChooseGalleryClicked(object? sender, EventArgs e)
    {
        _photoSelected = true;
        PreviewImage.IsVisible = true;
        EmptyLabel.IsVisible = false;
        UpdateContinueState();
    }

    private void OnConsentChanged(object? sender, CheckedChangedEventArgs e)
    {
        UpdateContinueState();
    }

    private void UpdateContinueState()
    {
        ContinueButton.IsEnabled = _photoSelected && ConsentCheck.IsChecked;
    }

    private async void OnContinueClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//hair-editor");
    }

    private async void OnCancelClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//home");
    }
}
