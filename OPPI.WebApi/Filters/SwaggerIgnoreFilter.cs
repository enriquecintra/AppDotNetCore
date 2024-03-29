﻿using Microsoft.OpenApi.Models;
using OPPI.Dominio.Attributes;
using OPPI.WebApi.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;

namespace OPPI.WebApi.Filters
{
    public class SwaggerIgnoreFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext schemaFilterContext)
        {
            if (schema?.Properties == null)
            {
                return;
            }
            var excludedProperties = schemaFilterContext.Type.GetProperties().Where(t => t.GetCustomAttribute<SwaggerIgnoreAttribute>() != null);
            foreach (PropertyInfo excludedProperty in excludedProperties)
            {
                if (schema.Properties.ContainsKey(excludedProperty.Name.ToCamelCase()))
                {
                    schema.Properties.Remove(excludedProperty.Name.ToCamelCase());
                }
            }
        }
    }
}
