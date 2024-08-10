using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigechipBack.Models
{
    [Table("paciente")]
    public class Paciente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Column("id_tipo_documento")]
        public int IdTipoDocumento { get; set; }

        [Column("documento")]
        public int Documento { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("apellido")]
        public string Apellido { get; set; }

        [Column("edad")]
        public string Edad { get; set; }

        [Column("raza")]
        public string Raza { get; set; }

        [Column("especie")]
        public string Especie { get; set; }

        [Column("foto")]
        public string Foto { get; set; }

        [Column("historia")]
        public string Historia { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdTipoDocumento")]
        public TipoDocumento TipoDocumento { get; set; }
    }
}
