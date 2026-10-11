namespace MonicaSalon.Views.Admin;
public partial class AdminCreateBookingPage : ContentPage
{
    private string _customer = "Siti Anisa";
    private string _service = "Potong Rambut";
    private string _price = "Rp 50.000";
    private string _slot = "09.00";
    private Button? _selectedCustomerBtn;
    private Button? _selectedServiceBtn;
    private Button? _selectedSlotBtn;

    public AdminCreateBookingPage()
    {
        InitializeComponent();
        UpdateSummary();
    }

    private void Highlight(Button btn, ref Button? current)
    {
        if (current != null)
            current.BackgroundColor = Colors.White;
        current = btn;
        btn.BackgroundColor = (Color)Application.Current!.Resources["DustyRose"];
        UpdateSummary();
    }

    private async void OnCustomerSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
        {
            _customer = b.Text;
            NewCustomerFields.IsVisible = _customer == "Pelanggan baru";
            Highlight(b, ref _selectedCustomerBtn);
        }
        await Task.CompletedTask;
    }

    private async void OnServiceSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
        {
            if (b == ServiceBtnCut) { _service = "Potong Rambut"; _price = "Rp 50.000"; }
            else if (b == ServiceBtnCream) { _service = "Creambath"; _price = "Rp 80.000"; }
            else { _service = "Pewarnaan Rambut"; _price = "Rp 200.000"; }
            Highlight(b, ref _selectedServiceBtn);
        }
        await Task.CompletedTask;
    }

    private async void OnSlotSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
        {
            _slot = b.Text;
            Highlight(b, ref _selectedSlotBtn);
        }
        await Task.CompletedTask;
    }

    private void UpdateSummary()
    {
        if (SummaryLabel == null) return;
        SummaryLabel.Text = $"{_customer} • {_service} {_price} • 14 Okt {_slot}";
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-dashboard");
    }

    private async void OnSave(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-booking-details");
    }
}
