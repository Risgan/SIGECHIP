using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Services
{
    public class TipoDocumentoService : GenericService<TipoDocumento>, ITipoDocumentoService
    {
        private readonly ITipoDocumentoRepository _repository;

        public TipoDocumentoService(ITipoDocumentoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

