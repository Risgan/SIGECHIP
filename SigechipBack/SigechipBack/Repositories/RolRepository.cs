using Microsoft.EntityFrameworkCore;
using SigechipBack.Data;
using SigechipBack.Interface.IRespositories;
using SigechipBack.Models;

namespace SigechipBack.Repositories
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        private readonly ApplicationDbContext _context;

        public RolRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> GetActiveRolesAsync()
        {
            return await _context.Roles
                .Where(r => r.Activo)
                .ToListAsync();
        }
    }
}
