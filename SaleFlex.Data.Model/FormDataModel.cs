using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SaleFlex.Data.Models;

namespace SaleFlex.Data.Models
{
    public class FormDataModel
    {
        public int iId { get; set; }
        public int iFormNo { get; set; }
        public string strName { get; set; }
        public string strFunction { get; set; }
        public bool bNeedLogin { get; set; }
        public bool bNeedAuth { get; set; }
        public int iWidth { get; set; }
        public int iHeight { get; set; }
        public string strStartPosition { get; set; }
        public string strFormBorderStyle { get; set; }
        public string strCaption { get; set; }
        public string strIcon { get; set; }
        public string strImage { get; set; }
        public string strBackColor { get; set; }
        public bool bShowStatusBar { get; set; }
        public bool bShowInTaskbar { get; set; }
        public bool bUseVirtualKeyboard { get; set; }
        public bool bIsVisible { get; set; }

        public List<FormControlDataModel> xListFormControlDataModel { get; set; }
    }
}
