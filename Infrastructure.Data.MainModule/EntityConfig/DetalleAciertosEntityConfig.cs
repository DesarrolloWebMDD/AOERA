using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    class DetalleAciertosEntityConfig : IEntityTypeConfiguration<DetalleAciertos>
    {
        public void Configure(EntityTypeBuilder<DetalleAciertos> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(x => x.Acierto).WithMany(x => x.DetalleAciertos).HasForeignKey(f => f.AciertoId);
            builder.HasOne(p => p.Deporte).WithMany().HasForeignKey(x => x.DeporteId);
        }
    }
}
