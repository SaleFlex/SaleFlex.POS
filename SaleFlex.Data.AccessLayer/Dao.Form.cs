using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public List<FormDataModel> xListGetForm(string prm_strFormName)
        {
            try
            {
                List<FormDataModel> xListFormDataModel = null;

                if (xListFormDataModel == null)
                    xListFormDataModel = new List<FormDataModel>();

                return xListFormDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public FormDataModel xGetFormByName(string prm_strFormName)
        {
            FormDataModel xFormDataModel = null;
            DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileName).xExecuteDataTable($"SELECT * FROM TableForm WHERE Name='{prm_strFormName}' ORDER BY Id");

            if (xDataTable != null)
            {
                DataRow xDataRow = xDataTable.Rows[0];
                if (xDataRow != null)
                {
                    xFormDataModel = new FormDataModel();

                    xFormDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                    xFormDataModel.iFormNo = Convert.ToInt32(xDataRow["FormNo"]);
                    xFormDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                    xFormDataModel.strFunction = Convert.ToString(xDataRow["Function"]) ?? string.Empty;
                    xFormDataModel.bNeedLogin = Convert.ToBoolean(xDataRow["NeedLogin"]);
                    xFormDataModel.bNeedAuth = Convert.ToBoolean(xDataRow["NeedAuth"]);
                    xFormDataModel.iWidth = Convert.ToInt32(xDataRow["Width"]);
                    xFormDataModel.iHeight = Convert.ToInt32(xDataRow["Height"]);
                    xFormDataModel.strFormBorderStyle = Convert.ToString(xDataRow["FormBorderStyle"]) ?? "NORMAL";
                    xFormDataModel.strStartPosition = Convert.ToString(xDataRow["StartPosition"]) ?? "CENTERSCREEN";
                    xFormDataModel.strCaption = Convert.ToString(xDataRow["Caption"]) ?? string.Empty;
                    xFormDataModel.strIcon = Convert.ToString(xDataRow["Icon"]) ?? string.Empty;
                    xFormDataModel.strImage = Convert.ToString(xDataRow["Image"]) ?? string.Empty;
                    xFormDataModel.strBackColor = Convert.ToString(xDataRow["BackColor"]) ?? "Gray";
                    xFormDataModel.bShowStatusBar = Convert.ToBoolean(xDataRow["ShowStatusBar"]);
                    xFormDataModel.bShowInTaskbar = Convert.ToBoolean(xDataRow["ShowInTaskbar"]);
                    xFormDataModel.bUseVirtualKeyboard = Convert.ToBoolean(xDataRow["UseVirtualKeyboard"]);
                    xFormDataModel.strImage = Convert.ToString(xDataRow["Image"]) ?? string.Empty;

                    xFormDataModel.xListFormControlDataModel = xListGetFormControls(xFormDataModel.iId);
                }
            }
            return xFormDataModel;
        }


        public List<FormControlDataModel> xGetShortCutButtons()
        {
            var query = string.Format("SELECT * FROM TableFormControl wHERE FormControlFunction1='SALE_PLU_BARCODE'  and TYPE='BUTTON'");
            DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileName).xExecuteDataTable(query);

            List<FormControlDataModel> xListFormControlDataModel = null;

            if (xDataTable != null && xDataTable.Rows.Count > 0)
            {
                foreach (DataRow xDataRow in xDataTable.Rows)
                {
                    if (xListFormControlDataModel == null)
                        xListFormControlDataModel = new List<FormControlDataModel>();

                    FormControlDataModel xFormControlDataModel = new FormControlDataModel();

                    xFormControlDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                    xFormControlDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                    xFormControlDataModel.iFkParentId = Convert.ToInt32(xDataRow["FkParentId"]);
                    xFormControlDataModel.strParentName = Convert.ToString(xDataRow["ParentName"]) ?? string.Empty;
                    xFormControlDataModel.iTypeNo = Convert.ToInt32(xDataRow["TypeNo"]);
                    xFormControlDataModel.strType = Convert.ToString(xDataRow["Type"]) ?? string.Empty;
                    xFormControlDataModel.xFormControlFunction1 = new FormControlFunctionDataModel { iId = 1, iNo = 1, strName = Convert.ToString(xDataRow["FormControlFunction1"]) ?? string.Empty, strDescription = string.Empty };
                    xFormControlDataModel.xFormControlFunction2 = new FormControlFunctionDataModel { iId = 2, iNo = 2, strName = Convert.ToString(xDataRow["FormControlFunction2"]) ?? string.Empty, strDescription = string.Empty };
                    xFormControlDataModel.iWidth = Convert.ToInt32(xDataRow["Width"]);
                    xFormControlDataModel.iHeight = Convert.ToInt32(xDataRow["Height"]);
                    xFormControlDataModel.iLocationX = Convert.ToInt32(xDataRow["LocationX"]);
                    xFormControlDataModel.iLocationY = Convert.ToInt32(xDataRow["LocationY"]);
                    xFormControlDataModel.strStartPosition = Convert.ToString(xDataRow["StartPosition"]) ?? string.Empty;
                    xFormControlDataModel.strCaption1 = Convert.ToString(xDataRow["Caption1"]) ?? string.Empty;
                    xFormControlDataModel.strCaption2 = Convert.ToString(xDataRow["Caption2"]) ?? string.Empty;
                    string strList = Convert.ToString(xDataRow["List"]) ?? string.Empty;
                    xFormControlDataModel.xList = strList.xGetList(";");
                    xFormControlDataModel.strDock = Convert.ToString(xDataRow["Dock"]) ?? string.Empty;
                    xFormControlDataModel.strAlignment = Convert.ToString(xDataRow["Alignment"]) ?? string.Empty;
                    xFormControlDataModel.strTextAlignment = Convert.ToString(xDataRow["TextAlignment"]) ?? string.Empty;
                    xFormControlDataModel.strCharacterCasing = Convert.ToString(xDataRow["CharacterCasing"]) ?? string.Empty;
                    xFormControlDataModel.strFont = Convert.ToString(xDataRow["Font"]) ?? "Tahoma";
                    xFormControlDataModel.strIcon = Convert.ToString(xDataRow["Icon"]) ?? string.Empty;
                    xFormControlDataModel.strToolTip = Convert.ToString(xDataRow["ToolTip"]) ?? string.Empty;
                    xFormControlDataModel.strImage = Convert.ToString(xDataRow["Image"]) ?? string.Empty;
                    xFormControlDataModel.strImageSelected = Convert.ToString(xDataRow["ImageSelected"]) ?? string.Empty;
                    xFormControlDataModel.bFontAutoHeight = Convert.ToBoolean(xDataRow["FontAutoHeight"]);
                    xFormControlDataModel.fFontSize = (float)Convert.ToDouble(xDataRow["FontSize"]);
                    xFormControlDataModel.strInputType = Convert.ToString(xDataRow["InputType"]) ?? string.Empty;
                    xFormControlDataModel.strTextImageRelation = Convert.ToString(xDataRow["TextImageRelation"]) ?? string.Empty;
                    xFormControlDataModel.strBackColor = Convert.ToString(xDataRow["BackColor"]) ?? string.Empty;
                    xFormControlDataModel.strForeColor = Convert.ToString(xDataRow["ForeColor"]) ?? string.Empty;
                    xFormControlDataModel.strKeyboardValue = Convert.ToString(xDataRow["KeyboardValue"]) ?? string.Empty;
                    xListFormControlDataModel.Add(xFormControlDataModel);
                }
            }

            return xListFormControlDataModel;
        }

        public List<FormControlDataModel> xGetKeyFunction(string prm_KeyboardValue)
        {

            List<FormControlDataModel> xListFormControlsDataModel = xListGetKeyFunctions(prm_KeyboardValue);

            if (xListFormControlsDataModel == null)
                return null;

            return xListFormControlsDataModel;

        }

        public bool bSaveFormControlsKeyboardValue(FormControlDataModel prm_xFormControlsDataModel)
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

        public FormControlDataModel xGetFormControlsByCaption1(string prm_strCaption1)
        {
            try
            {
                FormControlDataModel xFormControlDataModel = new FormControlDataModel();

                return xFormControlDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public FormControlDataModel xGetFormControl(int prm_iFormId, int prm_iControlId)
        {
            List<FormControlDataModel> xListFormControlsDataModel = xListGetFormControls(prm_iFormId, prm_iControlId);

            if (xListFormControlsDataModel == null)
                return null;

            return xListFormControlsDataModel.First();
        }

        public List<FormControlDataModel> xListGetFormControls()
        {
            return xListGetFormControls(0, 0);
        }

        public List<FormControlDataModel> xListGetFormControls(int prm_iFormId)
        {
            DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileName).xExecuteDataTable($"SELECT * FROM TableFormControl WHERE FkFormId= {prm_iFormId} ORDER BY Id");

            List<FormControlDataModel> xListFormControlDataModel = null;

            if (xDataTable != null && xDataTable.Rows.Count > 0)
            {
                foreach (DataRow xDataRow in xDataTable.Rows)
                {
                    if (xListFormControlDataModel == null)
                        xListFormControlDataModel = new List<FormControlDataModel>();

                    FormControlDataModel xFormControlDataModel = new FormControlDataModel();

                    xFormControlDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty; 
                    xFormControlDataModel.iFkParentId = Convert.ToInt32(xDataRow["FkParentId"]); 
                    xFormControlDataModel.strParentName = Convert.ToString(xDataRow["ParentName"]) ?? string.Empty;
                    xFormControlDataModel.iTypeNo = Convert.ToInt32(xDataRow["TypeNo"]);
                    xFormControlDataModel.strType = Convert.ToString(xDataRow["Type"]) ?? string.Empty;
                    xFormControlDataModel.xFormControlFunction1 = new FormControlFunctionDataModel { iId = 1, iNo = 1, strName = Convert.ToString(xDataRow["FormControlFunction1"]) ?? string.Empty, strDescription = string.Empty };
                    xFormControlDataModel.xFormControlFunction2 = new FormControlFunctionDataModel { iId = 2, iNo = 2, strName = Convert.ToString(xDataRow["FormControlFunction2"]) ?? string.Empty, strDescription = string.Empty };
                    xFormControlDataModel.iWidth = Convert.ToInt32(xDataRow["Width"]);
                    xFormControlDataModel.iHeight = Convert.ToInt32(xDataRow["Height"]);
                    xFormControlDataModel.iLocationX = Convert.ToInt32(xDataRow["LocationX"]);
                    xFormControlDataModel.iLocationY = Convert.ToInt32(xDataRow["LocationY"]);
                    xFormControlDataModel.strStartPosition = Convert.ToString(xDataRow["StartPosition"]) ?? string.Empty;
                    xFormControlDataModel.strCaption1 = Convert.ToString(xDataRow["Caption1"]) ?? string.Empty;
                    xFormControlDataModel.strCaption2 = Convert.ToString(xDataRow["Caption2"]) ?? string.Empty;
                    string strList = Convert.ToString(xDataRow["List"]) ?? string.Empty;
                    xFormControlDataModel.xList = strList.xGetList(";");
                    xFormControlDataModel.strDock = Convert.ToString(xDataRow["Dock"]) ?? string.Empty;
                    xFormControlDataModel.strAlignment = Convert.ToString(xDataRow["Alignment"]) ?? string.Empty;
                    xFormControlDataModel.strTextAlignment = Convert.ToString(xDataRow["TextAlignment"]) ?? string.Empty;
                    xFormControlDataModel.strCharacterCasing = Convert.ToString(xDataRow["CharacterCasing"]) ?? string.Empty;
                    xFormControlDataModel.strFont = Convert.ToString(xDataRow["Font"]) ?? "Tahoma";
                    xFormControlDataModel.strIcon = Convert.ToString(xDataRow["Icon"]) ?? string.Empty;
                    xFormControlDataModel.strToolTip = Convert.ToString(xDataRow["ToolTip"]) ?? string.Empty;
                    xFormControlDataModel.strImage = Convert.ToString(xDataRow["Image"]) ?? string.Empty;
                    xFormControlDataModel.strImageSelected = Convert.ToString(xDataRow["ImageSelected"]) ?? string.Empty;
                    xFormControlDataModel.bFontAutoHeight = Convert.ToBoolean(xDataRow["FontAutoHeight"]);
                    xFormControlDataModel.fFontSize = (float)Convert.ToDouble(xDataRow["FontSize"]);
                    xFormControlDataModel.strInputType = Convert.ToString(xDataRow["InputType"]) ?? string.Empty;
                    xFormControlDataModel.strTextImageRelation = Convert.ToString(xDataRow["TextImageRelation"]) ?? string.Empty;
                    xFormControlDataModel.strBackColor = Convert.ToString(xDataRow["BackColor"]) ?? string.Empty;
                    xFormControlDataModel.strForeColor = Convert.ToString(xDataRow["ForeColor"]) ?? string.Empty;
                    xFormControlDataModel.strKeyboardValue = Convert.ToString(xDataRow["KeyboardValue"]) ?? string.Empty;
                    xListFormControlDataModel.Add(xFormControlDataModel);
                }
            }

            return xListFormControlDataModel;
        }

        public List<FormControlDataModel> xListGetKeyFunctions(string prm_KeyboardValue)
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

        public List<FormControlDataModel> xListGetFormControls(int prm_iFormId, int prm_iControlId)
        {
            try
            {
                List<FormControlDataModel> xListFormControlDataModel = null;

                if (xListFormControlDataModel == null)
                    xListFormControlDataModel = new List<FormControlDataModel>();

                FormControlDataModel xFormControlDataModel = new FormControlDataModel();

                xFormControlDataModel.strName = "DEPARTMENT1";
                xFormControlDataModel.iFkParentId = 0;
                xFormControlDataModel.strParentName = string.Empty;
                xFormControlDataModel.strType = "BUTTON";
                xFormControlDataModel.xFormControlFunction1 = xGetFormControlFunctions(1);
                xFormControlDataModel.xFormControlFunction2 = xGetFormControlFunctions(0);
                xFormControlDataModel.iWidth = 100;
                xFormControlDataModel.iHeight = 100;
                xFormControlDataModel.iLocationX = 100;
                xFormControlDataModel.iLocationY = 200;
                xFormControlDataModel.strStartPosition = string.Empty;
                xFormControlDataModel.strCaption1 = string.Empty;
                xFormControlDataModel.strCaption2 = string.Empty;
                string strList = string.Empty;
                xFormControlDataModel.xList = strList.xGetList(";");
                xFormControlDataModel.strDock = string.Empty;
                xFormControlDataModel.strAlignment = string.Empty;
                xFormControlDataModel.strTextAlignment = string.Empty;
                xFormControlDataModel.strCharacterCasing = string.Empty;
                xFormControlDataModel.strFont = string.Empty;
                xFormControlDataModel.strIcon = string.Empty;
                xFormControlDataModel.strToolTip = string.Empty;
                xFormControlDataModel.strImage = "SaleFlex.POS.Muhtelif.jpg";
                xFormControlDataModel.strImageSelected = string.Empty;
                xFormControlDataModel.bFontAutoHeight = true;
                xFormControlDataModel.fFontSize = (float)0;
                xFormControlDataModel.strInputType = string.Empty;
                xFormControlDataModel.strTextImageRelation = string.Empty;
                xFormControlDataModel.strBackColor = "Black";
                xFormControlDataModel.strForeColor = "White";
                xFormControlDataModel.strKeyboardValue = string.Empty;
                xListFormControlDataModel.Add(xFormControlDataModel);

                xFormControlDataModel = new FormControlDataModel();

                xFormControlDataModel.strName = "SALESLIST";
                xFormControlDataModel.iFkParentId = 0;
                xFormControlDataModel.strParentName = string.Empty;
                xFormControlDataModel.strType = "SALESLIST";
                xFormControlDataModel.xFormControlFunction1 = xGetFormControlFunctions(1);
                xFormControlDataModel.xFormControlFunction2 = xGetFormControlFunctions(0);
                xFormControlDataModel.iWidth = 498;
                xFormControlDataModel.iHeight = 198;
                xFormControlDataModel.iLocationX = 500;
                xFormControlDataModel.iLocationY = 200;
                xFormControlDataModel.strStartPosition = string.Empty;
                xFormControlDataModel.strCaption1 = string.Empty;
                xFormControlDataModel.strCaption2 = string.Empty;
                strList = string.Empty;
                xFormControlDataModel.xList = strList.xGetList(";");
                xFormControlDataModel.strDock = string.Empty;
                xFormControlDataModel.strAlignment = string.Empty;
                xFormControlDataModel.strTextAlignment = string.Empty;
                xFormControlDataModel.strCharacterCasing = string.Empty;
                xFormControlDataModel.strFont = string.Empty;
                xFormControlDataModel.strIcon = string.Empty;
                xFormControlDataModel.strToolTip = string.Empty;
                xFormControlDataModel.strImage = string.Empty;
                xFormControlDataModel.strImageSelected = string.Empty;
                xFormControlDataModel.bFontAutoHeight = true;
                xFormControlDataModel.fFontSize = (float)0;
                xFormControlDataModel.strInputType = string.Empty;
                xFormControlDataModel.strTextImageRelation = string.Empty;
                xFormControlDataModel.strBackColor = "Black";
                xFormControlDataModel.strForeColor = "White";
                xFormControlDataModel.strKeyboardValue = string.Empty;
                xListFormControlDataModel.Add(xFormControlDataModel);

                xFormControlDataModel = new FormControlDataModel();

                xFormControlDataModel.strName = "EXIT";
                xFormControlDataModel.iFkParentId = 0;
                xFormControlDataModel.strParentName = string.Empty;
                xFormControlDataModel.strType = "BUTTON";
                xFormControlDataModel.xFormControlFunction1 = xGetFormControlFunctions(3);
                xFormControlDataModel.xFormControlFunction2 = xGetFormControlFunctions(0);
                xFormControlDataModel.iWidth = 100;
                xFormControlDataModel.iHeight = 100;
                xFormControlDataModel.iLocationX = 300;
                xFormControlDataModel.iLocationY = 200;
                xFormControlDataModel.strStartPosition = string.Empty;
                xFormControlDataModel.strCaption1 = string.Empty;
                xFormControlDataModel.strCaption2 = string.Empty;
                strList = string.Empty;
                xFormControlDataModel.xList = strList.xGetList(";");
                xFormControlDataModel.strDock = string.Empty;
                xFormControlDataModel.strAlignment = string.Empty;
                xFormControlDataModel.strTextAlignment = string.Empty;
                xFormControlDataModel.strCharacterCasing = string.Empty;
                xFormControlDataModel.strFont = string.Empty;
                xFormControlDataModel.strIcon = string.Empty;
                xFormControlDataModel.strToolTip = string.Empty;
                xFormControlDataModel.strImage = "SaleFlex.POS.Cikis.jpg";
                xFormControlDataModel.strImageSelected = string.Empty;
                xFormControlDataModel.bFontAutoHeight = true;
                xFormControlDataModel.fFontSize = (float)0;
                xFormControlDataModel.strInputType = string.Empty;
                xFormControlDataModel.strTextImageRelation = string.Empty;
                xFormControlDataModel.strBackColor = "Black";
                xFormControlDataModel.strForeColor = "White";
                xFormControlDataModel.strKeyboardValue = string.Empty;
                xListFormControlDataModel.Add(xFormControlDataModel);

                return xListFormControlDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public FormControlFunctionDataModel xGetFormControlFunctions(int prm_iFunctionNo)
        {
            List<FormControlFunctionDataModel> xListFormControlsFunctionDataModel = xListGetFormControlFunctions(prm_iFunctionNo);

            if (xListFormControlsFunctionDataModel == null)
                return null;

            return xListFormControlsFunctionDataModel.First();
        }

        public List<FormControlFunctionDataModel> xListGetFormControlFunctions()
        {
            return xListGetFormControlFunctions(0);
        }

        public List<FormControlFunctionDataModel> xListGetFormControlFunctions(int prm_iFunctionNo)
        {
            try
            {
                List<FormControlFunctionDataModel> xListFormControlFunctionDataModel = new List<FormControlFunctionDataModel>();
                FormControlFunctionDataModel xFormControlFunctionDataModel = null;

                if (prm_iFunctionNo == 1)
                {
                    xFormControlFunctionDataModel = new FormControlFunctionDataModel();

                    xFormControlFunctionDataModel.iId = 1;
                    xFormControlFunctionDataModel.iNo = 1;
                    xFormControlFunctionDataModel.strName = "SALE_DEPARTMENT";
                    xFormControlFunctionDataModel.strDescription = "SALE_DEPARTMENT";

                    xListFormControlFunctionDataModel.Add(xFormControlFunctionDataModel);
                }
                else if (prm_iFunctionNo == 2)
                {
                    xFormControlFunctionDataModel = new FormControlFunctionDataModel();

                    xFormControlFunctionDataModel.iId = 2;
                    xFormControlFunctionDataModel.iNo = 2;
                    xFormControlFunctionDataModel.strName = "SALE_PLU_BARCODE";
                    xFormControlFunctionDataModel.strDescription = "SALE_PLU_BARCODE";

                    xListFormControlFunctionDataModel.Add(xFormControlFunctionDataModel);
                }
                else
                {
                    xFormControlFunctionDataModel = new FormControlFunctionDataModel();

                    xFormControlFunctionDataModel.iId = 3;
                    xFormControlFunctionDataModel.iNo = 3;
                    xFormControlFunctionDataModel.strName = "EXIT_APPLICATION";
                    xFormControlFunctionDataModel.strDescription = "EXIT_APPLICATION";

                    xListFormControlFunctionDataModel.Add(xFormControlFunctionDataModel);
                }
                return xListFormControlFunctionDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public FormFunctionDataModel xGetFormFunction(int prm_iFunctionNo)
        {
            List<FormFunctionDataModel> xListFormFunctionDataModel = xListGetFormFunctions(prm_iFunctionNo);

            if (xListFormFunctionDataModel == null)
                return null;

            return xListFormFunctionDataModel.First();
        }

        public List<FormFunctionDataModel> xListGetFormFunctions()
        {
            return xListGetFormFunctions(0);
        }

        public List<FormFunctionDataModel> xListGetFormFunctions(int prm_iFunctionNo)
        {
            try
            {
                List<FormFunctionDataModel> xListFormFunctionDataModel = null;

                if (xListFormFunctionDataModel == null)
                    xListFormFunctionDataModel = new List<FormFunctionDataModel>();

                return xListFormFunctionDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public void vSaveForm(ServiceDataModel.FormModel prm_xFormModel, List<ServiceDataModel.FormControlModel> prm_xFormControlModel)
        {
            try
            {
                var query = string.Format("INSERT INTO TableForm " +
                    "(FormNo, Name, Function, NeedLogin, NeedAuth, Width, Height, FormBorderStyle, StartPosition, Caption, Icon, Image, BackColor, ShowStatusBar, " +
                    "ShowInTaskbar, UseVirtualKeyboard, IsVisible) VALUES ({0},'{1}','{2}',{3},{4},{5},{6},'{7}','{8}','{9}', " +
                    "'{10}','{11}', '{12}',{13},{14},{15},{16}); SELECT last_insert_rowid()",
                    prm_xFormModel.FormNo,
                    prm_xFormModel.Name,
                    prm_xFormModel.Function,
                    Convert.ToInt16(prm_xFormModel.NeedLogin),
                    Convert.ToInt16(prm_xFormModel.NeedAuth),
                    prm_xFormModel.Width,
                    prm_xFormModel.Height,
                    prm_xFormModel.FormBorderStyle,
                    prm_xFormModel.StartPosition,
                    prm_xFormModel.Caption,
                    prm_xFormModel.Icon,
                    prm_xFormModel.Image,
                    prm_xFormModel.BackColor,
                    Convert.ToInt16(prm_xFormModel.ShowStatusBar),
                    Convert.ToInt16(prm_xFormModel.ShowInTaskbar),
                    Convert.ToInt16(prm_xFormModel.UseVirtualKeyboard),
                    Convert.ToInt16(prm_xFormModel.IsVisible));
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileName).xExecuteDataTable(query);

                var formId = Convert.ToInt16(xDataTable.Rows[0]["last_insert_rowid()"]);

                foreach(ServiceDataModel.FormControlModel formControl in prm_xFormControlModel)
                {
                    query = string.Format("INSERT INTO TableFormControl (FkFormId, FkParentId, Name, ParentName, FormControlFunction1, " +
                    "FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, " +
                    "List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, " +
                    "FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue, IsVisible) " +
                    "VALUES ({0},{1},'{2}','{3}','{4}','{5}',{6},'{7}',{8},{9},{10},{11},'{12}','{13}','{14}','{15}','{16}'," +
                    "'{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}',{25},{26},'{27}','{28}','{29}','{30}','{31}',{32});",
                    formId,
                    formControl.FkParentId,
                    formControl.Name,
                    formControl.ParentName,
                    formControl.FormControlFunction1,
                    formControl.FormControlFunction2,
                    formControl.TypeNo,
                    formControl.Type,
                    formControl.Width,
                    formControl.Height,
                    formControl.LocationX,
                    formControl.LocationY,
                    formControl.StartPosition,
                    formControl.Caption1,
                    formControl.Caption2,
                    formControl.List,
                    formControl.Dock,
                    formControl.Alignment,
                    formControl.TextAlignment,
                    formControl.CharacterCasing,
                    formControl.Font,
                    formControl.Icon,
                    formControl.ToolTip,
                    formControl.Image,
                    formControl.ImageSelected,
                    Convert.ToInt16(formControl.FontAutoHeight),
                    formControl.FontSize,
                    formControl.InputType,
                    formControl.TextImageRelation,
                    formControl.BackColor,
                    formControl.ForeColor,
                    formControl.KeyboardValue,
                    Convert.ToInt16(formControl.IsVisible));
                    Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileName).xExecuteVoidDataTable(query);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public bool bUpdateFormControlName(int formControlId, string formControlName)
        {
            try
            {
                var query = string.Format("UPDATE TableFormControl Set Name = '{0}' where Id = {1}", formControlName, formControlId);
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileName).xExecuteDataTable(query);
                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        //public void vSaveFormControl(ServiceDataModel.FormControlModel prm_xFormControlDataModel)
        //{
        //    try
        //    {
        //        var query = string.Format("INSERT INTO TableFormControl (FkFormId, FkParentId, Name, ParentName, FormControlFunction1, " +
        //            "FormControlFunction2, TypeNo, Type, Width, Height, LocationX, LocationY, StartPosition, Caption1, Caption2, " +
        //            "List, Dock, Alignment, TextAlignment, CharacterCasing, Font, Icon, ToolTip, Image, ImageSelected, FontAutoHeight, " +
        //            "FontSize, InputType, TextImageRelation, BackColor, ForeColor, KeyboardValue, IsVisible) " +
        //            "VALUES ({0},{1},'{2}','{3}','{4}','{5}',{6},'{7}',{8},{9},{10},{11},'{12}','{13}','{14}','{15}','{16}'," +
        //            "'{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}',{25},{26},'{27}','{28}','{29}','{30}','{31}',{32});",
        //            prm_xFormControlDataModel.FkFormId,
        //            prm_xFormControlDataModel.FkParentId,
        //            prm_xFormControlDataModel.Name,
        //            prm_xFormControlDataModel.ParentName,
        //            prm_xFormControlDataModel.FormControlFunction1,
        //            prm_xFormControlDataModel.FormControlFunction2,
        //            prm_xFormControlDataModel.TypeNo,
        //            prm_xFormControlDataModel.Type,
        //            prm_xFormControlDataModel.Width,
        //            prm_xFormControlDataModel.Height,
        //            prm_xFormControlDataModel.LocationX,
        //            prm_xFormControlDataModel.LocationY,
        //            prm_xFormControlDataModel.StartPosition,
        //            prm_xFormControlDataModel.Caption1,
        //            prm_xFormControlDataModel.Caption2,
        //            prm_xFormControlDataModel.List,
        //            prm_xFormControlDataModel.Dock,
        //            prm_xFormControlDataModel.Alignment,
        //            prm_xFormControlDataModel.TextAlignment,
        //            prm_xFormControlDataModel.CharacterCasing,
        //            prm_xFormControlDataModel.Font,
        //            prm_xFormControlDataModel.Icon,
        //            prm_xFormControlDataModel.ToolTip,
        //            prm_xFormControlDataModel.Image,
        //            prm_xFormControlDataModel.ImageSelected,
        //            Convert.ToInt16(prm_xFormControlDataModel.FontAutoHeight),
        //            prm_xFormControlDataModel.FontSize,
        //            prm_xFormControlDataModel.InputType,
        //            prm_xFormControlDataModel.TextImageRelation,
        //            prm_xFormControlDataModel.BackColor,
        //            prm_xFormControlDataModel.ForeColor,
        //            prm_xFormControlDataModel.KeyboardValue,
        //            Convert.ToInt16(prm_xFormControlDataModel.IsVisible));
        //        Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileName).xExecuteVoidDataTable(query);
        //    }
        //    catch (Exception xException)
        //    {
        //        xException.strTraceError();
        //    }
        //}
    }
}
