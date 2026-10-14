using MonicaSalon.Models;
using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.Views.Customer;
public partial class HairstyleBookPage : ContentPage
{
    private readonly HairstyleBookViewModel _vm = new();

    public HairstyleBookPage()
    {
        InitializeComponent();
        BindingContext = _vm;
        CategoryPicker.SelectedIndex = 0;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.Refresh();
    }

    private async void OnStyleSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;
        var item = e.CurrentSelection[0] as HairstyleItem;
        ((CollectionView)sender).SelectedItem = null;
        if (item == null)
            return;
        BookingContext.SelectedHairstyle = null;
        HairstyleDetailPage.Selected = item;
        await Shell.Current.GoToAsync("hairstyle-detail");
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(BookingContext.HairstyleReturnTo);
    }
}
