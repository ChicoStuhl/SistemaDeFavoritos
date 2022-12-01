using Microsoft.EntityFrameworkCore;
using SistemaDeFavoritos.Models;

namespace SistemaDeFavoritos.Data
{
    public class SistemaDeFavoritosDBContext : DbContext
    {
        public SistemaDeFavoritosDBContext(DbContextOptions<SistemaDeFavoritosDBContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<FilmeModel> Filmes { get; set; }
        public DbSet<LivroModel> Livros { get; set; }   
        public DbSet<JogoModel> Jogos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
