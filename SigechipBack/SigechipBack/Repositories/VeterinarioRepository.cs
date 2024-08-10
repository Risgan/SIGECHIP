using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Models;

namespace SigechipBack.Repositories
{
    public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinarioRepository
    {
        private readonly ApplicationDbContext _context;

        public VeterinarioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
