using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Northwind.Blazor.Services.DTOs
{
    public class BearerTokenDto
    {
        [JsonPropertyName("bearerToken")]
        public string? BearerToken { get; set; }
    }
}
