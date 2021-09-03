using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<User, ProjectDbContext>, IUserDal
    {
        public EfUserDal(ProjectDbContext context) : base(context) { }

        public List<OperationClaim> GetClaims(User user)
        {
            var result = from operationClaim in base.Context.OperationClaims
                         join userOperationClaim in base.Context.UserOperationClaims
                         on operationClaim.ClaimId equals userOperationClaim.ClaimId
                         where userOperationClaim.UserId == user.UserId
                         select new OperationClaim
                         {
                             ClaimId = operationClaim.ClaimId,
                             Name = operationClaim.Name
                         };

            return result.ToList();
        }

    }
}
