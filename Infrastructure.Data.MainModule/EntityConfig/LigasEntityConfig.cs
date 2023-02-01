using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class LigasEntityConfig : IEntityTypeConfiguration<Ligas>
    {
        public void Configure(EntityTypeBuilder<Ligas> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(x => x.FutbolSubCagoria).WithMany(x => x.Ligas).HasForeignKey(x => x.FutbolSubCagoriaId);
        }
    }
}
