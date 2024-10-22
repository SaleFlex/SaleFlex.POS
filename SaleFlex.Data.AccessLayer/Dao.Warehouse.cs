using SaleFlex.CommonLibrary;
using SaleFlex.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public bool bCreateWarehouseDb()
        {
            bool returnvalue = false;

            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseWarehouseFileNameAndPath).xExecuteDataTable("SELECT count(*) FROM sqlite_master WHERE type='table'");

                if (xDataTable.Rows.Count > 0)
                {
                    int iTableCount = Convert.ToInt32(xDataTable.Rows[0][0]) - 1;

                    if (iTableCount == 1)
                    {
                        returnvalue = true;
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return returnvalue;
        }
    }
}
