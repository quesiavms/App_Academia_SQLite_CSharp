using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.Sql;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Academia
{
    public partial class F_Horarios : Form
    {
        public F_Horarios()
        {
            InitializeComponent();
        }

        private void F_Horarios_Load(object sender, EventArgs e)
        {
            string vquery = @"SELECT N_IDHORARIO AS 'ID', T_DSHORARIO AS 'Horário'
                              FROM tb_horarios
                              ORDER BY T_DSHORARIO";
            dgv_horarios.DataSource = Banco.dql(vquery);
            dgv_horarios.Columns[0].Width = 100;
            dgv_horarios.Columns[1].Width = 150; 
        }

        private void dgv_horarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contLinhas = dgv.SelectedRows.Count;
            if(contLinhas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString(); // pegando id
                string vquery = @"SELECT * 
                                  FROM tb_horarios
                                  WHERE N_IDHORARIO = " + vid;
                dt = Banco.dql(vquery);
                tb_id.Text = dt.Rows[0].Field<Int64>("N_IDHORARIO").ToString();
                mtb_dscHorario.Text = dt.Rows[0].Field<string>("T_DSHORARIO");
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_id.Clear();
            mtb_dscHorario.Clear();
            mtb_dscHorario.Focus();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string vquery;

            if (tb_id.Text == "") { 

                vquery = @"INSERT INTO tb_horarios (T_DSHORARIO)
                              VALUES ('" + mtb_dscHorario.Text + "');";
            }
            else
            {
                vquery = "UPDATE tb_horarios SET T_DSHORARIO = '" + mtb_dscHorario.Text +"'WHERE N_IDHORARIO = " + tb_id.Text + ";";

            }
            Banco.dml(vquery);
            vquery = @"SELECT N_IDHORARIO AS 'ID', T_DSHORARIO AS 'Horário'
                       FROM tb_horarios
                       ORDER BY T_DSHORARIO";
            dgv_horarios.DataSource = Banco.dql(vquery);
            tb_id.Clear();
            mtb_dscHorario.Clear();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja excluir?", "Excluir", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                string vquery = "DELETE FROM tb_horarios WHERE N_IDHORARIO = " + tb_id.Text+";";
                Banco.dml(vquery,null,"Erro ao Deletar Horario");
                dgv_horarios.Rows.Remove(dgv_horarios.CurrentRow);
                tb_id.Clear();
                mtb_dscHorario.Clear();
            }  

        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
