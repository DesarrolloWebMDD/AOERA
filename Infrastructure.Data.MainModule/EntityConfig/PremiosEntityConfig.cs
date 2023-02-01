using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class PremiosEntityConfig : IEntityTypeConfiguration<Premios>
    {
        public void Configure(EntityTypeBuilder<Premios> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
