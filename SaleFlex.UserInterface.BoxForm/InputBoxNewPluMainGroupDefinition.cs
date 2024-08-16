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
    public partial class InputBoxNewPluMainGroupDefinition : Form
    {
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
        private bool m_bCancelFormClosing = false;
        private List<PluMainGroupDataModel> m_xListPluMainGroupDataModel = new List<PluMainGroupDataModel>();
        private PluMainGroupDataModel m_xPluMainGroupDataModel = null;

        public InputBoxNewPluMainGroupDefinition()
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
            }


        }

        public int iPluMainGroupNo
        {
            get
            {
                return int.Parse(maskedTextboxPluMainGroupNo.Text);
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

        private void maskedTextboxPluMainGroupId_Leave(object sender, EventArgs e)
        {
            if (maskedTextboxPluMainGroupNo.Text.iConvertToInt() > 100)
            {
                CustomMessageBox.Show(LabelTranslations.strGet("PluGroupMaxWarning"), MessageBoxButtons.OK);
                maskedTextboxPluMainGroupNo.Focus();
                return;
            }

            foreach (PluMainGroupDataModel xPluMainGroupDataModel in xListPluMainGroupDataModel)
            {
                if (xPluMainGroupDataModel.iNo == iPluMainGroupNo)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("PluGroupExistWarning"), MessageBoxButtons.OK);
                    maskedTextboxPluMainGroupNo.Focus();
                    return;
                }
            }
        }

        private void maskedTextboxPluMainGroupId_Click(object sender, EventArgs e)
        {
            maskedTextboxPluMainGroupNo.Select(maskedTextboxPluMainGroupNo.Text.Length, 0);
        }

        }
    }

