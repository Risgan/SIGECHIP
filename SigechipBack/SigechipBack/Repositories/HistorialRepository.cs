using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Models;

namespace SigechipBack.Repositories
{
    public class HistorialRepository : GenericRepository<Historial>, IHistorialRepository
    {
        private readonly ApplicationDbContext _context;

        public HistorialRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
