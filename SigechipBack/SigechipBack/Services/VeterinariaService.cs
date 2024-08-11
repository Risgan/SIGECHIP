using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Services
{
    public class VeterinariaService : GenericService<Veterinaria>, IVeterinariaService
    {
        private readonly IVeterinariaRepository _repository;

        public VeterinariaService(IVeterinariaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
