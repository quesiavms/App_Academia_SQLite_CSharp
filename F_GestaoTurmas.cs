﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
            string vqueryDGV = @"SELECT tbt.N_IDTURMA as 'ID', tbt.T_DSTURMA as 'Desc. Turmas', tbt.N_MAXALUNOS as 'Max. ALunos',tbh.T_DSHORARIO as 'Horario', tbp.T_NOMEPROFESSOR as 'Professor',
                                 CASE WHEN tbt.T_STATUS = 'A' THEN 'Ativa'
                                      WHEN tbt.T_STATUS = 'P' THEN 'Paralisada'
                                      WHEN tbt.T_STATUS = 'C' THEN 'Cancelada'
                                 END as 'Status' from tb_turmas as tbt
                                 INNER JOIN tb_horarios as tbh on tbh.N_IDHORARIO = tbt.N_IDHORARIO, tb_professores as tbp on tbp.N_IDPROFESSOR = tbt.N_IDPROFESSOR
                                 ORDER BY tbt.N_IDHORARIO DESC;";
            dgv_turmas.DataSource = Banco.dql(vqueryDGV);
            dgv_turmas.Columns[0].Width = 40; //coluna id
            dgv_turmas.Columns[1].Width = 120;//coluna desc turmas
            dgv_turmas.Columns[2].Width = 85; //coluna max alunos
            dgv_turmas.Columns[3].Width = 85; //coluna horario
            dgv_turmas.Columns[4].Width = 85; //coluna professor
            dgv_turmas.Columns[5].Width = 85; //coluna status

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
                string vqueryCampos = @"SELECT N_IDTURMA, T_DSTURMA, N_IDPROFESSOR, N_IDHORARIO, N_MAXALUNOS, T_STATUS
                                        FROM tb_turmas
                                        WHERE N_IDTURMA = " + idSelecionado+";";
                DataTable dt = Banco.dql(vqueryCampos);
                tb_idTurma.Text = dt.Rows[0].Field<Int64>("N_IDTURMA").ToString();
                tb_dscTurma.Text= dt.Rows[0].Field<string>("T_DSTURMA");
                cb_professor.SelectedValue = dt.Rows[0].Field<Int64>("N_IDPROFESSOR").ToString(); //seleciona por id, pois nosso value era id
                n_maxAlunos.Value = dt.Rows[0].Field<Int64>("N_MAXALUNOS");
                cb_status.SelectedValue= dt.Rows[0].Field<string>("T_STATUS");
                cb_horario.SelectedValue = dt.Rows[0].Field<Int64>("N_IDHORARIO");
                tb_vagas.Text = CalculoVagas();
            }
        }

        private string CalculoVagas()
        {//Calculo de Vagas
            string queryVagas = string.Format(@"SELECT COUNT(N_IDALUNO) AS 'contVagas'
                                                FROM tb_alunos
                                                WHERE T_STATUS = 'A' AND N_IDTURMA = {0}", idSelecionado);
            DataTable dt = Banco.dql(queryVagas);
            int vagas = Int32.Parse(Math.Round(n_maxAlunos.Value, 0).ToString()); //colocando qntd max de alunos
            vagas -= Int32.Parse(dt.Rows[0].Field<Int64>("contVagas").ToString()); //subtraindo dos alunos ativos
            tb_vagas.Text = vagas.ToString();
            return vagas.ToString();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_idTurma.Clear();
            tb_dscTurma.Clear();
            cb_professor.SelectedIndex = -1;
            n_maxAlunos.Value = 0;
            cb_status.SelectedIndex = -1;
            cb_horario.SelectedIndex = -1;
            tb_dscTurma.Focus();
         }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string queryTurma = "";
            if (tb_idTurma.Text == "")
            {
                queryTurma = String.Format(@"INSERT INTO tb_turmas (T_DSTURMA, N_IDPROFESSOR, N_IDHORARIO, N_MAXALUNOS,T_STATUS)
                                                 VALUES ('{0}',{1},{2},{3},'{4}');", tb_dscTurma.Text, cb_professor.SelectedValue, cb_horario.SelectedValue, Int32.Parse(n_maxAlunos.Value.ToString()), cb_status.SelectedValue);


            }
            else
            {
                queryTurma = String.Format(@"UPDATE tb_turmas
                                                 SET T_DSTURMA = '{0}', N_IDPROFESSOR = {1},N_IDHORARIO = {2},N_MAXALUNOS = {3},T_STATUS = '{4}'
                                                 WHERE N_IDTURMA = {5};", tb_dscTurma.Text, cb_professor.SelectedValue, cb_horario.SelectedValue, Int32.Parse(Math.Round(n_maxAlunos.Value, 0).ToString()), cb_status.SelectedValue, idSelecionado);

            }
            int linha = dgv_turmas.SelectedRows[0].Index; //linha armazena o nmr da linha selecionada
            Banco.dml(queryTurma);
            MessageBox.Show("Dados Atualizados!!");
            string vqueryDataGridView = @"SELECT tbt.N_IDTURMA as 'ID', tbt.T_DSTURMA as 'Desc. Turmas', tbt.N_MAXALUNOS as 'Max. ALunos',tbh.T_DSHORARIO as 'Horario', tbp.T_NOMEPROFESSOR as 'Professor',
                                          CASE WHEN tbt.T_STATUS = 'A' THEN 'Ativa'
                                               WHEN tbt.T_STATUS = 'P' THEN 'Paralisada'
                                               WHEN tbt.T_STATUS = 'C' THEN 'Cancelada'
                                          END as 'Status' from tb_turmas as tbt
                                          INNER JOIN tb_horarios as tbh on tbh.N_IDHORARIO = tbt.N_IDHORARIO, tb_professores as tbp on tbp.N_IDPROFESSOR = tbt.N_IDPROFESSOR
                                          ORDER BY tbt.N_IDHORARIO DESC;";
            dgv_turmas.DataSource = Banco.dql(vqueryDataGridView);
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja exlcuir??", "Excluir", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                string queryDeletarTurma = String.Format(@"DELETE 
                                                           FROM tb_turmas
                                                           WHERE  N_IDTURMA = {0};", idSelecionado);
                Banco.dml(queryDeletarTurma);
                dgv_turmas.Rows.Remove(dgv_turmas.CurrentRow);
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void n_maxAlunos_ValueChanged(object sender, EventArgs e)
        {
            tb_vagas.Text = CalculoVagas();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            string nomeArquivo = Globais.caminho + @"\turmas.pdf";
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create); //caso ja tenha arquivo com esse nome, ele sobreescreve o conteudo
            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Globais.caminho + @"\logoAcademia.png");
            logo.ScaleToFit(140f, 110f);
            //logo.Alignment = Element.ALIGN_LEFT;
            logo.SetAbsolutePosition(0f, 742f); //x e y 
 
            string dados = "";

            Paragraph paragrafo1 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 20, (int)System.Drawing.FontStyle.Bold));
            paragrafo1.Alignment = Element.ALIGN_CENTER;
            paragrafo1.Add("Academia Shape Sharp\n");
            paragrafo1.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Italic);
            paragrafo1.Alignment = Element.ALIGN_CENTER;                
            paragrafo1.Add("Turmas\n\n");

            PdfPTable tabela = new PdfPTable(6); //numero de colunas
            tabela.WidthPercentage = 110; // Largura total da página
            tabela.SpacingBefore = 20f; // Espaçamento entre o parágrafo 1 e a tabela
            tabela.DefaultCell.FixedHeight = 30;

            tabela.AddCell("ID");
            tabela.AddCell("Turma");
            tabela.AddCell("Max Alunos");
            tabela.AddCell("Horario");
            tabela.AddCell("Professor");
            tabela.AddCell("Status");

            string vqueryDGV = @"SELECT tbt.N_IDTURMA as 'ID', tbt.T_DSTURMA as 'Desc. Turmas', tbt.N_MAXALUNOS as 'Max. ALunos',tbh.T_DSHORARIO as 'Horario', tbp.T_NOMEPROFESSOR as 'Professor',
                                 CASE WHEN tbt.T_STATUS = 'A' THEN 'Ativa'
                                      WHEN tbt.T_STATUS = 'P' THEN 'Paralisada'
                                      WHEN tbt.T_STATUS = 'C' THEN 'Cancelada'
                                 END as 'Status' from tb_turmas as tbt
                                 INNER JOIN tb_horarios as tbh on tbh.N_IDHORARIO = tbt.N_IDHORARIO, tb_professores as tbp on tbp.N_IDPROFESSOR = tbt.N_IDPROFESSOR
                                 ORDER BY tbt.N_IDHORARIO DESC;";
            
            DataTable dtTurmas = Banco.dql(vqueryDGV);

            for(int i = 0; i < dtTurmas.Rows.Count; i++)
            {
                tabela.AddCell(dtTurmas.Rows[i].Field<Int64>("ID").ToString()); //pesquisando na dtTurmas segundo o nome da coluna da query
                tabela.AddCell(dtTurmas.Rows[i].Field<string>("Desc. Turmas").ToString());
                tabela.AddCell(dtTurmas.Rows[i].Field<Int64>("Max. ALunos").ToString());
                tabela.AddCell(dtTurmas.Rows[i].Field<string>("Horario").ToString());
                tabela.AddCell(dtTurmas.Rows[i].Field<string>("Professor").ToString());
                tabela.AddCell(dtTurmas.Rows[i].Field<string>("Status").ToString());
            }

            Paragraph paragrafo2 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12, (int)System.Drawing.FontStyle.Underline));
            paragrafo2.Alignment = Element.ALIGN_CENTER;
            string texto = "https://github.com/quesiavms";
            paragrafo2.Add(texto);

            doc.Open();
            doc.Add(logo);
            doc.Add(paragrafo1);
            doc.Add(tabela);
            doc.Add(paragrafo2);
            doc.Close();

            DialogResult res = MessageBox.Show("Deseja abrir o relatorio?", "Abrir Relatorio", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Globais.caminho + @"\turmas.pdf");
            }
        }
    }
}
