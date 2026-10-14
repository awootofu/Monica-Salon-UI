using MonicaSalon.ViewModels.Customer;
namespace MonicaSalon.Views.Customer;
public partial class SchedulePage : ContentPage
{
    private readonly ScheduleViewModel _vm = new();
    private Button? _selectedDateBtn;
    private Button? _selectedTimeBtn;

    public SchedulePage()
    {
        InitializeComponent();
        BindingContext = _vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.Refresh();
    }

    private void Highlight(Button btn, ref Button? current, Color selected, Color normal)
    {
        if (current != null)
            current.BackgroundColor = normal;
        current = btn;
        btn.BackgroundColor = selected;
    }

    private async void OnDateSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
        {
            var date = b.Text.Replace(" Sen", "").Replace(" Sel", "").Replace(" Rab", "").Replace(" Kam", "").Replace(" Jum", "").Replace(" Sab", "").Replace(" Min", "");
            _vm.SelectDate(date);
            Highlight(b, ref _selectedDateBtn, (Color)Application.Current!.Resources["DustyRose"], Colors.White);
        }
        await Task.CompletedTask;
    }

    private async void OnTimeSelected(object sender, EventArgs e)
    {
        if (sender is Button b)
        {
            _vm.SelectTime(b.Text);
            Highlight(b, ref _selectedTimeBtn, (Color)Application.Current!.Resources["DustyRose"], Colors.White);
        }
        await Task.CompletedTask;
    }

    private async void OnBrowseStyles(object sender, EventArgs e)
    {
        Services.BookingContext.HairstyleReturnTo = "schedule";
        await Shell.Current.GoToAsync("hairstyle-book");
    }

    private void OnClearStyle(object sender, EventArgs e) => _vm.ClearHairstyle();

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("details");
    }

    private async void OnContinue(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("confirm");
    }
}
