﻿using CursoWindowsFormsBiblioteca;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_ValidaCPF2_UC : UserControl
    {
        public Frm_ValidaCPF2_UC()
        {
            InitializeComponent();
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            Msk_CPF.Text = string.Empty;
        }

        private void Btn_Valida_Click(object sender, EventArgs e)
        {
            string vConteudo = Msk_CPF.Text;
            vConteudo = vConteudo.Replace(".", "").Replace("-", "");
            vConteudo = vConteudo.Trim();

            if (vConteudo == "")
            {
                MessageBox.Show("Você deve digitar um CPF", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (vConteudo.Length != 11)
                {
                    MessageBox.Show("CPF deve conter 11 digitos", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Frm_Questao Db = new Frm_Questao("Frm_ValidaCPF2","Tem certeza em validar CPF?");
                    Db.ShowDialog();                

                    if (Db.DialogResult == DialogResult.Yes)
                    {
                        bool validaCpf = false;
                        validaCpf = Cls_Uteis.Valida(Msk_CPF.Text);

                        if (validaCpf == true)
                        {
                            MessageBox.Show("CPF Válido", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("CPF Inválido", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
