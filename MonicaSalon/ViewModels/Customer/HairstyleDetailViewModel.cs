using MonicaSalon.Models;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class HairstyleDetailViewModel : BaseViewModel
{
    private string _image = "haircut.jpg";
    public string Image
    {
        get => _image;
        private set => SetProperty(ref _image, value);
    }

    private string _category = string.Empty;
    public string Category
    {
        get => _category;
        private set => SetProperty(ref _category, value);
    }

    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        private set => SetProperty(ref _name, value);
    }

    private string _durationHint = string.Empty;
    public string DurationHint
    {
        get => _durationHint;
        private set => SetProperty(ref _durationHint, value);
    }

    private string _priceHint = string.Empty;
    public string PriceHint
    {
        get => _priceHint;
        private set => SetProperty(ref _priceHint, value);
    }

    private string _description = string.Empty;
    public string Description
    {
        get => _description;
        private set => SetProperty(ref _description, value);
    }

    private string _length = string.Empty;
    public string Length
    {
        get => _length;
        private set => SetProperty(ref _length, value);
    }

    private string _faceDisplay = string.Empty;
    public string FaceDisplay
    {
        get => _faceDisplay;
        private set => SetProperty(ref _faceDisplay, value);
    }

    private string _careDisplay = string.Empty;
    public string CareDisplay
    {
        get => _careDisplay;
        private set => SetProperty(ref _careDisplay, value);
    }

    public void Load(HairstyleItem item)
    {
        Image = item.Image;
        Category = item.Category;
        Name = item.Name;
        DurationHint = item.DurationHint;
        PriceHint = item.PriceHint;
        Description = item.Description;
        Length = item.Length;
        FaceDisplay = $"Cocok untuk wajah {item.FaceShape}";
        CareDisplay = $"Perawatan {item.Maintenance.ToLower()}";
    }
}
