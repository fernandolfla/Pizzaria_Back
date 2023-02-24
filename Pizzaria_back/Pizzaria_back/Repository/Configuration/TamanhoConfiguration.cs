using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository.Configuration
{
    public class TamanhoConfiguration : IEntityTypeConfiguration<Tamanho>
    {
        public void Configure(EntityTypeBuilder<Tamanho> builder)
        {
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.Nome).HasMaxLength(255)
                                         .IsRequired();
        }

    }
}
