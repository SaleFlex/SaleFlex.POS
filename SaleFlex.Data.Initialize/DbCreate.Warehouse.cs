using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFlex.Data.Initialize
{
    public partial class DbCreate
    {
        public static bool bCreateWarehouseDb()
        {
            bool bReturnValue = true;

            if (!File.Exists(CommonProperty.prop_strDatabaseWarehouseFileNameAndPath))
                SQLiteConnection.CreateFile(CommonProperty.prop_strDatabaseWarehouseFileNameAndPath);        // Create the file which will be hosting our database

            var DbTableCreateMethods = new List<Func<bool>>
            {
            };

            foreach (var DbTableCreateMethod in DbTableCreateMethods)
            {
                if (!DbTableCreateMethod())
                {
                    bReturnValue = false;
                    break;
                }
            }

            return bReturnValue;
        }
    }
}
