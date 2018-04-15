// ---------------------------------------------------------------------------------
// <copyright file="ApplySwaggerDocumentFilter.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace ElGuerre.Taskin.Api.Core.Mvc.Filters
{
    /// <summary>
    /// Post-modify the entire Swagger document by wiring up one or more Document filters.
    /// This gives full control to modify the final SwaggerDocument. You should have a good understanding of
    /// the Swagger 2.0 spec. - https://github.com/swagger-api/swagger-spec/blob/master/versions/V2.md
    /// before using this option.
    /// </summary>
    /// <seealso cref="Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter" />
    public class ApplySwaggerDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// This method is for applying the filter
        /// </summary>
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var methods = swaggerDoc.Paths.Select(i => i.Value);
            List<string> tags = new List<string>();
            foreach (var method in methods)
            {
                if (method.Delete != null)
                {
                    tags.AddRange(method.Delete.Tags);
                }

                if (method.Get != null)
                {
                    tags.AddRange(method.Get.Tags);
                }

                if (method.Put != null)
                {
                    tags.AddRange(method.Put.Tags);
                }

                if (method.Post != null)
                {
                    tags.AddRange(method.Post.Tags);
                }

                if (method.Patch != null)
                {
                    tags.AddRange(method.Patch.Tags);
                }
            }

            swaggerDoc.Tags = new List<Tag>();
            foreach (var tag in tags.Distinct())
            {
                swaggerDoc.Tags.Add(new Tag() { Name = tag, Description = $"Set of {tag} operations." });
            }

        }
    }
}
