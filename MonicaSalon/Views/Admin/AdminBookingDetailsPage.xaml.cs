using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class AdminBookingDetailsPage : ContentPage
{
    private AdminBookingDetailsViewModel Vm => (AdminBookingDetailsViewModel)BindingContext;

    public AdminBookingDetailsPage()
    {
        InitializeComponent();
        BindingContext = new AdminBookingDetailsViewModel();
    }

    private async void OnConfirm(object sender, EventArgs e)
    {
        Vm.Confirm();
        await Task.CompletedTask;
    }

    private async void OnComplete(object sender, EventArgs e)
    {
        Vm.Complete();
        await Task.CompletedTask;
    }

    private async void OnCancel(object sender, EventArgs e)
    {
        Vm.Cancel();
        await Task.CompletedTask;
    }

    private async void OnCashier(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-cashier");
    private async void OnReschedule(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-reschedule");

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-bookings");
    }
}
