using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.CommonLibrary
{
    public static class StringExtension
    {
        public static byte[] GetByteArray(this string prm_strString)
        {
            return Enumerable.Range(0, prm_strString.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(prm_strString.Substring(x, 2), 16))
                     .ToArray();
        }

        public static byte[] GetAsciiByteArray(this string prm_strString)
        {
            return System.Text.Encoding.ASCII.GetBytes(prm_strString);
        }

        public static string[] CleanArray(this string[] prm_strArray)
        {
            if (prm_strArray.Count() == 1 && prm_strArray[0] == "")
            {
                return new string[] { };
            }
            return prm_strArray;
        }

        public static string[] SplitToTwoPart(this string prm_xInputString, char[] prm_caAnyOfThisCharacters, bool prm_bConvertToUpperCase = false)
        {
            string[] straParsing = new string[2];
            int iIndexOfSubstring = 0;

            if (prm_bConvertToUpperCase == true)
                prm_xInputString = prm_xInputString.ToUpper();

            iIndexOfSubstring = prm_xInputString.IndexOfAny(prm_caAnyOfThisCharacters);

            straParsing[0] = prm_xInputString.Substring(0, iIndexOfSubstring);
            straParsing[1] = prm_xInputString.Substring(iIndexOfSubstring);

            return straParsing;
        }

        public static string[] SplitToTwoPart(this string prm_xInputString, char prm_cCharacter, bool prm_bConvertToUpperCase = false)
        {
            string[] straParsing = new string[2];
            int iIndexOfSubstring = 0;

            if (prm_bConvertToUpperCase == true)
                prm_xInputString = prm_xInputString.ToUpper();

            iIndexOfSubstring = prm_xInputString.IndexOf(prm_cCharacter);

            straParsing[0] = prm_xInputString.Substring(0, iIndexOfSubstring);
            straParsing[1] = prm_xInputString.Substring(iIndexOfSubstring);

            return straParsing;
        }


        public static string Rigth(this string prm_xInputString, int prm_iCount)
        {
            return prm_xInputString.Substring(prm_xInputString.Length - prm_iCount);
        }

        public static List<string> xGetList(this string prm_strSourceString, string prm_strDelimiter)
        {
            try
            {
                String[] straStrings = null;

                StringTokenizer xStringTokenizer = new StringTokenizer(prm_strSourceString, prm_strDelimiter);

                int iNumberOfStrings = xStringTokenizer.iCountTokens();

                if (iNumberOfStrings > 0)
                {
                    straStrings = new string[xStringTokenizer.iCountTokens()];

                    for (int iIndex = 0; xStringTokenizer.bHasMoreTokens(); iIndex++)
                    {
                        straStrings[iIndex] = xStringTokenizer.strNextToken();
                    }
                }

                List<string> xList = new List<string>();
                if (straStrings != null)
                {
                    foreach (string strListItem in straStrings)
                    {
                        xList.Add(strListItem);
                    }
                }

                return xList;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Check the string for specific characters and if found replace them with space
        /// </summary>
        /// <param name="prm_strString">string that will check</param>
        /// <param name="prm_strInvalidCharacters">character array those have to check and replace in string</param>
        public static string strCheckAndCleanStringWithInvalidCharacterList(this string prm_strString, string prm_strInvalidCharacters)
        {
            string strReturnMessage = string.Empty;

            try
            {
                char[] caInvalidCharacters = prm_strInvalidCharacters.ToCharArray();
                char[] caMessage = prm_strString.ToCharArray();

                for (int iIndex = 0; iIndex < caMessage.Length; iIndex++)
                {
                    if (prm_strInvalidCharacters.IndexOf(caMessage[iIndex]) != -1) caMessage[iIndex] = ' ';
                }

                strReturnMessage = new string(caMessage);
            }
            catch
            {
            }

            return strReturnMessage;
        }

        public static string strCheckAndRemoveStringFromInvalidCharacterList(this string prm_strString, string prm_strInvalidCharacters)
        {
            string strReturnMessage = prm_strString;

            try
            {
                char[] caInvalidCharacters = prm_strInvalidCharacters.ToCharArray();
                char[] caMessage = prm_strString.ToCharArray();

                for (int iIndex = 0; iIndex < caMessage.Length; iIndex++)
                {
                    if (prm_strInvalidCharacters.IndexOf(caMessage[iIndex]) != -1)
                        strReturnMessage = strReturnMessage.Remove(iIndex, 1);
                }
            }
            catch
            {
            }

            return strReturnMessage;
        }

        public static string strCenterAlignment(this string prm_strString, int prm_iRowLength)
        {
            int iLength = prm_strString.Length;
            int iSpaces = (prm_iRowLength - iLength) / 2;
            return prm_strString.PadLeft(iLength + iSpaces).PadRight(prm_iRowLength);
        }
    }
}
