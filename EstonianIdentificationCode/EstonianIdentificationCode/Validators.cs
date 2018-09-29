using System;

namespace EstonianIdentificationCode
{
    /// <summary>
    /// Custom validators for Estonian Identification code
    /// </summary>
    internal static class Validators
    {
        /// <summary>
        /// Validate that string contrains only numbers.
        /// </summary>
        /// <remarks>
        /// It is faster to do this way than with Int.TryParse. 
        /// </remarks>
        /// <param name="str"></param>
        /// <returns>String consists only numbers from 0-9</returns>
        internal static bool IsDigitsOnly(string str)
        {
            foreach (var c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Convert single character to Century number.
        /// </summary>
        /// <remarks>
        /// Examples:
        /// 1 and 2 = 1800;
        /// 3 and 4 = 1900;
        /// 5 and 6 = 2000;
        /// 7 and 8 = 2100;
        /// 9 and 0 = 2200; 
        /// </remarks>
        /// <param name="centuryDigit">Century as a number character</param>
        /// <returns>Century as a number</returns>
        internal static short GetCentury(char centuryDigit)
        {
            if (centuryDigit < '0' || centuryDigit > '9')
                throw new InvalidOperationException("Number must be between 0 and 9");

            return GetCentury(Convert.ToByte(centuryDigit));
        }

        /// <summary>
        /// Convert single character to Century number.
        /// </summary>
        /// <remarks>
        /// Examples:
        /// 1 and 2 = 1800;
        /// 3 and 4 = 1900;
        /// 5 and 6 = 2000;
        /// 7 and 8 = 2100;
        /// 9 and 0 = 2200; 
        /// </remarks>
        /// <param name="centuryDigit">Century as a digit</param>
        /// <returns>Century number</returns>
        internal static short GetCentury(byte centuryDigit)
        {
            switch (centuryDigit)
            {
                case 1:
                case 2:
                    {
                        return 1800;
                    }
                case 3:
                case 4:
                    {
                        return 1900;
                    }
                case 5:
                case 6:
                    {
                        return 2000;
                    }
                case 7:
                case 8:
                    {
                        return 2100;
                    }
                case 9:
                case 0:
                    {
                        return 2200;
                    }
                default:
                    throw new InvalidOperationException("Invalid number. Must be between 0 and 9");
            }
        }
    }
}