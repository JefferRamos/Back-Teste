using System.Collections.Generic;
using System.Threading.Tasks;
using Porto.Business.Model;

namespace Porto.Business.Interfaces
{
    public interface IMovimentoRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Movimento[]> GetAll();
        Task<Movimento> GetById(int id);
    }
}