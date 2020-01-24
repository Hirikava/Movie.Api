using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Movie.Api.Clients;
using Movie.Api.Clients.Movies;
using Movie.Api.Clients.Sessions;
using Movie.Api.Providers.Authorization;
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
            builder.RegisterHttpRequestMessage(GlobalConfiguration.Configuration);

            builder.Register(c => new DataBaseConnectionProvider("localhost", "movie.api", "TheDAX", "QWERTY12345"))
                .As<IDataBaseConnectionProvider>()
                .InstancePerRequest();

            builder.Register(c => new UsersClient(c.Resolve<IDataBaseConnectionProvider>()))
                .As<IUsersClient>()
                .InstancePerRequest();

            builder.Register(c => new SessionsClient(c.Resolve<IDataBaseConnectionProvider>()))
                .As<ISessionsClient>()
                .InstancePerRequest();

            builder.Register(c => new MovieClient(c.Resolve<IDataBaseConnectionProvider>()))
                .As<IMovieClient>()
                .InstancePerRequest();

            builder.Register(c =>
                {
                    var authHeader = c.Resolve<HttpRequestMessage>().Headers.Authorization?.ToString();
                    return new SessionAuthorizationProvider(c.Resolve<IDataBaseConnectionProvider>(), authHeader);
                }).As<IAuthorizationProvider>()
                .InstancePerRequest();
            //

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}