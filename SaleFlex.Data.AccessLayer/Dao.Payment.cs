using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;
using SaleFlex.Data.AccessLayer;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public List<PaymentTypeDataModel> xListGetPaymentTypes()
        {
            List<PaymentTypeDataModel> xListPaymentTypeDataModel = null;

            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable(string.Format("SELECT * FROM TablePaymentType ORDER BY TypeNo"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xListPaymentTypeDataModel == null)
                            xListPaymentTypeDataModel = new List<PaymentTypeDataModel>();

                        if (xDataRow != null)
                        {
                            PaymentTypeDataModel xPaymentTypeDataModel = new PaymentTypeDataModel();

                            xPaymentTypeDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xPaymentTypeDataModel.iTypeNo = Convert.ToInt32(xDataRow["TypeNo"]);
                            xPaymentTypeDataModel.strTypeName = Convert.ToString(xDataRow["TypeName"]) ?? string.Empty;
                            xPaymentTypeDataModel.strTypeDescription = Convert.ToString(xDataRow["TypeDescription"]) ?? string.Empty;

                            xListPaymentTypeDataModel.Add(xPaymentTypeDataModel);
                        }
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xListPaymentTypeDataModel;
        }

        public void vSavePaymentType(ServiceDataModel.PaymentTypeModel prm_xPaymentTypeDataModel)
        {
            try
            {
                Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteVoidDataTable(
                    string.Format("INSERT INTO TablePaymentType (TypeNo, TypeName, TypeDescription) VALUES({0},'{1}','{2}');",
                    prm_xPaymentTypeDataModel.TypeNo,
                    prm_xPaymentTypeDataModel.TypeName,
                    prm_xPaymentTypeDataModel.TypeDescription));
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public List<int> xSuspendedListValues;
        public bool bAddSuspendedList(int prm_iTransactionHeadId)
        {
            bool bReturnValue = false;
            int iSuspendListLimit = 1;
            try
            {
                if (xSuspendedListValues == null || xSuspendedListValues.Count == 0)
                {
                    xSuspendedListValues = new List<int>(1);
                }
                else if (xSuspendedListValues[0] == prm_iTransactionHeadId)
                {
                    bReturnValue = true;
                }
                if (!(xSuspendedListValues.Count >= iSuspendListLimit))
                {
                    if (!xSuspendedListValues.Contains(prm_iTransactionHeadId))
                    {
                        xSuspendedListValues.Add(prm_iTransactionHeadId);
                    }
                    bReturnValue = true;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                throw;
            }

            return bReturnValue;
        }

        public void vRemoveFromSuspendedList(int prm_iTransactionHeadId)
        {
            xSuspendedListValues.Remove(prm_iTransactionHeadId);
        }
    }
}
