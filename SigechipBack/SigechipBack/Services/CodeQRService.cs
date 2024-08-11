using SigechipBack.Interface.IRespositories;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Services
{
    public class CodeQRService : GenericService<CodeQR>, ICodeQRService
    {
        private readonly ICodeQRRepository _repository;

        public CodeQRService(ICodeQRRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
