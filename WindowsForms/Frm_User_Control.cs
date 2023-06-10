using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_User_Control : UserControl
    {
        public Frm_User_Control()
        {
            InitializeComponent();
        }

        private void Btn_ModificaLabel_Click(object sender, EventArgs e)
        {
            lbl_Titulo.Text = Txt_ConteudoLabel.Text;
        }
    }
}
