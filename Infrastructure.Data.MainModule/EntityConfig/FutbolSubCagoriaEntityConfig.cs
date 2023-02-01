using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class FutbolSubCagoriaEntityConfig : IEntityTypeConfiguration<FutbolSubCagoria>
    {
        public void Configure(EntityTypeBuilder<FutbolSubCagoria> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(x => x.CategoriaFutbol).WithMany(x => x.FutbolSubCagorias).HasForeignKey(x => x.CategoriaFutbolId);
        }
    }
}
