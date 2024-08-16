using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.CommonLibrary
{
    public static class CharacterExtension
    {
        public static bool bIsDigit(this char prm_cCharacter)
        {
            foreach (char cCharacter in "0123456789")
            {
                if (prm_cCharacter == cCharacter)
                    return true;
            }

            return false;
        }
    }
}
