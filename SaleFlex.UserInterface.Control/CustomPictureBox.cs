using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data;

namespace SaleFlex.UserInterface.Controls
{
    public class CustomPictureBox : PictureBox, ICustomControl
    {
        public CustomPictureBox(FormControlDataModel prm_xFormControlDataModel)
        {
            vInitializeCustomComponents(prm_xFormControlDataModel);
        }

        public void vInitializeCustomComponents(FormControlDataModel prm_xFormControlDataModel)
        {
            ((Control)this).bSetControlCommonProperties(prm_xFormControlDataModel);

            if (prm_xFormControlDataModel.strImage != string.Empty)
            {
                Bitmap xBitmap = new Bitmap(string.Format("{0}\\{1}", CommonProperty.prop_strImagesFolder, prm_xFormControlDataModel.strImage));

                if (xBitmap.Height > Height)
                {
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }

                BackgroundImage = xBitmap;
            }
        }

        public string strName { get; set; }
        public string strType { get; set; }
        public string strFunction1 { get; set; }
        public string strFunction2 { get; set; }
        public EventHandler xEventHandler1 { get; set; }
        public EventHandler xEventHandler2 { get; set; }

        public void vOnEvent1(object prm_objObject, EventArgs prm_xEventArgs)
        {
            if (xEventHandler1 != null)
                xEventHandler1(prm_objObject, prm_xEventArgs);
        }

        public void vOnEvent2(object prm_objObject, EventArgs prm_xEventArgs)
        {
            if (xEventHandler2 != null)
                xEventHandler2(prm_objObject, prm_xEventArgs);
        }
    }
}
