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
        public DepartmentDataModel xGetDepartmentByNo(int prm_iDepartmentNo)
        {
            List<DepartmentDataModel> xListDepartmentDataModel = xListGetDepartments(prm_iDepartmentNo);

            if (xListDepartmentDataModel == null)
                return null;

            return xListDepartmentDataModel.First();
        }

        public List<DepartmentDataModel> xListGetDepartments()
        {
            return xListGetDepartments(0);
        }

        public List<DepartmentDataModel> xListGetDepartments(int prm_iDepartmentNo)
        {
            try
            {
                List<DepartmentDataModel> xListDepartmentDataModel = null;

                if (xListDepartmentDataModel == null) xListDepartmentDataModel = new List<DepartmentDataModel>();

                DepartmentDataModel xDepartmentDataModel = new DepartmentDataModel();
                xDepartmentDataModel.iId = 1;
                xDepartmentDataModel.iNo = 1;
                xDepartmentDataModel.strName = "MISCELLANEOUS";
                xDepartmentDataModel.xVat = new VatDataModel { iId = 1, iNo = 1, iRate = 2000, strName = "20" };
                xDepartmentDataModel.lDefaultQuantity = 1;
                xDepartmentDataModel.lDefaultPrice = 10;
                xListDepartmentDataModel.Add(xDepartmentDataModel);

                return xListDepartmentDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveDepartment(DepartmentDataModel prm_xDepartmentDataModel)
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
