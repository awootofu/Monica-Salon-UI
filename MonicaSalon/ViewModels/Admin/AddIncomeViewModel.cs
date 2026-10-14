using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Admin;
public class AddIncomeViewModel : BaseViewModel
{
    private string _category = string.Empty;
    public string Category
    {
        get => _category;
        set => SetProperty(ref _category, value ?? string.Empty);
    }

    private string _amountText = string.Empty;
    public string AmountText
    {
        get => _amountText;
        set => SetProperty(ref _amountText, value ?? string.Empty);
    }

    private string _description = string.Empty;
    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value ?? string.Empty);
    }

    private string _reference = string.Empty;
    public string Reference
    {
        get => _reference;
        set => SetProperty(ref _reference, value ?? string.Empty);
    }

    private string _errorMessage = string.Empty;
    public string ErrorMessage
    {
        get => _errorMessage;
        private set => SetProperty(ref _errorMessage, value ?? string.Empty);
    }

    public void SelectCategory(string category) => Category = category ?? string.Empty;

    public bool TrySave()
    {
        bool amountOk = int.TryParse(AmountText, out int amt) && amt > 0;
        bool descOk = !string.IsNullOrWhiteSpace(Description);
        if (string.IsNullOrEmpty(Category) || !amountOk || !descOk)
        {
            ErrorMessage = "Please select category, enter amount more than 0, and fill description.";
            return false;
        }
        return true;
    }
}
