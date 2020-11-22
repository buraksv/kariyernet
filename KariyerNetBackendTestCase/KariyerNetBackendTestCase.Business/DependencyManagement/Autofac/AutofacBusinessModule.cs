using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using KariyerNetBackendTestCase.Business.DataAccess.Abstract;
using KariyerNetBackendTestCase.Business.DataAccess.Implementation;
using KariyerNetBackendTestCase.Core.Utilities.Interceptors;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.DataAccess.Implementation;

namespace KariyerNetBackendTestCase.Business.DependencyManagement.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyManager>().As<ICompanyManager>();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();

            builder.RegisterType<CompanyJobAdvertisementManager>().As<ICompanyJobAdvertisementManager>();
            builder.RegisterType<EfCompanyJobAdvertisementDal>().As<ICompanyJobAdvertisementDal>();

            builder.RegisterType<JobApplicationManager>().As<IJobApplicationManager>();
            builder.RegisterType<EfJobApplicationDal>().As<IJobApplicationDal>();

            builder.RegisterType<UserCvManager>().As<IUserCvManager>();
            builder.RegisterType<EfUserCvDal>().As<IUserCvDal>();
            
            builder.RegisterType<UserCvEducationManager>().As<IUserCvEducationManager>();
            builder.RegisterType<EfUserCvEducationDal>().As<IUserCvEducationDal>();

            builder.RegisterType<UserCvWorkExperienceManager>().As<IUserCvWorkExperienceManager>();
            builder.RegisterType<EfUserCvWorkingExperienceDal>().As<IUserCvWorkExperienceDal>();

            builder.RegisterType<UserManager>().As<IUserManager>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
