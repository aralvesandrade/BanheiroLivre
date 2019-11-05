using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace banheiro_livre
{
    public class LimpezaBanheiroMap : IEntityTypeConfiguration<LimpezaBanheiro>
    {
        public void Configure(EntityTypeBuilder<LimpezaBanheiro> builder)
        {
            builder.ToTable("LimpezaBanheiro");

            builder.HasKey(c => new { c.Id, c.BanheiroId, c.Dia });

            builder.Property(c => c.BanheiroId)
                .IsRequired();

            builder.Property(c => c.Dia)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.Serviço)
                .IsRequired();

            builder.Property(c => c.Inicio)
                .IsRequired();

            builder.Property(c => c.Final)
                .IsRequired();
        }
    }
}