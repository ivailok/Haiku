﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Haiku.Web.Filters;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using Haiku.Services;
using Haiku.Data;
using Haiku.Data.Entities;
using Newtonsoft.Json.Serialization;

namespace Haiku.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new ExceptionAttribute());
            config.Filters.Add(new ValidationAttribute());

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            // all routes with ~/api should be resolved by web api 
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

#if DEBUG
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
#else
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Never;
#endif

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            RegisterData(builder);
            RegisterServices(builder);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
                
            config.EnsureInitialized();
        }

        private static void RegisterData(ContainerBuilder builder)
        {
            builder.RegisterType<HaikuContext>().AsSelf().As<IDbContext>().InstancePerRequest();
            builder.RegisterGeneric(typeof(DbAsyncRepository<>)).As(typeof(IAsyncRepository<>)).InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<UsersService>().As<IUsersService>().InstancePerRequest();
            builder.RegisterType<HaikusService>().As<IHaikusService>().InstancePerRequest();
            builder.RegisterType<ReportsService>().As<IReportsService>().InstancePerRequest();
        }
    }
}
