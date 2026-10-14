using MonicaSalon.Models;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class ServiceOption : BaseViewModel
{
    public ServiceItem Service { get; }

    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set => SetProperty(ref _isSelected, value);
    }

    public ServiceOption(ServiceItem service, bool selected)
    {
        Service = service;
        _isSelected = selected;
    }
}
