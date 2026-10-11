namespace MonicaSalon.Views.Shared;
public partial class CustomerBottomNav : ContentView
{
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(CustomerBottomNav), string.Empty);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomerBottomNav), string.Empty);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public CustomerBottomNav() => InitializeComponent();

    private async void OnHomeClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//home");
    }

    private async void OnServicesClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//catalogue");
    }

    private async void OnBookingClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//schedule");
    }

    private async void OnHistoryClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//history");
    }

    private async void OnProfileClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//profile");
    }
}
