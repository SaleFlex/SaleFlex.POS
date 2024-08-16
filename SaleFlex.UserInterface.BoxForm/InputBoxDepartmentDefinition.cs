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
    public partial class InputBoxDepartmentDefinition : Form
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

        public InputBoxDepartmentDefinition()
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
              comboBoxDepartmentId.Items.Clear();
              foreach (DepartmentDataModel xDepartmentDataModel in m_xListDepartmentDataModel)
              {
                  comboBoxDepartmentId.Items.Add(string.Format("{0}", Convert.ToInt64(xDepartmentDataModel.iNo)));
              }
              comboBoxDepartmentId.SelectedIndex = 0;
          }
        }

        public int iDepartmentId
        {
            get
            {
                return int.Parse(comboBoxDepartmentId.Text);
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

        public decimal decDepartmentPrice
        {
            get
            {
                try
                {
                    return decimal.Parse(textBoxDepartmentPrice.Text);
                }
                catch
                {
                    return 0m;
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

        public decimal decDepartmentPriceLimitation
        {
            get
            {
                try
                {
                    return decimal.Parse(textBoxDepartmentPriceLimitation.Text);
                }
                catch
                {
                    return 0m;
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

        private void InputBoxDepartmentDefinition_Load(object sender, EventArgs e)
        {
          BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
          ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void comboBoxDepartmentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentDataModel xDepartmentDataModel = new DepartmentDataModel();
            xDepartmentDataModel = xListDepartmentDataModel.Where(x => x.iNo.ToString() == comboBoxDepartmentId.SelectedItem.ToString()).FirstOrDefault();

            textBoxDepartmentName.Text = string.Empty;
            textBoxDepartmentPrice.Text = string.Empty;
            textBoxDepartmentPriceLimitation.Text = string.Empty;
            comboBoxVATId.SelectedIndex = -1;

            if(xDepartmentDataModel != null)
            {
                textBoxDepartmentName.Text = xDepartmentDataModel.strName;
                textBoxDepartmentPrice.Text = xDepartmentDataModel.decDefaultPrice.ToString();
                textBoxDepartmentPriceLimitation.Text = xDepartmentDataModel.decMaxPrice.ToString();
                comboBoxVATId.SelectedItem = xDepartmentDataModel.xVat.iId.ToString();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
          
        }

        private void InputBoxDepartmentDefinition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            InputBoxNewDepartmentDefinition xInputBoxNewDepartmentDefinition = new InputBoxNewDepartmentDefinition();
            xInputBoxNewDepartmentDefinition.xListDepartmentDataModel = xListDepartmentDataModel;
            m_bCancelFormClosing = false;
            this.DialogResult = DialogResult.None;

            if (xInputBoxNewDepartmentDefinition.ShowDialog() == DialogResult.OK)
            {
                DepartmentDataModel xDepartmentDataModel = new DepartmentDataModel();
                xDepartmentDataModel.iNo = xInputBoxNewDepartmentDefinition.iDepartmentId;
                xDepartmentDataModel.xVat.iNo = xInputBoxNewDepartmentDefinition.iVATId;
                xDepartmentDataModel.strName = xInputBoxNewDepartmentDefinition.strDepartmentName;
                xDepartmentDataModel.decDefaultPrice = xInputBoxNewDepartmentDefinition.decDepartmentPrice;
                xDepartmentDataModel.decMaxPrice = xInputBoxNewDepartmentDefinition.decDepartmentPriceLimitation;
                xNewDepartmentDataModel = xDepartmentDataModel;
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
