namespace MonicaSalon.Views.Admin;
public partial class AdminBookingDetailsPage : ContentPage
{
    private string _status = "Menunggu Konfirmasi";

    public AdminBookingDetailsPage()
    {
        InitializeComponent();
        UpdateState();
    }

    private void UpdateState()
    {
        StatusLabel.Text = _status;
        var res = Application.Current!.Resources;
        if (_status == "Menunggu Konfirmasi")
        {
            StatusBadge.BackgroundColor = (Color)res["PendingBg"];
            StatusLabel.TextColor = (Color)res["PendingText"];
        }
        else if (_status == "Dibatalkan")
        {
            StatusBadge.BackgroundColor = (Color)res["DangerBg"];
            StatusLabel.TextColor = (Color)res["DangerText"];
        }
        else
        {
            StatusBadge.BackgroundColor = (Color)res["SuccessBg"];
            StatusLabel.TextColor = (Color)res["SuccessText"];
        }
        ConfirmBtn.IsVisible = _status == "Menunggu Konfirmasi";
        CompleteBtn.IsVisible = _status == "Dikonfirmasi";
        CashierBtn.IsVisible = _status == "Selesai";
        CancelNote.IsVisible = _status == "Dibatalkan";
        bool closed = _status == "Selesai" || _status == "Dibatalkan";
        RescheduleBtn.IsVisible = !closed;
        CancelBtn.IsVisible = !closed;
    }

    private async void OnConfirm(object sender, EventArgs e)
    {
        _status = "Dikonfirmasi";
        UpdateState();
        await Task.CompletedTask;
    }

    private async void OnComplete(object sender, EventArgs e)
    {
        _status = "Selesai";
        UpdateState();
        await Task.CompletedTask;
    }

    private async void OnCancel(object sender, EventArgs e)
    {
        _status = "Dibatalkan";
        UpdateState();
        await Task.CompletedTask;
    }

    private async void OnCashier(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-cashier");
    private async void OnReschedule(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-reschedule");

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-bookings");
    }
}
