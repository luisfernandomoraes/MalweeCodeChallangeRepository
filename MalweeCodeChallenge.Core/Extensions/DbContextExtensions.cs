using System.Data.Entity;
using MalweeCodeChallenge.Core.Contracts.Interfaces;
using MalweeCodeChallenge.Core.Infra.EntityFramework;

namespace MalweeCodeChallenge.Core.Extensions
{
    public static class DbContextExtensions
    {
        public static IRepository<T> GetRepository<T>(this DbContext dataContext) where T : class, IEntity
        {
            return new Repository<T>(dataContext);
        }
    }
}