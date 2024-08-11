using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Services
{
    public class HistorialService : GenericService<Historial>, IHistorialService
    {
        private readonly IHistorialRepository _repository;

        public HistorialService(IHistorialRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
