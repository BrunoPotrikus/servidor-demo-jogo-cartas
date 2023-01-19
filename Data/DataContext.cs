using Microsoft.EntityFrameworkCore;
using ServidorDemoJogoCartas.Data.Mappings;
using ServidorDemoJogoCartas.Models;

namespace ServidorDemoJogoCartas.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Personagem> Personagens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;" +
                                 "Database=JogoCartas;" +
                                 "User ID=sa;" +
                                 "Password=H2g@5dT$;" +
                                 "Trusted_Connection=False;" +
                                 "TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new PersonagemMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
