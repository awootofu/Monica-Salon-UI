namespace MonicaSalon.Views.Customer;
public partial class SchedulePage : ContentPage
{
    private string _selectedDate = string.Empty;
    private string _selectedTime = string.Empty;
    private Button? _selectedDateBtn;
    private Button? _selectedTimeBtn;

    public SchedulePage()
    {
        InitializeComponent();
        UpdateSummary();
    }

    private void Highlight(Button btn, ref Button? current, Color selected, Color normal)
    {
        if (current != null)
            current.BackgroundColor = normal;
        current = btn;
        btn.BackgroundColor = selected;
        UpdateSummary();
    }

    private async void OnDateSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
        {
            _selectedDate = b.Text.Replace(" Sen", "").Replace(" Sel", "").Replace(" Rab", "").Replace(" Kam", "").Replace(" Jum", "").Replace(" Sab", "").Replace(" Min", "");
            Highlight(b, ref _selectedDateBtn, (Color)Application.Current!.Resources["DustyRose"], Colors.White);
        }
        await Task.CompletedTask;
    }

    private async void OnTimeSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
        {
            _selectedTime = b.Text;
            Highlight(b, ref _selectedTimeBtn, (Color)Application.Current!.Resources["DustyRose"], Colors.White);
        }
        await Task.CompletedTask;
    }

    private void UpdateSummary()
    {
        if (SummaryLabel == null) return;
        if (!string.IsNullOrEmpty(_selectedDate) && !string.IsNullOrEmpty(_selectedTime))
            SummaryLabel.Text = $"Dipilih: {_selectedDate} Oktober 2026 • {_selectedTime} WIB • Pewarnaan Rambut Rp 200.000";
        else
            SummaryLabel.Text = "Pilih tanggal dan jam dahulu.";
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("details");
    }

    private async void OnContinue(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("confirm");
    }
}
