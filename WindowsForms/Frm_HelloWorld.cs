using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_HelloWorld : Form
    {
        public Frm_HelloWorld()
        {
            InitializeComponent();
        }

        private void Btn_Sair_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}
