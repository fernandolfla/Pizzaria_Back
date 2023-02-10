using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria_back.Models;
using System.Reflection.Emit;

namespace Pizzaria_back.Repository.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.Id).UseMySqlIdentityColumn();

            builder.Property(x => x.Nome).HasMaxLength(255)
                                         .IsRequired();
        }
    }
}
