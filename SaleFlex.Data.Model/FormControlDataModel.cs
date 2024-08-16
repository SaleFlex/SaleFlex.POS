using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class FormControlDataModel
    {
        public FormControlDataModel()
        {
            xFormControlFunction1 = new FormControlFunctionDataModel();
            xFormControlFunction2 = new FormControlFunctionDataModel();

            strName = "TMP_CONTROL_NAME";
            strCharacterCasing = "NORMAL";
            strTextAlignment = "LEFT";
            strInputType = "NUMERIC";
            iHeight = 0;
            iWidth = 0;
            strType = "NOTYPE";
            strFont = string.Empty;
            strImage = string.Empty;
            bFontAutoHeight = true;
            fFontSize = 0;
            strCaption1 = string.Empty;
        }

        public FormControlDataModel(string prm_strName, string prm_strCharacterCasing = "UPPER", string prm_strTextAlignment = "LEFT", string prm_strInputType = "ALPHANUMERIC")
        {
            xFormControlFunction1 = new FormControlFunctionDataModel();
            xFormControlFunction2 = new FormControlFunctionDataModel();

            strName = prm_strName;
            strCharacterCasing = prm_strCharacterCasing;
            strTextAlignment = prm_strTextAlignment;
            strInputType = prm_strInputType;
            iHeight = 0;
            iWidth = 0;
            strType = "NOTYPE";
            strFont = string.Empty;
            strImage = string.Empty;
            bFontAutoHeight = true;
            fFontSize = 0;
            strCaption1 = string.Empty;
        }

        public int iId { get; set; }
        public string strName { get; set; }
        public int iFkFormId { get; set; }
        public int iFkParentId { get; set; }
        public string strParentName { get; set; }
        public int iTypeNo { get; set; }
        public string strType { get; set; }
        public FormControlFunctionDataModel xFormControlFunction1 { get; set; }
        public FormControlFunctionDataModel xFormControlFunction2 { get; set; }
        public int iWidth { get; set; }
        public int iHeight { get; set; }
        public int iLocationX { get; set; }
        public int iLocationY { get; set; }
        public string strStartPosition { get; set; }
        public string strCaption1 { get; set; }
        public string strCaption2 { get; set; }
        public List<string> xList { get; set; }
        public string strDock { get; set; }
        public string strAlignment { get; set; }
        public string strTextAlignment { get; set; }
        public string strCharacterCasing { get; set; }
        public string strFont { get; set; }
        public string strIcon { get; set; }
        public string strToolTip { get; set; }
        public string strImage { get; set; }
        public string strImageSelected { get; set; }
        public bool bFontAutoHeight { get; set; }
        public float fFontSize { get; set; }
        public string strInputType { get; set; }
        public string strTextImageRelation { get; set; }
        public string strBackColor { get; set; }
        public string strForeColor { get; set; }
        public string strKeyboardValue { get; set; }
        public bool bIsVisible { get; set; }
    }

    public enum enumControlType
    {
        NONE = (short)0,
        BUTTON,
        PICTURE,
        LABEL,
        TEXT_BOX,
        COMBO_BOX,
        TOOL_BAR,
        MENU,
        MENU_ITEM,
        MENU_SUB_ITEM,
        TAB_PAGE,
        TAB_PAGE_ITEM,
        PANEL,
        WEB_BROWSER,
        GROUP,
        DATA_VIEW,
        POP_UP,
        LIST_BOX,
        CHECK_BOX,

        END_OF_ENUM
    }
}
