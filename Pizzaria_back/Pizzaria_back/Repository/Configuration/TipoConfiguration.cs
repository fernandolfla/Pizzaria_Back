using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository.Configuration
{
    public class TipoConfiguration : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.Nome).HasMaxLength(255)
                                         .IsRequired();
        }

    }
}
