using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_MouseCaptura : Form
    {
        public Frm_MouseCaptura()
        {
            InitializeComponent();
        }

        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            string str1 = e.Button.ToString();
            MessageBox.Show("Foi pressionado o botão do(a) " + str1);
        }
    }
}
