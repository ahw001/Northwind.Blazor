using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Northwind.Blazor.Services.Utilities
{
    public static class AddCardType
    {
        public static string SetCardType(string number)
        {
            // Extract the first 6 digits of the number
            string bin = number.Substring(0, 6);
            string firstInt = number.Substring(0, 1);
            string firstTwo = number.Substring(0, 2);
            string firstThree = number.Substring(0, 3);
            string firstFour = number.Substring(0, 4);
            string firstSix = number.Substring(0, 6);

            // Convert the BIN to an integer for comparison
            int binInt = int.Parse(bin);
            int firstDigitInt = int.Parse(firstInt);
            int firstTwoInt = int.Parse(firstTwo);
            int firstThreeInt = int.Parse(firstThree);
            int firstFourInt = int.Parse(firstFour);
            int firstSixInt = int.Parse(firstSix);

            // Determine the card type based on the BIN ranges
            if (firstDigitInt == 4)
            {
                return "001";
            }
            else if (firstTwoInt >= 51 && firstTwoInt < 56)
            {
                return "002";
            }
            else if (binInt >= 222100 && binInt < 272099)
            {
                return "002";
            }
            else if (firstTwoInt >= 50 && firstTwoInt < 51)
            {
                return "042";
            }
            else if (firstFourInt >= 3528 && firstFourInt < 3590)
            {
                return "007";
            }
            else if (firstTwoInt >= 34 && firstTwoInt < 39)
            {
                return "003";
            }
            else if (firstFourInt == 6011 || (firstSixInt >= 622126 && firstSixInt < 622926) || (firstThreeInt >= 644 && firstThreeInt < 650) || firstTwoInt == 65)
            {
                return "004";
            }
            else if (firstTwoInt == 36)
            {
                return "005";
            }
            else if (firstTwoInt == 58)
            {
                return "007";
            }
            else if ((firstTwoInt == 50) || (firstTwoInt == 58))
            {
                return "042";
            }
            else if ((firstTwoInt == 56) || (firstTwoInt == 67)) // || firstDigitInt == 6
            {
                return "007"; // 042 is Maestro Intl, 024 is Maestro UK

                // Maestro (International) 50, 58 Maestro (UK Domestic) 56, 67 
            }
            else if ((firstTwoInt >= 56 && firstTwoInt < 59)) // || firstDigitInt == 6
            {
                return "024"; 
            }
            else if (firstTwoInt == 62)
            {
                return "062";
            }
            else if (firstTwoInt >= 50 && firstTwoInt < 51 || firstTwoInt == 67) // || (firstTwoInt >= 56 && firstTwoInt < 59) 
            {
                return "042"; 
            }
            else
            {
                return "error";
            }
        }
    }
}
