using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria_back.Models;
using Pizzaria_back.Models.Enum;

namespace Pizzaria_back.Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Id).UseMySqlIdentityColumn();

            builder.Property(x => x.Ativo).HasDefaultValue(true);

            builder.Property(x => x.Email).HasMaxLength(255)
                                         .IsRequired();

            builder.Property(x => x.Senha).HasMaxLength(255)
                                          .IsRequired();

            builder.Property(x => x.Papel).HasDefaultValue(PapelEnum.Usuario)
                                          .IsRequired();
        }

    }
}
