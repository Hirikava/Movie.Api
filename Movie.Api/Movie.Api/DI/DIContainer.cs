using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace Movie.Api.DI
{
    public class DIContainer
    {
        public static IContainer Build(HttpConfiguration httpConfig)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers();    
            return builder.Build();
        }
    }
}