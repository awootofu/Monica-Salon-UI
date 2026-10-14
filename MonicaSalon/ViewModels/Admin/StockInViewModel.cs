using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class StockInViewModel : BaseViewModel
{
    public int CurrentStock => 4;
    public string Unit => "botol";

    public List<string> Reasons { get; } = new() { "Supplier delivery", "Return", "Stock correction" };

    private string _selectedReason = "Supplier delivery";
    public string SelectedReason
    {
        get => _selectedReason;
        set => SetProperty(ref _selectedReason, value ?? "Supplier delivery");
    }

    private string _qtyText = string.Empty;
    public string QtyText
    {
        get => _qtyText;
        set
        {
            if (SetProperty(ref _qtyText, value ?? string.Empty))
                UpdatePreview();
        }
    }

    private string _previewText = "Stok akhir: 4 botol";
    public string PreviewText
    {
        get => _previewText;
        private set => SetProperty(ref _previewText, value ?? string.Empty);
    }

    private string _savedDetail = "Stok diperbarui.";
    public string SavedDetail
    {
        get => _savedDetail;
        private set => SetProperty(ref _savedDetail, value ?? string.Empty);
    }

    private bool _isSaved;
    public bool IsSaved
    {
        get => _isSaved;
        private set => SetProperty(ref _isSaved, value);
    }

    private void UpdatePreview()
    {
        if (int.TryParse(QtyText, out var qty) && qty > 0)
            PreviewText = $"Stok akhir: {CurrentStock + qty} {Unit}";
        else
            PreviewText = $"Stok akhir: {CurrentStock} {Unit}";
    }

    public void Save()
    {
        int.TryParse(QtyText, out int qty);
        int finalStock = CurrentStock + Math.Max(0, qty);
        SavedDetail = $"Stok akhir: {finalStock} {Unit}.";
        PreviewText = SavedDetail;
        IsSaved = true;
    }
}
