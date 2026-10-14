using MonicaSalon.ViewModels.Customer;
namespace MonicaSalon.Views.Customer;
public partial class BookingFeedbackPage : ContentPage
{
    private readonly BookingFeedbackViewModel _vm = new();

    public BookingFeedbackPage()
    {
        InitializeComponent();
        BindingContext = _vm;
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("booking-details");
    }

    private void OnRescheduleOption(object sender, EventArgs e) => _vm.SelectReschedule();

    private void OnCancelOption(object sender, EventArgs e) => _vm.SelectCancel();

    private void OnConfirmSubmit(object sender, EventArgs e) => _vm.Submit();

    private async void OnBackToHistory(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("history");
    }
}
