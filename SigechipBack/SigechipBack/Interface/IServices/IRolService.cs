using SigechipBack.Models;

namespace SigechipBack.Interface.IServices
{
    public interface IRolService : IGenericService<Rol>
    {
        Task<IEnumerable<Rol>> GetActiveRolesAsync();

    }
}
