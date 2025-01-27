using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Entity.Core.Objects;
using System.Runtime.InteropServices.WindowsRuntime;

namespace App_Academia
{
    public partial class F_NovoAluno : Form
    {
        string origemCompleto = "";
        string foto = "";
        string pastaDestino = Globais.caminhoFoto;
        string destinoCompleto = "";
        public F_NovoAluno()
        {
            InitializeComponent();
        }

        private void F_NovoAluno_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add("A", "Ativo"); //key, value
            status.Add("B", "Bloqueado"); //chave, valor
            status.Add("C", "Cancelado");
            cb_status.DataSource = new BindingSource(status, null);
            cb_status.DisplayMember = "Value"; //mostra pro usuario
            cb_status.ValueMember = "Key"; // fica pro programa
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_nome.Enabled = true;
            mtb_telefone.Enabled = true;
            cb_status.Enabled = true;
            tb_nome.Clear();
            mtb_telefone.Clear();
            cb_status.SelectedIndex = 0;
            tb_nome.Focus();
            btn_salvar.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_novo.Enabled = false;
            tb_turma.Clear();
            pb_foto.Image = null;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tb_nome.Enabled = false;
            mtb_telefone.Enabled = false;
            cb_status.Enabled = false;
            tb_nome.Clear();
            mtb_telefone.Clear();
            cb_status.SelectedIndex = 0;
            tb_nome.Focus();
            btn_salvar.Enabled = false;
            btn_cancelar.Enabled = false;
            btn_novo.Enabled = true;
            tb_turma.Clear();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if(destinoCompleto == "")
            {
                if(MessageBox.Show("Nenhuma foto selecionada, deseja continuar?", "ERROR", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    return;
                }
            }

            if(destinoCompleto != "")
            {
                System.IO.File.Copy(origemCompleto, destinoCompleto, true);
                if (File.Exists(destinoCompleto))
                {
                    pb_foto.ImageLocation = destinoCompleto;
                }
                else
                {
                    if(MessageBox.Show("Erro ao localizar arquivo, deseja continuar?", "ERROR", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        return;
                    }
                }
            }

            //usamos tag em turma pq nao queremos o nome da turma querendo o ID da turma
            string queryInsertAluno = string.Format(@"INSERT INTO tb_alunos (T_NOMEALUNO, T_TELFEONE, T_STATUS, N_IDTURMA, T_FOTO)
                                                      VALUES ('{0}', '{1}', '{2}',{3}, '{4}')", tb_nome.Text, mtb_telefone.Text, cb_status.SelectedValue, tb_turma.Tag.ToString(), destinoCompleto);

            Banco.dml(queryInsertAluno);
            MessageBox.Show("Novo Aluno Inserido");

            tb_nome.Enabled = false;
            mtb_telefone.Enabled = false;
            cb_status.Enabled = false;
            tb_nome.Clear();
            mtb_telefone.Clear();
            cb_status.SelectedIndex = 0;
            tb_nome.Focus();
            btn_salvar.Enabled = false;
            btn_cancelar.Enabled = false;
            btn_novo.Enabled = true;
            tb_turma.Clear();
            pb_foto.ImageLocation = destinoCompleto;
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_selTurma_Click(object sender, EventArgs e)
        {
            F_SelecionarTurma f_SelecionarTurma = new F_SelecionarTurma(this);
            f_SelecionarTurma.ShowDialog();
        }

        private void btn_addFoto_Click(object sender, EventArgs e)
        {
            origemCompleto = "";
            foto = "";
            pastaDestino = Globais.caminhoFoto;
            destinoCompleto = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                origemCompleto = openFileDialog1.FileName; //pegando nome do arquivo e caminho
                foto = openFileDialog1.SafeFileName; //pegando só o nome do arquivo

                destinoCompleto = pastaDestino + foto;
            }

            if (File.Exists(destinoCompleto))
            {
                if (MessageBox.Show("Arquivo ja existente, deseja substituir?", "Substituir", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            pb_foto.ImageLocation = origemCompleto;
        }
    }
}
