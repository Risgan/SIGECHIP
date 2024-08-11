using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Services
{
    public class EvidenciasService : GenericService<Evidencias>, IEvidenciasService
    {
        private readonly IEvidenciasRepository _repository;

        public EvidenciasService(IEvidenciasRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
