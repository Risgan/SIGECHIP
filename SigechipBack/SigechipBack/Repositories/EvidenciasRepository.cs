using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Models;

namespace SigechipBack.Repositories
{
    public class EvidenciasRepository : GenericRepository<Evidencias>, IEvidenciasRepository
    {
        private readonly ApplicationDbContext _context;

        public EvidenciasRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
