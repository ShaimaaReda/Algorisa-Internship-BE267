using Core.Domain.Model;
using System.Linq.Expressions;

namespace Core.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllIncludesAsync(params Expression<Func<T, object>>[] includes);

        Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetByIdAsync(string id);
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T Model);
        Task EditAsync(T Model);
        Task DeleteAsync(string id);
        Task DeleteAsync(T Model);
        Task SaveChanges();

        IEnumerable<T> Top5Specializations();
        IEnumerable<T> Top10Doctors();
        int NumOfRequests();
        int NumOfPations();
        int NumOfDoctors();


    }
}
