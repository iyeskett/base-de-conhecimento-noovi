using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeConhecimentoNoovi
{
    static class Conn
    {
        static private string servidor = "localhost";
        static private string bancoDeDados = "base_de_conhecimento_noovi";
        static private string usuario = "root";
        static private string senha = "noovi@2021";

        static public string strConn = $"SERVER={servidor};USER={usuario};DATABASE={bancoDeDados};PASSWORD={senha}";

    }
}
