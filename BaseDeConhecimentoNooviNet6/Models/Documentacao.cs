using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNooviNet6.Models
{
    /// <summary>
    /// Classe para manipular a tabela de documentações
    /// </summary>
    public class Documentacao
    {
        public int IdDocumentacao { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Link { get; set; }
        public int IdCliente { get; set; }
    }

}

