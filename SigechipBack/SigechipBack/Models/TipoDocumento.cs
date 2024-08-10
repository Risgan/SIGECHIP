using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigechipBack.Models
{
    [Table("tipo_documento")]
    public class TipoDocumento
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("sigla")]
        public string Sigla { get; set; }

        [Column("documento")]
        public string Documento { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;
    }
}
