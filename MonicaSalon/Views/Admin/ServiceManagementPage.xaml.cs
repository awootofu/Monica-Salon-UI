using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class ServiceManagementPage : ContentPage
{
    private ServiceManagementViewModel Vm => (ServiceManagementViewModel)BindingContext;
    public ServiceManagementPage()
    {
        InitializeComponent();
        BindingContext = new ServiceManagementViewModel();
    }
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
    private async void OnAddService(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-service-form");
    private async void OnEdit(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-service-form");
    private void OnToggleActive(object sender, EventArgs e)
    {
        if (((Button)sender).BindingContext is ServiceManagementViewModel.ServiceRow row)
            Vm.ToggleActive(row);
    }
}
