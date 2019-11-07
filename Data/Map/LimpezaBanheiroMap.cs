using banheiro_livre.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace banheiro_livre
{
    public class LimpezaBanheiroMap : IEntityTypeConfiguration<LimpezaBanheiro>
    {
        public void Configure(EntityTypeBuilder<LimpezaBanheiro> builder)
        {
            builder.ToTable("LimpezaBanheiro");

            builder.HasKey(c => new { c.Id, c.BanheiroId, c.Dia, c.Servico });

            builder.Property(c => c.BanheiroId)
                .IsRequired();

            builder.Property(c => c.Dia)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.Servico)
                .IsRequired();

            builder.Property(c => c.ManhaInicio)
                .IsRequired();

            builder.Property(c => c.ManhaFinal)
                .IsRequired();

            builder.Property(c => c.TardeInicio)
                .IsRequired();

            builder.Property(c => c.TardeFinal)
                .IsRequired();
        }
    }
}