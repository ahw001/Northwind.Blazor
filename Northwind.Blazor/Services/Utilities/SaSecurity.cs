using System.Security.Cryptography;
using System.Text;

namespace Northwind.Blazor.Services.Utilities
{
    public static class SaSecurity
    {
        private const string SECRET_KEY = "31e557b791844b5bb6a0da55c16ffe794a94505fa6e743eeb50acc3a5978e98af9d12097f6f746478ccbfa9e0266211377fa5117fb1b4db7ae43573078100c22b5720ff412744512995320f10ca2daa9a1c17168f2ff4658b06941a90f2dcdb12baa2e29c35b4bd9ada25f8cb9f1d127d81cadcaf2144c3d97c9fafdd14fcb8b";

        public static string sign(IDictionary<string, string> paramsArray)
        {
            return sign(buildDataToSign(paramsArray), SECRET_KEY);
        }

        private static string sign(string data, string secretKey)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secretKey);

            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
            byte[] messageBytes = encoding.GetBytes(data);
            return Convert.ToBase64String(hmacsha256.ComputeHash(messageBytes));
        }

        private static string buildDataToSign(IDictionary<string, string> paramsArray)
        {
            string[] signedFieldNames = paramsArray["signed_field_names"].Split(',');
            IList<string> dataToSign = new List<string>();

            foreach (string signedFieldName in signedFieldNames)
            {
                dataToSign.Add(signedFieldName + "=" + paramsArray[signedFieldName]);
            }

            return commaSeparate(dataToSign);
        }

        private static string commaSeparate(IList<string> dataToSign)
        {
            return string.Join(",", dataToSign);
        }

        public static string getUUID()
        {
            return Guid.NewGuid().ToString();
        }

        public static string getUTCDateTime()
        {
            DateTime time = DateTime.Now.ToUniversalTime();
            return time.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
        }

    }
}
