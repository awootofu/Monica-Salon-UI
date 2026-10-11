using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MonicaSalon.Views.Customer;
public partial class HairEditorPage : ContentPage
{
    private Button? _selectedStyle;
    private Button? _selectedColor;
    private int _position = 2;
    private int _size = 2;

    public HairEditorPage()
    {
        InitializeComponent();
        _selectedStyle = StyleSoftLayer;
        _selectedColor = ColorNatural;
        RefreshSelection();
        RefreshAdjustLabels();
    }

    private void RefreshSelection()
    {
        var styles = new[] { StyleSoftLayer, StyleLongWave, StyleSleek, StyleShoulder };
        foreach (var b in styles)
        {
            bool active = b == _selectedStyle;
            b.BackgroundColor = active ? (Color)Application.Current!.Resources["DustyRose"] : Colors.White;
            b.TextColor = active ? Colors.White : (Color)Application.Current!.Resources["DeepCocoa"];
        }
        var colors = new[] { ColorNatural, ColorMocha, ColorCocoa, ColorAuburn };
        foreach (var b in colors)
        {
            bool active = b == _selectedColor;
            b.BackgroundColor = active ? (Color)Application.Current!.Resources["DustyRose"] : Colors.White;
            b.TextColor = active ? Colors.White : (Color)Application.Current!.Resources["DeepCocoa"];
        }
    }

    private void RefreshAdjustLabels()
    {
        PositionDots.Text = $"{_position} / 4";
        SizeDots.Text = $"{_size} / 4";
    }

    private void OnStyleClicked(object? sender, EventArgs e)
    {
        if (sender is Button b)
        {
            _selectedStyle = b;
            RefreshSelection();
        }
    }

    private void OnColorClicked(object? sender, EventArgs e)
    {
        if (sender is Button b)
        {
            _selectedColor = b;
            RefreshSelection();
        }
    }

    private void OnPositionMinusClicked(object? sender, EventArgs e)
    {
        if (_position > 0) _position--;
        RefreshAdjustLabels();
    }

    private void OnPositionPlusClicked(object? sender, EventArgs e)
    {
        if (_position < 4) _position++;
        RefreshAdjustLabels();
    }

    private void OnSizeMinusClicked(object? sender, EventArgs e)
    {
        if (_size > 0) _size--;
        RefreshAdjustLabels();
    }

    private void OnSizePlusClicked(object? sender, EventArgs e)
    {
        if (_size < 4) _size++;
        RefreshAdjustLabels();
    }

    private void OnResetClicked(object? sender, EventArgs e)
    {
        _position = 2;
        _size = 2;
        _selectedStyle = StyleSoftLayer;
        _selectedColor = ColorNatural;
        RefreshSelection();
        RefreshAdjustLabels();
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("photo-selection");
    }

    private async void OnSaveClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("simulation-result");
    }

    private async void OnDeleteClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("photo-selection");
    }
}
