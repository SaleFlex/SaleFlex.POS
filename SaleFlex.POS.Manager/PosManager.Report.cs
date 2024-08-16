using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.CommonLibrary;

namespace SaleFlex.POS.Manager
{
    public partial class PosManager
    {
        public bool bSaleDetailReport(out List<TransactionDataModel> prm_xListTransactionDataModel)
        {
            List<TransactionDataModel> xListTransactionDataModel = new List<TransactionDataModel>();
            TransactionDataModel xTransactionDataModel = new TransactionDataModel();

            xListTransactionDataModel.Add(xTransactionDataModel);

            prm_xListTransactionDataModel = xListTransactionDataModel;

            return true;
        }

        public bool bPluReport()
        {
            return bPluReport(DateTime.Today, DateTime.Now.AddMinutes(1));
        }

        public bool bPluReport(DateTime prm_xStartDate, DateTime prm_xEndDate)
        {
            return true;
        }
    }
}
