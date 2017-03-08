namespace nl.gn.Baudot
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /* 
     * Purpose: String <--> Baudot conversion.
     */
    public static class Baudot
    {
        private enum Shift
        {
            Letter,
            Figure,
            Both
        }


        /// <summary>
        /// Try to convert a char to a 5-bit Baudot code.
        /// </summary>
        /// <param name="ch">Char to convert.</param>
        /// <param name="result">Baudot code.</param>
        /// <param name="shift">Shift in which the char is found.</param>
        /// <param name="lsbFirst">Order of the returned code.</param>
        /// <returns>Whether the conversion succeeded.</returns>
        private static bool TryCharToCode(
            char ch, out VBit result, out Shift shift, bool lsbFirst)
        {
            // Determine wheter the char lives in both shifts,
            // in the letter shift or otherwise default to the figure shift.
            switch (ch)
            {
                case '\0':
                case '\r':
                case '\n':
                case ' ':
                    shift = Shift.Both;
                    break;
                default:
                    shift = (ch >= 65 && ch <= 90) ?
                        Shift.Letter :
                        Shift.Figure;
                    break;
            }

            // Check if we can lookup the char in the "main"
            // lookup array.
            if (ch < Constants.LsbFirstCodeLookup.Length)
            {
                if (lsbFirst)
                {
                    result = (VBit)Constants.LsbFirstCodeLookup[ch];
                }
                else
                {
                    result = (VBit)Constants.MsbFirstCodeLookup[ch];
                }

                // If result is 255 the char is found in the lookup
                // array but is not a baudot supported character.

                return (result != 0xFF);
            }

            // Check if the char is one of the four
            // that are not in main array.
            switch (ch)
            {
                case 'Э':
                    result = lsbFirst ?
                        (VBit)22 :
                        (VBit)13;
                    return true;
                case 'Ш':
                    result = lsbFirst ?
                        (VBit)11 :
                        (VBit)26;
                    return true;
                case 'Щ':
                    result = lsbFirst ?
                        (VBit)5 :
                        (VBit)20;
                    return true;
                case 'Ю':
                    result = lsbFirst ?
                        (VBit)26 :
                        (VBit)11;
                    return true;
            }

            // Not a supported character.

            result = (VBit)0x00;
            return false;
        }

        /// <summary>
        /// Converts a string to Baudot code.
        /// </summary>
        /// <param name="str">String to convert.
        /// Note: lowercase is converted upper,
        /// invalid characters are ignored.</param>
        /// <param name="lsbFirst">Whether the least significant bit is left.</param>
        /// <returns>Enumerable of Baudot codes.</returns>
        public static IEnumerable<VBit> ToCode(string str, bool lsbFirst)
        {
            // Start in the default Letter Shift.
            Shift currentSet = Shift.Letter;

            foreach (char ch in str.ToUpper())
            {
                Shift shift;
                VBit code;

                if (TryCharToCode(ch, out code, out shift, lsbFirst))
                {
                    // Valid baudot char,
                    // check if we need to switch shift.
                    if ((shift != Shift.Both) && (shift != currentSet))
                    {
                        VBit shiftCode = (shift == Shift.Figure) ?
                            Constants.FS :
                            Constants.LS;

                        yield return shiftCode;

                        currentSet = shift;
                    }

                    yield return code;
                }
            }
        }

        /// <summary>
        /// Converts Baudot to string.
        /// </summary>
        /// <param name="baudot">Enumerable of Baudot codes.</param>
        /// <param name="lsbFirst">Order of the codes.</param>
        /// <returns>String representation of the given code.</returns>
        public static string FromCode(IEnumerable<VBit> baudot, bool lsbFirst)
        {
            var builder = new StringBuilder();

            // If the first code is not the FS (Shift to Figures)
            // we start in the default Letter Shift.
            Shift currentSet =
                (baudot.FirstOrDefault() == Constants.FS) ?
                    Shift.Figure :
                    Shift.Letter;

            foreach (VBit code in baudot)
            {
                if (currentSet == Shift.Letter)
                {
                    // Check if we need to switch to figure shift.
                    if (code == Constants.FS)
                    {
                        currentSet = Shift.Figure;
                        continue;
                    }

                    // Get letter shift code.
                    char c = lsbFirst ?
                        Constants.LsbFirstLetterLookup[code.Value] :
                        Constants.MsbFirstLetterLookup[code.Value];

                    builder.Append(c);
                }
                else if (currentSet == Shift.Figure)
                {
                    // Check if we need to change to letter shift.
                    if (code == Constants.LS)
                    {
                        currentSet = Shift.Letter;
                        continue;
                    }

                    // Get figure shift code.
                    char c = lsbFirst ?
                        Constants.LsbFirstFigureLookup[code.Value] :
                        Constants.MsbFirstFigureLookup[code.Value];

                    builder.Append(c);
                }
            }

            return builder.ToString();
        }
    }
}
