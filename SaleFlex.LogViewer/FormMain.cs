using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;

using SaleFlex.CommonLibrary;

namespace SaleFlexLogViewer
{
    public partial class FormMain : Form
    {
        private int m_iFindPoint = 0;
        private string m_strFindCreteria = string.Empty;
        private string m_strMethodFindCreteria = string.Empty;
        private string m_strSelectedFileName = string.Empty;
        private int m_iSelectedFileIndex = -1;
        private int m_iSelectedPageNumber = 1;
        private int m_iFileInfoListElementCount = -1;
        private bool[] m_baShowWhichLevelofTrace;
        private string m_strCurrentFileName = string.Empty;
        private string m_strCurrentFileFolder = string.Empty;



        public FormMain()
        {
            InitializeComponent();
            timerLogFilesListRefresh.Enabled = true;
            m_baShowWhichLevelofTrace = new bool[6] { true, true, true, true, true, true };
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            cmbAplpicationName.Items.AddRange(ConfigurationManager.AppSettings["ApplicationsNameList"].Replace(" ",string.Empty).Split(','));
            cmbAplpicationName.SelectedIndex = 0;
            bDeleteLogfiles();

            vFillLogFilesListView();
        }
     
        private void dateTimePickerLogDateTime_ValueChanged(object sender, EventArgs e)
        {
            vFillLogFilesListView();
        }

        private void vFillLogFilesListView()
        {
            listViewLogFiles.Clear();
            FileInfo[] xFileInfoList = Trace.xTraceFileList(dateTimePickerLogDateTime.Value);
            if (xFileInfoList != null)
            {
                m_iFileInfoListElementCount = xFileInfoList.Length;
                foreach (FileInfo xFileInfo in xFileInfoList)
                {
                    if (radioShowAllLogs.Checked == true)
                    {
                        if (cmbAplpicationName.SelectedIndex == 0)
                            listViewLogFiles.Items.Add(xFileInfo.Name);
                        else
                        {
                            if (xFileInfo.Name.Contains(cmbAplpicationName.Text.Trim()))
                                listViewLogFiles.Items.Add(xFileInfo.Name);
                        }
                    }
                    else if (radioShowErrorLogs.Checked == true)
                    {
                        if (xFileInfo.Name.StartsWith("Error"))
                        {
                            if (cmbAplpicationName.SelectedIndex == 0)
                                listViewLogFiles.Items.Add(xFileInfo.Name);
                            else
                            {
                                if (xFileInfo.Name.Contains(cmbAplpicationName.Text.Trim()))
                                    listViewLogFiles.Items.Add(xFileInfo.Name);
                            }
                        }
                    }
                    //else if (radioShowDataLogs.Checked == true)
                    //{
                    //    if (xFileInfo.Name.StartsWith("DataLog"))
                    //    {
                    //        if (cmbAplpicationName.SelectedIndex == 0)
                    //            listViewLogFiles.Items.Add(xFileInfo.Name);
                    //        else
                    //        {
                    //            if (xFileInfo.Name.Contains(cmbAplpicationName.Text))
                    //                listViewLogFiles.Items.Add(xFileInfo.Name);
                    //        }
                    //    }
                    //}
                }
            }
        }

        private bool bCheckLogFilesListChanges()
        {
            bool bReturnValue = false;

            FileInfo[] xFileInfoList = Trace.xTraceFileList(dateTimePickerLogDateTime.Value);
            if (xFileInfoList != null && m_iFileInfoListElementCount != -1 && m_iFileInfoListElementCount != xFileInfoList.Length)
            {
                bReturnValue = true;
            }

            return bReturnValue;
        }

        private void listViewLogFiles_DoubleClick(object sender, EventArgs e)
        {
            if (listViewLogFiles.Items.Count > 0 && listViewLogFiles.SelectedItems.Count > 0)
            {
                try
                {
                    m_strCurrentFileName = listViewLogFiles.SelectedItems[0].Text;
                    m_iSelectedFileIndex = listViewLogFiles.SelectedIndices[0];
                    m_strCurrentFileFolder = Trace.strTraceFolderName(dateTimePickerLogDateTime.Value);
                    m_iSelectedPageNumber = 1;                    

                    if (bLoadFile(m_iSelectedPageNumber) == true)
                    {
                        m_strSelectedFileName = m_strCurrentFileName;
                        Text = string.Format("SaleFlex Log Viewer - {0}", m_strSelectedFileName);
                        listViewLogFiles.Items[m_iSelectedFileIndex].BackColor = SystemColors.InactiveCaption;
                        richTextBoxLogContent.Focus();

                    }
                }
                catch (Exception xException)
                {
                    xException.strTraceError();
                }
            }
        }

