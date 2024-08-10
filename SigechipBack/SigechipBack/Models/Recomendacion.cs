using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigechipBack.Models
{
    [Table("recomendacion")]
    public class Recomendacion
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_veterinario")]
        public int IdVeterinario { get; set; }

        [Column("id_paciente")]
        public int IdPaciente { get; set; }

        [Column("recomendacion")]
        public string RecomendacionText { get; set; }

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
