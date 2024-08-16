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
    public partial class CustomAlphanumericKeyboard : Form, ICustomKeyboard
    {
        public event delegate_vNewKey eventNewKey;

        public CustomAlphanumericKeyboard()
        {
            InitializeComponent();

            TopMost = true;
        }

        private void buttonQuotationMark_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "\"";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonAt_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "@";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
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

        private void buttonUnderscore_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "_";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonHyphen_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "-";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "=";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "+";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonQ_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "Q";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonW_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "W";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "E";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "R";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonT_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "T";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonY_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "Y";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonU_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "U";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonI_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "I";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonO_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "O";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonP_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "P";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonGG_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "Ğ";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonUU_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "Ü";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonParenleft_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "(";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonParenright_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = ")";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonVerticalbar_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "|";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "A";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "S";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "D";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "F";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonG_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "G";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonH_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "H";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonJ_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "J";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonK_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "K";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonL_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "L";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void SS_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "Ş";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void II_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "İ";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonQuestion_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "?";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonBracketleft_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "[";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonBracketright_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "]";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonSmaller_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "<";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonGreater_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = ">";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonZ_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "Z";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "X";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "C";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonV_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "V";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "B";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonN_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "N";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonM_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "M";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonOO_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "Ö";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonCC_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = "Ç";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = ".";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonColon_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = ":";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
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

        private void buttonSemicolon_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = ";";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = string.Empty;
            xNewKeyEventArgs.strFunction = "DELETE";

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonOk.Focus();
        }

        private void buttonSpace_Click(object sender, EventArgs e)
        {
            NewKeyEventArgs xNewKeyEventArgs = new NewKeyEventArgs();

            xNewKeyEventArgs.strValue = " ";
            xNewKeyEventArgs.strFunction = string.Empty;

            if (eventNewKey != null)
                eventNewKey(xNewKeyEventArgs);

            buttonSpace.Focus();
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

        private void button_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '"':
                    buttonQuotationMark_Click(sender, e);
                    break;
                case '@':
                    buttonAt_Click(sender, e);
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
                case '0':
                    buttonZero_Click(sender, e);
                    break;
                case '_':
                    buttonUnderscore_Click(sender, e);
                    break;
                case '-':
                    buttonHyphen_Click(sender, e);
                    break;
                case '=':
                    buttonEqual_Click(sender, e);
                    break;
                case '+':
                    buttonPlus_Click(sender, e);
                    break;
                case 'Q':
                    buttonQ_Click(sender, e);
                    break;
                case 'q':
                    buttonQ_Click(sender, e);
                    break;
                case 'W':
                    buttonW_Click(sender, e);
                    break;
                case 'w':
                    buttonW_Click(sender, e);
                    break;
                case 'E':
                    buttonE_Click(sender, e);
                    break;
                case 'e':
                    buttonE_Click(sender, e);
                    break;
                case 'R':
                    buttonR_Click(sender, e);
                    break;
                case 'r':
                    buttonR_Click(sender, e);
                    break;
                case 'T':
                    buttonT_Click(sender, e);
                    break;
                case 't':
                    buttonT_Click(sender, e);
                    break;
                case 'Y':
                    buttonY_Click(sender, e);
                    break;
                case 'y':
                    buttonY_Click(sender, e);
                    break;
                case 'U':
                    buttonU_Click(sender, e);
                    break;
                case 'u':
                    buttonU_Click(sender, e);
                    break;
                case 'I':
                    buttonI_Click(sender, e);
                    break;
                case 'ı':
                    buttonI_Click(sender, e);
                    break;
                case 'O':
                    buttonO_Click(sender, e);
                    break;
                case 'o':
                    buttonO_Click(sender, e);
                    break;
                case 'P':
                    buttonP_Click(sender, e);
                    break;
                case 'p':
                    buttonP_Click(sender, e);
                    break;
                case 'Ğ':
                    buttonGG_Click(sender, e);
                    break;
                case 'ğ':
                    buttonGG_Click(sender, e);
                    break;
                case 'Ü':
                    buttonUU_Click(sender, e);
                    break;
                case 'ü':
                    buttonUU_Click(sender, e);
                    break;
                case '(':
                    buttonParenleft_Click(sender, e);
                    break;
                case ')':
                    buttonParenright_Click(sender, e);
                    break;
                case '|':
                    buttonVerticalbar_Click(sender, e);
                    break;
                case 'A':
                    buttonA_Click(sender, e);
                    break;
                case 'a':
                    buttonA_Click(sender, e);
                    break;
                case 'S':
                    buttonS_Click(sender, e);
                    break;
                case 's':
                    buttonS_Click(sender, e);
                    break;
                case 'D':
                    buttonD_Click(sender, e);
                    break;
                case 'd':
                    buttonD_Click(sender, e);
                    break;
                case 'F':
                    buttonF_Click(sender, e);
                    break;
                case 'f':
                    buttonF_Click(sender, e);
                    break;
                case 'G':
                    buttonG_Click(sender, e);
                    break;
                case 'g':
                    buttonG_Click(sender, e);
                    break;
                case 'H':
                    buttonH_Click(sender, e);
                    break;
                case 'h':
                    buttonH_Click(sender, e);
                    break;
                case 'J':
                    buttonJ_Click(sender, e);
                    break;
                case 'j':
                    buttonJ_Click(sender, e);
                    break;
                case 'K':
                    buttonK_Click(sender, e);
                    break;
                case 'k':
                    buttonK_Click(sender, e);
                    break;
                case 'L':
                    buttonL_Click(sender, e);
                    break;
                case 'l':
                    buttonL_Click(sender, e);
                    break;
                case 'Ş':
                    SS_Click(sender, e);
                    break;
                case 'ş':
                    SS_Click(sender, e);
                    break;
                case 'İ':
                    II_Click(sender, e);
                    break;
                case 'i':
                    II_Click(sender, e);
                    break;
                case '?':
                    buttonQuestion_Click(sender, e);
                    break;
                case '[':
                    buttonBracketleft_Click(sender, e);
                    break;
                case ']':
                    buttonBracketright_Click(sender, e);
                    break;
                case '<':
                    buttonSmaller_Click(sender, e);
                    break;
                case '>':
                    buttonGreater_Click(sender, e);
                    break;
                case 'Z':
                    buttonZ_Click(sender, e);
                    break;
                case 'z':
                    buttonZ_Click(sender, e);
                    break;
                case 'X':
                    buttonX_Click(sender, e);
                    break;
                case 'x':
                    buttonX_Click(sender, e);
                    break;
                case 'C':
                    buttonC_Click(sender, e);
                    break;
                case 'c':
                    buttonC_Click(sender, e);
                    break;
                case 'V':
                    buttonV_Click(sender, e);
                    break;
                case 'v':
                    buttonV_Click(sender, e);
                    break;
                case 'B':
                    buttonB_Click(sender, e);
                    break;
                case 'b':
                    buttonB_Click(sender, e);
                    break;
                case 'N':
                    buttonN_Click(sender, e);
                    break;
                case 'n':
                    buttonN_Click(sender, e);
                    break;
                case 'M':
                    buttonM_Click(sender, e);
                    break;
                case 'm':
                    buttonM_Click(sender, e);
                    break;
                case 'Ö':
                    buttonOO_Click(sender, e);
                    break;
                case 'ö':
                    buttonOO_Click(sender, e);
                    break;
                case 'Ç':
                    buttonCC_Click(sender, e);
                    break;
                case 'ç':
                    buttonCC_Click(sender, e);
                    break;
                case '.':
                    buttonDot_Click(sender, e);
                    break;
                case ':':
                    buttonColon_Click(sender, e);
                    break;
                case ',':
                    buttonComma_Click(sender, e);
                    break;
                case ';':
                    buttonSemicolon_Click(sender, e);
                    break;
                case ' ':
                    buttonSpace_Click(sender, e);
                    break;
            }
        }

        private void button_KeyPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 46:
                    buttonDelete_Click(sender, e);
                    break;
                case 8:
                    buttonDelete_Click(sender, e);
                    break;
            }
        }
    }
}
