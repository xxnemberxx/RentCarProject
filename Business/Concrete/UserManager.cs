using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public async Task<IResult> AddAsync(User user)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            await _userDal.AddAsync(user);
            await _userDal.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<User>> GetByMailAsync(string email)
        {
            return new SuccessDataResult<User>
                (await _userDal.SingleOrDefaultAsync(u => u.Email == email));
        }
    }
}
