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
        public List<StoreDataModel> xListGetStore()
        {
            return xListGetStore(0);
        }

        public List<StoreDataModel> xListGetStore(int prm_iStoreId)
        {
            try
            {
                List<StoreDataModel> xListStoreDataModel = null;

                if (xListStoreDataModel == null)
                    xListStoreDataModel = new List<StoreDataModel>();

                return xListStoreDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveStore(StoreDataModel prm_xStoreDataModel)
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

        public List<StoreDataModel> xListGetStoreManager()
        {
            return xListGetStoreManager(0, string.Empty);
        }

        public List<StoreDataModel> xListGetStoreManager(int prm_iNo, string prm_strUserName)
        {
            try
            {
                List<StoreDataModel> xListStoreDataModel = null;

                if (xListStoreDataModel == null)
                    xListStoreDataModel = new List<StoreDataModel>();

                return xListStoreDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveStoreManagerUserNameandPassword(StoreDataModel prm_xStoreDataModel)
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
