using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text.Json;


namespace Northwind.Blazor.Model.Cybersource.FlexResponse
{
    public class FlexJson
    {
    }
    public class FlexRoot
    {
        [JsonPropertyName("kid")]
        public string? Kid { get; set; }

        [JsonPropertyName("alg")]
        public string? Alg { get; set; }

        [JsonPropertyName("token")]
        public TokenData? Token { get; set; }

        [JsonPropertyName("error")]
        public string? Error { get; set; }
    }

    public class Jwk
    {
        [JsonPropertyName("kty")]
        public string? Kty { get; set; }

        [JsonPropertyName("e")]
        public string? E { get; set; }

        [JsonPropertyName("use")]
        public string? Use { get; set; }

        [JsonPropertyName("n")]
        public string? N { get; set; }

        [JsonPropertyName("kid")]
        public string? Kid { get; set; }
    }

    public class Flx
    {
        [JsonPropertyName("path")]
        public string? Path { get; set; }

        [JsonPropertyName("data")]
        public string? Data { get; set; }

        [JsonPropertyName("origin")]
        public string? Origin { get; set; }

        [JsonPropertyName("jwk")]
        public Jwk? Jwk { get; set; }
    }

    public class CtxData
    {
        [JsonPropertyName("clientLibrary")]
        public string? ClientLibrary { get; set; }

        [JsonPropertyName("allowedCardNetworks")]
        public List<string>? AllowedCardNetworks { get; set; }

        [JsonPropertyName("targetOrigins")]
        public List<string>? TargetOrigins { get; set; }

        [JsonPropertyName("mfOrigin")]
        public string? MfOrigin { get; set; }
    }

    public class Ctx
    {
        [JsonPropertyName("data")]
        public CtxData? Data { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }

    public class TokenData
    {
        [JsonPropertyName("flx")]
        public Flx? Flx { get; set; }

        [JsonPropertyName("ctx")]
        public List<Ctx>? Ctx { get; set; }

        [JsonPropertyName("iss")]
        public string? Iss { get; set; }

        [JsonPropertyName("exp")]
        public long? Exp { get; set; }

        [JsonPropertyName("iat")]
        public long? Iat { get; set; }

        [JsonPropertyName("jti")]
        public string? Jti { get; set; }
    }
}
