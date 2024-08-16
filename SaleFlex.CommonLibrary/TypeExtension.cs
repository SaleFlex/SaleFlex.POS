using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.CommonLibrary
{
    public static class TypeExtension
    {
        public static bool bOverflowAmountCheck(this long prm_decAmountValue)
        {
            if (prm_decAmountValue <= 0 || prm_decAmountValue > 999999999)
            {
                return true;
            }

            return false;
        }

        public static bool bOverflowQuantityCheck(this long prm_decQuantityValue)
        {
            if (prm_decQuantityValue <= 0 || prm_decQuantityValue > 9999999999)
            {
                return true;
            }

            return false;
        }

        public static long decConvertToDecimal(this long prm_lValue, long prm_decF = 100)
        {
            try
            {
                return ((long)prm_lValue / prm_decF);
            }
            catch
            {
                return 0;
            }
        }

        public static decimal decConvertToDecimal(this int prm_iValue, long prm_decF = 100)
        {
            try
            {
                return ((long)prm_iValue / prm_decF);
            }
            catch
            {
                return 0;
            }
        }

        public static long lConvertToLong(this decimal prm_lValue, long prm_decF = 100)
        {
            try
            {
                return (long)(prm_lValue * prm_decF);
            }
            catch
            {
                return 0;
            }
        }

        public static long decConvertToDecimal(this string prm_strValue)
        {
            try
            {
                return long.Parse(Convert.ToInt64(Convert.ToDecimal(prm_strValue)*100).ToString());
            }
            catch
            {
                return 0;
            }
        }

        public static int iConvertToInt(this string prm_strValue)
        {
            try
            {
                return int.Parse(prm_strValue);
            }
            catch
            {
                return 0;
            }
        }
    }
}
