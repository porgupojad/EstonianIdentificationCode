using System;

namespace EstonianIdentificationCode
{
    /// <summary>
    /// Estonian IdentificationCode functions
    /// </summary>
    public static class EstonianIdentificationCode
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

            // calculate the checksum
            var checkSum = short.Parse(identificationCode[0].ToString()) * 1
                    + short.Parse(identificationCode[1].ToString()) * 2
                    + short.Parse(identificationCode[2].ToString()) * 3
                    + short.Parse(identificationCode[3].ToString()) * 4
                    + short.Parse(identificationCode[4].ToString()) * 5
                    + short.Parse(identificationCode[5].ToString()) * 6
                    + short.Parse(identificationCode[6].ToString()) * 7
                    + short.Parse(identificationCode[7].ToString()) * 8
                    + short.Parse(identificationCode[8].ToString()) * 9
                    + short.Parse(identificationCode[9].ToString()) * 1;

            var controllNumber = checkSum % 11;

            // special case recalculate the checksum
            if (controllNumber == 10)
            {
                checkSum = short.Parse(identificationCode[0].ToString()) * 3
                    + short.Parse(identificationCode[1].ToString()) * 4
                    + short.Parse(identificationCode[2].ToString()) * 5
                    + short.Parse(identificationCode[3].ToString()) * 6
                    + short.Parse(identificationCode[4].ToString()) * 7
                    + short.Parse(identificationCode[5].ToString()) * 8
                    + short.Parse(identificationCode[6].ToString()) * 9
                    + short.Parse(identificationCode[7].ToString()) * 1
                    + short.Parse(identificationCode[8].ToString()) * 2
                    + short.Parse(identificationCode[9].ToString()) * 3;

                controllNumber = checkSum % 11;
                controllNumber = controllNumber % 10;
            }

            return (controllNumber == short.Parse(identificationCode[10].ToString()));
        }

        /// <summary>
        /// Get BirthDate from identificationCode
        /// </summary>
        public static DateTime GetBirthDate(string identificationCode)
        {
            if (!IsValid(identificationCode))
            {
                throw new InvalidOperationException("Identification code not valid.");
            }

            var century = Validators.GetCentury(identificationCode[0]);
            var birthYear = int.Parse(identificationCode.Substring(1, 2));
            var birthMonth = int.Parse(identificationCode.Substring(3, 2));
            var birthDay = int.Parse(identificationCode.Substring(5, 2));

            var birthDateAsString = $"{century + birthYear}-{birthMonth}-{birthDay}";
            if (!DateTime.TryParse(birthDateAsString, out var birthDate))
            {
                throw new InvalidOperationException($"Identification birthDay format is invalid: {birthDateAsString}");
            }
            return birthDate;
        }

        /// <summary>
        /// Get Sex from identificationCode
        /// https://en.wikipedia.org/wiki/ISO/IEC_5218
        /// 0 = not known
        /// 1 = male
        /// 2 = female
        /// </summary>
        public static short GetSex(string identificationCode)
        {
            if (!IsValid(identificationCode))
            {
                throw new InvalidOperationException("Identification code not valid.");
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
                    throw new InvalidOperationException("Identification code not valid.");
            }
        }
    }
}
