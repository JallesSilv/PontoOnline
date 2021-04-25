using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Config;
using System.Data.SqlClient;

namespace Repositorio.Contexto
{
    public class PontoDbContext: DbContext
    {
        public PontoDbContext(DbContextOptions<PontoDbContext> options) : base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringBuillder = new SqlConnectionStringBuilder()
            {
                DataSource = XConfig.DataSource,
                InitialCatalog = XConfig.InitialCatalog,
                UserID = XConfig.UserID,
                Password = XConfig.Password
            };
            optionsBuilder.UseSqlServer(stringBuillder.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<NivelAcesso> NivelAcesso { get; set; }
        public DbSet<Ponto> Ponto { get; set; }
        public DbSet<PontoHistorico> PontoHistorico { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
    }
}
