using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModelDal : EfRepositoryBase<Model, ProjectDbContext>, IModelDal
    {
        public EfModelDal(ProjectDbContext context) : base(context) { }
    }
}
