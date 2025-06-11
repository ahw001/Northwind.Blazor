using System.IdentityModel.Tokens.Jwt;

namespace Northwind.WebApi.Service.Services.JWTProcessing
{
    public static class JWTItems
    {
        private static Dictionary<string, string> _jwtItems = new Dictionary<string, string>();
        public static Dictionary<string, string> DecodeJWT(string jwtToken)
        {
            _jwtItems.Clear();

            string token = jwtToken;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            var tokenPayload = jsonToken.Payload;

            foreach (var claim in tokenPayload.Claims)
            {
                Console.WriteLine($"{claim.Type}: {claim.Value}");
                _jwtItems.Add(claim.Type, claim.Value);
            }
            return _jwtItems!;
            
        }
    }
}
