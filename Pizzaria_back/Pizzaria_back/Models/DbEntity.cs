using System.ComponentModel.DataAnnotations;

namespace Pizzaria_back.Models
{
    public class DbEntity
    {
        public DbEntity()
        {
            Ativo = true;
        }
        public int Id { get; set; }
        public bool Ativo { get; set; }
    }
}
