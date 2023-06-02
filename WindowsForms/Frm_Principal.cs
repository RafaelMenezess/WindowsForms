using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void Btn_DemostracaKey_Click(object sender, EventArgs e)
        {
            Frm_DesmonstracaoKey f = new Frm_DesmonstracaoKey();
            f.ShowDialog();
        }

        private void Btn_HelloWorld_Click(object sender, EventArgs e)
        {
            Frm_HelloWorld f = new Frm_HelloWorld();
            f.ShowDialog();
        }

        private void Btn_Mascara_Click(object sender, EventArgs e)
        {
            Frm_Mascara f = new Frm_Mascara();
            f.ShowDialog();
        }

        private void Btn_ValidaCPF_Click(object sender, EventArgs e)
        {
            Frm_ValidaCPF f = new Frm_ValidaCPF();
            f.ShowDialog();
        }

        private void Btn_ValidaCPF2_Click(object sender, EventArgs e)
        {
            Frm_ValidaCPF2 f = new Frm_ValidaCPF2();
            f.ShowDialog();
        }

        private void Btn_ValidaSenha_Click(object sender, EventArgs e)
        {
            Frm_ValidaSenha f = new Frm_ValidaSenha();
            f.ShowDialog();
        }
    }
}
