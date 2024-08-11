using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Services
{
    public class PacienteService : GenericService<Paciente>, IPacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
