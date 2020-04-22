using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoviesWatched.Models
{
    [SwaggerSchemaFilter(typeof(MovieSchemaFilter))]
    public class Movie
    {
        private const double minRating = 0;
        private const double maxRating = 5;

        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(minRating, maxRating)]
        public double Rating { get; set; }

        [DefaultValue("N/A")]
        public string Comment { get; set; }
    }

    public class MovieSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                ["Id"] = new OpenApiInteger(4),
                ["Name"] = new OpenApiString("Sonic the Hedgehog"),
                ["Rating"] = new OpenApiDouble(4.3),
                ["Comment"] = new OpenApiString("Gotta go fast!")
            };
        }
    }
}