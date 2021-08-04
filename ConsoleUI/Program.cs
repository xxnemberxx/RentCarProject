using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
            ////VehicleGetAllTest();
            //VehicleManager vehicleManager = new VehicleManager(new EfVehicleDal());
            //vehicleManager.GetVehicleDetails().Data.ForEach(
            //    i => Console.WriteLine($"{i.VehicleId}, {i.LicensePlate}, {i.BrandName}, {i.ModelName}, {i.ColorName}, {i.VehicleType} ,{i.PricePerHr}")
            //    );
        }

        private static void VehicleGetAllTest()
        {
            VehicleManager vehicleManager = new VehicleManager(new EfVehicleDal());
            vehicleManager.GetAll().Data.ForEach(
                i => Console.WriteLine($"{i.VehicleId}, {i.LicensePlate}, {i.PricePerHr}")
                );
        }
    }
}
