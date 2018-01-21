// ---------------------------------------------------------------------------------
// <copyright file="IdentitySecurityScheme.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace IDB.Business.Disbursement.Api.Auth.Server
{
    public class IdentitySecurityScheme:SecurityScheme
    {
        public IdentitySecurityScheme()
        {
            Type = "IdentitySecurityScheme";
            Description = "Security definition that provides to the user of Swagger a mechanism to obtain a token from the identity service that secures the api";
            Extensions.Add("authorizationUrl", "http://localhost:5002/Auth/Client/popup.html");
            Extensions.Add("flow", "implicit");
            Extensions.Add("scopes", new List<string>
            {
                "disbursement"
            });
        }
    }
}
