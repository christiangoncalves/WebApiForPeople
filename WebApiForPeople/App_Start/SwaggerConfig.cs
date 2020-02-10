using System.Web.Http;
using WebActivatorEx;
using WebApiForPeople;
using Swashbuckle.Application;
using System;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiForPeople
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        
                        c.SingleApiVersion("v1", "WebApiForPeople");
                        c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\bin\WebApiForPeople.xml");
                        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
