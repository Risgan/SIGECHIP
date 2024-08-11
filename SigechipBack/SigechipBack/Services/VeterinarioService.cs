using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Services
{
    public class VeterinarioService : GenericService<Veterinario>, IVeterinarioService
    {
        private readonly IVeterinarioRepository _repository;

        public VeterinarioService(IVeterinarioRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
