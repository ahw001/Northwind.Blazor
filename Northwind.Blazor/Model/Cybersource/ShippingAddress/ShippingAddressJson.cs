﻿using Northwind.Blazor.Model.Cybersource.BaseData;
using System.Text.Json.Serialization;

namespace Northwind.Blazor.Model.Cybersource.ShippingAddress
{
    public class ShippingAddressJson
    {
        [JsonPropertyName("_links")]
        public Links? Links { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("_embedded")]
        public Embedded? Embedded { get; set; }
    }
}
