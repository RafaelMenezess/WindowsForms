using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_Busca : Form
    {
        List<List<string>> _listBusca = new List<List<string>>();

        public string idSelect { get; set; }

        public Frm_Busca(List<List<string>> listBusca)
        {
            _listBusca = listBusca;
            InitializeComponent();

            this.Text = "Busca";

            Tls_Principal.Items[0].ToolTipText = "Salvar a seleção";
            Tls_Principal.Items[1].ToolTipText = "Fechar a seleção";

            PreencherLista();

            Lst_busca.Sorted = true;
        }

        private void PreencherLista()
        {
            Lst_busca.Items.Clear();

            for (int i = 0; i <= _listBusca.Count - 1; i++)
            {
                ItemBox x = new ItemBox();
                x.Id = _listBusca[i][0];
                x.Nome = _listBusca[i][1];
                Lst_busca.Items.Add(x);
            }
        }

        private void ApagaToolStripButton1_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ItemBox itemSelecionado = (ItemBox)Lst_busca.Items[Lst_busca.SelectedIndex];
            idSelect = itemSelecionado.Id;
            this.Close();
        }

        public class ItemBox
        {
            public string Id { get; set; }
            public string Nome { get; set; }

            public override string ToString()
            {
                return Nome;
            }
        }
    }
}
