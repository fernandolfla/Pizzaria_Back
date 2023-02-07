using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pizzaria_back.Models;
using System.Reflection.Emit;

namespace Pizzaria_back.Repository.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(x => x.Id).UseIdentityAlwaysColumn();

            builder.Property(x => x.Nome).HasMaxLength(255)
                                         .IsRequired();

            builder.Property(x => x.Preco).IsRequired();

            builder.Property(x => x.Ativo).HasDefaultValue(true);

            builder.Property(x => x.Imagem).HasMaxLength(255)
                                           .IsRequired();
        }
    }
}
