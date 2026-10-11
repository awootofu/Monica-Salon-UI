namespace MonicaSalon.Views.Shared;
public partial class FlowsPage : ContentPage
{
    public FlowsPage() => InitializeComponent();

    private async void OnCustomerFlow(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("welcome");
    }

    private async void OnAdminFlow(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("admin-login");
    }
}
