using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Movie.Api.DI;

namespace Movie.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            config.DependencyResolver = new AutofacWebApiDependencyResolver(DIContainer.Build(config));
            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

        }
    }
}
