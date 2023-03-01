using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository.Configuration
{
    public class SaborConfiguration : BaseConfiguration, IEntityTypeConfiguration<Sabor>
    {
        public void Configure(EntityTypeBuilder<Sabor> builder)
        {
            builder.Property(x => x.Nome).HasMaxLength(255)
                                         .IsRequired();
        }

    }
}
