using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaleFlex.UserInterface.Controls
{
    public partial class CustomSaleOption : Form
    {
        public bool prop_bCancelSale { get; set; }
        public bool prop_bRepeatSale { get; set; }

        public CustomSaleOption()
        {
            InitializeComponent();
            prop_bCancelSale = false;
            prop_bRepeatSale = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            prop_bCancelSale = true;
            Close();
        }

        private void buttonRepeat_Click(object sender, EventArgs e)
        {
            prop_bRepeatSale = true;
            Close();
        }
    }
}
