using System.Linq;
using MalweeCodeChallenge.Core.Contracts.DataObjects;
using MalweeCodeChallenge.Core.Entities;

namespace MalweeCodeChallenge.Core.Contracts.Interfaces
{
    public interface ISupplierService
    {
        IQueryable<SupplierDto> GetAllSuppliers();

        void Insert(SupplierDto serviceProvided);
    }
}