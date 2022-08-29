using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeConhecimentoNooviNet6
{
    /// <summary>
    /// Dados da conexão com o banco
    /// </summary>
    static class Conn
    {
        //static private string servidor = "";
        //static private string bancoDeDados = "base_de_conhecimento_noovi";
        //static private string usuario = "admin";
        //static private string senha = "Noovi2022"; 

        static private string servidor = "localhost";
        static private string bancoDeDados = "base_de_conhecimento_noovi";
        static private string usuario = "root";
        static private string senha = "root";

        /// <summary>
        /// String de conexão com o banco de dados
        /// </summary>
        static public string strConn = $"SERVER={servidor};USER={usuario};DATABASE={bancoDeDados};PASSWORD={senha}";
        static public string strConnSQLite = @"Data Source=C:\Users\felip\Documents\BaseDeConhecimentoNoovi\SQLite\Noovi.db; Version=3";

    }
}
