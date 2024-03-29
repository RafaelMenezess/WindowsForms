using CursoWindownsFormsBiblioteca.Classes;
using CursoWindowsFormsBiblioteca;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_CadastroCliente_UC : UserControl
    {
        public Frm_CadastroCliente_UC()
        {
            InitializeComponent();

            Lbl_Bairro.Text = "Bairro";
            Lbl_CEP.Text = "CEP";
            Lbl_Complemento.Text = "Complemento";
            Lbl_CPF.Text = "CPF";
            Lbl_Estado.Text = "Estado";
            Lbl_Logradouro.Text = "Logradouro";
            Lbl_NomeCliente.Text = "Nome";
            Lbl_NomeMae.Text = "Nome da Mãe";
            Lbl_NomePai.Text = "Nome do Pai";
            Lbl_Profissao.Text = "Profissão";
            Lbl_RendaFamiliar.Text = "Renda Familiar";
            Lbl_Telefone.Text = "Telefone";
            Lbl_Cidade.Text = "Cidade";
            Grp_Codigo.Text = "Código";
            Grp_DadosPessoais.Text = "Dados Pessoais";
            Grp_Endereco.Text = "Endereço";
            Grp_Outros.Text = "Outros";
            Grp_Genero.Text = "Genero";
            Chk_TemPai.Text = "Pai desconhecido";
            Rdb_Masculino.Text = "Masculino";
            Rdb_Feminino.Text = "Feminino";
            Rdb_Indefinido.Text = "Indefinido";

            Btn_Busca.Text = "Buscar";

            Cmb_Estados.Items.Clear();
            Cmb_Estados.Items.Add("Acre (AC)");
            Cmb_Estados.Items.Add("Alagoas(AL)");
            Cmb_Estados.Items.Add("Amapá(AP)");
            Cmb_Estados.Items.Add("Amazonas(AM)");
            Cmb_Estados.Items.Add("Bahia(BA)");
            Cmb_Estados.Items.Add("Ceará(CE)");
            Cmb_Estados.Items.Add("Distrito Federal(DF)");
            Cmb_Estados.Items.Add("Espírito Santo(ES)");
            Cmb_Estados.Items.Add("Goiás(GO)");
            Cmb_Estados.Items.Add("Maranhão(MA)");
            Cmb_Estados.Items.Add("Mato Grosso(MT)");
            Cmb_Estados.Items.Add("Mato Grosso do Sul(MS)");
            Cmb_Estados.Items.Add("Minas Gerais(MG)");
            Cmb_Estados.Items.Add("Pará(PA)");
            Cmb_Estados.Items.Add("Paraíba(PB)");
            Cmb_Estados.Items.Add("Paraná(PR)");
            Cmb_Estados.Items.Add("Pernambuco(PE)");
            Cmb_Estados.Items.Add("Piauí(PI)");
            Cmb_Estados.Items.Add("Rio de Janeiro(RJ)");
            Cmb_Estados.Items.Add("Rio Grande do Norte(RN)");
            Cmb_Estados.Items.Add("Rio Grande do Sul(RS)");
            Cmb_Estados.Items.Add("Rondônia(RO)");
            Cmb_Estados.Items.Add("Roraima(RR)");
            Cmb_Estados.Items.Add("Santa Catarina(SC)");
            Cmb_Estados.Items.Add("São Paulo(SP)");
            Cmb_Estados.Items.Add("Sergipe(SE)");
            Cmb_Estados.Items.Add("Tocantins(TO)");

            Tls_Principal.Items[0].ToolTipText = "Incluir na base de dados um novo cliente";
            Tls_Principal.Items[1].ToolTipText = "Capturar um cliente já cadastrado na base";
            Tls_Principal.Items[2].ToolTipText = "Atualize o cliente já existente";
            Tls_Principal.Items[3].ToolTipText = "Apaga o cliente selecionado";
            Tls_Principal.Items[4].ToolTipText = "Limpa dados da tela da entrada de dados";

            Btn_Busca.Text = "Buscar";
            Grp_DataGrid.Text = "Clientes";

            AtualizaGrid();

            LimparFormulario();
        }

        private void LimparFormulario()
        {
            Txt_Bairro.Text = string.Empty;
            Txt_CEP.Text = string.Empty;
            Txt_Complemento.Text = string.Empty;
            Txt_CPF.Text = string.Empty;
            Cmb_Estados.SelectedIndex = -1;
            Txt_Logradouro.Text = string.Empty;
            Txt_NomeCliente.Text = string.Empty;
            Txt_NomeMae.Text = string.Empty;
            Txt_NomePai.Text = string.Empty;
            Txt_Profissao.Text = string.Empty;
            Txt_RendaFamiliar.Text = string.Empty;
            Txt_Telefone.Text = string.Empty;
            Txt_Cidade.Text = string.Empty;
            Txt_Codigo.Text = string.Empty;
            Chk_TemPai.Checked = false;
            Rdb_Masculino.Checked = false;
            Rdb_Feminino.Checked = false;
            Rdb_Indefinido.Checked = false;
        }

        private void Chk_TemPai_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_TemPai.Checked)
            {
                Txt_NomePai.Enabled = false;
            }
            else
            {
                Txt_NomePai.Enabled = true;
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente.Unit c = new Cliente.Unit();
                c = leituraFormulario();
                c.ValidaClasse();
                c.ValidaComplemento();
                //c.IncluirFicharioSQL("Cliente");
                c.IncluirFicharioSQLRel();
                MessageBox.Show("Ok: Identificador incluido com sucesso", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AtualizaGrid();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (Txt_Codigo.Text == string.Empty)
            {
                MessageBox.Show("Código do cliente vazio", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Cliente.Unit c = new Cliente.Unit();
                    //c = c.BuscarFicharioSQL(Txt_Codigo.Text, "Cliente");
                    c = c.BuscarFicharioSQLRel(Txt_Codigo.Text);
                    if (c == null)
                    {
                        MessageBox.Show("Identificador não encontrado", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        EscreveFormulario(c);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (Txt_Codigo.Text == string.Empty)
            {
                MessageBox.Show("Código do cliente vazio", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Cliente.Unit c = new Cliente.Unit();
                    c = leituraFormulario();
                    c.ValidaClasse();
                    c.ValidaComplemento();
                    //c.AlterarFicharioSQL("Cliente");
                    c.AlterarFicharioSQLRel();
                    MessageBox.Show("Ok: Identificador alterado com sucesso", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AtualizaGrid();
                }
                catch (ValidationException ex)
                {
                    MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ApagaToolStripButton1_Click(object sender, EventArgs e)
        {
            if (Txt_Codigo.Text == string.Empty)
            {
                MessageBox.Show("Código do cliente vazio", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Cliente.Unit c = new Cliente.Unit();
                //c = c.BuscarFicharioSQL(Txt_Codigo.Text, "Cliente");
                c = c.BuscarFicharioSQLRel(Txt_Codigo.Text);

                if (c == null)
                {
                    MessageBox.Show("Identificador não encontrado", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    EscreveFormulario(c);
                    Frm_Questao db = new Frm_Questao("icons8-question-96", "Você quer excluir o cliente?");
                    db.ShowDialog();
                    if (db.DialogResult == DialogResult.Yes)
                    {
                        //c.ApagarFicharioSQL("Cliente");
                        c.ApagarFicharioSqlRel();
                        MessageBox.Show("Ok: Identificador apagado com sucesso", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        AtualizaGrid();
                        LimparFormulario();
                    }
                }
            }
        }

        private void LimparToolStripButton1_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private Cliente.Unit leituraFormulario()
        {
            Cliente.Unit c = new Cliente.Unit();
            c.Id = Txt_Codigo.Text;
            c.Nome = Txt_NomeCliente.Text;
            c.NomeMae = Txt_NomeMae.Text;
            c.NomePai = Txt_NomePai.Text;
            c.NaoTemPai = Chk_TemPai.Checked ? 1 : 0;
            c.Cpf = Txt_CPF.Text;
            if (Rdb_Masculino.Checked)
            {
                c.Genero = 0;
            }
            else if (Rdb_Feminino.Checked)
            {
                c.Genero = 1;
            }
            else if (Rdb_Indefinido.Checked)
            {
                c.Genero = 2;
            }

            c.Cep = Txt_CEP.Text;
            c.Logradouro = Txt_Logradouro.Text;
            c.Complemento = Txt_Complemento.Text;
            c.Cidade = Txt_Cidade.Text;
            c.Bairro = Txt_Bairro.Text;

            if (Cmb_Estados.SelectedIndex < 0)
            {
                c.Estado = string.Empty;
            }
            else
            {
                c.Estado = Cmb_Estados.Items[Cmb_Estados.SelectedIndex].ToString();
            }

            c.Telefone = Txt_Telefone.Text;
            c.Profissao = Txt_Profissao.Text;

            if (Information.IsNumeric(Txt_RendaFamiliar.Text))
            {
                double vRenda = Convert.ToDouble(Txt_RendaFamiliar.Text);
                if (vRenda < 0)
                {
                    c.RendaFamiliar = 0;
                }
                else
                {
                    c.RendaFamiliar = vRenda;
                }
            }

            return c;
        }
        private void EscreveFormulario(Cliente.Unit c)
        {

            Txt_Codigo.Text = c.Id;
            Txt_NomeCliente.Text = c.Nome;
            Txt_NomeMae.Text = c.NomeMae;
            Txt_NomePai.Text = c.NomePai;
            Txt_CPF.Text = c.Cpf;

            if (c.NaoTemPai == 1)
            {
                Chk_TemPai.Checked = true;
                Txt_NomePai.Text = string.Empty;
            }
            else
            {
                Chk_TemPai.Checked = false;
                Txt_NomePai.Text = c.NomePai;
            }

            if (c.Genero == 0)
            {
                Rdb_Masculino.Checked = true;
            }
            else if (c.Genero == 1)
            {
                Rdb_Feminino.Checked = true;
            }
            else if (c.Genero == 2)
            {
                Rdb_Indefinido.Checked = true;
            }

            Txt_CEP.Text = c.Cep;
            Txt_Logradouro.Text = c.Logradouro;
            Txt_Complemento.Text = c.Complemento;
            Txt_Cidade.Text = c.Cidade;
            Txt_Bairro.Text = c.Bairro;
            Txt_Telefone.Text = c.Telefone;
            Txt_Profissao.Text = c.Profissao;
            Txt_RendaFamiliar.Text = c.RendaFamiliar.ToString();

            if (c.Estado == string.Empty)
            {
                Cmb_Estados.SelectedIndex = -1;
            }
            else
            {
                for (int i = 0; i <= Cmb_Estados.Items.Count - 1; i++)
                {
                    if (c.Estado == Cmb_Estados.Items[i].ToString())
                    {
                        Cmb_Estados.SelectedIndex = i;
                    }
                }
            }

        }

        private void Txt_CEP_Leave(object sender, EventArgs e)
        {
            string vCep = Txt_CEP.Text;
            if (vCep != string.Empty && vCep.Length == 8 && Information.IsNumeric(vCep))
            {
                var vJson = Cls_Uteis.GeraJSONCEP(vCep);
                var cep = Cep.DesSerializedClassUnit(vJson);
                Txt_Logradouro.Text = cep.logradouro;
                Txt_Bairro.Text = cep.bairro;
                Txt_Cidade.Text = cep.localidade;

                Cmb_Estados.SelectedIndex = -1;
                for (int i = 0; i <= Cmb_Estados.Items.Count - 1; i++)
                {
                    var vPos = Strings.InStr(Cmb_Estados.Items[i].ToString(), "(" + cep.uf + ")");
                    if (vPos > 0)
                    {
                        Cmb_Estados.SelectedIndex = i;
                    }
                }
            }
        }

        private void Btn_Busca_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente.Unit c = new Cliente.Unit();
                //var list = c.ListaFicharioSQL("Cliente");
                var list = c.BuscarFicharioDBTodosSqlRel();
                Frm_Busca FForm = new Frm_Busca(list);
                FForm.ShowDialog();
                if (FForm.DialogResult == DialogResult.OK)
                {
                    var idSelect = FForm.idSelect;
                    //c = c.BuscarFicharioSQL(idSelect, "Cliente");
                    c = c.BuscarFicharioSQLRel(idSelect);
                    if (c == null)
                    {
                        MessageBox.Show("Identificador não encontrado.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        EscreveFormulario(c);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizaGrid()
        {
            try
            {
                Cliente.Unit c = new Cliente.Unit();
                var list = c.BuscarFicharioDBTodosSqlRel();

                Dg_Clientes.Rows.Clear();

                for (int i = 0; i <= list.Count; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(Dg_Clientes);
                    row.Cells[0].Value = list[i][0].ToString();
                    row.Cells[1].Value = list[i][1].ToString();
                    Dg_Clientes.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dg_Clientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = Dg_Clientes.SelectedRows[0];
                string Id = row.Cells[0].Value.ToString();

                Cliente.Unit c = new Cliente.Unit();
                 c = c.BuscarFicharioSQLRel(Id);

                if (c == null)
                {
                    MessageBox.Show("Identificador não encontrado.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    EscreveFormulario(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}