﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Academia
{
    public partial class F_GestaoUsuarios : Form
    {
        public F_GestaoUsuarios()
        {
            InitializeComponent();
        }

        private void F_GestaoUsuarios_Load(object sender, EventArgs e)
        {
            dgv_usuarios.DataSource = Banco.ObterUsuarioIdNome();
            dgv_usuarios.Columns[0].Width = 80;
            dgv_usuarios.Columns[1].Width = 250;
        }

        private void dgv_usuarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contLinhas = dgv.SelectedRows.Count;

            if (contLinhas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                dt = Banco.ObterDadosUsuario(vid);
                tb_id.Text = dt.Rows[0].Field<Int64>("N_IDUSUARIO").ToString();
                tb_nome.Text = dt.Rows[0].Field<string>("T_NOMEUSUARI0");
                tb_username.Text = dt.Rows[0].Field<string>("T_USERNAME");
                tb_senha.Text = dt.Rows[0].Field<string>("T_SENHAUSUARIO");
                cb_status.Text = dt.Rows[0].Field<string>("T_STATUSUSUARIO");
                n_nivel.Value = dt.Rows[0].Field<Int64>("N_NIVELUSUARIO");

            }
        }

        private void btb_novo_Click(object sender, EventArgs e)
        {
            F_NovoUsuario f_NovoUsuario = new F_NovoUsuario();
            f_NovoUsuario.ShowDialog();
            dgv_usuarios.DataSource = Banco.ObterUsuarioIdNome();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            int linha = dgv_usuarios.SelectedRows[0].Index;

            Usuario u = new Usuario();
            u.id =Convert.ToInt32(tb_id.Text);
            u.nome = tb_nome.Text;
            u.username = tb_username.Text;
            u.senha = tb_senha.Text;
            u.status = cb_status.Text;
            u.nivel = Convert.ToInt32(Math.Round(n_nivel.Value));
           
            Banco.AtualizarUsuario(u);
            //dgv_usuarios.DataSource = Banco.ObterUsuarioIdNome();
            //dgv_usuarios.CurrentCell = dgv_usuarios[0, linha];
            dgv_usuarios[1, linha].Value = tb_nome.Text;

        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja excluir o usuario?","Excluir",MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Banco.ExcluirUsuario(tb_id.Text);
                dgv_usuarios.Rows.Remove(dgv_usuarios.CurrentRow);
            }

        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
