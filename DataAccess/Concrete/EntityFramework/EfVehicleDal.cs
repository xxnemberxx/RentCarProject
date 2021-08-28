using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfVehicleDal : EfRepositoryBase<Vehicle, ProjectDbContext>, IVehicleDal
    {
        public EfVehicleDal(ProjectDbContext context) : base(context) { }
        public List<VehicleDetailDto> GetVehicleDetails()
        {
            var result = from v in base.Context.Vehicles
                         join m in base.Context.Models on v.ModelId equals m.ModelId
                         join b in base.Context.Brands on m.BrandId equals b.BrandId
                         join type in base.Context.ModelTypes on m.TypeId equals type.TypeId
                         join color in base.Context.Colors on v.ColorId equals color.ColorId
                         select new VehicleDetailDto
                         {
                             VehicleId = v.VehicleId,
                             LicensePlate = v.LicensePlate,
                             BrandName = b.BrandName,
                             ColorName = color.ColorName,
                             ModelName = m.ModelName,
                             PricePerHr = v.PricePerHr,
                             VehicleType = type.TypeName
                         };

            return result.ToList();
        }
    }
}
