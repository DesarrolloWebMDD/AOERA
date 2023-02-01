using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class ConfiguracionCorreoEntityConfig : IEntityTypeConfiguration<ConfiguracionCorreo>
    {
        public void Configure(EntityTypeBuilder<ConfiguracionCorreo> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
