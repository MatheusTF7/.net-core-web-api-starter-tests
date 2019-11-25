using Microsoft.EntityFrameworkCore;

namespace ProjetoWebVale.Models
{
    public class ProjetoWebValeDbContext : DbContext
    {
        public ProjetoWebValeDbContext(DbContextOptions<ProjetoWebValeDbContext> options) : base(options) { }
        
        public DbSet<Valor> valores { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Task> Task { get; set; }

    }
}