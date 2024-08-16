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
    public partial class InputBoxNewDepartmentDefinition : Form
    {
        private bool m_bCancelFormClosing = false;
        private DepartmentDataModel m_xDepartmentDataModel = null;

        public DepartmentDataModel xNewDepartmentDataModel
        {
            get
            {
                return m_xDepartmentDataModel;
            }
            set
            {
                m_xDepartmentDataModel = value;
            }
        }

        private List<DepartmentDataModel> m_xListDepartmentDataModel = new List<DepartmentDataModel>();

        public List<VatDataModel> xListVatDataModel { get; set; }

        public InputBoxNewDepartmentDefinition()
        {
            InitializeComponent();
        }

        public List<DepartmentDataModel> xListDepartmentDataModel
        {
            get
            {
                return m_xListDepartmentDataModel;
            }
            set
            {
                m_xListDepartmentDataModel = value;
            }
        }

        public int iDepartmentId
        {
            get
            {
                return int.Parse(maskedTextBoxDeparmentId.Text);
            }
        }

        public int iVATId
        {
            get
            {
                return int.Parse(comboBoxVATId.Text);
            }
        }

        public string strDepartmentName
        {
            get
            {
                return textBoxDepartmentName.Text;
            }
        }

        public long decDepartmentPrice
        {
            get
            {
                try
                {
                    return long.Parse(textBoxDepartmentPrice.Text);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int iVatIndex
        {
            get
            {
                int iIndex = 0;
                for (iIndex = 0; iIndex < xListVatDataModel.Count; iIndex++)
                {
                    if (xListVatDataModel[iIndex].iNo.ToString() == (string)comboBoxVATId.SelectedValue)
                        break;
                }
                return iIndex;
            }
        }

        public VatDataModel xVatDataModel
        {
            get
            {
                return xListVatDataModel[iVatIndex];
            }
            set
            {
                int iIndex = 0;
                for (iIndex = 0; iIndex < comboBoxVATId.Items.Count; iIndex++)
                {
                    if (value.iNo == ((VatDataModel)comboBoxVATId.Items[iIndex]).iNo)
                        break;
                }
                //comboBoxVATId.SelectedIndex = iIndex;
            }
        }

        public long decDepartmentPriceLimitation
        {
            get
            {
                try
                {
                    return long.Parse(textBoxDepartmentPriceLimitation.Text);
                }
                catch
                {
                    return 0;
                }
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

        private void InputBoxNewDepartmentDefinition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }

        private void InputBoxNewDepartmentDefinition_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void maskedTextBoxDeparmentId_Leave(object sender, EventArgs e)
        {
           // if (maskedTextBoxDeparmentId.Text.ConvertToInt() > 100)
            if (maskedTextBoxDeparmentId.Text.iConvertToInt() > 8)
            {
                CustomMessageBox.Show(LabelTranslations.strGet("DepartmentMaxWarning"), MessageBoxButtons.OK);
                maskedTextBoxDeparmentId.Focus();
                return;
            }

            foreach (DepartmentDataModel xDepartmentDataModel in xListDepartmentDataModel)
            {
                if (xDepartmentDataModel.iNo == iDepartmentId)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("DepartmentExistWarning"), MessageBoxButtons.OK);
                    maskedTextBoxDeparmentId.Focus();
                    return;
                }
            }
        }

        private void maskedTextBoxDeparmentId_Click(object sender, EventArgs e)
        {
            maskedTextBoxDeparmentId.Select(maskedTextBoxDeparmentId.Text.Length, 0);
        }

    }
}
