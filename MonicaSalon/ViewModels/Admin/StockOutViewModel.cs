using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class StockOutViewModel : BaseViewModel
{
    public int CurrentStock => 12;
    public string Unit => "tube";
    public string ErrorText => "Jumlah tidak valid. Maksimal 12 tube.";

    public List<string> Reasons { get; } = new() { "Material usage", "Damaged", "Stock correction" };

    private string _selectedReason = "Material usage";
    public string SelectedReason
    {
        get => _selectedReason;
        set
        {
            if (SetProperty(ref _selectedReason, value ?? "Material usage"))
                IsRelatedVisible = _selectedReason == "Material usage";
        }
    }

    private string _qtyText = string.Empty;
    public string QtyText
    {
        get => _qtyText;
        set
        {
            if (SetProperty(ref _qtyText, value ?? string.Empty))
                UpdateState();
        }
    }

    private string _previewText = "Sisa: 12 tube";
    public string PreviewText
    {
        get => _previewText;
        private set => SetProperty(ref _previewText, value ?? string.Empty);
    }

    private bool _hasError;
    public bool HasError
    {
        get => _hasError;
        private set => SetProperty(ref _hasError, value);
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

    private bool _isRelatedVisible = true;
    public bool IsRelatedVisible
    {
        get => _isRelatedVisible;
        private set => SetProperty(ref _isRelatedVisible, value);
    }

    private void UpdateState()
    {
        if (int.TryParse(QtyText, out var qty) && qty > 0 && qty <= CurrentStock)
        {
            PreviewText = $"Sisa: {CurrentStock - qty} {Unit}";
            HasError = false;
        }
        else
        {
            PreviewText = $"Sisa: {CurrentStock} {Unit}";
            HasError = !string.IsNullOrWhiteSpace(QtyText);
        }
    }

    public bool TrySave()
    {
        if (!int.TryParse(QtyText, out var qty) || qty <= 0 || qty > CurrentStock)
        {
            HasError = true;
            IsSaved = false;
            return false;
        }
        HasError = false;
        SavedDetail = $"Sisa stok: {CurrentStock - qty} {Unit}.";
        PreviewText = SavedDetail;
        IsSaved = true;
        return true;
    }
}
