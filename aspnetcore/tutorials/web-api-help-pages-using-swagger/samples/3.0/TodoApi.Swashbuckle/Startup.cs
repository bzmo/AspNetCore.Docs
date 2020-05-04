using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MoviesWatched.Models;
using MoviesWatched.SwaggerOptions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace MoviesWatched
{
    public class Startup
    {

        private IHostEnvironment currentEnvironment;

        public Startup(IHostEnvironment environment)
        {
            currentEnvironment = environment;
        }

        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MovieContext>(opt =>
                opt.UseInMemoryDatabase("TodoList"));
            services.AddControllers();

            services.AddApiVersioning(c =>
            {
                // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                c.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(c =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                c.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                c.SubstituteApiVersionInUrl = true;
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(c =>
            {
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
        #endregion

        #region snippet_Configure
        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json", 
                        $"Movies Watched API {description.GroupName.ToUpperInvariant()}"
                    );
                }
                c.DisplayOperationId();
                c.DisplayRequestDuration();
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #endregion
    }
}
