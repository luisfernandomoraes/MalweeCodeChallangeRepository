using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MalweeCodeChallenge.Core.Contracts.DataObjects;
using MalweeCodeChallenge.Core.Contracts.Interfaces;
using MalweeCodeChallenge.Core.Entities;

namespace MalweeCodeChallenge.Core.Services
{
    public class SupplierService:ISupplierService
    {
        private readonly IRepositoryEscope _escope;
        private IRepository<Supplier> _supplierRepository;

        public SupplierService(IRepositoryEscope escope)
        {
            _escope = escope;
            _supplierRepository = _escope.GetRepository<Supplier>();
        }

        public IQueryable<SupplierDto> GetAllSuppliers()
        {
            return _supplierRepository.GetAll().ProjectTo<SupplierDto>();
        }

        public void Insert(SupplierDto serviceProvided)
        {
            var entity = Mapper.Map<Supplier>(serviceProvided);
            _supplierRepository.Add(entity);
        }
    }
}