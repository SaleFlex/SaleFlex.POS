using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public ReceiptFooterDataModel xGetReceiptFooter()
        {
            return xGetReceiptFooter(1);
        }

        public ReceiptHeaderDataModel xGetReceiptHeader()
        {
            return xGetReceiptHeader(1);
        }

        public ReceiptFooterDataModel xGetReceiptFooter(int prm_iId)
        {
            try
            {
                ReceiptFooterDataModel xReceiptFooterDataModel = null;

                if (xReceiptFooterDataModel == null)
                    xReceiptFooterDataModel = new ReceiptFooterDataModel();

                return xReceiptFooterDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public ReceiptHeaderDataModel xGetReceiptHeader(int prm_iId)
        {
            try
            {
                ReceiptHeaderDataModel xReceiptHeaderDataModel = null;
                
                    if (xReceiptHeaderDataModel == null)
                    xReceiptHeaderDataModel = new ReceiptHeaderDataModel();

                return xReceiptHeaderDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveReceiptFooter(ReceiptFooterDataModel prm_xReceiptFooterDataModel)
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

        public bool bSaveReceiptHeader(ReceiptHeaderDataModel prm_xReceiptHeaderDataModel)
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
