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
        public TemplatesDataModel xGetTemplatesById(long prm_iId)
        {
            List<TemplatesDataModel> xListTemplatesDataModel = xListGetTemplates(prm_iId);
            if (xListTemplatesDataModel == null)
                return null;

            return xListTemplatesDataModel.First();
        }

        public List<TemplatesDataModel> xListGetTemplates()
        {
            return xListGetTemplates(0);
        }

        public List<TemplatesDataModel> xListGetTemplates(long prm_iId)
        {
            try
            {
                List<TemplatesDataModel> xListTemplatesDataModel = new List<TemplatesDataModel>();

                return xListTemplatesDataModel;

            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }

        }

        public bool bSaveTemplates(TemplatesDataModel prm_xTemplatesDataModel)
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

        public bool bSaveFormControlsTemplates(long prm_lTemplateID, List<FormControlDataModel> prm_xListFormControlsDataModel)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<FormControlDataModel> xListGetFormControlsTemplates(long prm_lTemplateId)
        {
            try
            {
                List<FormControlDataModel> xListFormControlDataModel = null;

                if (xListFormControlDataModel == null)
                    xListFormControlDataModel = new List<FormControlDataModel>();

                return xListFormControlDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }
    }
}
