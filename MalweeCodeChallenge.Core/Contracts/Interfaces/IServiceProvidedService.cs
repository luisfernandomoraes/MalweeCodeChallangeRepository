using System.Linq;
using MalweeCodeChallenge.Core.Contracts.DataObjects;
using MalweeCodeChallenge.Core.Services;

namespace MalweeCodeChallenge.Core.Contracts.Interfaces
{
    public interface IServiceProvidedService
    {
        IQueryable<ServiceProvidedDto> GetAllServicesProvieds();

        void Insert(ServiceProvidedDto serviceProvided);

        IQueryable<ServiceProvidedDto> ServicesFiltered(FilterTypeEnum filterType, string filter);

        IQueryable<SupplierAverageByServiceDto> GetSupplierAverageByService();

        IQueryable<SupplierServiceByMonthDto> GetSupplierServiceByMonth();
        IQueryable<ExpensesPerMonthDto> GetExpensesPerMonth();
    }
}