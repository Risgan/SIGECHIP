using SigechipBack.Models;

namespace SigechipBack.Interface.IRespositories
{
    public interface IRolRepository : IGenericRepository<Rol>
    {
        Task<IEnumerable<Rol>> GetActiveRolesAsync();

    }
}
