using System;
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
    public partial class F_GestaoTurmas : Form
    {
        string idSelecionado;
        public F_GestaoTurmas()
        {
            InitializeComponent();
        }

        private void F_GestaoTurmas_Load(object sender, EventArgs e)
        {
            string vqueryDGV = @"SELECT tbt.N_IDTURMA as 'ID', tbt.T_DSTURMA as 'Desc. Turmas', tbh.T_DSHORARIO as 'Horario'
                                 FROM tb_turmas as tbt
                                 INNER JOIN tb_horarios as tbh on tbh.N_IDHORARIO = tbt.N_IDHORARIO;";
            dgv_turmas.DataSource = Banco.dql(vqueryDGV);
            dgv_turmas.Columns[0].Width = 40;
            dgv_turmas.Columns[1].Width = 120;
            dgv_turmas.Columns[2].Width = 85;

            //Popular ComboBox Professores
            string vqueryProfessores = @"SELECT N_IDPROFESSOR, T_NOMEPROFESSOR
                                         FROM tb_professores
                                         ORDER BY N_IDPROFESSOR;";
            cb_professor.Items.Clear();
            cb_professor.DataSource = Banco.dql(vqueryProfessores);
            cb_professor.DisplayMember = "T_NOMEPROFESSOR"; //mostra pro usuario
            cb_professor.ValueMember = "N_IDPROFESSOR"; // mostra pro programa

            //Popular ComboBox Status (A = Ativa, P = Paralisada, C = Cancelada)
            Dictionary<string, string> st = new Dictionary<string, string>(); //dicionario de chave e valor
            st.Add("A","Ativa");
            st.Add("P", "Paralisada");
            st.Add("C", "Cancelada");
            cb_status.Items.Clear();
            cb_status.DataSource = new BindingSource(st, null); 
            cb_status.DisplayMember = "Value"; // mostra pro usuario
            cb_status.ValueMember = "Key"; //mostra pro programa

            //Propular ComboBox Horarios
            string vqueryHOrarios = @"SELECT *
                                      FROM tb_horarios
                                      ORDER BY T_DSHORARIO;";
            cb_horario.Items.Clear();
            cb_horario.DataSource = Banco.dql(vqueryHOrarios);
            cb_horario.DisplayMember = "T_DSHORARIO"; //mostra pro usuario
            cb_horario.ValueMember = "N_IDHORARIO"; // mostra pro programa
        }

        private void dgv_turmas_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contLinhas = dgv.SelectedRows.Count;

            if(contLinhas > 0 )
            {
                idSelecionado = dgv_turmas.Rows[dgv_turmas.SelectedRows[0].Index].Cells[0].Value.ToString();
                string vqueryCampos = @"SELECT T_DSTURMA, N_IDPROFESSOR, N_IDHORARIO, N_MAXALUNOS, T_STATUS
                                        FROM tb_turmas
                                        WHERE N_IDTURMA ="+ idSelecionado+";";
                DataTable dt = Banco.dql(vqueryCampos);
                tb_dscTurma.Text= dt.Rows[0].Field<string>("T_DSTURMA");
                cb_professor.SelectedValue = dt.Rows[0].Field<Int64>("N_IDPROFESSOR").ToString(); //seleciona por id, pois nosso value era id
                n_maxAlunos.Value = dt.Rows[0].Field<Int64>("N_MAXALUNOS");
                cb_status.SelectedValue= dt.Rows[0].Field<string>("T_STATUS");
                cb_horario.SelectedValue = dt.Rows[0].Field<Int64>("N_IDHORARIO");
            }
        }
    }
}
