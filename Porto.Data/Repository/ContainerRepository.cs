using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Porto.Business.Interfaces;
using Porto.Business.Model;
using Porto.Data.DataContext;

namespace Porto.Data.Repository
{
    public class ContainerRepository : IContainerRepository
    {
        public readonly PortoContext _context;
        public ContainerRepository(PortoContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Container[]> GetAll()
        {
           var query = _context.Containers
           .Include(x => x.Movimentos);

           return await query.ToArrayAsync();
        }

        public async Task<Container> GetById(int id)
        {
            var query = _context.Containers
            .Include(x => x.Movimentos)
            .Where(x => x.Id == id);


           return await query.FirstOrDefaultAsync();
        }
    }
}