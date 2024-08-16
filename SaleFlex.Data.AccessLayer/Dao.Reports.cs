using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        #region CashReport
        public List<CashReportDataModel> xGetCashReportDaily()
        {
            List<CashReportDataModel> xCashReportList = new List<CashReportDataModel>();
            try
            {
                List<PluPurschaseModel> xPluByBarcodeList = new List<PluPurschaseModel>();

                CashReportDataModel xCashReportDataModel = new CashReportDataModel();

                PluPurschaseModel xPluPurschaseModel = new PluPurschaseModel();

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT ifnull(sum(h.ReceiptTotalPrice),0) as ReceiptTotal,(ifnull(sum(h.ReceiptTotalPrice),0) - ifnull(sum(h.ReceiptTotalVat),0)) as CashWithoutVat FROM TableTransactionHead h INNER JOIN TableTransactionDocumentType dt ON dt.Id=h.FkTransactionDocumentTypeId WHERE h.IsVoided=0 AND strftime('%d-%m-%Y',h.TransactionDateTime) = strftime('%d-%m-%Y','now') AND dt.[No] NOT IN (8,9,10)"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xCashReportDataModel.ReceiptTotal = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["ReceiptTotal"]) / 100));
                    xCashReportDataModel.CashWithoutVat = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["CashWithoutVat"]) / 100));
                }

                xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT ifnull(sum(h.ReceiptTotalPrice),0) as ReturnProductCash FROM TableTransactionHead h INNER JOIN TableTransactionDocumentType dt ON  dt.Id=h.FkTransactionDocumentTypeId WHERE h.IsVoided=0 AND strftime('%d-%m-%Y',h.TransactionDateTime) = strftime('%d-%m-%Y','now') AND dt.[No]=10"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xCashReportDataModel.ReturnProductCash = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["ReturnProductCash"]) / 100));
                }

                xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("ATTACH DATABASE 'SaleFlex.POS.STOCK.db3' as STOCK;SELECT IFNULL(SUM(CASE WHEN plu.StockUnitNo = 1 THEN (tpb.PurchasePrice*td.Quantity)/1000 ELSE (tpb.PurchasePrice*td.Quantity) END),0) as PurchasePrice FROM TableTransactionHead h JOIN TableTransactionDocumentType dt ON h.TransactionDocumentTypeNo=dt.No JOIN TableTransactionDetail td ON td.FkTransactionHeadId=h.Id INNER JOIN STOCK.TablePluBarcode as tpb ON tpb.FkPluId=td.FkPluId INNER JOIN STOCK.TablePlu as plu ON plu.Id=tpb.FkPluId WHERE h.IsVoided=0 AND dt.[No] NOT IN (8,9,10) AND strftime('%d-%m-%Y',h.TransactionDateTime) = strftime('%d-%m-%Y','now')"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xCashReportDataModel.PurchasePrice = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["PurchasePrice"]) / 100));
                }

                xCashReportDataModel.Profit = string.Format("{0:#,0.00}", (decimal.Parse(xCashReportDataModel.CashWithoutVat) - decimal.Parse(xCashReportDataModel.PurchasePrice)));

                xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT IFNULL(SUM(p.PaymentAmount),0) as CashPayment FROM TableTransactionPayment p INNER JOIN TableTransactionHead h ON h.Id=p.FkTransactionHeadId INNER JOIN TableTransactionDocumentType dt ON dt.Id=h.FkTransactionDocumentTypeId WHERE h.IsVoided=0 AND strftime('%d-%m-%Y',h.TransactionDateTime)= strftime('%d-%m-%Y','now') AND dt.[No] NOT IN (8,9,10) AND p.FkPaymentTypeId=1"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xCashReportDataModel.CashPayment = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["CashPayment"]) / 100));
                }

                xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT IFNULL(SUM(p.PaymentAmount),0) as CardPayment FROM TableTransactionPayment p INNER JOIN TableTransactionHead h ON h.Id=p.FkTransactionHeadId INNER JOIN TableTransactionDocumentType dt ON dt.Id=h.FkTransactionDocumentTypeId WHERE h.IsVoided=0 AND strftime('%d-%m-%Y',h.TransactionDateTime)= strftime('%d-%m-%Y','now') AND dt.[No] NOT IN (8,9,10) AND p.FkPaymentTypeId=2"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xCashReportDataModel.CardPayment = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["CardPayment"]) / 100));
                }

                xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT IFNULL(SUM(p.PaymentAmount),0) as OtherPayment FROM TableTransactionPayment p INNER JOIN TableTransactionHead h ON h.Id=p.FkTransactionHeadId INNER JOIN TableTransactionDocumentType dt ON dt.Id=h.FkTransactionDocumentTypeId WHERE h.IsVoided=0 AND strftime('%d-%m-%Y',h.TransactionDateTime)= strftime('%d-%m-%Y','now') AND dt.[No] NOT IN (8,9,10) AND p.FkPaymentTypeId NOT IN (1,2)"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xCashReportDataModel.OtherPayment = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["OtherPayment"]) / 100));
                }

                xCashReportList.Add(xCashReportDataModel);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xCashReportList;
        }

        public List<CashReportDataModel> xGetCashReportMonthly()
        {
            List<CashReportDataModel> xCashReportList = new List<CashReportDataModel>();
            try
            {
                List<PluPurschaseModel> xPluByBarcodeList = new List<PluPurschaseModel>();

                CashReportDataModel xCashReportDataModel = new CashReportDataModel();

                PluPurschaseModel xPluPurschaseModel = new PluPurschaseModel();

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT ifnull(sum(h.ReceiptTotalPrice),0) as ReceiptTotal, (ifnull(sum(h.ReceiptTotalPrice),0) - ifnull(sum(h.ReceiptTotalVat),0)) as CashWithoutVat FROM TableTransactionHead h INNER JOIN TableTransactionDocumentType dt ON dt.Id=h.FkTransactionDocumentTypeId WHERE h.IsVoided=0 AND strftime('%m-%Y',h.TransactionDateTime) = strftime('%m-%Y','now') AND dt.[No] NOT IN (8,9,10)"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xCashReportDataModel.ReceiptTotal = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["ReceiptTotal"]) / 100));
                    xCashReportDataModel.CashWithoutVat = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["CashWithoutVat"]) / 100));
                }

                xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT ifnull(sum(h.ReceiptTotalPrice),0) as ReturnProductCash FROM TableTransactionHead h INNER JOIN TableTransactionDocumentType dt ON dt.[No]=h.TransactionDocumentTypeNo WHERE h.IsVoided=0 AND strftime('%m-%Y',h.TransactionDateTime) = strftime('%m-%Y','now') AND dt.[No]=10"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xCashReportDataModel.ReturnProductCash = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["ReturnProductCash"]) / 100));
                }

                xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("ATTACH DATABASE 'SaleFlex.POS.STOCK.db3' as STOCK;SELECT IFNULL(SUM(CASE WHEN plu.StockUnitNo = 1 THEN (tpb.PurchasePrice*td.Quantity)/1000 ELSE (tpb.PurchasePrice*td.Quantity) END),0) as PurchasePrice FROM TableTransactionHead h JOIN TableTransactionDocumentType dt ON h.TransactionDocumentTypeNo=dt.No JOIN TableTransactionDetail td ON td.FkTransactionHeadId=h.Id INNER JOIN STOCK.TablePluBarcode as tpb ON tpb.FkPluId=td.FkPluId INNER JOIN STOCK.TablePlu as plu ON plu.Id=tpb.FkPluId WHERE h.IsVoided=0 AND dt.[No] NOT IN (8,9,10) AND strftime('%m-%Y',h.TransactionDateTime) = strftime('%m-%Y','now')"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xCashReportDataModel.PurchasePrice = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["PurchasePrice"]) / 100));
                }

                xCashReportDataModel.Profit = string.Format("{0:#,0.00}", (decimal.Parse(xCashReportDataModel.CashWithoutVat) - decimal.Parse(xCashReportDataModel.PurchasePrice)));

                xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT IFNULL(SUM(p.PaymentAmount),0) as CashPayment FROM TableTransactionPayment p INNER JOIN TableTransactionHead h ON h.Id=p.FkTransactionHeadId INNER JOIN TableTransactionDocumentType dt ON dt.Id=h.FkTransactionDocumentTypeId WHERE h.IsVoided=0 AND strftime('%m-%Y',h.TransactionDateTime)= strftime('%m-%Y','now') AND dt.[No] NOT IN (8,9,10) AND p.FkPaymentTypeId=1"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xCashReportDataModel.CashPayment = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["CashPayment"]) / 100));
                }

                xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT IFNULL(SUM(p.PaymentAmount),0) as CardPayment FROM TableTransactionPayment p INNER JOIN TableTransactionHead h ON h.Id=p.FkTransactionHeadId INNER JOIN TableTransactionDocumentType dt ON dt.Id=h.FkTransactionDocumentTypeId WHERE h.IsVoided=0 AND strftime('%m-%Y',h.TransactionDateTime)= strftime('%m-%Y','now') AND dt.[No] NOT IN (8,9,10) AND p.FkPaymentTypeId=2"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xCashReportDataModel.CardPayment = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["CardPayment"]) / 100));
                }

                xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT IFNULL(SUM(p.PaymentAmount),0) as OtherPayment FROM TableTransactionPayment p INNER JOIN TableTransactionHead h ON h.Id=p.FkTransactionHeadId INNER JOIN TableTransactionDocumentType dt ON dt.Id=h.FkTransactionDocumentTypeId WHERE h.IsVoided=0 AND strftime('%m-%Y',h.TransactionDateTime)= strftime('%m-%Y','now') AND dt.[No] NOT IN (8,9,10) AND p.FkPaymentTypeId NOT IN (1,2)"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xCashReportDataModel.OtherPayment = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["OtherPayment"]) / 100));
                }
                xCashReportDataModel.Day = "TOPLAM";
                xCashReportList.Add(xCashReportDataModel);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xCashReportList;
        }
        public List<CashReportDataModel> xGetCashReportMonthlyDetailed()
        {
            List<CashReportDataModel> xCashReportList = new List<CashReportDataModel>();
            try
            {
                for (int i = 1; i <= Convert.ToInt32(DateTime.Now.Day); i++)
                {
                    
                    string strDateDay = i < 10 ? "0" + i : i.ToString();
                    string strDateMonth = DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month : DateTime.Now.Month.ToString();
                    string strDateNow = strDateDay + "-" + strDateMonth + "-" + DateTime.Now.Year;
                    CashReportDataModel xCashReportDataModel = new CashReportDataModel();

                    DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT ifnull(sum(h.ReceiptTotalPrice),0) as ReceiptTotal, (ifnull(sum(h.ReceiptTotalPrice),0) - ifnull(sum(h.ReceiptTotalVat),0)) as CashWithoutVat FROM TableTransactionHead h INNER JOIN TableTransactionDocumentType dt ON dt.Id=h.FkTransactionDocumentTypeId WHERE h.IsVoided=0 AND dt.[No] NOT IN (8,9,10) ANd (strftime('%d-%m-%Y',h.TransactionDateTime) = '{0}')", strDateNow));

                    if (xDataTable != null && xDataTable.Rows.Count > 0)
                    {
                        xCashReportDataModel.ReceiptTotal = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["ReceiptTotal"]) / 100));
                        xCashReportDataModel.CashWithoutVat = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["CashWithoutVat"]) / 100));
                    }

                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT ifnull(sum(h.ReceiptTotalPrice),0) as ReturnProductCash FROM TableTransactionHead h INNER JOIN TableTransactionDocumentType dt ON dt.[No]=h.TransactionDocumentTypeNo WHERE h.IsVoided=0 AND dt.[No]=10 AND (strftime('%d-%m-%Y',h.TransactionDateTime) = '{0}')", strDateNow));

                    if (xDataTable != null && xDataTable.Rows.Count > 0)
                    {
                        xCashReportDataModel.ReturnProductCash = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["ReturnProductCash"]) / 100));
                    }

                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("ATTACH DATABASE 'SaleFlex.POS.STOCK.db3' as STOCK;SELECT IFNULL(SUM(CASE WHEN plu.StockUnitNo = 1 THEN (tpb.PurchasePrice*td.Quantity)/1000 ELSE (tpb.PurchasePrice*td.Quantity) END),0) as PurchasePrice FROM TableTransactionHead h JOIN TableTransactionDocumentType dt ON h.TransactionDocumentTypeNo=dt.No JOIN TableTransactionDetail td ON td.FkTransactionHeadId=h.Id INNER JOIN STOCK.TablePluBarcode as tpb ON tpb.FkPluId=td.FkPluId INNER JOIN STOCK.TablePlu as plu ON plu.Id=tpb.FkPluId WHERE h.IsVoided=0 AND dt.[No] NOT IN (8,9,10) AND (strftime('%d-%m-%Y',h.TransactionDateTime) = '{0}')", strDateNow));

                    if (xDataTable != null && xDataTable.Rows.Count > 0)
                    {
                        xCashReportDataModel.PurchasePrice = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["PurchasePrice"]) / 100));
                    }

                    xCashReportDataModel.Profit = string.Format("{0:#,0.00}", (decimal.Parse(xCashReportDataModel.CashWithoutVat) - decimal.Parse(xCashReportDataModel.PurchasePrice)));

                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT IFNULL(SUM(p.PaymentAmount),0) as CashPayment FROM TableTransactionPayment p INNER JOIN TableTransactionHead h ON h.Id=p.FkTransactionHeadId INNER JOIN TableTransactionDocumentType dt ON dt.No=h.TransactionDocumentTypeNo WHERE p.FkPaymentTypeId=1 AND h.IsVoided=0 AND dt.[No] NOT IN (8,9,10) AND (strftime('%d-%m-%Y',h.TransactionDateTime)= '{0}')", strDateNow));

                    if (xDataTable != null && xDataTable.Rows.Count > 0)
                    {
                        xCashReportDataModel.CashPayment = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["CashPayment"]) / 100));
                    }

                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT IFNULL(SUM(p.PaymentAmount),0) as CardPayment FROM TableTransactionPayment p INNER JOIN TableTransactionHead h ON h.Id=p.FkTransactionHeadId INNER JOIN TableTransactionDocumentType dt ON dt.No=h.TransactionDocumentTypeNo WHERE p.FkPaymentTypeId=2 AND h.IsVoided=0 AND dt.[No] NOT IN (8,9,10) AND (strftime('%d-%m-%Y',h.TransactionDateTime)= '{0}')", strDateNow));

                    if (xDataTable != null && xDataTable.Rows.Count > 0)
                    {
                        xCashReportDataModel.CardPayment = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["CardPayment"]) / 100));
                    }

                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSaleFileName).xExecuteDataTable(string.Format("SELECT IFNULL(SUM(p.PaymentAmount),0) as OtherPayment FROM TableTransactionPayment p INNER JOIN TableTransactionHead h ON h.Id=p.FkTransactionHeadId INNER JOIN TableTransactionDocumentType dt ON dt.No=h.TransactionDocumentTypeNo WHERE p.FkPaymentTypeId NOT IN (1,2) AND h.IsVoided=0 AND dt.[No] NOT IN (8,9,10) AND (strftime('%d-%m-%Y',h.TransactionDateTime)= '{0}')", strDateNow));

                    if (xDataTable != null && xDataTable.Rows.Count > 0)
                    {
                        xCashReportDataModel.OtherPayment = string.Format("{0:#,0.00}", (Convert.ToDecimal(xDataTable.Rows[0]["OtherPayment"]) / 100));
                    }

                    xCashReportDataModel.Day = strDateNow;
                    xCashReportList.Add(xCashReportDataModel);
                }
                xCashReportList.AddRange(xGetCashReportMonthly());
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xCashReportList;
        }
    }
    #endregion
}
