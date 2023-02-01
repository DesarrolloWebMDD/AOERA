using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class PuntosPaqueteEntityConfig : IEntityTypeConfiguration<PuntosPaquete>
    {
        public void Configure(EntityTypeBuilder<PuntosPaquete> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
