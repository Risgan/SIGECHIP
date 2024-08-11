using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Services
{
    public class VacunasService : GenericService<Vacunas>, IVacunasService
    {
        private readonly IVacunasRepository _repository;

        public VacunasService(IVacunasRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
