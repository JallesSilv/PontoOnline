using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Contexto
{
    public class PontoDbContext: DbContext
    {
        public PontoDbContext(DbContextOptions<PontoDbContext> options) : base(options) 
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            //modelBuilder.Entity<Usuario>()
            //    .Property(b => b.Empresa)
            //    .IsRequired();
        //}

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<NivelAcesso> NivelAcesso { get; set; }
        public DbSet<Ponto> Ponto { get; set; }
        public DbSet<PontoHistorico> PontoHistorico { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
    }
}
