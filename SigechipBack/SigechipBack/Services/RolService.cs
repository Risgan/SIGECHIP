using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Services
{
    public class RolService : GenericService<Rol>, IRolService
    {
        private readonly IRolRepository _repository;

        public RolService(IRolRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Rol>> GetActiveRolesAsync()
        {
            return await _repository.GetActiveRolesAsync();
        }
    }
}
