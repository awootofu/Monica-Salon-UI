using MonicaSalon.Models;
using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.Views.Customer;
public partial class HairstyleDetailPage : ContentPage
{
    public static HairstyleItem? Selected { get; set; }

    private readonly HairstyleDetailViewModel _vm = new();

    public HairstyleDetailPage()
    {
        InitializeComponent();
        BindingContext = _vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.Load(Selected ?? MockDataService.Hairstyles.First());
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("hairstyle-book");
    }

    private async void OnChoose(object sender, EventArgs e)
    {
        if (Selected != null)
            BookingContext.SelectedHairstyle = Selected;
        await Shell.Current.GoToAsync("schedule");
    }
}
