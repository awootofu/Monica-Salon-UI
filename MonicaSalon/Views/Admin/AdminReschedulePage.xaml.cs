namespace MonicaSalon.Views.Admin;
public partial class AdminReschedulePage : ContentPage
{
    private string _date = string.Empty;
    private string _time = string.Empty;
    private Button? _selectedDateBtn;
    private Button? _selectedTimeBtn;

    public AdminReschedulePage()
    {
        InitializeComponent();
        UpdateState();
    }

    private void Highlight(Button btn, ref Button? current)
    {
        if (current != null)
            current.BackgroundColor = Colors.White;
        current = btn;
        btn.BackgroundColor = (Color)Application.Current!.Resources["DustyRose"];
    }

    private async void OnDateSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
        {
            _date = b.Text;
            Highlight(b, ref _selectedDateBtn);
            UpdateState();
        }
        await Task.CompletedTask;
    }

    private async void OnTimeSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
        {
            _time = b.Text;
            Highlight(b, ref _selectedTimeBtn);
            UpdateState();
        }
        await Task.CompletedTask;
    }

    private void UpdateState()
    {
        if (ConflictLabel == null || SaveBtn == null) return;
        if (_time == "10.00")
        {
            ConflictLabel.Text = "Jadwal bentrok, pilih jam lain.";
            ConflictLabel.TextColor = (Color)Application.Current!.Resources["DangerText"];
            SaveBtn.IsEnabled = false;
        }
        else if (!string.IsNullOrEmpty(_date) && !string.IsNullOrEmpty(_time))
        {
            ConflictLabel.Text = $"Slot tersedia: {_date} • {_time} WIB.";
            ConflictLabel.TextColor = (Color)Application.Current!.Resources["SuccessText"];
            SaveBtn.IsEnabled = true;
        }
        else
        {
            ConflictLabel.Text = "Pilih tanggal dan jam baru.";
            ConflictLabel.TextColor = (Color)Application.Current!.Resources["Muted"];
            SaveBtn.IsEnabled = true;
        }
    }

    private async void OnSave(object sender, EventArgs e)
    {
        SuccessBox.IsVisible = true;
        await Task.CompletedTask;
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-booking-details");
    }

    private async void OnBackToDetail(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-booking-details");
    }
}
