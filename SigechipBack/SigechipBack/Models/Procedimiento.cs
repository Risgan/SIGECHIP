using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigechipBack.Models
{
    [Table("procedimiento")]
    public class Procedimiento
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_historial")]
        public int IdHistorial { get; set; }

        [Column("id_veterinario")]
        public int IdVeterinario { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; }

        [Column("fecha_fin")]
        public DateTime FechaFin { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("id_estado")]
        public int IdEstado { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [ForeignKey("IdHistorial")]
        public Historial Historial { get; set; }

        [ForeignKey("IdVeterinario")]
        public Veterinario Veterinario { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }
    }
}
