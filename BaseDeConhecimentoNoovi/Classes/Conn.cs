using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeConhecimentoNoovi
{
    static class Conn
    {
        static private string servidor = "mysqlserver.cufeu2a6mzqq.us-east-1.rds.amazonaws.com";
        static private string bancoDeDados = "base_de_conhecimento_noovi";
        static private string usuario = "admin";
        static private string senha = "Noovi2022";

        static public string strConn = $"SERVER={servidor};USER={usuario};DATABASE={bancoDeDados};PASSWORD={senha}";

    }
}
