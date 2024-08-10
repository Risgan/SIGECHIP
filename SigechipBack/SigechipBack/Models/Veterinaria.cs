using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigechipBack.Models
{
    [Table("veterinaria")]
    public class Veterinaria
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_veterinario")]
        public int IdVeterinario { get; set; }

        [Column("razon_social")]
        public string RazonSocial { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("id_estado")]
        public int IdEstado { get; set; }

        [ForeignKey("IdVeterinario")]
        public Veterinario Veterinario { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }
    }
}
