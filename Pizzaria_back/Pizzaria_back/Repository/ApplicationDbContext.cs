using Microsoft.EntityFrameworkCore;
using Pizzaria_back.Models;
using System.Reflection;
using System.Xml.Linq;

namespace Pizzaria_back.Repository
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
           // AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{ 
        //    optionsBuilder.UseMySql("Host=real10.postgresql.dbaas.com.br;Database=real10;Username=real10;Password=P@ssword1");
        //}
    }
}
