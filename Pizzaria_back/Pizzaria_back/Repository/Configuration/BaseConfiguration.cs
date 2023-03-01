using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository.Configuration
{
    public class BaseConfiguration
    {
        public void Configure(EntityTypeBuilder<DbEntity> builder)
        {
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
        }
    }
}
