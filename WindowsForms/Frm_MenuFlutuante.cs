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
                contextMenu.Items.Add(DesenhaItemMenu("Item do menu 1"));
                contextMenu.Items.Add(DesenhaItemMenu("Item do menu 2"));
                contextMenu.Show(this, new Point(e.X, e.Y));
            }
        }
        private ToolStripMenuItem DesenhaItemMenu(string text)
        {
            var vToolti = new ToolStripMenuItem();
            vToolti.Text = text;

            return vToolti;
        }
    }
}
