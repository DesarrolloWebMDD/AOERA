using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class AciertosEntityConfig : IEntityTypeConfiguration<Aciertos>
    {
        public void Configure(EntityTypeBuilder<Aciertos> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
