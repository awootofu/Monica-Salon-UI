using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class AdminReschedulePage : ContentPage
{
    private AdminRescheduleViewModel Vm => (AdminRescheduleViewModel)BindingContext;

    public AdminReschedulePage()
    {
        InitializeComponent();
        BindingContext = new AdminRescheduleViewModel();
    }

    private async void OnDateSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
            Vm.SelectDate(b.CommandParameter as string ?? b.Text);
        await Task.CompletedTask;
    }

    private async void OnTimeSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
            Vm.SelectTime(b.CommandParameter as string ?? b.Text);
        await Task.CompletedTask;
    }

    private async void OnSave(object sender, EventArgs e)
    {
        Vm.Save();
        await Task.CompletedTask;
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-booking-details");
    }

    private async void OnBackToDetail(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-booking-details");
    }
}
