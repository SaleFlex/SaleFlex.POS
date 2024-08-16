using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class FormFunctionDataModel
    {
        public long lId { get; set; }
        public string strName { get; set; }
        public int iNo { get; set; }
        public bool bNeedLogin { get; set; }
        public bool bNeedAuth { get; set; }
        public string strDescription { get; set; }
    }
}
