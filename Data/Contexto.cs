using Microsoft.EntityFrameworkCore;

namespace banheiro_livre
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Banheiro> Banheiros { get; set; }
        public DbSet<LimpezaBanheiro> LimpezaBanheiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BanheiroMap());
            modelBuilder.ApplyConfiguration(new LimpezaBanheiroMap());
        }
    }
}