using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using jiujitsutoolbox_apiService.DataObjects;
using jiujitsutoolbox_apiService.Models;
using System.Data.Entity.Migrations;
using jiujitsutoolbox_apiService.Migrations;
using System.Linq;
using Autofac;
using Newtonsoft.Json;

namespace jiujitsutoolbox_apiService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options, (configuration, builder) =>
            {
                jiujitsutoolbox_apiContext context = new jiujitsutoolbox_apiContext();
                builder.RegisterInstance(context).As<jiujitsutoolbox_apiContext>().SingleInstance();

            }));

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            var matches = config.Formatters
                .Where(f => f.SupportedMediaTypes
                    .Where(m => m.MediaType.ToString() == "application/xml" || m.MediaType.ToString() == "text/xml").Count() > 0)
                    .ToList();

            foreach (var match in matches)
                config.Formatters.Remove(match);

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }
    }

   
}

