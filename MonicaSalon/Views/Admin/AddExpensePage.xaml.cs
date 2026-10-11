namespace MonicaSalon.Views.Admin;
public partial class AddExpensePage : ContentPage
{
    private string _category = string.Empty;
    public AddExpensePage() => InitializeComponent();
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-finance");
    private async void OnCategory(object sender, EventArgs e)
    {
        var b = (Button)sender;
        _category = b.Text;
        foreach (var btn in new[] { CatInv, CatUtil, CatOps, CatPay })
            btn.BackgroundColor = btn == b ? (Color)Application.Current.Resources["DustyRose"] : Colors.White;
        await Task.CompletedTask;
    }
    private async void OnSave(object sender, EventArgs e)
    {
        bool amountOk = int.TryParse(AmountEntry.Text, out int amt) && amt > 0;
        bool descOk = !string.IsNullOrWhiteSpace(DescEditor.Text);
        if (string.IsNullOrEmpty(_category) || !amountOk || !descOk)
        {
            ErrorLabel.Text = "Please select category, enter amount more than 0, and fill description.";
            return;
        }
        await Shell.Current.GoToAsync("//admin-financial-records");
    }
}
