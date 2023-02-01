using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class CategoriaFutbolEntityConfig : IEntityTypeConfiguration<CategoriaFutbol>
    {
        public void Configure(EntityTypeBuilder<CategoriaFutbol> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
