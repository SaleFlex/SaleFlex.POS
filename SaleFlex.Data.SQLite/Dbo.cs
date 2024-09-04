using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;

namespace SaleFlex.Data.SQLite
{
    public partial class Dbo
    {
        private static Dbo m_xGlobalsInstance = null;
        private string m_strConnectionString = string.Empty;

        public string prop_strConnectionString
        {
            get
            {
                return m_strConnectionString;
            }
        }

        public static Dbo xGetInstance(string prm_strDatabaseFileName)
        {
            if (m_xGlobalsInstance == null)
                m_xGlobalsInstance = new Dbo(prm_strDatabaseFileName);
            else
                m_xGlobalsInstance.bCreateConnectionString(prm_strDatabaseFileName);
            return m_xGlobalsInstance;
        }

        public Dbo(int prm_iDatabaseFileType)
        {
            DirectoryInfo xDirectoryInfo = new DirectoryInfo(CommonProperty.prop_strDbsFolder);

            if (xDirectoryInfo.Exists == false)
                Directory.CreateDirectory(CommonProperty.prop_strDbsFolder);

            switch (prm_iDatabaseFileType)
            {
                case 1:
                    bCreateConnectionString(CommonProperty.prop_strDatabasePosFileNameAndPath);
                    break;
                case 2:
                    bCreateConnectionString(CommonProperty.prop_strDatabaseSalesFileNameAndPath);
                    break;
                case 3:
                    bCreateConnectionString(CommonProperty.prop_strDatabaseProductsFileNameAndPath);
                    break;
                default:
                    throw new ApplicationException("DB FILE TYPE IS NOT RECOGNIZED.");
            }
        }

        public Dbo(string prm_strDatabaseFileName)
        {
            DirectoryInfo xDirectoryInfo = new DirectoryInfo(CommonProperty.prop_strDbsFolder);

            if (xDirectoryInfo.Exists == false)
                Directory.CreateDirectory(CommonProperty.prop_strDbsFolder);

            bCreateConnectionString(prm_strDatabaseFileName);
        }

        private bool bCreateConnectionString(string prm_strDatabaseFileName)
        {
            m_strConnectionString = string.Format("Data Source={0}; Version=3; UseUTF16Encoding=True;", prm_strDatabaseFileName);
            return true;
        }

        public DataSet xExecuteDataSet(string prm_strCommandText)
        {
            DataSet xDataSet = null;

            using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(m_strConnectionString))
            {
                xSQLiteConnection.Open();
                SQLiteCommand xSQLiteCommand = new SQLiteCommand(xSQLiteConnection);
                xSQLiteCommand.CommandText = prm_strCommandText;
                xSQLiteCommand.CommandType = CommandType.Text;

                SQLiteDataAdapter xSQLiteDataAdapter = new SQLiteDataAdapter(xSQLiteCommand);

                xDataSet = new DataSet();
                xSQLiteDataAdapter.Fill(xDataSet);
            }

            return xDataSet;
        }

        public int iExecuteNonQuery(string prm_strCommandText)
        {
            int iReturnValue = 0;

            using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(m_strConnectionString))
            {
                xSQLiteConnection.Open();
                SQLiteCommand xSQLiteCommand = new SQLiteCommand(xSQLiteConnection);
                xSQLiteCommand.CommandText = prm_strCommandText;
                xSQLiteCommand.CommandType = CommandType.Text;

                iReturnValue = xSQLiteCommand.ExecuteNonQuery();
            }

            return iReturnValue;
        }

        public DataTable xExecuteDataTable(string prm_strCommandText)
        {
            DataTable xDataTable = null;

            using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(m_strConnectionString))
            {
                xSQLiteConnection.Open();
                SQLiteCommand xSQLiteCommand = new SQLiteCommand(xSQLiteConnection);
                xSQLiteCommand.CommandText = prm_strCommandText;
                xSQLiteCommand.CommandType = CommandType.Text;

                DataRow xDataRow = null;

                SQLiteDataAdapter xSQLiteDataAdapter = new SQLiteDataAdapter(xSQLiteCommand);
                xDataTable = new DataTable();

                try
                {
                    xSQLiteDataAdapter.Fill(xDataTable);
                    xDataRow = xDataTable.Rows[0];
                }
                catch (IndexOutOfRangeException ex)
                {
                }
                catch (SqlException exSqlException)
                {
                }

                if (xDataRow == null)
                {
                    return null;
                }
            }

            return xDataTable;
        }

        public void xExecuteVoidDataTable(string prm_strCommandText)
        {
            DataTable xDataTable = null;

            using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(m_strConnectionString))
            {
                xSQLiteConnection.Open();
                SQLiteCommand xSQLiteCommand = new SQLiteCommand(xSQLiteConnection);
                xSQLiteCommand.CommandText = prm_strCommandText;
                xSQLiteCommand.CommandType = CommandType.Text;

                DataRow xDataRow = null;

                SQLiteDataAdapter xSQLiteDataAdapter = new SQLiteDataAdapter(xSQLiteCommand);
                xDataTable = new DataTable();

                try
                {
                    xSQLiteDataAdapter.Fill(xDataTable);
                    //xDataRow = xDataTable.Rows[0];
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw ex;
                }
                catch (SqlException exSqlException)
                {
                    throw exSqlException;
                }
            }
        }

        public object objExecuteScalar(string prm_strCommandText)
        {
            object objObject = null;

            using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(m_strConnectionString))
            {
                xSQLiteConnection.Open();
                SQLiteCommand xSQLiteCommand = new SQLiteCommand(xSQLiteConnection);
                xSQLiteCommand.CommandText = prm_strCommandText;
                xSQLiteCommand.CommandType = CommandType.Text;

                objObject = xSQLiteCommand.ExecuteScalar();
            }

            return objObject;
        }
    }
}
