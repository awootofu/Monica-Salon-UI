using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class AdminCreateBookingPage : ContentPage
{
    private AdminCreateBookingViewModel Vm => (AdminCreateBookingViewModel)BindingContext;

    public AdminCreateBookingPage()
    {
        InitializeComponent();
        BindingContext = new AdminCreateBookingViewModel();
    }

    private async void OnCustomerSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
            Vm.SelectCustomer(b.CommandParameter as string ?? b.Text);
        await Task.CompletedTask;
    }

    private async void OnServiceSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
            Vm.SelectService(b.CommandParameter as string);
        await Task.CompletedTask;
    }

    private async void OnSlotSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
            Vm.SelectSlot(b.CommandParameter as string ?? b.Text);
        await Task.CompletedTask;
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-dashboard");
    }

    private async void OnSave(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-booking-details");
    }
}
