using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Movie.Api.Providers.DataBase;

namespace Movie.Api.App_Start
{
    public class DiConfiguration
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //DI Registrations here

            builder.Register(c => new DataBaseConnectionProvider("localhost", "movie.api", "TheDAX", "QWERTY12345"))
                .As<IDataBaseConnectionProvider>()
                .InstancePerRequest();

            
            //

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}