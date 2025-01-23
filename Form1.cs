using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_Academia;

namespace App_Academia
{
    public partial class Form1 : Form
    {

        private void abreForm(int nivel, Form f)
        {
            if (Globais.logado == true)
            {
                if (Globais.nivel >= nivel)
                {
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Acesso não Permitido");
                }
            }
            else
            {
                MessageBox.Show("Necessario ter usuario logado!!");
            }
        }
        public Form1()
        {
            InitializeComponent();
            F_Login f_Login = new F_Login(this); //passando o form 1 como parametro
            f_Login.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void logOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Login f_login = new F_Login(this);
            f_login.ShowDialog();
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Usuario "+ lb_nomeUsuario.Text + " desconectado");
            lb_acesso.Text = "0";
            lb_nomeUsuario.Text = "---";
            pb_led_logado.Image = App_Academia.Resource1.led_vermelho_png;

            Globais.nivel = 0;
            Globais.logado = false;
        }

        private void bancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //abreForm();
        }

        private void novoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_NovoUsuario f_NovoUsuario = new F_NovoUsuario();
            abreForm(1, f_NovoUsuario);
        }

        private void gestãoDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_GestaoUsuarios f_GestaoUsuarios = new F_GestaoUsuarios();
            abreForm(1, f_GestaoUsuarios);
        }

        private void horariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           F_Horarios f_Horarios = new F_Horarios();
            abreForm(2, f_Horarios);        
        }

        private void horariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            F_Horarios f_Horarios = new F_Horarios();
            abreForm(2, f_Horarios);
        }

        private void professoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_GestaoProfessores f_GestaoProfessores = new F_GestaoProfessores();
            abreForm(2, f_GestaoProfessores);
        }
    }
}
