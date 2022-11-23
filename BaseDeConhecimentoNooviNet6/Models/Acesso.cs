using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeConhecimentoNooviNet6.Models
{
    public class Acesso
    {
        public int IdAcesso;
        public int IdCliente;
        public string? NomeCliente;
        public string? TituloAcesso;
        public string? Login;
        public string? Senha;
        public string? TipoAcesso;
        
        public Acesso() { }

        public Acesso(int idAcesso, int idCliente, string? nomeCliente, string? tituloAcesso, string? login, string? senha, string? tipoAcesso)
        {
            IdAcesso= idAcesso;
            IdCliente = idCliente;
            NomeCliente = nomeCliente;
            TituloAcesso = tituloAcesso;
            Login = login;
            Senha = senha;
            TipoAcesso = tipoAcesso;
        }
    }
}
