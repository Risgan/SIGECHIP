using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Models;

namespace SigechipBack.Repositories
{
    public class TipoDocumentoRepository : GenericRepository<TipoDocumento>, ITipoDocumentoRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoDocumentoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
