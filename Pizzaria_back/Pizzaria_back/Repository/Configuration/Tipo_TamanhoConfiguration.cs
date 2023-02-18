using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository.Configuration
{
    public class Tipo_TamanhoConfiguration : IEntityTypeConfiguration<Tipo_Tamanho>
    {
        public void Configure(EntityTypeBuilder<Tipo_Tamanho> builder)
        {
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.Preco).IsRequired();
        }

    }
}
