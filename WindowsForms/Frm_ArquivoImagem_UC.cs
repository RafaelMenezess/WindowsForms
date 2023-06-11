using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_ArquivoImagem_UC : UserControl
    {
        public Frm_ArquivoImagem_UC(string nomeArquivoImagem)
        {
            InitializeComponent();

            Lbl_ArquivoImagem.Text = nomeArquivoImagem;
        }
    }
}
