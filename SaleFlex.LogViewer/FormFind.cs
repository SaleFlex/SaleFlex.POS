using System.Windows.Forms;

namespace SaleFlexLogViewer
{
    public partial class FormFind : Form
    {
        public FormFind()
        {
            InitializeComponent();
        }

        public string strFindCreteria
        {
            get
            {
                return textBoxFind.Text;
            }
        }
    }
}
