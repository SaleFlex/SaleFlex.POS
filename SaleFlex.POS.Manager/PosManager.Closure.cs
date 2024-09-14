using SaleFlex.Data.AccessLayer;
using SaleFlex.Data.Models;
using SaleFlex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFlex.POS.Manager
{
    public partial class PosManager
    {
        public bool bClosure()
        {
            ClosureDataModel xClosureDataModel = new ClosureDataModel();

            if (m_xPosManagerData.xCashierDataModel == null)
            {
                m_enumErrorCode = EnumErrorCode.NEED_CASHIER_LOGIN;
                return false;
            }

            if (m_xPosManagerData.xTransactionDataModel == null ||
                m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel == null ||
                m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber <= 1 ||
                m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber < 1)
            {
                m_enumErrorCode = EnumErrorCode.CLOSURE_NOT_POSSIBLE;
                return false;
            }

            xClosureDataModel = Dao.xGetInstance().xCalculateClosureData(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber);

            if (xClosureDataModel == null)
            {
                m_enumErrorCode = EnumErrorCode.CLOSURE_NOT_POSSIBLE;
                return false;
            }

            return true;
        }
    }
}
