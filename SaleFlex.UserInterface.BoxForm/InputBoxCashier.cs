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
  public partial class InputBoxCashier : Form
  {
    private List<CashierDataModel> m_xListCashierDataModel = new List<CashierDataModel>();
    private bool m_bCancelFormClosing = false;

    public InputBoxCashier()
    {
      InitializeComponent();
    }

    public int iCashierId
    {
      get
      {
        return int.Parse(comboBoxCashierId.Text);
      }
    }

    public string strCashierName
    {
      get
      {
        return textBoxCashierName.Text;
      }
    }

    public string strCashierPassword
    {
      get
      {
        return textBoxCashierPassword.Text;
      }
    }

    public List<CashierDataModel> xListCashierDataModel
    {
      get
      {
        return m_xListCashierDataModel;
      }
      set
      {
          m_xListCashierDataModel = value;
      }
    }

    private void buttonOk_Click(object sender, EventArgs e)
    {
      if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
      {
        m_bCancelFormClosing = true;
      }
    }

    private void comboBoxDepartmentId_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        textBoxCashierName.Text = xListCashierDataModel.FirstOrDefault(x => x.iNo.ToString() == comboBoxCashierId.SelectedItem.ToString()).strName;
        textBoxCashierPassword.Text = xListCashierDataModel.FirstOrDefault(x => x.iNo.ToString() == comboBoxCashierId.SelectedItem.ToString()).strPassword;
      }
      catch( Exception xException)
      {
        xException.strTraceError();
        textBoxCashierName.Text = string.Empty;
        textBoxCashierPassword.Text = string.Empty;
      }
        
    }

    private void InputBoxDepartmentDefinition_Load(object sender, EventArgs e)
    {

        BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
        ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
      
    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      

    }

    private void InputBoxCashier_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (m_bCancelFormClosing == true)
            e.Cancel = true;
        m_bCancelFormClosing = false;
    }
  }
}

