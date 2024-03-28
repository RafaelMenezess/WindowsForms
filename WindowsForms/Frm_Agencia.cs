using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_Agencia : Form
    {
        public Frm_Agencia()
        {
            InitializeComponent();
            this.Text = "Cadastro de Agência";
            Tls_Principal.Items[0].ToolTipText = "Fechar a caixa de diálogo";
        }

        private void ApagaToolStripButton1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
