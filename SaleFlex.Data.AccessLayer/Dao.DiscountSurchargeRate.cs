using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public int iGetDiscountRate()
        {
            return iGetDiscountRate(1);
        }

        public int iGetDiscountRate(int prm_iId)
        {
            try
            {
                return 0;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return 0;
            }
        }

        public bool bSaveDiscountRate(int prm_iId, int prm_iDiscountRate)
        {
            try
            {
                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }

        }

        public int iGetSurchargeRate()
        {
            return iGetSurchargeRate(1);
        }

        public int iGetSurchargeRate(int prm_iId)
        {
            try
            {
                return 0;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return 0;
            }
        }

        public bool bSaveSurchargeRate(int prm_iId, int prm_iSurchargeRate)
        {
            try
            {
                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }

        }
    }
}
