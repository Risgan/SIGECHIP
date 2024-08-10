using Microsoft.EntityFrameworkCore;
using SigechipBack.Models;

namespace SigechipBack.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Agrega aquí tus DbSets para cada entidad

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Historial> Historiales { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }
        public DbSet<Recomendacion> Recomendaciones { get; set; }
        public DbSet<Formula> Formulas { get; set; }
        public DbSet<Evidencias> Evidencias { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Vacunas> Vacunas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<CodeQR> CodesQR { get; set; }
        public DbSet<Veterinaria> Veterinarias { get; set; }

    }
}
