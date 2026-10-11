namespace MonicaSalon.Views.Customer;
public partial class BookingFeedbackPage : ContentPage
{
    private string _mode = string.Empty;

    public BookingFeedbackPage() => InitializeComponent();

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("booking-details");
    }

    private async void OnRescheduleOption(object sender, EventArgs e)
    {
        _mode = "reschedule";
        ConfirmLabel.Text = "Ajukan ubah jadwal untuk MON-261014-028?";
        OptionsLayout.IsVisible = false;
        ConfirmLayout.IsVisible = true;
        SuccessLayout.IsVisible = false;
        await Task.CompletedTask;
    }

    private async void OnCancelOption(object sender, EventArgs e)
    {
        _mode = "cancel";
        ConfirmLabel.Text = "Ajukan pembatalan untuk MON-261014-028?";
        OptionsLayout.IsVisible = false;
        ConfirmLayout.IsVisible = true;
        SuccessLayout.IsVisible = false;
        await Task.CompletedTask;
    }

    private async void OnConfirmSubmit(object sender, EventArgs e)
    {
        ConfirmLayout.IsVisible = false;
        SuccessLayout.IsVisible = true;
        await Task.CompletedTask;
    }

    private async void OnBackToHistory(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("history");
    }
}
