using MonicaSalon.Models;
using MonicaSalon.Services;
using MonicaSalon.ViewModels;
namespace MonicaSalon.ViewModels.Customer;
public class HomeViewModel : BaseViewModel
{
    public List<ServiceItem> PopularServices { get; } = MockDataService.Services.Take(3).ToList();
}
