namespace MonicaSalon.Views.Shared;
public partial class AdminBottomNav : ContentView
{
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(AdminBottomNav), string.Empty);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(AdminBottomNav), string.Empty);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public AdminBottomNav() => InitializeComponent();

    private async void OnDashboardClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-dashboard");
    }

    private async void OnBookingsClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-bookings");
    }

    private async void OnCashierClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-cashier");
    }

    private async void OnInventoryClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-inventory");
    }

    private async void OnMoreClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-more");
    }
}
