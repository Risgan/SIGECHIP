using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Models;

namespace SigechipBack.Repositories
{
    public class RecomendacionRepository : GenericRepository<Recomendacion>, IRecomendacionRepository
    {
        private readonly ApplicationDbContext _context;

        public RecomendacionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
