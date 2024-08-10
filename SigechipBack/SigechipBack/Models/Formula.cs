using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigechipBack.Models
{
    [Table("formula")]
    public class Formula
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_veterinario")]
        public int IdVeterinario { get; set; }

        [Column("id_paciente")]
        public int IdPaciente { get; set; }

        [Column("medicamento")]
        public string Medicamento { get; set; }

        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; }

        [Column("fecha_fin")]
        public DateTime FechaFin { get; set; }

        [Column("dosis")]
        public string Dosis { get; set; }

        [Column("observaciones")]
        public string Observaciones { get; set; }

        [Column("id_estado")]
        public int IdEstado { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [ForeignKey("IdVeterinario")]
        public Veterinario Veterinario { get; set; }

        [ForeignKey("IdPaciente")]
        public Paciente Paciente { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }
    }
}
