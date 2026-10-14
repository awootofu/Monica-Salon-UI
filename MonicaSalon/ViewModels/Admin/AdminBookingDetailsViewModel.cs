using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class AdminBookingDetailsViewModel : BaseViewModel
{
    private string _status = "Menunggu Konfirmasi";
    public string Status
    {
        get => _status;
        private set
        {
            if (SetProperty(ref _status, value ?? "Menunggu Konfirmasi"))
                UpdateState();
        }
    }

    private bool _showConfirm = true;
    public bool ShowConfirm
    {
        get => _showConfirm;
        private set => SetProperty(ref _showConfirm, value);
    }

    private bool _showComplete;
    public bool ShowComplete
    {
        get => _showComplete;
        private set => SetProperty(ref _showComplete, value);
    }

    private bool _showCashier;
    public bool ShowCashier
    {
        get => _showCashier;
        private set => SetProperty(ref _showCashier, value);
    }

    private bool _showCancelNote;
    public bool ShowCancelNote
    {
        get => _showCancelNote;
        private set => SetProperty(ref _showCancelNote, value);
    }

    private bool _showReschedule = true;
    public bool ShowReschedule
    {
        get => _showReschedule;
        private set => SetProperty(ref _showReschedule, value);
    }

    private bool _showCancel = true;
    public bool ShowCancel
    {
        get => _showCancel;
        private set => SetProperty(ref _showCancel, value);
    }

    public AdminBookingDetailsViewModel() => UpdateState();

    public void Confirm() => Status = "Dikonfirmasi";

    public void Complete() => Status = "Selesai";

    public void Cancel() => Status = "Dibatalkan";

    private void UpdateState()
    {
        ShowConfirm = _status == "Menunggu Konfirmasi";
        ShowComplete = _status == "Dikonfirmasi";
        ShowCashier = _status == "Selesai";
        ShowCancelNote = _status == "Dibatalkan";
        bool closed = _status == "Selesai" || _status == "Dibatalkan";
        ShowReschedule = !closed;
        ShowCancel = !closed;
    }
}
