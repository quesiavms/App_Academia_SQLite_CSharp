using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Academia
{
    internal class Globais
    {
        public static string versao = "1.0";
        public static bool logado = false;
        public static int nivel = 0; //0 - basico, 1 - gerente, 2 - master
        public static string caminho = System.Environment.CurrentDirectory;
        public static string nomeBanco = "db_academia";
        public static string caminhoBanco = caminho +@"\db\";
        public static string caminhoFoto = caminho + @"\fotos\";

        /*
        N_IDUSUARIO
        T_NOMEUSUARI0
        T_USERNAME
        T_SENHAUSUARIO
        T_STATUSUSUARIO
        N_NIVELUSUARIO         
        */
    }
}
