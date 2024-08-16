using System.Configuration;

namespace SaleFlexLogViewer
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.contextMenuStripFileListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelLeftSide = new System.Windows.Forms.Panel();
            this.listViewLogFiles = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbPageNumbers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbAplpicationName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioShowAllLogs = new System.Windows.Forms.RadioButton();
            this.radioShowErrorLogs = new System.Windows.Forms.RadioButton();
            this.progressBarLoad = new System.Windows.Forms.ProgressBar();
            this.dateTimePickerLogDateTime = new System.Windows.Forms.DateTimePicker();
            this.richTextBoxLogContent = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripTraceEditorContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.level0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.timerLogFilesListRefresh = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripFileListContextMenu.SuspendLayout();
            this.panelLeftSide.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStripTraceEditorContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripFileListContextMenu
            // 
            this.contextMenuStripFileListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripSeparator1,
            this.openLogFileToolStripMenuItem,
            this.deleteLogFileToolStripMenuItem});
            this.contextMenuStripFileListContextMenu.Name = "contextMenuStripFileListContextMenu";
            this.contextMenuStripFileListContextMenu.Size = new System.Drawing.Size(152, 76);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // openLogFileToolStripMenuItem
            // 
            this.openLogFileToolStripMenuItem.Name = "openLogFileToolStripMenuItem";
            this.openLogFileToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openLogFileToolStripMenuItem.Text = "Open Log File";
            this.openLogFileToolStripMenuItem.Click += new System.EventHandler(this.openLogFileToolStripMenuItem_Click);
            // 
            // deleteLogFileToolStripMenuItem
            // 
            this.deleteLogFileToolStripMenuItem.Name = "deleteLogFileToolStripMenuItem";
            this.deleteLogFileToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.deleteLogFileToolStripMenuItem.Text = "Delete Log File";
            this.deleteLogFileToolStripMenuItem.Click += new System.EventHandler(this.deleteLogFileToolStripMenuItem_Click);
            // 
            // panelLeftSide
            // 
            this.panelLeftSide.Controls.Add(this.listViewLogFiles);
            this.panelLeftSide.Controls.Add(this.panel1);
            this.panelLeftSide.Controls.Add(this.progressBarLoad);
            this.panelLeftSide.Controls.Add(this.dateTimePickerLogDateTime);
            this.panelLeftSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftSide.Location = new System.Drawing.Point(0, 0);
            this.panelLeftSide.Name = "panelLeftSide";
            this.panelLeftSide.Size = new System.Drawing.Size(300, 587);
            this.panelLeftSide.TabIndex = 1;
            // 
            // listViewLogFiles
            // 
            this.listViewLogFiles.BackColor = System.Drawing.Color.White;
            this.listViewLogFiles.ContextMenuStrip = this.contextMenuStripFileListContextMenu;
            this.listViewLogFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLogFiles.HideSelection = false;
            this.listViewLogFiles.Location = new System.Drawing.Point(0, 153);
            this.listViewLogFiles.Name = "listViewLogFiles";
            this.listViewLogFiles.Size = new System.Drawing.Size(300, 407);
            this.listViewLogFiles.TabIndex = 4;
            this.listViewLogFiles.UseCompatibleStateImageBehavior = false;
            this.listViewLogFiles.View = System.Windows.Forms.View.List;
            this.listViewLogFiles.DoubleClick += new System.EventHandler(this.listViewLogFiles_DoubleClick);
            this.listViewLogFiles.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.listViewLogFiles_PreviewKeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.cmbPageNumbers);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 133);
            this.panel1.TabIndex = 3;
            // 
            // cmbPageNumbers
            // 
            this.cmbPageNumbers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageNumbers.FormattingEnabled = true;
            this.cmbPageNumbers.Location = new System.Drawing.Point(223, 102);
            this.cmbPageNumbers.Name = "cmbPageNumbers";
            this.cmbPageNumbers.Size = new System.Drawing.Size(61, 21);
            this.cmbPageNumbers.TabIndex = 4;
            this.cmbPageNumbers.SelectionChangeCommitted += new System.EventHandler(this.cmbPageNumbers_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(177, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sayfa: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbAplpicationName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(12, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 45);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Uygulama Adı";
            // 
            // cmbAplpicationName
            // 
            this.cmbAplpicationName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAplpicationName.FormattingEnabled = true;
            this.cmbAplpicationName.Location = new System.Drawing.Point(6, 19);
            this.cmbAplpicationName.Name = "cmbAplpicationName";
            this.cmbAplpicationName.Size = new System.Drawing.Size(266, 23);
            this.cmbAplpicationName.TabIndex = 3;
            this.cmbAplpicationName.SelectedIndexChanged += new System.EventHandler(this.cmbAplpicationName_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioShowAllLogs);
            this.groupBox1.Controls.Add(this.radioShowErrorLogs);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 41);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log Tipi";
            // 
            // radioShowAllLogs
            // 
            this.radioShowAllLogs.AutoSize = true;
            this.radioShowAllLogs.Checked = true;
            this.radioShowAllLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioShowAllLogs.Location = new System.Drawing.Point(32, 19);
            this.radioShowAllLogs.Name = "radioShowAllLogs";
            this.radioShowAllLogs.Size = new System.Drawing.Size(85, 17);
            this.radioShowAllLogs.TabIndex = 0;
            this.radioShowAllLogs.TabStop = true;
            this.radioShowAllLogs.Text = "Bütün Loglar";
            this.radioShowAllLogs.UseVisualStyleBackColor = true;
            this.radioShowAllLogs.CheckedChanged += new System.EventHandler(this.radioShowAllLogs_CheckedChanged);
            // 
            // radioShowErrorLogs
            // 
            this.radioShowErrorLogs.AutoSize = true;
            this.radioShowErrorLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioShowErrorLogs.Location = new System.Drawing.Point(146, 19);
            this.radioShowErrorLogs.Name = "radioShowErrorLogs";
            this.radioShowErrorLogs.Size = new System.Drawing.Size(81, 17);
            this.radioShowErrorLogs.TabIndex = 1;
            this.radioShowErrorLogs.Text = "Error Logları";
            this.radioShowErrorLogs.UseVisualStyleBackColor = true;
            this.radioShowErrorLogs.CheckedChanged += new System.EventHandler(this.radioShowErrorLogs_CheckedChanged);
            // 
            // progressBarLoad
            // 
            this.progressBarLoad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarLoad.Location = new System.Drawing.Point(0, 560);
            this.progressBarLoad.Name = "progressBarLoad";
            this.progressBarLoad.Size = new System.Drawing.Size(300, 27);
            this.progressBarLoad.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarLoad.TabIndex = 2;
            this.progressBarLoad.Visible = false;
            // 
            // dateTimePickerLogDateTime
            // 
            this.dateTimePickerLogDateTime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerLogDateTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateTimePickerLogDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerLogDateTime.Location = new System.Drawing.Point(0, 0);
            this.dateTimePickerLogDateTime.Name = "dateTimePickerLogDateTime";
            this.dateTimePickerLogDateTime.Size = new System.Drawing.Size(300, 20);
            this.dateTimePickerLogDateTime.TabIndex = 1;
            this.dateTimePickerLogDateTime.ValueChanged += new System.EventHandler(this.dateTimePickerLogDateTime_ValueChanged);
            // 
            // richTextBoxLogContent
            // 
            this.richTextBoxLogContent.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxLogContent.ContextMenuStrip = this.contextMenuStripTraceEditorContextMenu;
            this.richTextBoxLogContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLogContent.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBoxLogContent.Location = new System.Drawing.Point(300, 0);
            this.richTextBoxLogContent.Name = "richTextBoxLogContent";
            this.richTextBoxLogContent.ReadOnly = true;
            this.richTextBoxLogContent.Size = new System.Drawing.Size(654, 587);
            this.richTextBoxLogContent.TabIndex = 0;
            this.richTextBoxLogContent.Text = "";
            this.richTextBoxLogContent.TextChanged += new System.EventHandler(this.richTextBoxLogContent_TextChanged);
            this.richTextBoxLogContent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBoxLogContent_KeyUp);
            // 
            // contextMenuStripTraceEditorContextMenu
            // 
            this.contextMenuStripTraceEditorContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.showMethodToolStripMenuItem,
            this.toolStripSeparator2,
            this.level0ToolStripMenuItem,
            this.level1ToolStripMenuItem,
            this.level2ToolStripMenuItem,
            this.level3ToolStripMenuItem,
            this.level4ToolStripMenuItem,
            this.level5ToolStripMenuItem});
            this.contextMenuStripTraceEditorContextMenu.Name = "contextMenuStripTraceEditorContextMenu";
            this.contextMenuStripTraceEditorContextMenu.Size = new System.Drawing.Size(149, 186);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // showMethodToolStripMenuItem
            // 
            this.showMethodToolStripMenuItem.Name = "showMethodToolStripMenuItem";
            this.showMethodToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.showMethodToolStripMenuItem.Text = "Show Method";
            this.showMethodToolStripMenuItem.Click += new System.EventHandler(this.showMethodToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // level0ToolStripMenuItem
            // 
            this.level0ToolStripMenuItem.Checked = true;
            this.level0ToolStripMenuItem.CheckOnClick = true;
            this.level0ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.level0ToolStripMenuItem.Name = "level0ToolStripMenuItem";
            this.level0ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.level0ToolStripMenuItem.Text = "Level 0";
            this.level0ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.traceLevelToolStripMenuItem_CheckedChanged);
            // 
            // level1ToolStripMenuItem
            // 
            this.level1ToolStripMenuItem.Checked = true;
            this.level1ToolStripMenuItem.CheckOnClick = true;
            this.level1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.level1ToolStripMenuItem.Name = "level1ToolStripMenuItem";
            this.level1ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.level1ToolStripMenuItem.Text = "Level 1";
            this.level1ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.traceLevelToolStripMenuItem_CheckedChanged);
            // 
            // level2ToolStripMenuItem
            // 
            this.level2ToolStripMenuItem.Checked = true;
            this.level2ToolStripMenuItem.CheckOnClick = true;
            this.level2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.level2ToolStripMenuItem.Name = "level2ToolStripMenuItem";
            this.level2ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.level2ToolStripMenuItem.Text = "Level 2";
            this.level2ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.traceLevelToolStripMenuItem_CheckedChanged);
            // 
            // level3ToolStripMenuItem
            // 
            this.level3ToolStripMenuItem.Checked = true;
            this.level3ToolStripMenuItem.CheckOnClick = true;
            this.level3ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.level3ToolStripMenuItem.Name = "level3ToolStripMenuItem";
            this.level3ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.level3ToolStripMenuItem.Text = "Level 3";
            this.level3ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.traceLevelToolStripMenuItem_CheckedChanged);
            // 
            // level4ToolStripMenuItem
            // 
            this.level4ToolStripMenuItem.Checked = true;
            this.level4ToolStripMenuItem.CheckOnClick = true;
            this.level4ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.level4ToolStripMenuItem.Name = "level4ToolStripMenuItem";
            this.level4ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.level4ToolStripMenuItem.Text = "Level 4";
            this.level4ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.traceLevelToolStripMenuItem_CheckedChanged);
            // 
            // level5ToolStripMenuItem
            // 
            this.level5ToolStripMenuItem.Checked = true;
            this.level5ToolStripMenuItem.CheckOnClick = true;
            this.level5ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.level5ToolStripMenuItem.Name = "level5ToolStripMenuItem";
            this.level5ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.level5ToolStripMenuItem.Text = "Level 5";
            this.level5ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.traceLevelToolStripMenuItem_CheckedChanged);
            // 
            // timerLogFilesListRefresh
            // 
            this.timerLogFilesListRefresh.Interval = 1000;
            this.timerLogFilesListRefresh.Tick += new System.EventHandler(this.timerLogFilesListRefresh_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 587);
            this.Controls.Add(this.richTextBoxLogContent);
            this.Controls.Add(this.panelLeftSide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaleFlex Log Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStripFileListContextMenu.ResumeLayout(false);
            this.panelLeftSide.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStripTraceEditorContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeftSide;
        private System.Windows.Forms.RichTextBox richTextBoxLogContent;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFileListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogFileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTraceEditorContextMenu;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.Timer timerLogFilesListRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem level0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level5ToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBarLoad;
        private System.Windows.Forms.ToolStripMenuItem showMethodToolStripMenuItem;
        private System.Windows.Forms.ListView listViewLogFiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioShowErrorLogs;
        private System.Windows.Forms.RadioButton radioShowAllLogs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbAplpicationName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbPageNumbers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerLogDateTime;
    }
}

