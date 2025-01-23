namespace App_Academia
{
    partial class F_GestaoTurmas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_salvar = new System.Windows.Forms.Button();
            this.btn_novo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_turmas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_professor = new System.Windows.Forms.ComboBox();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.cb_horario = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_dscTurma = new System.Windows.Forms.TextBox();
            this.n_maxAlunos = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turmas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_maxAlunos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_imprimir);
            this.panel1.Controls.Add(this.btn_fechar);
            this.panel1.Controls.Add(this.btn_excluir);
            this.panel1.Controls.Add(this.btn_salvar);
            this.panel1.Controls.Add(this.btn_novo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 33);
            this.panel1.TabIndex = 47;
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_imprimir.Location = new System.Drawing.Point(472, 3);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(150, 23);
            this.btn_imprimir.TabIndex = 8;
            this.btn_imprimir.Text = "Imprimir Turma";
            this.btn_imprimir.UseVisualStyleBackColor = true;
            // 
            // btn_fechar
            // 
            this.btn_fechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_fechar.Location = new System.Drawing.Point(628, 3);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(89, 23);
            this.btn_fechar.TabIndex = 9;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.UseVisualStyleBackColor = true;
            // 
            // btn_excluir
            // 
            this.btn_excluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_excluir.Location = new System.Drawing.Point(316, 3);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(150, 23);
            this.btn_excluir.TabIndex = 7;
            this.btn_excluir.Text = "Excluir Turma";
            this.btn_excluir.UseVisualStyleBackColor = true;
            // 
            // btn_salvar
            // 
            this.btn_salvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salvar.Location = new System.Drawing.Point(136, 3);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(174, 23);
            this.btn_salvar.TabIndex = 6;
            this.btn_salvar.Text = "Salvar Alterações";
            this.btn_salvar.UseVisualStyleBackColor = true;
            // 
            // btn_novo
            // 
            this.btn_novo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_novo.Location = new System.Drawing.Point(3, 3);
            this.btn_novo.Name = "btn_novo";
            this.btn_novo.Size = new System.Drawing.Size(127, 23);
            this.btn_novo.TabIndex = 5;
            this.btn_novo.Text = "Nova Turma";
            this.btn_novo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 48;
            this.label1.Text = "Professor";
            // 
            // dgv_turmas
            // 
            this.dgv_turmas.AllowUserToAddRows = false;
            this.dgv_turmas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_turmas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_turmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_turmas.EnableHeadersVisualStyles = false;
            this.dgv_turmas.Location = new System.Drawing.Point(8, 9);
            this.dgv_turmas.MultiSelect = false;
            this.dgv_turmas.Name = "dgv_turmas";
            this.dgv_turmas.ReadOnly = true;
            this.dgv_turmas.RowHeadersVisible = false;
            this.dgv_turmas.RowHeadersWidth = 51;
            this.dgv_turmas.RowTemplate.Height = 24;
            this.dgv_turmas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_turmas.Size = new System.Drawing.Size(436, 402);
            this.dgv_turmas.TabIndex = 50;
            this.dgv_turmas.SelectionChanged += new System.EventHandler(this.dgv_turmas_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "Máximo Alunos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 53;
            this.label4.Text = "Horário";
            // 
            // cb_professor
            // 
            this.cb_professor.FormattingEnabled = true;
            this.cb_professor.Location = new System.Drawing.Point(450, 85);
            this.cb_professor.Name = "cb_professor";
            this.cb_professor.Size = new System.Drawing.Size(255, 24);
            this.cb_professor.TabIndex = 1;
            // 
            // cb_status
            // 
            this.cb_status.FormattingEnabled = true;
            this.cb_status.Location = new System.Drawing.Point(581, 149);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(124, 24);
            this.cb_status.TabIndex = 3;
            // 
            // cb_horario
            // 
            this.cb_horario.FormattingEnabled = true;
            this.cb_horario.Location = new System.Drawing.Point(450, 209);
            this.cb_horario.Name = "cb_horario";
            this.cb_horario.Size = new System.Drawing.Size(255, 24);
            this.cb_horario.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(447, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 55;
            this.label5.Text = "Nome Turma";
            // 
            // tb_dscTurma
            // 
            this.tb_dscTurma.Location = new System.Drawing.Point(450, 28);
            this.tb_dscTurma.Name = "tb_dscTurma";
            this.tb_dscTurma.Size = new System.Drawing.Size(255, 22);
            this.tb_dscTurma.TabIndex = 56;
            // 
            // n_maxAlunos
            // 
            this.n_maxAlunos.Location = new System.Drawing.Point(450, 151);
            this.n_maxAlunos.Name = "n_maxAlunos";
            this.n_maxAlunos.Size = new System.Drawing.Size(120, 22);
            this.n_maxAlunos.TabIndex = 57;
            // 
            // F_GestaoTurmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 450);
            this.Controls.Add(this.n_maxAlunos);
            this.Controls.Add(this.tb_dscTurma);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_horario);
            this.Controls.Add(this.cb_status);
            this.Controls.Add(this.cb_professor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_turmas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_GestaoTurmas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestao de Turmas";
            this.Load += new System.EventHandler(this.F_GestaoTurmas_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turmas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_maxAlunos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.Button btn_novo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_turmas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_professor;
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.ComboBox cb_horario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_dscTurma;
        private System.Windows.Forms.NumericUpDown n_maxAlunos;
    }
}