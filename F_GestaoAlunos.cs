using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace App_Academia
{
    public partial class F_GestaoAlunos : Form
    {
        string vqueryDGV = "";
        string turmaAtual = "";
        string idSelecionado = "";
        string turma = "";
        int linha = 0;
        public F_GestaoAlunos()
        {
            InitializeComponent();
        }

        private void F_GestaoAlunos_Load(object sender, EventArgs e)
        {
            string queryDGV = @"SELECT N_IDALUNO as 'ID', T_NOMEALUNO as 'Nome'
                                FROM tb_alunos";
            dgv_gestaoAlunos.DataSource = Banco.dql(queryDGV);
            dgv_gestaoAlunos.Columns[0].Width = 40; //coluna do ID
            dgv_gestaoAlunos.Columns[1].Width = 120; // coluna do Nome do Aluno

            tb_nome.Text = dgv_gestaoAlunos.Rows[dgv_gestaoAlunos.SelectedRows[0].Index].Cells[1].Value.ToString();

            //popular combo box turmas
            string queryTurmas = @"SELECT tbt.N_IDTURMA, ('Vagas: ' || (tbt.N_MAXALUNOS - IFNULL(COUNT(tba.N_IDALUNO), 0)) || ' / Turma: ' || tbt.T_DSTURMA) AS 'Turma'
                                   FROM tb_turmas AS tbt
                                   LEFT JOIN tb_alunos AS tba ON tbt.N_IDTURMA = tba.N_IDTURMA AND tba.T_STATUS = 'A'
                                   GROUP BY tbt.N_IDTURMA, tbt.N_MAXALUNOS, tbt.T_DSTURMA
                                   ORDER BY tbt.N_IDTURMA;";
            cb_turma.Items.Clear();
            cb_turma.DataSource = Banco.dql(queryTurmas);
            cb_turma.DisplayMember = "Turma";
            cb_turma.ValueMember = "N_IDTURMA";

            //popular combo box de status
            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add("A","Ativo");
            status.Add("B", "Bloqueado");
            status.Add("C", "Cancelado");
            cb_status.DataSource = new BindingSource(status, null);
            cb_status.DisplayMember = "Value";
            cb_status.ValueMember = "Key";

            turma = cb_turma.Text;
            idSelecionado = dgv_gestaoAlunos.Rows[0].Cells[0].Value.ToString();
        }

        private void dgv_gestaoAlunos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            linha = dgv.SelectedRows.Count;

            if(linha > 0)
            {
                idSelecionado = dgv_gestaoAlunos.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                string vqueryCampos = string.Format(@"SELECT N_IDALUNO, T_NOMEALUNO, T_TELFEONE, T_STATUS, N_IDTURMA, T_FOTO
                                                       FROM tb_alunos
                                                       WHERE N_IDALUNO = {0};", idSelecionado);
                DataTable dt = Banco.dql(vqueryCampos);
                tb_nome.Text = dt.Rows[0].Field<string>("T_NOMEALUNO");
                mtb_telefone.Text = dt.Rows[0].Field<string>("T_TELFEONE");
                cb_status.SelectedValue = dt.Rows[0].Field<string>("T_STATUS");
                cb_status.SelectedValue = dt.Rows[0].Field<string>("T_STATUS");
                cb_turma.SelectedValue = dt.Rows[0].Field<Int64>("N_IDTURMA");
                turmaAtual = cb_turma.Text;
                pb_fotoAluno.ImageLocation = dt.Rows[0].Field<string>("T_FOTO");
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            turma = cb_turma.Text;
            if(turmaAtual != turma)
            {
                string[] t = turma.Split(' ');
                int vagas = int.Parse(t[1]);
                if(vagas < 1)
                {
                    MessageBox.Show("Nao ha vagas para essa turma, selecione outra turma");
                    cb_turma.Focus();
                    return;
                }
                linha = dgv_gestaoAlunos.SelectedRows[0].Index;
                string queryAtualizarAluno = string.Format(@"UPDATE tb_alunos SET T_NOMEALUNO = '{0}',T_TELFEONE = '{1}',T_STATUS = '{2}', N_IDTURMA = {3}
                                                             WHERE  N_IDALUNO = {4}", tb_nome.Text, mtb_telefone.Text, cb_status.SelectedValue, cb_turma.SelectedValue, idSelecionado);
                Banco.dml(queryAtualizarAluno);
                dgv_gestaoAlunos[1,linha].Value = tb_nome.Text;
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja excluir?", "Exluir", MessageBoxButtons.YesNo);
            if(res == DialogResult.Yes)
            {

                if (File.Exists(pb_fotoAluno.ImageLocation))
                {
                    File.Delete(pb_fotoAluno.ImageLocation);
                }

                string queryExcluirAluno = string.Format(@"DELETE 
                                                           FROM tb_alunos
                                                           WHERE N_IDALUNO = {0}",idSelecionado);
                Banco.dml(queryExcluirAluno);
                dgv_gestaoAlunos.Rows.Remove(dgv_gestaoAlunos.CurrentRow);
                tb_nome.Clear();
                mtb_telefone.Clear();
                cb_status.SelectedIndex = 0;
                cb_turma.SelectedIndex = 0;
                pb_fotoAluno.ImageLocation = null;
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            string nomeArquivo = Globais.caminhoCarteirinha + @"\carteirinha "+tb_nome.Text+".pdf";
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);

            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Globais.caminho + @"/logoAcademia.png");
            logo.ScaleToFit(140f, 110f);
            //logo.Alignment = Element.ALIGN_LEFT;
            logo.SetAbsolutePosition(0f, 742f); //x e y 

            string dados = "";
            Paragraph paragrafo1 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 20, (int)System.Drawing.FontStyle.Bold));
            paragrafo1.Alignment = Element.ALIGN_RIGHT;
            paragrafo1.Add("Carteirinha de Aluno\n");
            paragrafo1.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Italic);
            paragrafo1.Alignment = Element.ALIGN_RIGHT;
            paragrafo1.Add("Nome: "+tb_nome.Text+"\nTelefone: "+mtb_telefone.Text+"\n\n");

            Paragraph paragrafoFoto = new Paragraph();
            string fotoDoAluno = "";
            string queryDaFoto = string.Format( @"SELECT T_FOTO
                                                  FROM tb_alunos 
                                                  WHERE N_IDALUNO = {0}",idSelecionado);
            DataTable dt = Banco.dql(queryDaFoto);
            fotoDoAluno = dt.Rows[0].Field<string>("T_FOTO");
            
            
            if (!string.IsNullOrEmpty(fotoDoAluno))// verificando se o caminho da foto não está vazio
            {
                iTextSharp.text.Image fotoImagem = iTextSharp.text.Image.GetInstance(fotoDoAluno);// Cria a imagem a partir do caminho da foto

                fotoImagem.ScaleToFit(200f, 200f);
                fotoImagem.SetAbsolutePosition(0f, 700f);

                paragrafoFoto.Add(fotoImagem);// Adiciona a imagem no parágrafo
            }

            doc.Open();
            //doc.Add(logo);
            doc.Add(paragrafoFoto);
            doc.Add(paragrafo1);
            doc.Close();

            if(MessageBox.Show("Deseja abrir a carteirinha?", "Carteirinha", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Globais.caminhoCarteirinha + @"\carteirinha " + tb_nome.Text + ".pdf");
            }

        }
    }
}
