using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_Login : Form
    {
        public string senha;
        public string login;
        public Frm_Login()
        {
            InitializeComponent();

            Lbl_Login.Text = "Usuário";
            Lbl_Password.Text = "Senha";
            Btn_Ok.Text = "OK";
            Btn_Cancel.Text = "Cancel";
        }

        private void Btn_Ok_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;

            senha = Txt_Password.Text;
            login = Txt_Login.Text;

            this.Close();
        }

        private void Btn_Cancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
