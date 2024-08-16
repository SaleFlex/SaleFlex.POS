using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public TransactionDocumentTypeDataModel xGetTransactionDocumentType(int prm_iTransactionDocumentNo)
        {
            try
            {
                return null;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public long lGetPrinterId()
        {
            return 0;
        }

        public TransactionDocumentDesignDataModel xGetTransactionDocumentDesign(long prm_lTransactionDocumentTypeId)
        {
            try
            {
                TransactionDocumentDesignDataModel xTransactionDocumentDesignDataModel = null;

                xTransactionDocumentDesignDataModel = new TransactionDocumentDesignDataModel();

                return xTransactionDocumentDesignDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<TransactionDocumentDesignDataModel> xListGetTransactionDocumentDesignDataModel()
        {
            return xListGetTransactionDocumentDesignDataModel(0, string.Empty, 0);
        }

        public List<TransactionDocumentDesignDataModel> xListGetTransactionDocumentDesignDataModel(int prm_iNo, string prm_strDocumentName, int prm_iDocumentTypeNo)
        {
            try
            {
                List<TransactionDocumentDesignDataModel> xListTransactionDocumentDesignDataModel = new List<TransactionDocumentDesignDataModel>();
                return xListTransactionDocumentDesignDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveDocumentDesign(TransactionDocumentDesignDataModel prm_xTransactionDocumentDesignDataModel)
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
