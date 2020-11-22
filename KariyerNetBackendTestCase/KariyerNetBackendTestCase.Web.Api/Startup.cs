using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using KariyerNetBackendTestCase.Business.DependencyManagement.Autofac;
using KariyerNetBackendTestCase.Business.Mappings.AutoMapper;
using KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KariyerNetBackendTestCase.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<KariyerNetBackendTestCaseDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("KariyerNetBackendTestCase"));
               
            });

            services.AddAutoMapper(typeof(EntityToDtoMapper));
            services.AddOptions();

            services.AddControllers();

        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
             
            builder.RegisterModule(new AutofacBusinessModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<KariyerNetBackendTestCaseDbContext>()?.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
