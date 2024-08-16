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
    public partial class InputBoxIdleMessage : Form
    {
        private bool m_bCancelFormClosing = false;

        public InputBoxIdleMessage()
        {
            InitializeComponent();
        }

        public string strIdleMessage
        {
          get
          {
            return textBoxIdleMessage.Text;
          }
          set
          {
            textBoxIdleMessage.Text = value;
          }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
          if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
          {
            m_bCancelFormClosing = true;
          }
        }

        private void InputBoxIdleMessage_Load(object sender, EventArgs e)
        {
          BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
          ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
          
        }

        private void InputBoxIdleMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }
 
    }
}
