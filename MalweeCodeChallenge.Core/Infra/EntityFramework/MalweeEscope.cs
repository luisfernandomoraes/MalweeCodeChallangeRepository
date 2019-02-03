using System;
using MalweeCodeChallenge.Core.Contracts.Interfaces;
using MalweeCodeChallenge.Core.Extensions;

namespace MalweeCodeChallenge.Core.Infra.EntityFramework
{
    public class MalweeEscope : IRepositoryEscope, IDisposable
    {
        private readonly MalweeContext _context;

        public MalweeEscope(MalweeContext context)
        {
            _context = context;
        }
        public IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            return _context.GetRepository<T>();
        }

        public bool Finish()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception excecao)
            {
                throw new InvalidOperationException("Erro ao finalizar repositorio escopo", excecao);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}