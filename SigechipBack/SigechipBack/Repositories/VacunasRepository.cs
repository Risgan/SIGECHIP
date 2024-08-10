using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Models;

namespace SigechipBack.Repositories
{
    public class VacunasRepository : GenericRepository<Vacunas>, IVacunasRepository
    {
        private readonly ApplicationDbContext _context;

        public VacunasRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
