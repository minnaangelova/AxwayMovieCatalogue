﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using MovieCatalogueApp.Data;
using MovieCataloogueApp.Services;
using MovieCataloogueApp.Services.Interfaces;

namespace MovieCatalogueAppWebApi.Infrastructure
{
    public class AutofacConfig
    {

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterType<MovieCatalogueAppContext>().InstancePerRequest();

            builder.RegisterGeneric(typeof(DbRepository<>)).As(typeof(IRepository<>));

           builder.RegisterType<MovieService>().As<IMovieService>().InstancePerRequest();



            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}