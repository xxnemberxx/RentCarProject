using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //VehicleGetAllTest();
            VehicleManager vehicleManager = new VehicleManager(new EfVehicleDal());
            vehicleManager.GetVehicleDetails().ForEach(
                i => Console.WriteLine($"{i.VehicleId}, {i.LicensePlate}, {i.BrandName}, {i.ModelName}, {i.ColorName}, {i.VehicleType} ,{i.PricePerHr}")
                );
        }

        private static void VehicleGetAllTest()
        {
            VehicleManager vehicleManager = new VehicleManager(new EfVehicleDal());
            vehicleManager.GetAll().ForEach(
                i => Console.WriteLine($"{i.VehicleId}, {i.LicensePlate}, {i.PricePerHr}")
                );
        }
    }
}
