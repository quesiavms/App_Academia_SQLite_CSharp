namespace App_Academia
{
    partial class F_NovoAluno
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
            this.mtb_telefone = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_nome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_turma = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_plano = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_salvar = new System.Windows.Forms.Button();
            this.btn_novo = new System.Windows.Forms.Button();
            this.btn_selTurma = new System.Windows.Forms.Button();
            this.btn_selPlano = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtb_telefone
            // 
            this.mtb_telefone.Enabled = false;
            this.mtb_telefone.Location = new System.Drawing.Point(410, 36);
            this.mtb_telefone.Mask = "(99) 0000-0000";
            this.mtb_telefone.Name = "mtb_telefone";
            this.mtb_telefone.Size = new System.Drawing.Size(107, 22);
            this.mtb_telefone.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 52;
            this.label2.Text = "Telefone";
            // 
            // tb_nome
            // 
            this.tb_nome.Enabled = false;
            this.tb_nome.Location = new System.Drawing.Point(15, 36);
            this.tb_nome.Name = "tb_nome";
            this.tb_nome.Size = new System.Drawing.Size(378, 22);
            this.tb_nome.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Nome";
            // 
            // cb_status
            // 
            this.cb_status.Enabled = false;
            this.cb_status.FormattingEnabled = true;
            this.cb_status.Location = new System.Drawing.Point(15, 99);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(180, 24);
            this.cb_status.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "Status";
            // 
            // tb_turma
            // 
            this.tb_turma.Location = new System.Drawing.Point(213, 99);
            this.tb_turma.Name = "tb_turma";
            this.tb_turma.ReadOnly = true;
            this.tb_turma.Size = new System.Drawing.Size(304, 22);
            this.tb_turma.TabIndex = 63;
            this.tb_turma.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(210, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 16);
            this.label12.TabIndex = 62;
            this.label12.Text = "Turma";
            // 
            // tb_plano
            // 
            this.tb_plano.Location = new System.Drawing.Point(15, 164);
            this.tb_plano.Name = "tb_plano";
            this.tb_plano.ReadOnly = true;
            this.tb_plano.Size = new System.Drawing.Size(241, 22);
            this.tb_plano.TabIndex = 65;
            this.tb_plano.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 64;
            this.label4.Text = "Plano";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_fechar);
            this.panel1.Controls.Add(this.btn_cancelar);
            this.panel1.Controls.Add(this.btn_salvar);
            this.panel1.Controls.Add(this.btn_novo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 227);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 33);
            this.panel1.TabIndex = 66;
            // 
            // btn_fechar
            // 
            this.btn_fechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_fechar.Location = new System.Drawing.Point(411, 3);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(106, 23);
            this.btn_fechar.TabIndex = 9;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancelar.Enabled = false;
            this.btn_cancelar.Location = new System.Drawing.Point(286, 3);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(119, 23);
            this.btn_cancelar.TabIndex = 7;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_salvar
            // 
            this.btn_salvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salvar.Enabled = false;
            this.btn_salvar.Location = new System.Drawing.Point(149, 3);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(131, 23);
            this.btn_salvar.TabIndex = 6;
            this.btn_salvar.Text = "Gravar";
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            // 
            // btn_novo
            // 
            this.btn_novo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_novo.Location = new System.Drawing.Point(3, 3);
            this.btn_novo.Name = "btn_novo";
            this.btn_novo.Size = new System.Drawing.Size(140, 23);
            this.btn_novo.TabIndex = 5;
            this.btn_novo.Text = "Novo";
            this.btn_novo.UseVisualStyleBackColor = true;
            this.btn_novo.Click += new System.EventHandler(this.btn_novo_Click);
            // 
            // btn_selTurma
            // 
            this.btn_selTurma.Location = new System.Drawing.Point(482, 100);
            this.btn_selTurma.Name = "btn_selTurma";
            this.btn_selTurma.Size = new System.Drawing.Size(35, 23);
            this.btn_selTurma.TabIndex = 67;
            this.btn_selTurma.Text = "...";
            this.btn_selTurma.UseVisualStyleBackColor = true;
            this.btn_selTurma.Click += new System.EventHandler(this.btn_selTurma_Click);
            // 
            // btn_selPlano
            // 
            this.btn_selPlano.Location = new System.Drawing.Point(221, 164);
            this.btn_selPlano.Name = "btn_selPlano";
            this.btn_selPlano.Size = new System.Drawing.Size(35, 23);
            this.btn_selPlano.TabIndex = 68;
            this.btn_selPlano.Text = "...";
            this.btn_selPlano.UseVisualStyleBackColor = true;
            // 
            // F_NovoAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 260);
            this.Controls.Add(this.btn_selPlano);
            this.Controls.Add(this.btn_selTurma);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tb_plano);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_turma);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cb_status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mtb_telefone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_nome);
            this.Controls.Add(this.label1);
            this.Name = "F_NovoAluno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_NovoAluno";
            this.Load += new System.EventHandler(this.F_NovoAluno_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtb_telefone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_nome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_plano;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.Button btn_novo;
        private System.Windows.Forms.Button btn_selTurma;
        private System.Windows.Forms.Button btn_selPlano;
        public System.Windows.Forms.TextBox tb_turma;
    }
}