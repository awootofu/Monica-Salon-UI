using System.Collections;
using System.Collections.ObjectModel;

namespace MonicaSalon.Views.Shared;

public partial class SearchableDropdown : ContentView
{
    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
        nameof(ItemsSource), typeof(IList), typeof(SearchableDropdown), null,
        propertyChanged: (b, _, _) => ((SearchableDropdown)b).RefreshFiltered());

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        nameof(SelectedItem), typeof(object), typeof(SearchableDropdown), null,
        BindingMode.TwoWay,
        propertyChanged: (b, _, _) => ((SearchableDropdown)b).RefreshDisplay());

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        nameof(Placeholder), typeof(string), typeof(SearchableDropdown), "Pilih...",
        propertyChanged: (b, _, _) => ((SearchableDropdown)b).RefreshDisplay());

    public static readonly BindableProperty SearchPlaceholderProperty = BindableProperty.Create(
        nameof(SearchPlaceholder), typeof(string), typeof(SearchableDropdown), "Cari...");

    public static readonly BindableProperty IsOpenProperty = BindableProperty.Create(
        nameof(IsOpen), typeof(bool), typeof(SearchableDropdown), false);

    public static readonly BindableProperty DisplayTextProperty = BindableProperty.Create(
        nameof(DisplayText), typeof(string), typeof(SearchableDropdown), "Pilih...");

    public IList? ItemsSource
    {
        get => (IList?)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public object? SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public string SearchPlaceholder
    {
        get => (string)GetValue(SearchPlaceholderProperty);
        set => SetValue(SearchPlaceholderProperty, value);
    }

    public bool IsOpen
    {
        get => (bool)GetValue(IsOpenProperty);
        set
        {
            SetValue(IsOpenProperty, value);
            ChevronLabel.Text = value ? "⌃" : "⌄";
        }
    }

    public string DisplayText
    {
        get => (string)GetValue(DisplayTextProperty);
        private set => SetValue(DisplayTextProperty, value);
    }

    public ObservableCollection<object> FilteredItems { get; } = new();

    public SearchableDropdown()
    {
        InitializeComponent();
        RefreshDisplay();
        RefreshFiltered();
    }

    private void OnHeaderTapped(object? sender, TappedEventArgs e)
    {
        IsOpen = !IsOpen;
        if (IsOpen)
            SearchEntry.Text = string.Empty;
    }

    private void OnSearchChanged(object? sender, TextChangedEventArgs e) => RefreshFiltered();

    private void OnOptionTapped(object? sender, TappedEventArgs e)
    {
        if (sender is View v && v.GestureRecognizers.FirstOrDefault() is TapGestureRecognizer t)
            SelectedItem = t.CommandParameter;
        else if (e.Parameter is object p)
            SelectedItem = p;
        IsOpen = false;
    }

    private void RefreshDisplay() =>
        DisplayText = SelectedItem?.ToString() ?? Placeholder;

    private void RefreshFiltered()
    {
        var query = SearchEntry?.Text?.Trim() ?? string.Empty;
        // Map kembali ke object asli agar SelectedItem bertipe benar.
        var source = ItemsSource?.Cast<object>().ToList() ?? new List<object>();
        FilteredItems.Clear();
        foreach (var item in source)
        {
            var text = item?.ToString() ?? string.Empty;
            if (query.Length == 0 || text.Contains(query, StringComparison.OrdinalIgnoreCase))
                FilteredItems.Add(item!);
        }
    }
}
