using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public SupervisorDataModel xGetSupervisorPassword()
        {
            return xGetSupervisorPassword(1);
        }

        public SupervisorDataModel xGetSupervisorPassword(int prm_iId)
        {
            try
            {
                SupervisorDataModel xSupervisorDataModel = null;

                if (xSupervisorDataModel == null)
                    xSupervisorDataModel = new SupervisorDataModel();

                return xSupervisorDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveSupervisorPassword(SupervisorDataModel prm_xSupervisorDataModel)
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
