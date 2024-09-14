using System;
using System.Collections.Generic;
using System.Data;
using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        // Inserts a closure record into the TableClosure. If successful, it proceeds to insert payment type summaries.
        public bool bInsertClosure(ref ClosureDataModel prm_xClosureDataModel)
        {
            bool bReturnValue = false;
            try
            {
                // Construct the SQL query to insert a closure record into the TableClosure table.
                var query = string.Format(
                    "INSERT INTO TableClosure(ZNumber, ReceiptNumber, ClosureDateTime, FkPosId, FkCashierId, TotalTransactionCount, TotalTransactionAmount, TotalVatAmount, TotalDiscountCount, TotalDiscountAmount, TotalSurchargeCount, TotalSurchargeAmount, TotalChangeCount, TotalChangeAmount, TotalRoundAmount, CumulativeTotalAmount, CumulativeVatAmount, Canceled, Deleted) " +
                    "VALUES({0},{1},datetime('now', 'localtime'),{2},'{3}',{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},0,0); " +
                    "SELECT last_insert_rowid() AS InsertedId",
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
                    prm_xClosureDataModel.lCumulativeVatAmount
                );

                // Execute the query and store the result in a DataTable.
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);

                // If the closure record was successfully inserted, insert the payment type summaries.
                if (int.Parse(xDataTable.Rows[0]["InsertedId"].ToString()) > 0)
                {
                    prm_xClosureDataModel.lId = int.Parse(xDataTable.Rows[0]["InsertedId"].ToString());
                    bReturnValue = bInsertClosurePaymentTypeSummary(ref prm_xClosureDataModel);
                    if (bReturnValue == false)
                    {
                        query = $"UPDATE TableClosure SET Canceled = 1, Deleted = 1 WHERE Id = {prm_xClosureDataModel.lId};";
                        xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);
                    }
                }
            }
            catch (Exception xException)
            {
                // Log any exception that occurs during the process.
                xException.strTraceError();
            }
            return bReturnValue;
        }

        // Inserts payment type summary records associated with the closure into the TableClosure.
        public bool bInsertClosurePaymentTypeSummary(ref ClosureDataModel prm_xClosureDataModel)
        {
            bool bReturnValue = false;
            try
            {
                // Iterate through the payment type summaries and insert each into the database.
                foreach (ClosurePaymentTypeSummaryDataModel xClosurePaymentTypeSummaryDataModel in prm_xClosureDataModel.xListClosurePaymentTypeSummaryDataModel)
                {
                    xClosurePaymentTypeSummaryDataModel.lFkClosureId = prm_xClosureDataModel.lId;

                    // Prepare the SQL query to insert a payment type summary record into the TableClosure.
                    var query = string.Format(
                        "INSERT INTO TableClosure(FkClosureId, FkPaymentType, TotalCount, TotalAmount) " +
                        "VALUES({0},{1},{2},'{3}'); SELECT last_insert_rowid() AS InsertedId;",
                        xClosurePaymentTypeSummaryDataModel.lFkClosureId,
                        xClosurePaymentTypeSummaryDataModel.lFkPaymentType,
                        xClosurePaymentTypeSummaryDataModel.iTotalCount,
                        xClosurePaymentTypeSummaryDataModel.lTotalAmount
                    );

                    // Execute the query and store the result in a DataTable.
                    DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);

                    // Check if the payment type summary was successfully inserted.
                    if (int.Parse(xDataTable.Rows[0]["InsertedId"].ToString()) > 0)
                    {
                        xClosurePaymentTypeSummaryDataModel.lId = int.Parse(xDataTable.Rows[0]["InsertedId"].ToString());
                        bReturnValue = true;
                    }
                    else
                    {
                        bReturnValue = false;
                        break;
                    }
                }
            }
            catch (Exception xException)
            {
                // Log any exception that occurs during the process.
                xException.strTraceError();
            }
            return bReturnValue;
        }

        public ClosureDataModel xCalculateClosureData(int prm_iZNumber)
        {
            ClosureDataModel xClosureDataModel = null;
            var query = $"SELECT MAX(th.ReceiptNumber) AS iMaxReceiptNumber, COUNT(th.Id) AS iTotalTransactionCount,  SUM(th.ReceiptTotalPrice) AS lTotalTransactionAmount, SUM(th.ReceiptTotalVat) AS lTotalVatAmount, COUNT(CASE WHEN th.TotalDiscountAmount IS NOT NULL AND th.TotalDiscountAmount > 0 THEN 1 END) AS iTotalDiscountCount, SUM(th.TotalDiscountAmount) AS lTotalDiscountAmount, COUNT(CASE WHEN th.SurchargeAmount IS NOT NULL AND th.SurchargeAmount > 0 THEN 1 END) AS iTotalSurchargeCount, SUM(th.SurchargeAmount) AS lTotalSurchargeAmount, COUNT(CASE WHEN th.ChangeAmount IS NOT NULL AND th.ChangeAmount > 0 THEN 1 END) AS iTotalChangeCount, SUM(th.ChangeAmount) AS lTotalChangeAmount, SUM(th.RoundAmount) AS lTotalRoundAmount FROM TableTransactionHead th WHERE th.ZNumber = {prm_iZNumber};";

            DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);

            if (xDataTable != null && xDataTable.Rows.Count > 0)
            {
                DataRow xDataRow = xDataTable.Rows[0];

                ClosureDataModel xTempClosureDataModel = new ClosureDataModel();
                xTempClosureDataModel.iZNumber = prm_iZNumber;
                xTempClosureDataModel.iReceiptNumber = Convert.ToInt32(xDataRow["iMaxReceiptNumber"]);
                xTempClosureDataModel.xClosureDateTime = DateTime.Now;
                xTempClosureDataModel.iTotalTransactionCount = Convert.ToInt32(xDataRow["iTotalTransactionCount"]);
                xTempClosureDataModel.lTotalTransactionAmount = Convert.ToInt32(xDataRow["lTotalTransactionAmount"]);
                xTempClosureDataModel.lTotalVatAmount = Convert.ToInt32(xDataRow["lTotalVatAmount"]);
                xTempClosureDataModel.iTotalDiscountCount = Convert.ToInt32(xDataRow["iTotalDiscountCount"]);
                xTempClosureDataModel.lTotalDiscountAmount = Convert.ToInt32(xDataRow["lTotalDiscountAmount"]);
                xTempClosureDataModel.iTotalSurchargeCount = Convert.ToInt32(xDataRow["iTotalSurchargeCount"]);
                xTempClosureDataModel.lTotalSurchargeAmount = Convert.ToInt32(xDataRow["lTotalSurchargeAmount"]);
                xTempClosureDataModel.iTotalChangeCount = Convert.ToInt32(xDataRow["iTotalChangeCount"]);
                xTempClosureDataModel.lTotalChangeAmount = Convert.ToInt32(xDataRow["lTotalChangeAmount"]);
                xTempClosureDataModel.lTotalRoundAmount = Convert.ToInt32(xDataRow["lTotalRoundAmount"]);

                query = "SELECT COALESCE(( SELECT TotalTransactionAmount FROM TableClosure ORDER BY ClosureDateTime DESC LIMIT 1 ), 0) AS lLastTotalTransactionAmount, COALESCE(( SELECT TotalVatAmount FROM TableClosure ORDER BY ClosureDateTime DESC LIMIT 1 ), 0) AS lLastTotalVatAmount;";

                xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xTempClosureDataModel.lCumulativeTotalAmount = Convert.ToInt32(xDataRow["lLastTotalTransactionAmount"]) + xTempClosureDataModel.lTotalTransactionAmount;
                    xTempClosureDataModel.lCumulativeVatAmount = Convert.ToInt32(xDataRow["lLastTotalVatAmount"]) + xTempClosureDataModel.lTotalVatAmount;

                    xClosureDataModel = xTempClosureDataModel;
                }
            }
            
            return xClosureDataModel;
        }
    }
}
