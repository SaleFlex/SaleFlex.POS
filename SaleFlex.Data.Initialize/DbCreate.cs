using System;

using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleFlex.Data;
using SaleFlex.CommonLibrary;
using SaleFlex.Windows;

namespace SaleFlex.Data.Initialize
{
    public partial class DbCreate
    {
        private static string strCreateConnectionString(string prm_strDatabaseFileName)
        {
            string strConnectionString = string.Format("Data Source={0}; Version=3; UseUTF16Encoding=True;", prm_strDatabaseFileName);
            return strConnectionString;
        }
    }
}
