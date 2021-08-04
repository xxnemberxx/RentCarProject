using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Business Layer
            builder.RegisterType<VehicleManager>().As<IVehicleService>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<ReservationManager>().As<IReservationService>().SingleInstance();
            builder.RegisterType<ModelManager>().As<IModelService>().SingleInstance();
            builder.RegisterType<ModelTypeManager>().As<IModelTypeService>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();

            // DataAccess Layer
            builder.RegisterType<EfVehicleDal>().As<IVehicleDal>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<EfReservationDal>().As<IReservationDal>().SingleInstance();
            builder.RegisterType<EfModelDal>().As<IModelDal>().SingleInstance();
            builder.RegisterType<EfModelTypeDal>().As<IModelTypeDal>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
        }
    }
}
