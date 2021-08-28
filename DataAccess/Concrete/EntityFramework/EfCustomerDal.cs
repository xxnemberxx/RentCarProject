using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfRepositoryBase<Customer, ProjectDbContext>, ICustomerDal
    {
        public EfCustomerDal(ProjectDbContext context) : base(context) { }
    }
}
