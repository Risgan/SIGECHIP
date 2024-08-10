using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigechipBack.Models
{
    [Table("historial")]
    public class Historial
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_paciente")]
        public int IdPaciente { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [ForeignKey("IdPaciente")]
        public Paciente Paciente { get; set; }
    }
}
