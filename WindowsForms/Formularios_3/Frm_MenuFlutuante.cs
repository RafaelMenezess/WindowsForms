using System;
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
                var vTooltip001 = DesenhaItemMenu("Item do menu 1", "icons8_key_96");
                var vTooltip002 = DesenhaItemMenu("Item do menu 2", "Frm_ValidaSenha");

                contextMenu.Items.Add(vTooltip001);
                contextMenu.Items.Add(vTooltip002);
                contextMenu.Show(this, new Point(e.X, e.Y));

                vTooltip001.Click += new EventHandler(vTooltip001_Click);
                vTooltip002.Click += new EventHandler(vTooltip002_Click);
            }
        }
        private ToolStripMenuItem DesenhaItemMenu(string text, string nomeImagem)
        {
            var vTooltip = new ToolStripMenuItem();
            vTooltip.Text = text;            
            Image myImage = (Image)Properties.Resources.ResourceManager.GetObject(nomeImagem);
            vTooltip.Image = myImage;

            return vTooltip;
        }
        private void vTooltip001_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecionei opção do menu 001");
        }
        private void vTooltip002_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecionei opção do menu 002");
        }
    }
}