        private bool bLoadFile(int prm_iPageNumber = 1)
        {
            bool bReturnValue = false;
            int iPageLinesCount = 1000;
            string strTemporary = richTextBoxLogContent.Text = string.Empty;

            Font fntNormalFont = new Font("Tahoma", 10, FontStyle.Regular);
            Font fntUnderlinedFont = new Font("Tahoma", 10, FontStyle.Underline);


            try
            {
                if (m_strCurrentFileFolder != string.Empty && m_strCurrentFileName != string.Empty)
                {

                    int iLinesCount = File.ReadLines(string.Format("{0}\\{1}", m_strCurrentFileFolder, m_strCurrentFileName)).Count();
                    decimal iPagesCount = Math.Ceiling((decimal)iLinesCount / iPageLinesCount);

                    cmbPageNumbers.Items.Clear();
                    for(int iPageNumber = 1;iPageNumber <= iPagesCount;iPageNumber++)
                        cmbPageNumbers.Items.Add(iPageNumber);

                    cmbPageNumbers.SelectedIndex = prm_iPageNumber - 1;

                    richTextBoxLogContent.SuspendDrawing();
                    richTextBoxLogContent.Hide();

                    using (StreamReader xStreamReader = new StreamReader(string.Format("{0}\\{1}", m_strCurrentFileFolder, m_strCurrentFileName), true))
                    {
                        int iTraceNumber = 1;
                        progressBarLoad.Maximum = iPageLinesCount;
                        progressBarLoad.Visible = true;
                        int iLineNumber = 1;
                        for (iLineNumber = 1; iLineNumber <= (prm_iPageNumber - 1) * iPageLinesCount; iLineNumber++)
                        {
                            xStreamReader.ReadLine();
                        }

                        iTraceNumber = iLineNumber;

                        while (xStreamReader.EndOfStream == false && iTraceNumber <= iPageLinesCount * prm_iPageNumber)
                        {
                            strTemporary = xStreamReader.ReadLine();

                            if (m_strCurrentFileName.StartsWith("Error") == true)
                            {
                                richTextBoxLogContent.AppendText(string.Format("{0}\n", strTemporary));
                            }
                            else
                            {
                                string[] straFieldsOfTrace = strTemporary.Split('^');

                                if (m_baShowWhichLevelofTrace[Convert.ToInt32(straFieldsOfTrace[1].Substring(6, 1))] == false)
                                    continue;

                                if (m_strMethodFindCreteria != string.Empty && straFieldsOfTrace[2].Contains(m_strMethodFindCreteria) == false)
                                    continue;

                                richTextBoxLogContent.SelectionBackColor = Color.White;
                                richTextBoxLogContent.SelectionFont = fntNormalFont;
                                richTextBoxLogContent.SelectedText = string.Format("{0,-5}>>>\nTrace {1} at {2}\n", iTraceNumber++, straFieldsOfTrace[1], straFieldsOfTrace[0]);
                                richTextBoxLogContent.SelectionFont = fntNormalFont;
                                richTextBoxLogContent.SelectedText = string.Format("Trace Location Is ");
                                richTextBoxLogContent.SelectionFont = fntUnderlinedFont;
                                richTextBoxLogContent.SelectedText = string.Format("{0}\n", straFieldsOfTrace[2]);
                                richTextBoxLogContent.SelectionFont = fntNormalFont;
                                richTextBoxLogContent.SelectedText = string.Format("Method Called By ");
                                richTextBoxLogContent.SelectionFont = fntUnderlinedFont;
                                richTextBoxLogContent.SelectedText = string.Format("{0}\n", straFieldsOfTrace[3]);
                                for (int iIndex = 0; iIndex < straFieldsOfTrace.Length; iIndex++)
                                {
                                    switch (straFieldsOfTrace[1])
                                    {
                                        case "Level(0)":
                                            richTextBoxLogContent.SelectionColor = Color.Gray;
                                            break;
                                        case "Level(1)":
                                            richTextBoxLogContent.SelectionColor = Color.DarkSlateGray;
                                            break;
                                        case "Level(2)":
                                            richTextBoxLogContent.SelectionColor = Color.Black;
                                            break;
                                        case "Level(3)":
                                            richTextBoxLogContent.SelectionColor = Color.IndianRed;
                                            break;
                                        case "Level(4)":
                                            richTextBoxLogContent.SelectionColor = Color.Red;
                                            break;
                                        case "Level(5)":
                                            richTextBoxLogContent.SelectionColor = Color.DarkRed;
                                            break;
                                    }
                                    richTextBoxLogContent.SelectionFont = new Font("Tahoma", 10, FontStyle.Bold);
                                    if (iIndex > 3)
                                    {
                                        richTextBoxLogContent.SelectedText = straFieldsOfTrace[iIndex];
                                        richTextBoxLogContent.SelectedText = " ";
                                    }
                                }
                                richTextBoxLogContent.SelectedText = "\n";

                                try
                                {
                                    progressBarLoad.Value = iTraceNumber - ((prm_iPageNumber -1) * iPageLinesCount);
                                }
                                catch (Exception)
                                {
                                    progressBarLoad.Value = progressBarLoad.Maximum;
                                }
                                //System.Threading.Thread.Sleep(1);
                            }                            
                        }
                        richTextBoxLogContent.Show();
                        richTextBoxLogContent.ResumeDrawing();

                        bReturnValue = true;
                        progressBarLoad.Visible = false;
                    }
                }
            }
            catch
            {               
                richTextBoxLogContent.ResumeDrawing();
            }
            return bReturnValue;
        }

