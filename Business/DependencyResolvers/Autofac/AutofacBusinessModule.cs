using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.UnitOfWork;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<VehicleManager>().As<IVehicleService>().SingleInstance();
            builder.RegisterType<VehicleImageManager>().As<IVehicleImageService>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<ReservationManager>().As<IReservationService>().SingleInstance();
            builder.RegisterType<ModelManager>().As<IModelService>().SingleInstance();
            builder.RegisterType<ModelTypeManager>().As<IModelTypeService>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<ProjectDbContext>().As<ProjectDbContext>().SingleInstance();

            builder.RegisterType<EfVehicleDal>().As<IVehicleDal>().SingleInstance();
            builder.RegisterType<EfVehicleImageDal>().As<IVehicleImageDal>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<EfReservationDal>().As<IReservationDal>().SingleInstance();
            builder.RegisterType<EfModelDal>().As<IModelDal>().SingleInstance();
            builder.RegisterType<EfModelTypeDal>().As<IModelTypeDal>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();



            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                });

        }
    }
}
