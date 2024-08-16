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
        public List<CurrencyDataModel> xListGetCurrency()
        {
            return xListGetCurrency(0);
        }

        public List<CurrencyDataModel> xListGetCurrency(int prm_iCurrencyNo)
        {

            try
            {
                List<CurrencyDataModel> xListCurrencyDataModel = null;

                if (xListCurrencyDataModel == null)
                    xListCurrencyDataModel = new List<CurrencyDataModel>();

                return xListCurrencyDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveCurrency(CurrencyDataModel prm_xCurrencyDataModel)
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
