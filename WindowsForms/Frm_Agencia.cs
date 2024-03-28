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

        private void tB_AgenciaBindingNavigatorSaveItem_Click(object sender, System.EventArgs e)
        {
            this.Validate();
            this.tB_AgenciaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.byteBankDataSet);

        }

        private void Frm_Agencia_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'byteBankDataSet.TB_Agencia' table. You can move, or remove it, as needed.
            this.tB_AgenciaTableAdapter.Fill(this.byteBankDataSet.TB_Agencia);

        }
    }
}
