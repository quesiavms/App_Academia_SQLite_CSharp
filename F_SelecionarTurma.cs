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
    public partial class F_SelecionarTurma : Form
    {
        F_NovoAluno formNovoAluno;
        public F_SelecionarTurma(F_NovoAluno f)
        {
            InitializeComponent();
            formNovoAluno = f;
        }

        private void F_SelecionarTurma_Load(object sender, EventArgs e)
        {
            string queryTurmas = string.Format(@"SELECT tbt.N_IDTURMA AS 'ID', tbt.T_DSTURMA AS 'Turma', tbh.T_DSHORARIO AS 'Horario', tbp.T_NOMEPROFESSOR AS 'Professor',tbt.N_MAXALUNOS as 'Max Alunos',
                                                 COUNT(tba.N_IDALUNO) AS 'Qtde Alunos'
                                                 FROM tb_turmas AS tbt
                                                 INNER JOIN tb_professores AS tbp ON tbp.N_IDPROFESSOR = tbt.N_IDPROFESSOR
                                                 INNER JOIN tb_horarios AS tbh ON tbt.N_IDHORARIO = tbh.N_IDHORARIO
                                                 LEFT JOIN tb_alunos AS tba ON tba.N_IDTURMA = tbt.N_IDTURMA AND tba.T_STATUS = 'A'
                                                 GROUP BY tbt.N_IDTURMA, tbt.T_DSTURMA, tbh.T_DSHORARIO, tbp.T_NOMEPROFESSOR;");
            dgv_selecionarTurma.DataSource = Banco.dql(queryTurmas);
        }

        private void dgv_selecionarTurma_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int maxAlunos = 0;
            int qtdeAlunos = 0;
            maxAlunos =Int32.Parse(dgv.SelectedRows[0].Cells[4].Value.ToString());
            qtdeAlunos = Int32.Parse(dgv.SelectedRows[0].Cells[5].Value.ToString());

            if(qtdeAlunos >= maxAlunos)
            {
                MessageBox.Show("Não Há Vagas nesta turma");
            }
            else
            {
                formNovoAluno.tb_turma.Text = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString(); //pega descrição da turma
                formNovoAluno.tb_turma.Tag = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString(); //pega o ID da turma pra colocar na tag, e usarmos a tag na query de novo aluno
            }

        }
    }
}
