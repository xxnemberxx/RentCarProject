using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfReservationDal : EfRepositoryBase<Reservation, ProjectDbContext>, IReservationDal
    {
        public EfReservationDal(ProjectDbContext context) : base(context) { }
    }
}
