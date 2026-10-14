using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class ProductManagementPage : ContentPage
{
    private ProductManagementViewModel Vm => (ProductManagementViewModel)BindingContext;
    public ProductManagementPage()
    {
        InitializeComponent();
        BindingContext = new ProductManagementViewModel();
    }
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
    private async void OnAddProduct(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-product-form");
    private async void OnEdit(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-product-form");
    private void OnToggleActive(object sender, EventArgs e)
    {
        if (((Button)sender).BindingContext is ProductManagementViewModel.ProductRow row)
            Vm.ToggleActive(row);
    }
}
