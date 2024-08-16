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
        public bool bSaveEndOfDayParameters(EndOfDayDataModel prm_xEndOfDayDataModel)
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
