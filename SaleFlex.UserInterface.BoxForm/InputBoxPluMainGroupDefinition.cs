using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.BoxForm
{
    public partial class InputBoxPluMainGroupDefinition : Form
    {
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
        private bool m_bCancelFormClosing = false;
        private List<PluMainGroupDataModel> m_xListPluMainGroupDataModel = new List<PluMainGroupDataModel>();
        private PluMainGroupDataModel m_xPluMainGroupDataModel = null;

        public InputBoxPluMainGroupDefinition()
        {
            InitializeComponent();
        }

        public PluMainGroupDataModel xNewPluMainGroupDataModel
        {
            get
            {
                return m_xPluMainGroupDataModel;
            }
            set
            {
                m_xPluMainGroupDataModel = value;
            }
        }

        public List<PluMainGroupDataModel> xListPluMainGroupDataModel
        {
            get
            {
                return m_xListPluMainGroupDataModel;
            }
            set
            {
                m_xListPluMainGroupDataModel = value;
                comboBoxPluMainGroupNo.Items.Clear();
                foreach (PluMainGroupDataModel xPluMainGroupDataModel in m_xListPluMainGroupDataModel)
                {
                    comboBoxPluMainGroupNo.Items.Add(string.Format("{0}",Convert.ToInt64(xPluMainGroupDataModel.iNo.ToString())));
                }
                comboBoxPluMainGroupNo.SelectedIndex = 0;
            }


        }

        public int iPluMainGroupNo
        {
            get
            {
                return int.Parse(comboBoxPluMainGroupNo.SelectedItem.ToString());
            }
        }

        public string strPLUGroupName
        {
            get
            {
                return textBoxPLUGroupName.Text;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                m_bCancelFormClosing = true;
            }
       
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            InputBoxNewPluMainGroupDefinition xInputBoxNewPluMainGroupDefinition = new InputBoxNewPluMainGroupDefinition();
            xInputBoxNewPluMainGroupDefinition.xListPluMainGroupDataModel = xListPluMainGroupDataModel;

            m_bCancelFormClosing = false;
            this.DialogResult = DialogResult.None;

            if (xInputBoxNewPluMainGroupDefinition.ShowDialog() == DialogResult.OK) 
            {
                PluMainGroupDataModel xPluMainGroupDataModel = new PluMainGroupDataModel();

                xPluMainGroupDataModel.iNo = xInputBoxNewPluMainGroupDefinition.iPluMainGroupNo;
                xPluMainGroupDataModel.strName = xInputBoxNewPluMainGroupDefinition.strPLUGroupName;
                xPluMainGroupDataModel.strDescription = xInputBoxNewPluMainGroupDefinition.strPLUGroupName;
                xNewPluMainGroupDataModel = xPluMainGroupDataModel;
                this.DialogResult = DialogResult.Cancel;
            }


        }

        private void InputBoxPluMainGroupDefinition_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void InputBoxPluMainGroupDefinition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }

        private void comboBoxPluMainGroupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PluMainGroupDataModel xPluMainGroupDataModel = new PluMainGroupDataModel();
                xPluMainGroupDataModel = xListPluMainGroupDataModel.Where(x => x.iNo == comboBoxPluMainGroupNo.SelectedItem.ToString().iConvertToInt()).FirstOrDefault();

                if (xPluMainGroupDataModel != null)
                {
                    textBoxPLUGroupName.Text = xPluMainGroupDataModel.strName;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        }
    }

