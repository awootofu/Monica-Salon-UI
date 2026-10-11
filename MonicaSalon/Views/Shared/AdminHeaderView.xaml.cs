namespace MonicaSalon.Views.Shared;
public partial class AdminHeaderView : ContentView
{
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(AdminHeaderView), string.Empty);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(AdminHeaderView), string.Empty);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public AdminHeaderView() => InitializeComponent();

    private async void OnDashboardClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//admin-dashboard");
    }
}
