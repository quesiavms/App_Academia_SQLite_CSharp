using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace App_Academia
{
    internal class Banco
    {
        private static SQLiteConnection conexao;

        private static SQLiteConnection ConexaoBanco()
        {
            conexao = new SQLiteConnection("Data Source = C:\\Users\\quesi\\OneDrive\\.Estagio_TCS\\Estagio_Courses\\App_SQLite_CSharp\\App_Academia\\db\\db_academia");
            conexao.Open();
            return conexao;
        }

        public static DataTable ObterTodosUsuarios()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_usuarios";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon); //comando sql e a conexao do banco
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable Consulta(string sql)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon); //comando sql e a conexao do banco
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //funcoes do FORM F_NovoUsuario
        public static void NovoUsuario(Usuario u)
        {
            if (existeUserName(u) == true)
            {
                MessageBox.Show("Username Ja Existe");
                return;
            }
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO tb_usuarios (T_NOMEUSUARI0, T_USERNAME, T_SENHAUSUARIO, T_STATUSUSUARIO, N_NIVELUSUARIO) VALUES(@nome, @username, @senha,@status, @nivel)";
                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@senha", u.senha);
                cmd.Parameters.AddWithValue("@status", u.status);
                cmd.Parameters.AddWithValue("@nivel", u.nivel);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Novo Usuario Inserido com Sucesso");
                vcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Salvar Novo Usuario");
            }
        }

        //rotinas gerais
        public static bool existeUserName(Usuario u)
        {
            bool res;
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            var vcon = ConexaoBanco();
            var cmd = vcon.CreateCommand();
            cmd.CommandText = "SELECT T_USERNAME FROM tb_usuarios WHERE T_USERNAME ='" + u.username + "';";
            da = new SQLiteDataAdapter(cmd.CommandText, vcon);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            vcon.Close();
            return res;
        }


        //forms gestao de usuario
        public static DataTable ObterUsuarioIdNome()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT N_IDUSUARIO as 'ID', T_NOMEUSUARI0 as 'Nome' FROM tb_usuarios";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon); //comando sql e a conexao do banco
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ObterDadosUsuario(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_usuarios WHERE N_IDUSUARIO = " + id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon); //comando sql e a conexao do banco
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AtualizarUsuario(Usuario u)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE tb_usuarios SET T_NOMEUSUARI0 = '"+u.nome+"',T_USERNAME = '"+u.username+"', T_SENHAUSUARIO = '"+u.senha+"',T_STATUSUSUARIO = '"+u.status+"',N_NIVELUSUARIO="+u.nivel+" WHERE N_IDUSUARIO = "+u.id+";";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon); //comando sql e a conexao do banco
                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario Atualizado com Sucesso");
                vcon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void ExcluirUsuario(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "DELETE FROM tb_usuarios WHERE N_IDUSUARIO ="+id+ ";";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon); //comando sql e a conexao do banco
                cmd.ExecuteNonQuery();
                vcon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
