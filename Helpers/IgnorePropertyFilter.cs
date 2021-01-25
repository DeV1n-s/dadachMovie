using System.Linq;
using System.Text.Json.Serialization;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace dadachMovie.Helpers
{
    public class IgnorePropertyFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription == null || operation.Parameters == null)
                return;

            if (!context.ApiDescription.ParameterDescriptions.Any())
                return;

            
            context.ApiDescription.ParameterDescriptions.Where(p => p.Source.Equals(BindingSource.Form)
                        && p.CustomAttributes().Any(p => p.GetType().Equals(typeof(JsonIgnoreAttribute))))
                .ForAll(p => operation.RequestBody.Content.Values.Single(v => v.Schema.Properties.Remove(p.Name)));



            context.ApiDescription.ParameterDescriptions.Where(p => p.Source.Equals(BindingSource.Query)
                        && p.CustomAttributes().Any(p => p.GetType().Equals(typeof(JsonIgnoreAttribute))))
                .ForAll(p => operation.Parameters.Remove(operation.Parameters.Single(w => w.Name.Equals(p.Name))));


        }
    }
}