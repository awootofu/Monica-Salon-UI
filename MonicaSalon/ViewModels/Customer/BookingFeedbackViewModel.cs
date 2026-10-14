using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class BookingFeedbackViewModel : BaseViewModel
{
    private string _mode = string.Empty;
    public string Mode
    {
        get => _mode;
        private set => SetProperty(ref _mode, value);
    }

    private string _confirmMessage = "Konfirmasi pengajuan";
    public string ConfirmMessage
    {
        get => _confirmMessage;
        private set => SetProperty(ref _confirmMessage, value);
    }

    private bool _isOptionsVisible = true;
    public bool IsOptionsVisible
    {
        get => _isOptionsVisible;
        private set => SetProperty(ref _isOptionsVisible, value);
    }

    private bool _isConfirmVisible;
    public bool IsConfirmVisible
    {
        get => _isConfirmVisible;
        private set => SetProperty(ref _isConfirmVisible, value);
    }

    private bool _isSuccessVisible;
    public bool IsSuccessVisible
    {
        get => _isSuccessVisible;
        private set => SetProperty(ref _isSuccessVisible, value);
    }

    public void SelectReschedule()
    {
        Mode = "reschedule";
        ConfirmMessage = "Ajukan ubah jadwal untuk MON-261014-028?";
        IsOptionsVisible = false;
        IsConfirmVisible = true;
        IsSuccessVisible = false;
    }

    public void SelectCancel()
    {
        Mode = "cancel";
        ConfirmMessage = "Ajukan pembatalan untuk MON-261014-028?";
        IsOptionsVisible = false;
        IsConfirmVisible = true;
        IsSuccessVisible = false;
    }

    public void Submit()
    {
        IsConfirmVisible = false;
        IsSuccessVisible = true;
    }
}
