using Microsoft.EntityFrameworkCore;

namespace banheiro_livre
{
    public class Contexto: DbContext
    {
        //dotnet ef database drop
        //dotnet ef migrations add Initial
        //dotnet ef database update

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Banheiro> Banheiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BanheiroMap());
        }
    }
}