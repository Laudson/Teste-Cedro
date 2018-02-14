using Core.Comum.Comum;
using Microsoft.EntityFrameworkCore;

namespace Core.Dominio.Comum
{

    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RestauranteDTO> Restaurante { get; set; }
        public virtual DbSet<PratosDTO> Pratos { get; set; }
        public virtual DbSet<AutenticacaoDTO> Autenticacao { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            
        }
    }
}
