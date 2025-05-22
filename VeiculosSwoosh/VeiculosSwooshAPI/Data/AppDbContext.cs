using Microsoft.EntityFrameworkCore;
using VeiculosSwooshAPI.Models;


namespace VeiculosSwooshAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Cor> Cores { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

    }
}