using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public bool bCheckSalesDb()
        {
            bool returnvalue = false;

            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable("SELECT count(*) FROM sqlite_master WHERE type='table'");

                if (xDataTable.Rows.Count > 0)
                {
                    int iTableCount = Convert.ToInt32(xDataTable.Rows[0][0]) - 1;

                    if (iTableCount == 3)
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

        public int iGetPosId()
        {
            return 0;
        }

        public List<TransactionHeadDataModel> xGetListClosedTransactionHeaders(int prm_iTransactionDocumentTypeNo = 0)
        {
            try
            {
                List<TransactionHeadDataModel> xListTransactionHeadDataModel = null;

                if (xListTransactionHeadDataModel == null)
                    xListTransactionHeadDataModel = new List<TransactionHeadDataModel>();

                return xListTransactionHeadDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<TransactionHeadDataModel> xGetListOpenTransactionHeaders()
        {
            try
            {
                List<TransactionHeadDataModel> xListTransactionHeadDataModel = null;

                if (xListTransactionHeadDataModel == null)
                    xListTransactionHeadDataModel = new List<TransactionHeadDataModel>();

                return xListTransactionHeadDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public TransactionDataModel xGetLastOpenTransaction()
        {
            try
            {
                TransactionDataModel xTransactionDataModel = null;
                TransactionHeadDataModel xTransactionHeadDataModel = null;

                if ((xTransactionHeadDataModel = xGetLastOpenTransactionHead()) != null)
                {
                    xTransactionDataModel = new TransactionDataModel();
                    xTransactionDataModel.xTransactionHeadDataModel = xTransactionHeadDataModel;

                    TransactionDetailDataModel xTransactionDetailDataModel = new TransactionDetailDataModel();
                    xTransactionDetailDataModel.bCanceled = false;

                    xTransactionDataModel.xListTransactionDetailDataModel.Add(xTransactionDetailDataModel);
                }

                return xTransactionDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public TransactionHeadDataModel xGetLastOpenTransactionHead()
        {
            try
            {
                List<TransactionHeadDataModel> xListTransactionHeadDataModel = null;

                if ((xListTransactionHeadDataModel = xGetListOpenTransactionHeaders()) != null)
                {
                    return xListTransactionHeadDataModel.First();
                }

                return null;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public ServiceDataModel.TransactionHeadModel GetTransactionByHeadId(long transactionHeadId)
        {
            try
            {
                ServiceDataModel.TransactionHeadModel transactionHead = new ServiceDataModel.TransactionHeadModel();
                var query = string.Format("SELECT * FROM TableTransactionHead WHERE Id = {0}", transactionHeadId);
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);
                if (xDataTable.Rows.Count > 0)
                {
                    transactionHead = xDataTable.Rows[0].ToModelItem<ServiceDataModel.TransactionHeadModel>();
                }

                transactionHead.TransactionDetailList = GetTransactionDetailListByHeadId(transactionHeadId);
                transactionHead.TransactionPaymentList = GetTransactionPaymentListByHeadId(transactionHeadId);

                return transactionHead;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return new ServiceDataModel.TransactionHeadModel();
            }
        }

        public List<ServiceDataModel.TransactionDetailModel> GetTransactionDetailListByHeadId(long transactionHeadId)
        {
            try
            {
                List<ServiceDataModel.TransactionDetailModel> transactionDetailList = new List<ServiceDataModel.TransactionDetailModel>();

                var query = string.Format("SELECT * FROM TableTransactionDetail WHERE FkTransactionHeadId = {0}", transactionHeadId);
                DataTable dataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);
                foreach (DataRow dr in dataTable.Rows)
                {
                    transactionDetailList.Add(dr.ToModelItem<ServiceDataModel.TransactionDetailModel>());
                }

                return transactionDetailList;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return new List<ServiceDataModel.TransactionDetailModel>();
            }
        }

        public List<ServiceDataModel.TransactionPaymentModel> GetTransactionPaymentListByHeadId(long transactionHeadId)
        {
            try
            {
                List<ServiceDataModel.TransactionPaymentModel> transactionPaymentList = new List<ServiceDataModel.TransactionPaymentModel>();

                var query = string.Format("SELECT * FROM TableTransactionPayment WHERE FkTransactionHeadId = {0}", transactionHeadId);
                DataTable dataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);
                foreach (DataRow dr in dataTable.Rows)
                {
                    transactionPaymentList.Add(dr.ToModelItem<ServiceDataModel.TransactionPaymentModel>());
                }

                return transactionPaymentList;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return new List<ServiceDataModel.TransactionPaymentModel>();
            }
        }

        public List<ServiceDataModel.TransactionHeadModel> GetUnsendTransactionList()
        {
            try
            {
                var transactionHeadList = new List<ServiceDataModel.TransactionHeadModel>();
                var transactionHead = new ServiceDataModel.TransactionHeadModel();
                var query = string.Format("SELECT * FROM TableTransactionHead WHERE FkServerId is null");
                DataTable dataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    transactionHead = dataRow.ToModelItem<ServiceDataModel.TransactionHeadModel>();
                    transactionHead.TransactionDetailList = GetTransactionDetailListByHeadId(transactionHead.Id);
                    transactionHead.TransactionPaymentList = GetTransactionPaymentListByHeadId(transactionHead.Id);
                    transactionHeadList.Add(transactionHead);
                }

                return transactionHeadList;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return new List<ServiceDataModel.TransactionHeadModel>();
            }
        }
             
        public bool bUpdateTransactionIsSend(long prm_lTransactionHeadId)
        {
            bool bReturnValue = false;
            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(string.Format("UPDATE TableTransactionHead SET IsSend = 1 WHERE Id = {0}; SELECT changes() as Result;", prm_lTransactionHeadId));

                if (int.Parse(xDataTable.Rows[0]["Result"].ToString()) > 0)
                {
                    bReturnValue = true;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return bReturnValue;
        }

        public TransactionDetailDataModel xGetTransactionDetail(int prm_iTransactionDetailId)
        {
            try
            {
                TransactionDetailDataModel xTransactionDetailDataModel = new TransactionDetailDataModel();

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(string.Format("SELECT * FROM TableTransactionDetail WHERE Id={0}", prm_iTransactionDetailId));
                if (xDataTable.Rows.Count > 0)
                {
                    xTransactionDetailDataModel.iId = int.Parse(xDataTable.Rows[0]["Id"].ToString());
                    xTransactionDetailDataModel.iFkTransactionHeadId = int.Parse(xDataTable.Rows[0]["FkTransactionHeadId"].ToString());
                    xTransactionDetailDataModel.iFkPluId = int.Parse(xDataTable.Rows[0]["FkPluId"].ToString());
                    xTransactionDetailDataModel.iFkDepartmentId = int.Parse(xDataTable.Rows[0]["FkDepartmentId"].ToString());
                    xTransactionDetailDataModel.decPrice = long.Parse(xDataTable.Rows[0]["Price"].ToString());
                    xTransactionDetailDataModel.decQuantity = long.Parse(xDataTable.Rows[0]["Quantity"].ToString());
                    xTransactionDetailDataModel.decTotalPrice = long.Parse(xDataTable.Rows[0]["TotalPrice"].ToString());
                    xTransactionDetailDataModel.decTotalPriceWithoutVat = long.Parse(xDataTable.Rows[0]["TotalPriceWithoutVat"].ToString());
                    xTransactionDetailDataModel.decTotalVat = long.Parse(xDataTable.Rows[0]["TotalVat"].ToString());
                    xTransactionDetailDataModel.bCanceled = bool.Parse(xDataTable.Rows[0]["Canceled"].ToString());
                    xTransactionDetailDataModel.xTransactionDetailDateTime = DateTime.Parse(xDataTable.Rows[0]["TransactionDetailDateTime"].ToString());
                    xTransactionDetailDataModel.xPluDataModel = Dao.xGetInstance().xGetPluById(xTransactionDetailDataModel.iFkPluId);
                }

                return xTransactionDetailDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<TransactionDetailDataModel> xGetListTransactionDetailByHeadId(int prm_iTransactionHeadId)
        {
            try
            {
                List<TransactionDetailDataModel> xTransactionDetailDataModel = new List<TransactionDetailDataModel>();


                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(string.Format("SELECT * FROM TableTransactionDetail WHERE FkTransactionHeadId={0}", prm_iTransactionHeadId));
                if (xDataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < xDataTable.Rows.Count; i++)
                    {
                        TransactionDetailDataModel xDataModel = new TransactionDetailDataModel();

                        xDataModel.iId = int.Parse(xDataTable.Rows[i]["Id"].ToString());
                        xDataModel.iFkTransactionHeadId = int.Parse(xDataTable.Rows[i]["FkTransactionHeadId"].ToString());
                        xDataModel.iFkPluId = int.Parse(xDataTable.Rows[i]["FkPluId"].ToString());
                        xDataModel.iFkDepartmentId = int.Parse(xDataTable.Rows[i]["FkDepartmentId"].ToString());
                        xDataModel.decPrice = long.Parse(xDataTable.Rows[i]["Price"].ToString());
                        xDataModel.decQuantity = long.Parse(xDataTable.Rows[i]["Quantity"].ToString());
                        xDataModel.decTotalPrice = long.Parse(xDataTable.Rows[i]["TotalPrice"].ToString());
                        xDataModel.decTotalPriceWithoutVat = long.Parse(xDataTable.Rows[i]["TotalPriceWithoutVat"].ToString());
                        xDataModel.decTotalVat = long.Parse(xDataTable.Rows[i]["TotalVat"].ToString());
                        xDataModel.bCanceled = bool.Parse(xDataTable.Rows[i]["Canceled"].ToString());
                        xDataModel.xTransactionDetailDateTime = DateTime.Parse(xDataTable.Rows[i]["TransactionDetailDateTime"].ToString());
                        xDataModel.xPluDataModel = Dao.xGetInstance().xGetPluById(xDataModel.iFkPluId);

                        xTransactionDetailDataModel.Add(xDataModel);
                    }

                }

                return xTransactionDetailDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public TransactionDataModel xGetTransactionDataModelByHeadId(int prm_iTransactionHeadId)
        {
            try
            {
                TransactionDataModel xTransactionDataModel = new TransactionDataModel();
                TransactionHeadDataModel xTransactionHeadDataModel = xGetTransactionHeader(prm_iTransactionHeadId);
                List<TransactionDetailDataModel> xTransactionDetailDataModel = xGetListTransactionDetailByHeadId(prm_iTransactionHeadId);

                xTransactionDataModel.xTransactionHeadDataModel = xTransactionHeadDataModel;
                xTransactionDataModel.xListTransactionDetailDataModel = xTransactionDetailDataModel;


                return xTransactionDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public TransactionHeadDataModel xGetTransactionHeader(int prm_iTransactionHeadId)
        {
            try
            {
                TransactionHeadDataModel xTransactionHeadDataModel = new TransactionHeadDataModel();

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(string.Format("SELECT * FROM TableTransactionHead WHERE Id={0}", prm_iTransactionHeadId));
                if (xDataTable.Rows.Count > 0)
                {
                    xTransactionHeadDataModel.iId = int.Parse(xDataTable.Rows[0]["Id"].ToString());
                    xTransactionHeadDataModel.iFkCashierId = int.Parse(xDataTable.Rows[0]["FkCashierId"].ToString());
                    xTransactionHeadDataModel.xTransactionDateTime = DateTime.Parse(xDataTable.Rows[0]["TransactionDateTime"].ToString());
                    xTransactionHeadDataModel.iFkTransactionDocumentTypeId = int.Parse(xDataTable.Rows[0]["FkTransactionDocumentTypeId"].ToString());
                    xTransactionHeadDataModel.iTransactionDocumentTypeNo = int.Parse(xDataTable.Rows[0]["TransactionDocumentTypeNo"].ToString());
                    xTransactionHeadDataModel.iFkCustomerId = int.Parse(xDataTable.Rows[0]["FkCustomerId"].ToString());
                    xTransactionHeadDataModel.strTransactionNo = xDataTable.Rows[0]["TransactionNo"].ToString();
                    xTransactionHeadDataModel.iReceiptNumber = int.Parse(xDataTable.Rows[0]["ReceiptNumber"].ToString());
                    xTransactionHeadDataModel.iZNumber = int.Parse(xDataTable.Rows[0]["ZNumber"].ToString());
                    xTransactionHeadDataModel.decReceiptTotalPrice = long.Parse(xDataTable.Rows[0]["ReceiptTotalPrice"].ToString());
                    xTransactionHeadDataModel.decReceiptTotalVat = long.Parse(xDataTable.Rows[0]["ReceiptTotalVat"].ToString());
                    xTransactionHeadDataModel.decTotalDiscountAmount = long.Parse(xDataTable.Rows[0]["TotalDiscountAmount"].ToString());
                    xTransactionHeadDataModel.decTransactionsDiscountAmount = long.Parse(xDataTable.Rows[0]["TransactionsDiscountAmount"].ToString());
                    xTransactionHeadDataModel.decCustomerTotalDiscountAmount = long.Parse(xDataTable.Rows[0]["CustomerTotalDiscountAmount"].ToString());
                    xTransactionHeadDataModel.decPromotionTotalDiscountAmount = long.Parse(xDataTable.Rows[0]["PromotionTotalDiscountAmount"].ToString());
                    xTransactionHeadDataModel.decSurchargeAmount = long.Parse(xDataTable.Rows[0]["SurchargeAmount"].ToString());
                    xTransactionHeadDataModel.decPaymentAmount = long.Parse(xDataTable.Rows[0]["PaymentAmount"].ToString());
                    xTransactionHeadDataModel.decChangeAmount = long.Parse(xDataTable.Rows[0]["ChangeAmount"].ToString());
                    xTransactionHeadDataModel.decRoundAmount = long.Parse(xDataTable.Rows[0]["RoundAmount"].ToString());
                    xTransactionHeadDataModel.bIsVoided = bool.Parse(xDataTable.Rows[0]["IsVoided"].ToString());
                }

                return xTransactionHeadDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<TransactionDetailDataModel> xGetListClosedTransaction()
        {
            return xGetListClosedTransaction(0);
        }

        public List<TransactionDetailDataModel> xGetListClosedTransaction(long prm_lTransactionHeadId)
        {
            try
            {
                List<TransactionDetailDataModel> xListTransactionDetailDataModel = new List<TransactionDetailDataModel>();

                return xListTransactionDetailDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bCloseTransaction(long prm_lTransactionId)
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

        public bool bCancelTransaction(long prm_lTransactionId)
        {
            bool bReturnValue = false;
            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(string.Format("UPDATE TableTransactionHead SET IsVoided=1 WHERE Id={0}; SELECT changes() as Result;", prm_lTransactionId));

                if (int.Parse(xDataTable.Rows[0]["Result"].ToString()) > 0)
                {
                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(string.Format("UPDATE TableTransactionDetail SET Canceled=1 WHERE FkTransactionHeadId={0}; SELECT changes() as Result;", prm_lTransactionId));
                    bReturnValue = true;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return bReturnValue;
        }

        public bool bCancelTransactionDetail(long prm_lTransactionDetailId)
        {
            bool bReturnValue = false;
            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(string.Format("UPDATE TableTransactionDetail SET Canceled=1 WHERE Id={0}; SELECT changes() as Result;", prm_lTransactionDetailId));

                if (int.Parse(xDataTable.Rows[0]["Result"].ToString()) > 0)
                {
                    bReturnValue = true;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return bReturnValue;
        }

        public List<TransactionTypeDataModel> xListGetTransactionTypes()
        {
            try
            {
                List<TransactionTypeDataModel> xListTransactionTypeDataModel = null;

                if (xListTransactionTypeDataModel == null)
                    xListTransactionTypeDataModel = new List<TransactionTypeDataModel>();

                return xListTransactionTypeDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bUpdateTransactionHead(TransactionHeadDataModel prm_xTransactionHeadDataModel)
        {
            bool bReturnValue = false;
            try
            {
                var query = string.Format("UPDATE TableTransactionHead SET ReceiptTotalPrice={0}, ReceiptTotalVat={1} WHERE Id={2}; SELECT changes() as Result",
                    prm_xTransactionHeadDataModel.decReceiptTotalPrice,
                    prm_xTransactionHeadDataModel.decReceiptTotalVat,
                    prm_xTransactionHeadDataModel.iId);
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);

                if (int.Parse(xDataTable.Rows[0]["Result"].ToString()) > 0)
                {
                    bReturnValue = true;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return bReturnValue;

        }

        public bool bInsertTransactionHead(ref TransactionHeadDataModel prm_xTransactionHeadDataModel)
        {
            bool bReturnValue = false;
            try
            {
                var query = string.Format("INSERT INTO TableTransactionHead(FkCashierId, TransactionDateTime, FkTransactionDocumentTypeId, FkCustomerId, TransactionNo, ReceiptNumber, ZNumber, ReceiptTotalPrice, ReceiptTotalVat, TotalDiscountAmount, TransactionsDiscountAmount, CustomerTotalDiscountAmount, PromotionTotalDiscountAmount, SurchargeAmount, PaymentAmount, ChangeAmount, RoundAmount) VALUES({0},datetime('now', 'localtime'),{1},{2},'{3}',{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}); SELECT last_insert_rowid() AS InsertedId",
                    prm_xTransactionHeadDataModel.iFkCashierId,
                    prm_xTransactionHeadDataModel.iFkTransactionDocumentTypeId,
                    prm_xTransactionHeadDataModel.iFkCustomerId,
                    prm_xTransactionHeadDataModel.strTransactionNo,
                    prm_xTransactionHeadDataModel.iReceiptNumber,
                    prm_xTransactionHeadDataModel.iZNumber,
                    prm_xTransactionHeadDataModel.decReceiptTotalPrice,
                    prm_xTransactionHeadDataModel.decReceiptTotalVat,
                    prm_xTransactionHeadDataModel.decTotalDiscountAmount,
                    prm_xTransactionHeadDataModel.decTransactionsDiscountAmount,
                    prm_xTransactionHeadDataModel.decCustomerTotalDiscountAmount,
                    prm_xTransactionHeadDataModel.decPromotionTotalDiscountAmount,
                    prm_xTransactionHeadDataModel.decSurchargeAmount,
                    prm_xTransactionHeadDataModel.decPaymentAmount,
                    prm_xTransactionHeadDataModel.decChangeAmount,
                    prm_xTransactionHeadDataModel.decRoundAmount);
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);

                if (int.Parse(xDataTable.Rows[0]["InsertedId"].ToString()) > 0)
                {
                    bReturnValue = true;
                    prm_xTransactionHeadDataModel.iId = int.Parse(xDataTable.Rows[0]["InsertedId"].ToString());
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return bReturnValue;
        }

        public bool bInsertTransactionDetail(ref TransactionDetailDataModel prm_xTransactionDetailDataModel)
        {
            bool returnvalue = false;
            try
            {
                var query = string.Format("INSERT INTO TableTransactionDetail(FkTransactionHeadId, FkPluId, FkDepartmentId, Price, Quantity, TotalPrice, TotalPriceWithoutVat, TotalVat, Canceled, TransactionDetailDateTime) VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},datetime('now', 'localtime') ); SELECT last_insert_rowid() as InsertedId ",
                    prm_xTransactionDetailDataModel.iFkTransactionHeadId,
                    prm_xTransactionDetailDataModel.iFkPluId,
                    prm_xTransactionDetailDataModel.iFkDepartmentId,
                    prm_xTransactionDetailDataModel.decPrice,
                    prm_xTransactionDetailDataModel.decQuantity,
                    prm_xTransactionDetailDataModel.decTotalPrice,
                    prm_xTransactionDetailDataModel.decTotalPriceWithoutVat,
                    prm_xTransactionDetailDataModel.decTotalVat.ToString(),
                    prm_xTransactionDetailDataModel.bCanceled == true ? 1 : 0);
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);

                if (int.Parse(xDataTable.Rows[0]["InsertedId"].ToString()) > 0)
                {
                    returnvalue = true;
                    prm_xTransactionDetailDataModel.iId = int.Parse(xDataTable.Rows[0]["InsertedId"].ToString());
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                returnvalue = false;
            }
            return returnvalue;
        }

        public bool bSaleDepartmentTemp(int prm_iTransactionHeadId, ref TransactionDetailDataModel prm_xTransactionDetailDataModel)
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

        public bool bSalePluTemp(long prm_lTransactionHead, ref TransactionDetailDataModel prm_xTransactionDetailDataModel)
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

        public bool bTransactionDetailTempDone(ref TransactionDetailDataModel prm_xTransactionDetailDataModel)
        {
            try
            {
                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return false;
        }

        public bool bPaymentTemp(long prm_lTransactionHead, ref PaymentDataModel prm_xPaymentDataModel)
        {
            try
            {
                var query = $"INSERT INTO TableTransactionPaymentDetail (FkTransactionHeadId, FkPaymentTypeId, Amount) VALUES({prm_lTransactionHead},{prm_xPaymentDataModel.xPaymentTypeDataModel.iTypeNo},{prm_xPaymentDataModel.lAmount}); SELECT last_insert_rowid() as InsertedId ";
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable(query);

                // Check if the DataTable has rows and retrieve the InsertedId.
                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    // Get the InsertedId from the first row of the result.
                    long insertedId = Convert.ToInt64(xDataTable.Rows[0]["InsertedId"]);

                    prm_xPaymentDataModel.lId = insertedId;
                }

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bPaymentTempDone(ref PaymentDataModel prm_xPaymentDataModel)
        {
            try
            {
                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return false;
        }

        public bool bSaleDepartment(long prm_lTransactionHead, ref TransactionDetailDataModel prm_xTransactionDetailDataModel)
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

        public bool bSalePlu(long prm_lTransactionHead, ref TransactionDetailDataModel prm_xTransactionDetailDataModel)
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

        public bool bPayment(long prm_lTransactionHead, ref PaymentDataModel prm_xPaymentDataModel)
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

        public int iGetLineDisplayColumn()
        {
            try
            {
                return 20;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return 20;
            }
        }

        public string strGetLineDisplayName()
        {
            return string.Empty;
        }

        #region TransactionDocumentType

        public List<TransactionDocumentTypeDataModel> xListGetTransactionDocumentTypes()
        {
            try
            {
                List<TransactionDocumentTypeDataModel> xListTransactionDocumentTypeDataModel = null;

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteDataTable("SELECT * FROM TableTransactionDocumentType ORDER BY Id");

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xListTransactionDocumentTypeDataModel == null)
                            xListTransactionDocumentTypeDataModel = new List<TransactionDocumentTypeDataModel>();

                        if (xDataRow != null)
                        {
                            TransactionDocumentTypeDataModel xTransactionDocumentTypeDataModel = new TransactionDocumentTypeDataModel();

                            xTransactionDocumentTypeDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xTransactionDocumentTypeDataModel.iNo = Convert.ToInt32(xDataRow["No"]);
                            xTransactionDocumentTypeDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                            xTransactionDocumentTypeDataModel.strDisplayName = Convert.ToString(xDataRow["DisplayName"]) ?? string.Empty;
                            xTransactionDocumentTypeDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;

                            xListTransactionDocumentTypeDataModel.Add(xTransactionDocumentTypeDataModel);
                        }

                    }
                }

                return xListTransactionDocumentTypeDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public void vSaveTransactionDocumentType(ServiceDataModel.TransactionDocumentType prm_xTransactionDocumentTypeDataModel)
        {
            try
            {
                Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteVoidDataTable(
                    string.Format("INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) " +
                    "VALUES({0},'{1}','{2}', '{3}');",
                    prm_xTransactionDocumentTypeDataModel.No,
                    prm_xTransactionDocumentTypeDataModel.Name,
                    prm_xTransactionDocumentTypeDataModel.DisplayName,
                    prm_xTransactionDocumentTypeDataModel.Description));
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void UpdateTransactionForSendServer(ServiceDataModel.TransactionHeadResponseModel transactionHeadResponse)
        {
            try
            {
                var query = string.Format("UPDATE TableTransactionHead Set FkServerId = '{0}' where Id = {1}", transactionHeadResponse.TransactionHead.FkServerId, transactionHeadResponse.TransactionHead.TransactionId);
                Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteVoidDataTable(query);
                foreach (var detail in transactionHeadResponse.TransactionDetailList)
                {
                    query = string.Format("UPDATE TableTransactionDetail Set FkServerId = '{0}' where Id = {1}", detail.FkServerId, detail.TransactionId);
                    Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteVoidDataTable(query);
                }
                foreach (var detail in transactionHeadResponse.TransactionPaymentList)
                {
                    query = string.Format("UPDATE TableTransactionPayment Set FkServerId = '{0}' where Id = {1}", detail.FkServerId, detail.TransactionId);
                    Dbo.xGetInstance(CommonProperty.prop_strDatabaseSalesFileNameAndPath).xExecuteVoidDataTable(query);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        #endregion
    }
}
