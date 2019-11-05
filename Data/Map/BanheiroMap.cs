using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace banheiro_livre
{
    public class BanheiroMap : IEntityTypeConfiguration<Banheiro>
    {
        public void Configure(EntityTypeBuilder<Banheiro> builder)
        {
            builder.ToTable("Banheiro");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}