using Microsoft.AspNetCore.Mvc;

namespace BE_clps.Repositories
{
    public interface ICrudRepository<T>
    {
        IEnumerable<T>? GetAll();
        T? GetByCode(string code);
        bool Create(T entity);
        bool UpdateByCode(string code, T entity);
        bool DeleteByCode(string code);
    }
}
