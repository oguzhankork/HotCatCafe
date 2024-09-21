using HotCatCafe.Model.Base;

namespace HotCatCafe.BLL.Repositories.Abstracts.BaseAbstracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();

        T GetByID(int id);

        IEnumerable<T> GetActives();

        IEnumerable<T> GetPassives();

        Task<string> DestroyData(T entity);

        Task<string> Create(T entity);

        Task<string> Update(T entity);

        Task<string>? Delete(T entity);

    }
}
