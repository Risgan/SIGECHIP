using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigechipBack.Models
{
    [Table("vacunas")]
    public class Vacunas
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_paciente")]
        public int IdPaciente { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("fecha_proxima")]
        public DateTime FechaProxima { get; set; }

        [ForeignKey("IdPaciente")]
        public Paciente Paciente { get; set; }
    }
}
