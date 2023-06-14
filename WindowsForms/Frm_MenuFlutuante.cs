using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_MenuFlutuante : Form
    {
        public Frm_MenuFlutuante()
        {
            InitializeComponent();
        }

        private void Frm_MenuFlutuante_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var contextMenu = new ContextMenuStrip();
                contextMenu.Items.Add(DesenhaItemMenu("Item do menu 1", "icons8_key_96"));
                contextMenu.Items.Add(DesenhaItemMenu("Item do menu 2", "Frm_ValidaSenha"));
                contextMenu.Show(this, new Point(e.X, e.Y));
            }
        }
        private ToolStripMenuItem DesenhaItemMenu(string text, string nomeImagem)
        {
            var vToolti = new ToolStripMenuItem();
            vToolti.Text = text;            
            Image myImage = (Image)Properties.Resources.ResourceManager.GetObject(nomeImagem);
            vToolti.Image = myImage;

            return vToolti;
        }
    }
}
