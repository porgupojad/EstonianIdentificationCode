using System;

namespace IdentificationCode
{
    /// <summary>
    /// Identification Code method
    /// </summary>
    public static class IdentificationCode
    {
        /// <summary>
        /// Is valid identificationCode
        /// </summary>
        public static bool IsValid(string identificationCode)
        {
            if (string.IsNullOrWhiteSpace(identificationCode) || identificationCode.Length != 11 || !Validators.IsDigitsOnly(identificationCode))
                return false;

            var century = Validators.GetCentury(identificationCode[0]);
            var birthYear = int.Parse(identificationCode.Substring(1, 2));
            var birthMonth = int.Parse(identificationCode.Substring(3, 2));
            var birthDay = int.Parse(identificationCode.Substring(5, 2));

            var birthDateAsString = $"{century + birthYear}-{birthMonth}-{birthDay}";
            if (!DateTime.TryParse(birthDateAsString, out _))
                return false;

            var controllNumber = Validators.CalculateControllNumber(identificationCode);

            return (controllNumber == short.Parse(identificationCode[10].ToString()));
        }

        /// <summary>
        /// Get birthdate from valid identification code. From 2nd to 7th char (included)
        /// </summary>
        /// <param name="identificationCode">Identification to work on</param>
        /// <returns>If valid birtDate then we return birthDate. Otherwise 0.</returns>
        public static DateTime? GetBirthDate(string identificationCode)
        {
            if (!IsValid(identificationCode))
            {
                return null;
            }

            var century = Validators.GetCentury(identificationCode[0]);
            var birthYear = int.Parse(identificationCode.Substring(1, 2));
            var birthMonth = int.Parse(identificationCode.Substring(3, 2));
            var birthDay = int.Parse(identificationCode.Substring(5, 2));

            var birthDateAsString = $"{century + birthYear}-{birthMonth}-{birthDay}";
            return DateTime.Parse(birthDateAsString);
        }

        /// <summary>
        /// Get Sex from identificationCode first number. Can only be done on valid Identification code.
        /// https://en.wikipedia.org/wiki/ISO/IEC_5218
        /// </summary>
        /// <remarks>
        /// 1,3,5,7 return 1 (Male)
        /// 2,4,6,8 return 2 (Female)
        /// Others return 0 (unknown)
        /// </remarks>
        /// <param name="identificationCode">Identification code to work on.</param>
        /// <returns>Sex in IEC 5218 format. 0 if not valid.</returns>
        public static short GetSex(string identificationCode)
        {
            if (!IsValid(identificationCode))
            {
                return 0;
            }

            switch (identificationCode[0])
            {
                case '1':
                case '3':
                case '5':
                case '7':
                    {
                        return 1;
                    }
                case '2':
                case '4':
                case '6':
                case '8':
                    {
                        return 2;
                    }
                default:
                    return 0;
            }
        }
    }
}
