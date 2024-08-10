using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Models;

namespace SigechipBack.Repositories
{
    public class EstadoRepository : GenericRepository<Estado>, IEstadoRepository
    {
        private readonly ApplicationDbContext _context;

        public EstadoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
