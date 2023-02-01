using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class DeportesEntityConfig : IEntityTypeConfiguration<Deportes>
    {
        public void Configure(EntityTypeBuilder<Deportes> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(x => x.Liga).WithMany(x => x.Deportes).HasForeignKey(f => f.LigaId);
        }
    }
}
