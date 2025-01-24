namespace App_Academia
{
    partial class F_SelecionarTurma
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_selecionarTurma = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_selecionarTurma)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_selecionarTurma
            // 
            this.dgv_selecionarTurma.AllowUserToAddRows = false;
            this.dgv_selecionarTurma.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_selecionarTurma.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_selecionarTurma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_selecionarTurma.EnableHeadersVisualStyles = false;
            this.dgv_selecionarTurma.Location = new System.Drawing.Point(3, 12);
            this.dgv_selecionarTurma.MultiSelect = false;
            this.dgv_selecionarTurma.Name = "dgv_selecionarTurma";
            this.dgv_selecionarTurma.ReadOnly = true;
            this.dgv_selecionarTurma.RowHeadersVisible = false;
            this.dgv_selecionarTurma.RowHeadersWidth = 51;
            this.dgv_selecionarTurma.RowTemplate.Height = 24;
            this.dgv_selecionarTurma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_selecionarTurma.Size = new System.Drawing.Size(879, 402);
            this.dgv_selecionarTurma.TabIndex = 51;
            this.dgv_selecionarTurma.DoubleClick += new System.EventHandler(this.dgv_selecionarTurma_DoubleClick);
            // 
            // F_SelecionarTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 425);
            this.Controls.Add(this.dgv_selecionarTurma);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_SelecionarTurma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar Turma";
            this.Load += new System.EventHandler(this.F_SelecionarTurma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_selecionarTurma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_selecionarTurma;
    }
}