using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class MaestroDetalleEntityConfig : IEntityTypeConfiguration<MaestroDetalle>
    {
        public void Configure(EntityTypeBuilder<MaestroDetalle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Maestro).WithMany(x => x.MaestroDetalleLista).HasForeignKey(f => f.IdMaestro);
        }
    }
}