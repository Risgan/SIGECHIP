using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Models;

namespace SigechipBack.Repositories
{
    public class ProcedimientoRepository : GenericRepository<Procedimiento>, IProcedimientoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProcedimientoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
