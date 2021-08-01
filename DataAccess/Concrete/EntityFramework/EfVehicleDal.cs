using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfVehicleDal : EfEntityRepositoryBase<Vehicle, RentCarContext>, IVehicleDal
    {

        public List<VehicleDetailDto> GetVehicleDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from v in context.Vehicles
                             join m in context.Models on v.ModelId equals m.ModelId
                             join b in context.Brands on m.BrandId equals b.BrandId
                             join type in context.ModelTypes on m.TypeId equals type.TypeId
                             join color in context.Colors on v.ColorId equals color.ColorId   
                             select new VehicleDetailDto
                             {
                                 VehicleId = v.VehicleId,
                                 LicensePlate = v.LicensePlate,
                                 BrandName =  b.BrandName,
                                 ColorName = color.ColorName,
                                 ModelName = m.ModelName,
                                 PricePerHr = v.PricePerHr,
                                 VehicleType = type.TypeName
                             };
                return result.ToList();
            }
        }
    }
}
