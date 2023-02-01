using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class DeporteResultadosEntityConfig : IEntityTypeConfiguration<DeporteResultados>
    {
        public void Configure(EntityTypeBuilder<DeporteResultados> builder)
        {
            builder.HasKey(p => p.Id);
            //builder.HasOne(p => p.Deporte).WithMany().HasForeignKey(x => x.DeporteId);
        }
    }
}
