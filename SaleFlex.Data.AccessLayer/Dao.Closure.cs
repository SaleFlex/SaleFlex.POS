using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public bool bInsertClosure(ref ClosureDataModel prm_xClosureDataModel)
        {
            bool bReturnValue = false;
            try
            {
                var query = string.Format("INSERT INTO TableClosure(ZNumber, ReceiptNumber, ClosureDateTime, FkPosId, FkCashierId, TotalTransactionCount, TotalTransactionAmount, TotalVatAmount, TotalDiscountCount, TotalDiscountAmount, TotalSurchargeCount, TotalSurchargeAmount, TotalChangeCount, TotalChangeAmount, TotalRoundAmount, CumulativeTotalAmount, CumulativeVatAmount, Canceled, Deleted) VALUES({0},{1},datetime('now', 'localtime'),{2},'{3}',{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},0,0); SELECT last_insert_rowid() AS InsertedId",
                    prm_xClosureDataModel.iReceiptNumber,
                    prm_xClosureDataModel.iZNumber,
                    prm_xClosureDataModel.lFkPosId,
                    prm_xClosureDataModel.lFkCashierId,
                    prm_xClosureDataModel.iTotalTransactionCount,
                    prm_xClosureDataModel.lTotalTransactionAmount,
                    prm_xClosureDataModel.lTotalDiscountAmount,
                    prm_xClosureDataModel.lTotalVatAmount,
                    prm_xClosureDataModel.iTotalDiscountCount,
                    prm_xClosureDataModel.lTotalDiscountAmount,
                    prm_xClosureDataModel.iTotalSurchargeCount,
                    prm_xClosureDataModel.lTotalSurchargeAmount,
                    prm_xClosureDataModel.iTotalChangeCount,
                    prm_xClosureDataModel.lTotalChangeAmount,
                    prm_xClosureDataModel.lTotalRoundAmount,
                    prm_xClosureDataModel.lCumulativeTotalAmount,
                    prm_xClosureDataModel.lCumulativeVatAmount);
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);

                if (int.Parse(xDataTable.Rows[0]["InsertedId"].ToString()) > 0)
                {
                    bReturnValue = true;
                    prm_xClosureDataModel.lId = int.Parse(xDataTable.Rows[0]["InsertedId"].ToString());
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return bReturnValue;
        }

        public bool bInsertClosurePaymentTypeSummary(ref ClosureDataModel prm_xClosureDataModel)
        {
            bool bReturnValue = false;
            try
            {
                foreach (ClosurePaymentTypeSummaryDataModel xClosurePaymentTypeSummaryDataModel in prm_xClosureDataModel.xListClosurePaymentTypeSummaryDataModel)
                {
                    var query = string.Format("INSERT INTO TableClosure(FkClosureId, FkPaymentType, TotalCount, TotalAmount) VALUES({0},{1},{2},'{3}'); SELECT last_insert_rowid() AS InsertedId;",
                        xClosurePaymentTypeSummaryDataModel.lFkClosureId = prm_xClosureDataModel.lId,
                        xClosurePaymentTypeSummaryDataModel.lFkPaymentType,
                        xClosurePaymentTypeSummaryDataModel.iTotalCount,
                        xClosurePaymentTypeSummaryDataModel.lTotalAmount);
                    DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);

                    if (int.Parse(xDataTable.Rows[0]["InsertedId"].ToString()) > 0)
                    {
                        bReturnValue = true;
                        xClosurePaymentTypeSummaryDataModel.lId = int.Parse(xDataTable.Rows[0]["InsertedId"].ToString());
                    }
                    else
                    {
                        bReturnValue = false;
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return bReturnValue;
        }
    }
}
