using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class TokenTarjetaPagoEntityConfig : IEntityTypeConfiguration<TokenTarjetaPago>
    {
        public void Configure(EntityTypeBuilder<TokenTarjetaPago> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
