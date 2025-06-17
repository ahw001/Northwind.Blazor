using System.Numerics;
using System.Security.Cryptography;

namespace Northwind.Blazor.Services.Utilities
{
    public static class GeneralClientUtilities
    {

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            if (minValue >= maxValue)
                throw new ArgumentOutOfRangeException("minValue must be less than maxValue");

            // Create an instance of the default implementation of RandomNumberGenerator:
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] randomNumber = new byte[4]; // uint size
                rng.GetBytes(randomNumber);
                int value = BitConverter.ToInt32(randomNumber, 0);

                return Math.Abs(value % (maxValue - minValue + 1)) + minValue;
            }
        }

        public static string GenerateRandomFixedNumber(int digits)
        {
            byte[] randomNumber = new byte[8];
            RandomNumberGenerator.Fill(randomNumber);
            // Convert the random bytes to a positive integer
            var num = new BigInteger(randomNumber);
            if (num < 0) num = -num;
            // Ensure the number is long enough
            while (num.ToString().Length < digits)
            {
                num *= 10;
            }
            // Take only the first number of digits
            return num.ToString().Substring(0, digits);
        }

        public static string GenerateRandom20DigitNumber()
        {
            Random random = new Random();
            string result = "";

            // First digit should be non-zero to ensure it's a 20-digit number
            result += random.Next(1, 10); // Generates a number between 1 and 9

            // Generate the remaining 19 digits
            for (int i = 0; i < 19; i++)
            {
                result += random.Next(0, 10); // Generates a number between 0 and 9
            }

            return result;
        }

        public static decimal GenerateRandomAmount()
        {
            Random rand = new Random();
            decimal min = 10.00m;
            decimal max = 100.00m;

            // Scale: generate an integer from 0 to 1000, then map it to [min, max)
            int scaled = rand.Next(0, 1000);
            decimal result = min + (scaled * (max - min) / 1000);

            // Truncate to 2 decimal places (optional, to avoid floating imprecision)
            result = Math.Truncate(result * 100) / 100;

            return result; // Ensure a value is returned
        }

        public static string Base64UrlToBase64(string base64Url)
        {
            string base64 = base64Url.Replace('-', '+').Replace('_', '/');
            int padding = 4 - (base64.Length % 4);
            if (padding < 4)
            {
                base64 += new string('=', padding);
            }
            return base64;
        }

    }
}
