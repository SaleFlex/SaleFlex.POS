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
        public PosDataModel xGetIdleMessage()
        {
            return xGetIdleMessage(1);
        }

        public PosDataModel xGetIdleMessage(int prm_iId)
        {
            try
            {
                PosDataModel xPosDataModel = null;

                if (xPosDataModel == null)
                    xPosDataModel = new PosDataModel();

                return xPosDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveIdleMessage(PosDataModel prm_xPosDataModel)
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
