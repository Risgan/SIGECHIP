using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigechipBack.Models
{
    [Table("code_qr")]
    public class CodeQR
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_paciente")]
        public int IdPaciente { get; set; }

        [Column("codigo")]
        public string Codigo { get; set; }

        [ForeignKey("IdPaciente")]
        public Paciente Paciente { get; set; }
    }
}
