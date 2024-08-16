using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SaleFlex.UserInterface.Controls;
using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.POS.Manager;
using SaleFlex.POS.Device.Manager;

namespace SaleFlex.UserInterface.Manager
{
    public partial class Events
    {
        /// <summary>
        /// GET_PLU_FROM_MAINGROUP
        /// </summary>
        /// <param name="prm_objSender"></param>
        /// <param name="prm_xEventArgs"></param>
        public void vGetPluFromMainGroup(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                
                Control xControl = (Control)prm_objSender;
                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton)
                {
                    CustomButton xCustomButton = (CustomButton)prm_objSender;
                    if (xCustomButton.strName.Length > 9 && xCustomButton.strName.Substring(0, 9).ToUpper() == "MAINGROUP")
                    {
                        CustomEventHandler xCustomEventHandler = new CustomEventHandler();

                        int iPLUMainGroupNo = int.Parse(xCustomButton.strName.Substring(9, xCustomButton.strName.Length - 9));
                        int m_iTabIndex = xCustomButton.TabIndex + 5;
                        
                        List<PluDataModel> xListPluDataModel = new List<PluDataModel>();
                        xListPluDataModel = Dao.xGetInstance().xListGetPlusByMainGroupId(iPLUMainGroupNo);

                        List<Control> xWillDeleteControls = new List<Control>();
                        foreach (Control xFormControl in m_xLastCustomForm.Controls)
                        {
                            if (xFormControl is CustomButton && ((CustomButton)xFormControl).strName.ToUpper().StartsWith("PLU"))
                            {
                                xWillDeleteControls.Add(xFormControl);                                
                            }
                        }

                        foreach (Control xWillDeleteControl in xWillDeleteControls)
                        {
                            xWillDeleteControl.Dispose();
                        }

                        List<FormControlDataModel> xListPLUFormControlDataModel = m_xLastCustomForm.m_xFormDataModel.xListFormControlDataModel.Where(x => x.strName.ToUpper().StartsWith("PLU")).ToList();
                        
                        for (int iIndex = 0; iIndex < xListPLUFormControlDataModel.Count; iIndex++)
                        {
                            if (xListPluDataModel.Count > iIndex)
                            {
                                FormControlDataModel xFormControlDataModel = xListPLUFormControlDataModel[iIndex];
                                xFormControlDataModel.strName = string.Format("{0}{1}", "PLU", xListPluDataModel[iIndex].strCode);
                                xListPLUFormControlDataModel[iIndex] = xFormControlDataModel;

                                CustomButton xNewCustomButton = new CustomButton(xFormControlDataModel);
                                xNewCustomButton.TabIndex = m_iTabIndex++;

                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction1.strName) == false)
                                    xNewCustomButton.xEventHandler1 = xCustomEventHandler.xEventDistributor(xFormControlDataModel.xFormControlFunction1.strName);
                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction2.strName) == false)
                                    xNewCustomButton.xEventHandler2 = xCustomEventHandler.xEventDistributor(xFormControlDataModel.xFormControlFunction2.strName);

                                m_xLastCustomForm.bAddControl(xNewCustomButton, xFormControlDataModel);
                            }
                            else { }
                        }
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

    }
}
