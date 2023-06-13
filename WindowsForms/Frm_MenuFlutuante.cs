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
                var posicaoX = e.X;
                var posicaoY = e.Y;

                var contextMenu = new ContextMenuStrip();
                var vTooltip001 = new ToolStripMenuItem();
                vTooltip001.Text = "Item do menu 1";
                contextMenu.Items.Add(vTooltip001);
                contextMenu.Show(this, new Point(posicaoX, posicaoY));

            }
        }
    }
}
