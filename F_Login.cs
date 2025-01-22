using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_Academia.Properties;
using App_Academia;


namespace App_Academia
{
    public partial class F_Login : Form
    {
        Form1 form1;
        DataTable dt = new DataTable();

        public F_Login(Form1 f) //usando parametro, para poder o usar o form1 dentro da classe de F_Login
        {
            InitializeComponent();
            form1 = f;
        }

        private void btn_logar_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text;
            string senha = tb_senha.Text;

            if(username == "" || senha == "")
            {
                MessageBox.Show("Usuario e/ou senha Invalidos");
                tb_username.Focus();
                return;
            }

            string sql = "SELECT * FROM tb_usuarios WHERE T_USERNAME ='"+username+"'AND T_SENHAUSUARIO ='" +senha+"';";
            dt = Banco.Consulta(sql); //faz retornar uma tabela com o comando do sql acima

            if(dt.Rows.Count == 1) //confere se retorna alguma linha pra ver se tem o username e senha na db
            {
                form1.lb_acesso.Text = dt.Rows[0].ItemArray[5].ToString(); //retorna o acesso, itemarray = coluna
                form1.lb_nomeUsuario.Text = dt.Rows[0].Field<string>("T_USERNAME"); //retorna usernamepelo nome da coluna, colocando o tipo
                form1.pb_led_logado.Image = App_Academia.Resource1.led_verde_png;

                Globais.nivel = int.Parse(dt.Rows[0].Field<Int64>("N_NIVELUSUARIO").ToString());
                Globais.logado = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario e/ou senha não encontrado");
                tb_username.Clear();
                tb_senha.Clear();
                tb_username.Focus();
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
