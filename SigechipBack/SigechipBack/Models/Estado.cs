using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigechipBack.Models
{
    [Table("estado")]
    public class Estado
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("estado")]
        public string EstadoValue { get; set; }
    }
}
