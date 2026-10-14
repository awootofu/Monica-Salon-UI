using MonicaSalon.ViewModels.Admin;
namespace MonicaSalon.Views.Admin;
public partial class AddIncomePage : ContentPage
{
    private AddIncomeViewModel Vm => (AddIncomeViewModel)BindingContext;
    public AddIncomePage()
    {
        InitializeComponent();
        BindingContext = new AddIncomeViewModel();
    }
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-finance");
    private void OnDateChanged(object? sender, DateChangedEventArgs e)
    {
        if (DatePicker.Date is DateTime picked)
            DateLabel.Text = picked.ToString("d MMM yyyy", new System.Globalization.CultureInfo("id-ID"));
    }
    private void OnCategory(object sender, EventArgs e)
    {
        var b = (Button)sender;
        Vm.SelectCategory(b.Text);
        foreach (var btn in new[] { CatOther, CatCapital, CatAdj })
            btn.BackgroundColor = btn == b ? (Color)Application.Current!.Resources["DustyRose"] : Colors.White;
    }
    private async void OnSave(object sender, EventArgs e)
    {
        if (!Vm.TrySave())
            return;
        await Shell.Current.GoToAsync("admin-financial-records");
    }
}
