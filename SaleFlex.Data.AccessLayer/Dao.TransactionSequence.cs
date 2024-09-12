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
        public int iGetLastRecieptNumber()
        {
            int iReturnValue = 0;
            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable("SELECT Value FROM TableTransactionSequence WHERE Name = 'ReceiptNumber';");

                if (xDataTable.Rows.Count > 0)
                {
                    iReturnValue = Convert.ToInt32(xDataTable.Rows[0]["Value"]);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return iReturnValue;
        }
        
        public int iIncreaseReceiptNumberByOne()
        {
            int iReturnValue = 0;
            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable("SELECT Value FROM TableTransactionSequence WHERE Name = 'ReceiptNumber';");

                if (xDataTable.Rows.Count > 0)
                {
                    iReturnValue = Convert.ToInt32(xDataTable.Rows[0]["Value"]);

                    iReturnValue++;

                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable($"UPDATE TableTransactionSequence SET Value = {iReturnValue} WHERE Name = 'ReceiptNumber';");
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return iReturnValue;
        }

        public int iGetLastZNumber()
        {
            int iReturnValue = 0;
            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable("SELECT Value FROM TableTransactionSequence WHERE Name = 'ZNumber';");

                if (xDataTable.Rows.Count > 0)
                {
                    iReturnValue = Convert.ToInt32(xDataTable.Rows[0]["Value"]);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return iReturnValue;
        }
    }
}
