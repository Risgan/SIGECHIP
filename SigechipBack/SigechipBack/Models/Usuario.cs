using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigechipBack.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_tipo_documento")]
        public int IdTipoDocumento { get; set; }

        [Column("documento")]
        public int Documento { get; set; }

        [Column("correo")]
        public string Correo { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("primer_nombre")]
        public string PrimerNombre { get; set; }

        [Column("segundo_nombre")]
        public string SegundoNombre { get; set; }

        [Column("primer_apellido")]
        public string PrimerApellido { get; set; }

        [Column("segundo_apellido")]
        public string SegundoApellido { get; set; }

        [Column("rol")]
        public int Rol { get; set; }

        [Column("foto")]
        public string Foto { get; set; }

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [ForeignKey("IdTipoDocumento")]
        public TipoDocumento TipoDocumento { get; set; }

        [ForeignKey("Rol")]
        public Rol RolNavigation { get; set; }
    }
}
