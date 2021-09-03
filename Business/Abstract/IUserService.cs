using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        Task<IResult> AddAsync(User user);
        Task<IDataResult<User>> GetByMailAsync(string email);
    }
}
