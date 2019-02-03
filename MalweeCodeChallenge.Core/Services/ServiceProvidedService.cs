using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MalweeCodeChallenge.Core.Contracts.DataObjects;
using MalweeCodeChallenge.Core.Contracts.Enums;
using MalweeCodeChallenge.Core.Contracts.Interfaces;
using MalweeCodeChallenge.Core.Entities;
using MalweeCodeChallenge.Core.Helper;
using MalweeCodeChallenge.Core.Infra.EntityFramework;

namespace MalweeCodeChallenge.Core.Services
{
    public class ServiceProvidedService : IServiceProvidedService
    {
        private readonly MalweeContext _context;

        private readonly IRepositoryEscope _escope;
        private IRepository<ServiceProvided> _supplierRepository;

        //SQL queries
        private const string SqlSupplierAverageByService = @"SELECT  row_number() over (order by Supplier.Name) as Id, Supplier.Name, ServiceProvided.Service, AVG(ServiceProvided.Value) Value
								FROM ServiceProvided 
								INNER JOIN AspNetUsers ON AspNetUsers.Id = ServiceProvided.ServiceProvidedClientId
								INNER JOIN Supplier ON Supplier.IdDbKey = AspNetUsers.SupplierId
								GROUP BY Supplier.Name, ServiceProvided.Service";

        private const string SqlExpensesPerMonth = @"SELECT row_number() over(order by id) as id, UsuariosQueMaisGastaram.Id IdUsuario, UsuariosQueMaisGastaram.Name, DATEPART(MONTH, ServicoPrestado.DateOfService) Month, SUM(ServicoPrestado.Value) Value
								FROM ServiceProvided ServicoPrestado
								INNER JOIN AspNetUsers UsuariosQueMaisGastaram on ServicoPrestado.ServiceProvidedClientId = UsuariosQueMaisGastaram.Id
								GROUP BY UsuariosQueMaisGastaram.Id, UsuariosQueMaisGastaram.Name, DATEPART(MONTH, ServicoPrestado.DateOfService)";

        private const string SqlSupplierServiceByMonth = @"SELECT  row_number() over (order by Supplier.Name) as Id,
								 Supplier.Name, 
								 DATEPART(MONTH,ServiceProvided.DateOfService) Month
								 FROM ServiceProvided 
								 INNER JOIN AspNetUsers ON AspNetUsers.Id = ServiceProvided.ServiceProvidedClientId
								 INNER JOIN Supplier ON Supplier.IdDbKey = AspNetUsers.SupplierId
								 GROUP BY Supplier.Name, Supplier.Name, 
								 DATEPART(MONTH,ServiceProvided.DateOfService)";

        public ServiceProvidedService(MalweeContext context, IRepositoryEscope escope)
        {
            _context = context;
            _escope = escope;
            _supplierRepository = _escope.GetRepository<ServiceProvided>();
        }


        public IQueryable<ServiceProvidedDto> GetAllServicesProvieds()
        {
            return _supplierRepository.GetAll().ProjectTo<ServiceProvidedDto>();
        }

        public void Insert(ServiceProvidedDto serviceProvided)
        {
            var entity = Mapper.Map<ServiceProvided>(serviceProvided);
            _supplierRepository.Add(entity);
        }

        public IQueryable<ServiceProvidedDto> ServicesFiltered(FilterTypeEnum filterType, string filter)
        {
            switch (filterType)
            {
                case FilterTypeEnum.CLIENT:
                    return _supplierRepository.GetAll().Where(x => x.ServiceProvidedClient.Name.Contains(filter)).ProjectTo<ServiceProvidedDto>();
                    break;
                case FilterTypeEnum.STATE:
                    var resultState = Enum.GetValues(typeof(StatesEnum))
                        .Cast<StatesEnum>()
                        .FirstOrDefault(v => v.ToString().Contains(filter));

                    return _supplierRepository.GetAll().Where(x => x.ServiceProvidedClient.State == resultState).ProjectTo<ServiceProvidedDto>();
                    break;
                case FilterTypeEnum.CITY:
                    return _supplierRepository.GetAll().Where(x => x.ServiceProvidedClient.City.Contains(filter)).ProjectTo<ServiceProvidedDto>();
                    break;
                case FilterTypeEnum.NEIGHBORHOOD:
                    return _supplierRepository.GetAll().Where(x => x.ServiceProvidedClient.Neighborhood.Contains(filter)).ProjectTo<ServiceProvidedDto>();
                    break;
                case FilterTypeEnum.SERVICE:
                    ServiceEnum result = Enum.GetValues(typeof(ServiceEnum))
                        .Cast<ServiceEnum>()
                        .FirstOrDefault(v => v.ToString().Contains(filter));

                    return _supplierRepository.GetAll().Where(x => x.Service == result).ProjectTo<ServiceProvidedDto>();
                    break;
                case FilterTypeEnum.MIN_VALUE:
                    var resultTryParseMin = decimal.TryParse(filter, out decimal @decimalMin);
                    if (resultTryParseMin)
                        return _supplierRepository.GetAll().Where(x => x.Value > @decimalMin)
                            .ProjectTo<ServiceProvidedDto>();
                    break;
                case FilterTypeEnum.MAX_VALUE:
                    var resultTryParseMax = decimal.TryParse(filter, out decimal @decimalMax);
                    if (resultTryParseMax)
                        return _supplierRepository.GetAll().Where(x => x.Value < @decimalMax)
                            .ProjectTo<ServiceProvidedDto>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(filterType), filterType, null);
            }
            return _supplierRepository.GetAll().ProjectTo<ServiceProvidedDto>();
        }

        public IQueryable<SupplierAverageByServiceDto> GetSupplierAverageByService()
        {
            return _context.Database.SqlQuery<SupplierAverageByServiceDto>(SqlSupplierAverageByService).AsQueryable();
        }

        public IQueryable<SupplierServiceByMonthDto> GetSupplierServiceByMonth()
        {
            return _context.Database.SqlQuery<SupplierServiceByMonthDto>(SqlSupplierServiceByMonth).AsQueryable();
        }

        public IQueryable<ExpensesPerMonthDto> GetExpensesPerMonth()
        {
            return _context.Database.SqlQuery<ExpensesPerMonthDto>(SqlExpensesPerMonth).AsQueryable();

        }
    }
}