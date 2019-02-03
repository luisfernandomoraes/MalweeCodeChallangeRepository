namespace MalweeCodeChallenge.Core.Contracts.Interfaces
{
    public interface IRepositoryEscope
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity;
        bool Finish();
    }
}