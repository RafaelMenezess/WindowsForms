using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_Busca : Form
    {
        public Frm_Busca()
        {
            InitializeComponent();

            this.Text = "Busca";

            Tls_Principal.Items[0].ToolTipText = "Salvar a seleção";
            Tls_Principal.Items[1].ToolTipText = "Fechar a seleção";
        }

        private void ApagaToolStripButton1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
