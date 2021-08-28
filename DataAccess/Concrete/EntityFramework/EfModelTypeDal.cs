using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModelTypeDal : EfRepositoryBase<ModelType, ProjectDbContext>, IModelTypeDal
    {
        public EfModelTypeDal(ProjectDbContext context) : base(context) { }
    }
}
