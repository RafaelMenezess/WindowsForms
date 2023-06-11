using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_Questao : Form
    {
        public Frm_Questao(string nomeImagem, string mensagem)
        {
            InitializeComponent();

            Image myImage = (Image)global::WindowsForms.Properties.Resources.ResourceManager.GetObject(nomeImagem);
            Pic_Imagem.Image = myImage;
            Lbl_Questao.Text = mensagem;
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
