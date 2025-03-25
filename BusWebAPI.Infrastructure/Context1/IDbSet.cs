using BusWebAPI.Domain.Common;

namespace BusWebAPI.Infrastructure.Context1
{
    public interface IDbSet<T> where T : class, IEntiryBase, new()
    {
        T Get(int key);
        IEnumerable<T> GetList();
        T Add(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}
