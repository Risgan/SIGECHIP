using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Services
{
    public class ProcedimientoService : GenericService<Procedimiento>, IProcedimientoService
    {
        private readonly IProcedimientoRepository _repository;

        public ProcedimientoService(IProcedimientoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
