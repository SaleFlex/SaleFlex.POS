using System.Windows.Forms;

namespace SaleFlexLogViewer
{
    public partial class FormMethodFind : Form
    {
        public FormMethodFind()
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
