using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    /// <summary>
    /// iNo: 1
    /// strName: United States Dollars
    /// lRateOfCurrency: 2,20
    /// iCurrencyCode: 840
    /// strSign: $
    /// strSignDirection: R
    /// strCurrencySymbol: USD
    /// </summary>
    public class CurrencyDataModel
    {
        public CurrencyDataModel()
        {
        }

        public int iId { get; set; }
        public int iNo { get; set; }
        public string strName { get; set; }
        public long lRateOfCurrency { get; set; }
        public int iCurrencyCode { get; set; }
        public string strSign { get; set; }
        public string strSignDirection { get; set; }
        public string strCurrencySymbol { get; set; }
    }
}
