using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Services
{
    public class RecomendacionService : GenericService<Recomendacion>, IRecomendacionService
    {
        private readonly IRecomendacionRepository _repository;

        public RecomendacionService(IRecomendacionRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
