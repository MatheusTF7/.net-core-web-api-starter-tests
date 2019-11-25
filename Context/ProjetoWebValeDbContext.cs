using Microsoft.EntityFrameworkCore;

namespace ProjetoWebVale.Models {
    public class ProjetoWebValeDbContext : DbContext {
        public ProjetoWebValeDbContext (DbContextOptions<ProjetoWebValeDbContext> options) : base (options) { }
        public DbSet<Valor> valores { get; set; }
    }
}