        private void openLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewLogFiles_DoubleClick(sender, e);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vFillLogFilesListView();
        }

        private void listViewLogFiles_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                listViewLogFiles_DoubleClick(sender, e);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFind xFormFind = new FormFind();
            m_strFindCreteria = string.Empty;
            if (xFormFind.ShowDialog() == DialogResult.OK)
            {
                richTextBoxLogContent.Focus();
                m_strFindCreteria = xFormFind.strFindCreteria;
                m_iFindPoint = richTextBoxLogContent.Find(m_strFindCreteria);
                if (m_iFindPoint >= 0)
                    richTextBoxLogContent.Select();
                else
                    m_iFindPoint = 0;
            }
        }
        
        private void richTextBoxLogContent_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.Control == true && e.KeyCode == Keys.F) || e.KeyCode == Keys.F3)
                {
                    if (e.Control == true && e.KeyCode == Keys.F)
                        m_strFindCreteria = string.Empty;
                    if (m_strFindCreteria == string.Empty)
                    {
                        FormFind xFormFind = new FormFind();
                        m_strFindCreteria = string.Empty;
                        if (xFormFind.ShowDialog() == DialogResult.OK)
                        {
                            richTextBoxLogContent.Focus();
                            m_strFindCreteria = xFormFind.strFindCreteria;
                            m_iFindPoint = 0;
                        }
                    }
                    if (m_strFindCreteria != string.Empty)
                    {
                        RichTextBoxFinds xRichTextBoxFinds = new RichTextBoxFinds();
                        m_iFindPoint = richTextBoxLogContent.Find(m_strFindCreteria, m_iFindPoint + m_strFindCreteria.Length, xRichTextBoxFinds);
                        if (m_iFindPoint >= 0)
                            richTextBoxLogContent.Select();
                        else
                            m_iFindPoint = 0;
                    }
                }
            }
            catch
            {
            }
        }

        private void deleteLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewLogFiles.Items.Count > 0 && listViewLogFiles.SelectedItems.Count > 0)
            {
                List<string> straFileName=new List<string>();
                foreach (ListViewItem item in listViewLogFiles.SelectedItems)
                    straFileName.Add(item.Text);

                foreach (string fileName in straFileName)
                {
                    string strFileName = fileName;//listViewLogFiles.SelectedItems[0].Text;
                    string strFolderName = Trace.strTraceFolderName(dateTimePickerLogDateTime.Value);

                    File.Move(string.Format("{0}\\{1}", strFolderName, strFileName), string.Format("{0}\\{1}.BAK", strFolderName, strFileName));
                }

              
                vFillLogFilesListView();
            }
        }

        private void timerLogFilesListRefresh_Tick(object sender, EventArgs e)
        {
            if (bCheckLogFilesListChanges() == true)
            {
                vFillLogFilesListView();
            }
        }

        private void traceLevelToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            m_baShowWhichLevelofTrace[0] = level0ToolStripMenuItem.Checked;
            m_baShowWhichLevelofTrace[1] = level1ToolStripMenuItem.Checked;
            m_baShowWhichLevelofTrace[2] = level2ToolStripMenuItem.Checked;
            m_baShowWhichLevelofTrace[3] = level3ToolStripMenuItem.Checked;
            m_baShowWhichLevelofTrace[4] = level4ToolStripMenuItem.Checked;
            m_baShowWhichLevelofTrace[5] = level5ToolStripMenuItem.Checked;
            bLoadFile();
        }

        private void showMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMethodFind xFormFind = new FormMethodFind();
            m_strMethodFindCreteria = string.Empty;
            if (xFormFind.ShowDialog() == DialogResult.OK)
            {
                m_strMethodFindCreteria = xFormFind.strFindCreteria;
                bLoadFile();
            }
        }

        private void radioShowErrorLogs_CheckedChanged(object sender, EventArgs e)
        {
            vFillLogFilesListView();
        }

        private void radioShowAllLogs_CheckedChanged(object sender, EventArgs e)
        {
            vFillLogFilesListView();
        }

        private bool bDeleteLogfiles()
        {
            bool bResult = true;

            try
            {

                string strRootLogPath = JsonParameter.xGetInstance().prop_strTracesFolder;

                string[] stra_DirectoryPaths = Directory.GetDirectories(strRootLogPath);

                for (int iCounter = 0; iCounter < stra_DirectoryPaths.Count() - 1; iCounter++)
                {
                    string strDirectoryPath = stra_DirectoryPaths[iCounter];
                    string strDate = strDirectoryPath.Split('\\').Last().Replace("Log_","");
                    DateTime xDateTimeParsed = DateTime.MinValue;
                    if(DateTime.TryParseExact(strDate,"yyyyMMdd",System.Globalization.CultureInfo.CurrentCulture,System.Globalization.DateTimeStyles.None, out xDateTimeParsed)){

                        TimeSpan tsCompare = new TimeSpan();
                        tsCompare = DateTime.Now.Subtract(xDateTimeParsed);

                        if (tsCompare.Days > 30)//30 GÜNDEN ESKİ LOGLARI SİL
                            Directory.Delete(strDirectoryPath, true);
                    }
                }
            }
            catch(Exception ex)
            {
                bResult = false;
                Trace.vInsertError(ex);
            }

            return bResult;
        }

        private void radioShowDataLogs_CheckedChanged(object sender, EventArgs e)
        {
            vFillLogFilesListView();
        }

        private void cmbAplpicationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            vFillLogFilesListView();
        }

        private void cmbPageNumbers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                m_iSelectedPageNumber = int.Parse(cmbPageNumbers.Text);

                if (bLoadFile(m_iSelectedPageNumber) == true)
                {
                    m_strSelectedFileName = m_strCurrentFileName;
                    Text = string.Format("SaleFlex Log Viewer - {0}", m_strSelectedFileName);
                    listViewLogFiles.Items[m_iSelectedFileIndex].BackColor = SystemColors.InactiveCaption;
                    richTextBoxLogContent.Focus();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        private void richTextBoxLogContent_TextChanged(object sender, EventArgs e)
        {

        }

    }

    public static class RichTextBoxExtensions
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int WM_SETREDRAW = 0x0b;

        public static void SuspendDrawing(this System.Windows.Forms.RichTextBox richTextBox)
        {
            SendMessage(richTextBox.Handle, WM_SETREDRAW, (IntPtr)0, IntPtr.Zero);
        }

        public static void ResumeDrawing(this System.Windows.Forms.RichTextBox richTextBox)
        {
            SendMessage(richTextBox.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
            richTextBox.Invalidate();
        }
    }
}

