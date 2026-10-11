namespace MonicaSalon.Views.Admin;

public partial class TransactionDetailsPage : ContentPage
{
    public TransactionDetailsPage() => InitializeComponent();

    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("//admin-transactions");

    private async void OnPrintReceipt(object sender, EventArgs e)
    {
        ReceiptNote.Text = "Struk TRX-261014-083 siap dicetak.";
        await Task.CompletedTask;
    }
}
