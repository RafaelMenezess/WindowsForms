using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_DemonstracaoKey_UC : UserControl
    {
        public Frm_DemonstracaoKey_UC()
        {
            InitializeComponent();
        }

        private void Txt_Input_KeyDown(object sender, KeyEventArgs e)
        {
            Txt_Msg.AppendText("\r\n" + "Precionei a tecla: " + e.KeyCode + "\r\n");
            Txt_Msg.AppendText("\t" + "Código da tecla: " + ((int)e.KeyCode) + "\r\n");
            Txt_Msg.AppendText("\t" + "Nome da tecla: " + e.KeyData + "\r\n");
            Lbl_Lower.Text = e.KeyCode.ToString().ToLower();
            Lbl_Upper.Text = e.KeyCode.ToString().ToUpper();
        }

        private void Btn_Reset_Click(object sender, System.EventArgs e)
        {
            Txt_Msg.Text = string.Empty;
            Txt_Input.Text = string.Empty;
            Lbl_Upper.Text = string.Empty;
            Lbl_Lower.Text = string.Empty;
        }
    }
}
