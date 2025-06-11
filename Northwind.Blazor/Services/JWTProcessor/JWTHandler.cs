using System.IdentityModel.Tokens.Jwt;

namespace Northwind.WebApi.Service.Services.JWTProcessing
{
    public static class JWTHandler
    {
        public static string DecodeJWT(string jwtToken)
        {
            string token = jwtToken;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            var tokenPayload = jsonToken.Payload;

            foreach (var claim in tokenPayload.Claims)
            {
                Console.WriteLine($"{claim.Type}: {claim.Value}");
            }
            return tokenPayload.ToString()!;
            
        }
    }
}
