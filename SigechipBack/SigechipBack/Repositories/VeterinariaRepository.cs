using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Models;

namespace SigechipBack.Repositories
{
    public class VeterinariaRepository : GenericRepository<Veterinaria>, IVeterinariaRepository
    {
        private readonly ApplicationDbContext _context;

        public VeterinariaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
