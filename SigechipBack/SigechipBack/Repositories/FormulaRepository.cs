using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Models;

namespace SigechipBack.Repositories
{
    public class FormulaRepository : GenericRepository<Formula>, IFormulaRepository
    {
        private readonly ApplicationDbContext _context;

        public FormulaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
