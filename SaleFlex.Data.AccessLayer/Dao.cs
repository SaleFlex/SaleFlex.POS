using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data;
using SaleFlex.Data.SQLite;
using System.Data;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        private static Dao m_xGlobalsInstance = null;
        private string m_strConnectionString = string.Empty;

        Dao()
        {
            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                throw new ApplicationException("DB CONNECTION FAILED");
            }
        }

        public static Dao xGetInstance()
        {
            if (m_xGlobalsInstance == null)
                m_xGlobalsInstance = new Dao();
            return m_xGlobalsInstance;
        }

        public long lGetSequence(string prm_strSequenceName)
        {
            return 1;
        }

        public TransactionDocumentDesignDataModel xGetTransactionDocumentDesign(int prm_iTransactionDocumentTypeDataModelId)
        {
            TransactionDocumentDesignDataModel xTransactionDocumentDesignDataModel = new TransactionDocumentDesignDataModel();
            return xTransactionDocumentDesignDataModel;
        }

        public FormFunctionDataModel xGetFormFunction(EnumFormType prm_enumFormType)
        {
            DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileName).xExecuteDataTable($"SELECT * FROM TableForm WHERE Function='{prm_enumFormType.ToString()}' ORDER BY Id");

            List<FormFunctionDataModel> xListFormFunctionDataModel = null;

            if (xDataTable != null && xDataTable.Rows.Count > 0)
            {
                foreach (DataRow xDataRow in xDataTable.Rows)
                {
                    if (xListFormFunctionDataModel == null)
                        xListFormFunctionDataModel = new List<FormFunctionDataModel>();

                    FormFunctionDataModel xFormFunctionDataModel = new FormFunctionDataModel();

                    xFormFunctionDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                    xFormFunctionDataModel.strName = Convert.ToString(xDataRow["Name"]);
                    xFormFunctionDataModel.bNeedAuth = Convert.ToBoolean(xDataRow["NeedAuth"]);
                    xFormFunctionDataModel.bNeedLogin = Convert.ToBoolean(xDataRow["NeedLogin"]);
                    xFormFunctionDataModel.iNo = Convert.ToInt32(xDataRow["FormNo"]);
                    xListFormFunctionDataModel.Add(xFormFunctionDataModel);
                }
            }
            
            return xListFormFunctionDataModel.FirstOrDefault();
        }
    }
}
