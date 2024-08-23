using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data;

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
            FormFunctionDataModel xFormFunctionDataModel = new FormFunctionDataModel();

            xFormFunctionDataModel.bNeedAuth = false;
            xFormFunctionDataModel.bNeedLogin = true;
            xFormFunctionDataModel.iNo = 1;

            return xFormFunctionDataModel;
        }
    }
}
