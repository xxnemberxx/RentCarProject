using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfRepositoryBase<Color, ProjectDbContext>, IColorDal
    {
        public EfColorDal(ProjectDbContext context) : base(context) { }
    }
}
