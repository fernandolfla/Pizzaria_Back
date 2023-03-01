using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository.Configuration
{  
        public class CategoriaConfiguration : BaseConfiguration, IEntityTypeConfiguration<Categoria>
        {
            public void Configure(EntityTypeBuilder<Categoria> builder)
            {
                builder.Property(x => x.Nome).HasMaxLength(255)
                                             .IsRequired();
            }

        }
}