using MySql.Data.MySqlClient;
using System.Data;

namespace BaseDeConhecimentoNooviNet6.Models
{
    /// <summary>
    /// Classe para manipular a tabela de clientes
    /// </summary>
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string? NomeCliente { get; set; }
    }

}
