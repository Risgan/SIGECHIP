using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Models;

namespace SigechipBack.Repositories
{
    public class CodeQRRepository : GenericRepository<CodeQR>, ICodeQRRepository
    {
        private readonly ApplicationDbContext _context;

        public CodeQRRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
