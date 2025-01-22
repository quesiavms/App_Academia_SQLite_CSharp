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
                using(var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM tb_usuarios";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco()); //comando sql e a conexao do banco
                    da.Fill(dt);
                    ConexaoBanco().Close();
                    return dt;
                }

            }catch (Exception ex)
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
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco()); //comando sql e a conexao do banco
                    da.Fill(dt);
                    ConexaoBanco().Close();
                    return dt;
                }

            }
            catch (Exception ex)
            {
                ConexaoBanco().Close();
                throw ex;
            }

        }
    }
}
