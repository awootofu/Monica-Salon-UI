namespace MonicaSalon.Views.Admin;
public partial class SalonProfilePage : ContentPage
{
    public SalonProfilePage() => InitializeComponent();
    private async void OnBack(object sender, EventArgs e) => await Shell.Current.GoToAsync("admin-more");
    private async void OnEdit(object sender, EventArgs e)
    {
        NameEntry.IsEnabled = true;
        AddressEntry.IsEnabled = true;
        PhoneEntry.IsEnabled = true;
        EmailEntry.IsEnabled = true;
        HoursEntry.IsEnabled = true;
        NoteEditor.IsEnabled = true;
        SaveBtn.IsVisible = true;
        EditBtn.IsVisible = false;
        await Task.CompletedTask;
    }
    private async void OnSave(object sender, EventArgs e)
    {
        NameEntry.IsEnabled = false;
        AddressEntry.IsEnabled = false;
        PhoneEntry.IsEnabled = false;
        EmailEntry.IsEnabled = false;
        HoursEntry.IsEnabled = false;
        NoteEditor.IsEnabled = false;
        SaveBtn.IsVisible = false;
        EditBtn.IsVisible = true;
        await Task.CompletedTask;
    }
}
