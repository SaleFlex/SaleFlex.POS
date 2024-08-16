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
        public List<KeyboardTypeFirstDataModel> xListGetKeyboardTypeFirst()
        {
            return xListGetKeyboardTypeFirst(String.Empty);
        }

        public List<KeyboardTypeFirstDataModel> xListGetKeyboardTypeFirst(string prm_strDefaultButtonName)
        {
            try
            {
                List<KeyboardTypeFirstDataModel> xListKeyboardTypeFirstDataModel = new List<KeyboardTypeFirstDataModel>();

                return xListKeyboardTypeFirstDataModel;
            }
            catch
            {
                return null;
            }
        }

        public bool bSaveKeyboardTypeFirst(KeyboardTypeFirstDataModel prm_xKeyboardTypeFirstDataModel)
        {
            try
            {                
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
