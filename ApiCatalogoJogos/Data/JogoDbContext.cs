using ApiCatalogoJogos.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiCatalogoJogos.Data
{
    public class JogoDbContext : DbContext
    {
        public JogoDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Jogo> Jogo { get; set; }
    }
}
