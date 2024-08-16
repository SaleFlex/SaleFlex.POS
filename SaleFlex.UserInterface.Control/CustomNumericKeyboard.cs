using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;

namespace SaleFlex.UserInterface.Controls
{
    public partial class CustomNumericKeyboard : Form, ICustomKeyboard
    {
        public event delegate_vNewKey eventNewKey;

        public CustomNumericKeyboard()
        {
            InitializeComponent();

            TopMost = true;
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "1";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "2";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "3";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "4";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "5";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "6";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "7";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "8";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "9";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "0";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = string.Empty;
            xNewKeyEventArgs.strFunction = "DELETE";

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = string.Empty;
            xNewKeyEventArgs.strFunction = "OK";

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = string.Empty;
            xNewKeyEventArgs.strFunction = "CANCEL";

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            Close();
        }

        private void button_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    buttonZero_Click(sender, e);
                    break;
                case '1':
                    buttonOne_Click(sender, e);
                    break;
                case '2':
                    buttonTwo_Click(sender, e);
                    break;
                case '3':
                    buttonThree_Click(sender, e);
                    break;
                case '4':
                    buttonFour_Click(sender, e);
                    break;
                case '5':
                    buttonFive_Click(sender, e);
                    break;
                case '6':
                    buttonSix_Click(sender, e);
                    break;
                case '7':
                    buttonSeven_Click(sender, e);
                    break;
                case '8':
                    buttonEight_Click(sender, e);
                    break;
                case '9':
                    buttonNine_Click(sender, e);
                    break;
            }
        }

        private void button_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46 || e.KeyValue == 8)
            {
                buttonDelete_Click(sender, e);
            }
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = ",";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }
    }
}
