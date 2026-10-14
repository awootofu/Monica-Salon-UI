using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class AddExpensePage : ContentPage
{
    private AddExpenseViewModel Vm => (AddExpenseViewModel)BindingContext;
    public AddExpensePage()
    {
        InitializeComponent();
        BindingContext = new AddExpenseViewModel();
    }
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-finance");
    private void OnCategory(object sender, EventArgs e)
    {
        var b = (Button)sender;
        Vm.SelectCategory(b.Text);
        foreach (var btn in new[] { CatInv, CatUtil, CatOps, CatPay })
            btn.BackgroundColor = btn == b ? (Color)Application.Current!.Resources["DustyRose"] : Colors.White;
    }
    private async void OnSave(object sender, EventArgs e)
    {
        if (!Vm.TrySave())
            return;
        await Shell.Current.GoToAsync("admin-financial-records");
    }
}
