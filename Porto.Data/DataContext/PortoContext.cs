using Microsoft.EntityFrameworkCore;
using Porto.Business.Model;

namespace Porto.Data.DataContext
{
    public class PortoContext : DbContext
    {
        public PortoContext(DbContextOptions<PortoContext> options) : base(options) { }

        public DbSet<Container> Containers { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }
    }
}