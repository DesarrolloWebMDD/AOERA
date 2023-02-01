using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class PagosIzipayEntityConfig : IEntityTypeConfiguration<PagosIzipay>
    {
        public void Configure(EntityTypeBuilder<PagosIzipay> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
