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
using SaleFlex.Data.AccessLayer;
using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.BoxForm
{
  public partial class InputBoxCustomer : Form
  {
    
    public List<CountryDataModel> xListCountryDataModel { get; set; }
    public List<CityDataModel> xListCityDataModel { get; set; }
    public List<DistrictDataModel> xListDistrictDataModel { get; set; }

    private bool m_bControlCancelButton;

    public bool bControlCancelButton
    {
        get { return m_bControlCancelButton; }
        set 
        {
            btnCncl.Location = new Point(489,400);
            buttonCancel.Location=new Point(489,400);
            m_bControlCancelButton = value;
            if (m_bControlCancelButton == false)
            {
                buttonClearForm.Location = new Point(21, 400);
            }
            buttonCancel.Visible =!m_bControlCancelButton;
            buttonOk.Visible = !m_bControlCancelButton;
            btnCncl.Visible = m_bControlCancelButton;
            buttonOk.Visible = m_bControlCancelButton;
            
        }
    }
    
    private bool m_bCancelFormClosing = false;


    public InputBoxCustomer(CustomerDataModel prm_xCustomerDataModel)
    {
      InitializeComponent();

      vPopulateCountryCombobox();
      vPopulateCityCombobox();
      vPopulateDistrictCombobox();

      try
      {
        if (prm_xCustomerDataModel != null)
        {
          iId = prm_xCustomerDataModel.iId;
          strCode = prm_xCustomerDataModel.strCode;
          strName = prm_xCustomerDataModel.strName;
          strLasName = prm_xCustomerDataModel.strLasName;
          strDescription = prm_xCustomerDataModel.strDescription;
          strAddressLine1 = prm_xCustomerDataModel.strAddressLine1;
          strAddressLine2 = prm_xCustomerDataModel.strAddressLine2;
          strAddressLine3 = prm_xCustomerDataModel.strAddressLine3;
          strZipCode = prm_xCustomerDataModel.strZipCode;
          lBonus = prm_xCustomerDataModel.lBonus;
          strNationalIdentityNumber = prm_xCustomerDataModel.strNationalIdentityNumber;
          strTaxOffice = prm_xCustomerDataModel.strTaxOffice;
          strTaxNumber = prm_xCustomerDataModel.strTaxNumber;
          strEmailAddress = prm_xCustomerDataModel.strEmailAddress;

          xCountryDataModel = prm_xCustomerDataModel.xCountryDataModel;
          xCityDataModel = prm_xCustomerDataModel.xCityDataModel;
          xDistrictDataModel = prm_xCustomerDataModel.xDistrictDataModel;
        }
      }
      catch (Exception xException)
      {
        xException.strTraceError();
      }
    }

    public int iId { get; set; }

    public string strCode
    {
      get
      {
        return textBoxCardNumber.Text;
      }
      set
      {
        textBoxCardNumber.Text = value;
      }
    }

    public string strName
    {
      get
      {
        return textBoxName.Text;
      }
      set
      {
        textBoxName.Text = value;
      }
    }

    public string strLasName
    {
      get
      {
        return textBoxSurname.Text;
      }
      set
      {
        textBoxSurname.Text = value;
      }
    }

    public string strDescription
    {
      get
      {
        return textBoxDescription.Text;
      }
      set
      {
        textBoxDescription.Text = value;
      }
    }

    public string strAddressLine1
    {
      get
      {
        return textBoxAddressLine1.Text;
      }
      set
      {
        textBoxAddressLine1.Text = value;
      }
    }

    public string strAddressLine2
    {
      get
      {
        return textBoxAddressLine2.Text;
      }
      set
      {
        textBoxAddressLine2.Text = value;
      }
    }

    public string strAddressLine3
    {
      get
      {
        return textBoxAddressLine3.Text;
      }
      set
      {
        textBoxAddressLine3.Text = value;
      }
    }

    public string strZipCode
    {
      get
      {
        return textBoxZipCode.Text;
      }
      set
      {
        textBoxZipCode.Text = value;
      }
    }

    public DistrictDataModel xDistrictDataModel
    {
      get
      {
          try
          {
              if (xListDistrictDataModel != null)
              {
                  return xListDistrictDataModel[iDistrictIndex];
              }
              return null;
          }
          catch (Exception)
          {
              return null;
          }
        
      }
      set
      {
        try
        {
          int iIndex = 0;
          for (iIndex = 0; iIndex < comboBoxDistrict.Items.Count; iIndex++)
          {
            if (value.strName == ((DistrictDataModel)comboBoxDistrict.Items[iIndex]).strName)
              break;
          }
          comboBoxDistrict.SelectedIndex = iIndex;
        }
        catch
        {
        }
      }
    }

    public CityDataModel xCityDataModel
    {
      get
      {
          try
          {
              if (xListCityDataModel != null)
              {
                  return xListCityDataModel[iCityIndex];
              }
              return null;
          }
          catch (Exception)
          {
              return null;
          }
        
      }
      set
      {
        try
        {
          int iIndex = 0;
          for (iIndex = 0; iIndex < comboBoxCity.Items.Count; iIndex++)
          {
            if (value.strName == ((CityDataModel)comboBoxCity.Items[iIndex]).strName)
              break;
          }
          comboBoxCity.SelectedIndex = iIndex;
        }
        catch
        {
        }
      }
    }

    public CountryDataModel xCountryDataModel
    {
      get
      {
          try
          {
              if (xListCountryDataModel != null)
              {
                  return xListCountryDataModel[iCountryIndex];
              }
              return null;
          }
          catch (Exception)
          {
              return null;
          }
       
      }
      set
      {
        try
        {
          int iIndex = 0;
          for (iIndex = 0; iIndex < comboBoxCountry.Items.Count; iIndex++)
          {
            if (value.strName == ((CountryDataModel)comboBoxCountry.Items[iIndex]).strName)
              break;
          }
          comboBoxCountry.SelectedIndex = iIndex;
        }
        catch
        {
        }
      }
    }

    public long lBonus
    {
      get
      {
        return 0;
      }
      set
      {
        long lTempBonus = value;
      }
    }

    public string strNationalIdentityNumber
    {
      get
      {
        return string.Empty;
      }
      set
      {
        string strTempNationalIdentityNumber = value;
      }
    }

    public string strTaxOffice
    {
      get
      {
        return textBoxTaxOffice.Text;
      }
      set
      {
        textBoxTaxOffice.Text = value;
      }
    }

    public string strTaxNumber
    {
      get
      {
        return textBoxTaxNo.Text;
      }
      set
      {
        textBoxTaxNo.Text = value;
      }
    }

    public string strEmailAddress
    {
      get
      {
        return textBoxEmailAddress.Text;
      }
      set
      {
        textBoxEmailAddress.Text = value;
      }
    }

    public int iCountryIndex
    {
      get
      {
        int iIndex = 0;
        for (iIndex = 0; iIndex < xListCountryDataModel.Count; iIndex++)
        {
          if (xListCountryDataModel[iIndex].strName == (string)comboBoxCountry.SelectedValue)
            break;
        }
        return iIndex;
      }
    }

    public int iCityIndex
    {
      get
      {
        int iIndex = 0;
        for (iIndex = 0; iIndex < xListCityDataModel.Count; iIndex++)
        {
          if (xListCityDataModel[iIndex].strName == (string)comboBoxCity.SelectedValue)
            break;
        }
        return iIndex;
      }
    }

    public int iDistrictIndex
    {
      get
      {
        int iIndex = 0;
        for (iIndex = 0; iIndex < xListDistrictDataModel.Count; iIndex++)
        {
          if (xListDistrictDataModel[iIndex].strName == (string)comboBoxDistrict.SelectedValue)
            break;
        }
        return iIndex;
      }
    }

    public int iCountryDefaultIndex
    {
      get
      {
        int iIndex = 0;
        for (iIndex = 0; iIndex < xListCountryDataModel.Count; iIndex++)
        {
          if (xListCountryDataModel[iIndex].bDefault == true)
            break;
        }
        return iIndex;
      }
    }

    public int iCityDefaultIndex
    {
      get
      {
        int iIndex = 0;
        for (iIndex = 0; iIndex < xListCityDataModel.Count; iIndex++)
        {
          if (xListCityDataModel[iIndex].bDefault == true)
            break;
        }
        return iIndex;
      }
    }

    public int iDistrictDefaultIndex
    {
      get
      {
        int iIndex = 0;
        for (iIndex = 0; iIndex < xListDistrictDataModel.Count; iIndex++)
        {
          if (xListDistrictDataModel[iIndex].bDefault == true)
            break;
        }
        return iIndex;
      }
    }

    private void buttonOk_Click(object sender, EventArgs e)
    {
      strCode = this.strCode;
      strDescription = this.strDescription;
      strAddressLine1 = this.strAddressLine1;
      strAddressLine2 = this.strAddressLine2;
      strAddressLine3 = this.strAddressLine3;
      strZipCode = this.strZipCode;
      lBonus = 0;
      strNationalIdentityNumber = this.strNationalIdentityNumber;
      strTaxOffice = this.strTaxOffice;
      strTaxNumber = this.strTaxNumber;
      strEmailAddress = this.strEmailAddress;
      xCountryDataModel = this.xCountryDataModel;
      xCityDataModel = this.xCityDataModel;
      xDistrictDataModel = this.xDistrictDataModel;

      if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
      {
          m_bCancelFormClosing = true;
      }
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        if (CustomMessageBox.Show(LabelTranslations.strGet("PrintControl"), MessageBoxButtons.YesNo) == DialogResult.No)
        {
            this.DialogResult = DialogResult.No;
          
        }
        else
        {
           this.DialogResult = DialogResult.OK;
          
        }
    }

    private void InputBoxCustomer_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (m_bCancelFormClosing == true)
        e.Cancel = true;
      m_bCancelFormClosing = false;
    }

    private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
      vPopulateCityCombobox();
      vPopulateDistrictCombobox();
    }

    private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
    {
      vPopulateDistrictCombobox();
    }

    private void comboBoxDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void vPopulateCountryCombobox()
    {
      try
      {
        xListCountryDataModel = Dao.xGetInstance().xListGetCountry();
        comboBoxCountry.DataSource = xListCountryDataModel;
        comboBoxCountry.SelectedIndex = iCountryDefaultIndex;
      }
      catch
      {
      }
    }

    private void vPopulateCityCombobox()
    {
      try
      {
        xListCityDataModel = Dao.xGetInstance().xListGetCity(xListCountryDataModel[iCountryIndex].iId);
        comboBoxCity.DataSource = xListCityDataModel;
        comboBoxCity.SelectedIndex = iCityDefaultIndex;
      }
      catch (Exception xException)
      {
        xException.strTraceError();
      }
    }

    private void vPopulateDistrictCombobox()
    {
      try
      {
        xListDistrictDataModel = Dao.xGetInstance().xListGetDistricts(xListCityDataModel[iCityIndex].iId);
        comboBoxDistrict.DataSource = xListDistrictDataModel;
        comboBoxDistrict.SelectedIndex = iDistrictDefaultIndex;
      }
      catch (Exception xException)
      {
        xException.strTraceError();
      }
    }

    private void textBox_Leave(object sender, EventArgs e)
    {
      string strCustomerCode = string.Empty;
      string strCustomerName = string.Empty;
      string strCustomerLastName = string.Empty;
      List<CustomerDataModel> xListCustomerDataModel = null;

      if (strCode != string.Empty)
      {
        strCustomerCode = strCode;
      }
      else if (strName != string.Empty && strLasName != string.Empty)
      {
        strCustomerName = strName;
        strCustomerLastName = strLasName;
      }

      if ((strCustomerCode != string.Empty) || (strCustomerName != string.Empty && strCustomerLastName != string.Empty))
        xListCustomerDataModel = Dao.xGetInstance().xListGetCustomers(strCustomerCode, strCustomerName, strCustomerLastName);

      if (xListCustomerDataModel != null && xListCustomerDataModel.Count > 0)
      {
        iId = xListCustomerDataModel[0].iId;
        strCode = xListCustomerDataModel[0].strCode;
        strName = xListCustomerDataModel[0].strName;
        strLasName = xListCustomerDataModel[0].strLasName;
        strDescription = xListCustomerDataModel[0].strDescription;
        strAddressLine1 = xListCustomerDataModel[0].strAddressLine1;
        strAddressLine2 = xListCustomerDataModel[0].strAddressLine2;
        strAddressLine3 = xListCustomerDataModel[0].strAddressLine3;
        strZipCode = xListCustomerDataModel[0].strZipCode;
        lBonus = xListCustomerDataModel[0].lBonus;
        strNationalIdentityNumber = xListCustomerDataModel[0].strNationalIdentityNumber;
        strTaxOffice = xListCustomerDataModel[0].strTaxOffice;
        strTaxNumber = xListCustomerDataModel[0].strTaxNumber;
        strEmailAddress = xListCustomerDataModel[0].strEmailAddress;

        xCountryDataModel = xListCustomerDataModel[0].xCountryDataModel;
        xCityDataModel = xListCustomerDataModel[0].xCityDataModel;
        xDistrictDataModel = xListCustomerDataModel[0].xDistrictDataModel;
      }
    }

    private void buttonClearForm_Click(object sender, EventArgs e)
    {
      if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        strCode = string.Empty;
        strName = string.Empty;
        strLasName = string.Empty;
        strDescription = string.Empty;
        strAddressLine1 = string.Empty;
        strAddressLine2 = string.Empty;
        strAddressLine3 = string.Empty;
        strZipCode = string.Empty;
        lBonus = 0;
        strNationalIdentityNumber = string.Empty;
        strTaxOffice = string.Empty;
        strTaxNumber = string.Empty;
        strEmailAddress = string.Empty;

        this.DialogResult = DialogResult.None;
        
      }
      else
      {
        m_bCancelFormClosing = true;
      }
    }

    private void InputBoxCustomer_Load(object sender, EventArgs e)
    {
      BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
      ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
    }

    private void btnCncl_Click(object sender, EventArgs e)
    {
        strCode = string.Empty;
        strName = string.Empty;
        strLasName = string.Empty;
        strDescription = string.Empty;
        strAddressLine1 = string.Empty;
        strAddressLine2 = string.Empty;
        strAddressLine3 = string.Empty;
        strZipCode = string.Empty;
        lBonus = 0;
        strNationalIdentityNumber = string.Empty;
        strTaxOffice = string.Empty;
        strTaxNumber = string.Empty;
        strEmailAddress = string.Empty;
    }
  }
}
