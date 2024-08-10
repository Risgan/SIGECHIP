using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigechipBack.Models
{
    [Table("evidencias")]
    public class Evidencias
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_procedimiento")]
        public int IdProcedimiento { get; set; }

        [Column("imagen")]
        public string Imagen { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [ForeignKey("IdProcedimiento")]
        public Procedimiento Procedimiento { get; set; }
    }
}
