using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using TestWebAPI_list_.Models;
using TestWebApiRepository;
using TestWebApiRepositoryCommon;
using TestWebApiService;
using TestWebApiServiceCommon;

namespace TestWebAPI_list_.App_Start
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<BuyerService>().As<IBuyerService>();
            builder.RegisterType<BuyerRepository>().As<IBuyerRepository>();
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ControllerMappingProfile());
            }));
            builder.Register(context => context.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().SingleInstance();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
