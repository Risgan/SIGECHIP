using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Services
{
    public class FormulaService : GenericService<Formula>, IFormulaService
    {
        private readonly IFormulaRepository _repository;

        public FormulaService(IFormulaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
