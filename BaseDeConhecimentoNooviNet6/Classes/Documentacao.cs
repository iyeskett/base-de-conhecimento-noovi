using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNooviNet6
{
    /// <summary>
    /// Classe para manipular a tabela de documentações
    /// </summary>
    public class Documentacao
    {
        public int IdDocumentacao { get; set; }
        public string Titulo { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string Link { get; set; } = "";
        public int IdCliente { get; set; }

        /// <summary>
        /// Procura a documentação pelo seu id
        /// </summary>
        /// <param name="idDocumentacao">id da documentação</param>
        public void GetDocumentacao(int idDocumentacao)
        {
            var sqlQuery = $"SELECT * FROM documentacao INNER JOIN clientes ON documentacao.idCliente = clientes.idCliente WHERE documentacao.idDocumentacao = {idDocumentacao} ";
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();

                    using (var cmd = new MySqlCommand(sqlQuery, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    this.IdDocumentacao = Convert.ToInt32(dr["idDocumentacao"]);
                                    this.IdCliente = Convert.ToInt32(dr["idCliente"]);
                                    this.Titulo = Convert.ToString(dr["titulo"]);
                                    this.Descricao = Convert.ToString(dr["descricao"]);
                                    this.Link = Convert.ToString(dr["link"]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha: " + e.Message);
            }
        }


        /// <summary>
        /// Traz o nome e id do cliente
        /// </summary>
        /// <param name="idCliente">id do cliente que deseja procurar</param>
        /// <returns></returns>
        public static DataTable GetNomeCliente(int idCliente)
        {
            DataTable dt = new DataTable();
            var sqlQuery = $"SELECT clientes.idCliente, clientes.nomeCliente from clientes WHERE clientes.idCliente = {idCliente}";

            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();

                    using (MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, cn))
                    {
                        using (dt = new DataTable())
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return dt;


            }
            catch (Exception e)
            {
                MessageBox.Show("Falha: " + e.Message);
            }
            return dt;
        }

        /// <summary>
        /// Traz toda documentação de um cliente, por padrão busca por todas as documentações.
        /// </summary>
        /// <param name="idCliente">id do cliente</param>
        /// <param name="procurar"></param>
        /// <returns></returns>
        public static DataTable GetDocumentacoes(int idCliente, string procurar = "")
        {
            DataTable dt = new DataTable();
            var sqlQuery = "";

            if (idCliente > 0)
            {
                sqlQuery = $"SELECT * from documentacao INNER JOIN clientes ON clientes.idCliente = documentacao.idCliente WHERE documentacao.idCliente ={idCliente}";

            }
            else
            {
                sqlQuery += $"SELECT * from documentacao INNER JOIN clientes ON clientes.idCliente = documentacao.idCliente";


            }
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();

                    using (MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, cn))
                    {
                        using (dt = new DataTable())
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return dt;


            }
            catch (Exception e)
            {
                MessageBox.Show("Falha: " + e.Message);
            }
            return dt;

        }

        /// <summary>
        /// Traz os clientes em ordem alfabetica
        /// </summary>
        /// <returns></returns>
        public static DataTable GetClienteAlfabeticamente()
        {
            DataTable dt = new DataTable();
            var sqlQuery = $"SELECT idCliente, nomeCliente from clientes ORDER BY nomeCliente";

            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();

                    using (MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, cn))
                    {
                        using (dt = new DataTable())
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return dt;


            }
            catch (Exception e)
            {
                MessageBox.Show("Falha: " + e.Message);
            }
            return dt;

        }

        /// <summary>
        /// Salva a documentação no banco de dados
        /// </summary>
        public void SalvarDocumento()
        {
            var sqlQuery = "";
            if (this.IdDocumentacao == 0)
            {
                sqlQuery = "INSERT INTO `documentacao`(`idCliente`, `titulo`, `descricao`, `link`) VALUES (@idCliente,@titulo,@descricao,@link)";
            }
            else
            {
                sqlQuery = $"UPDATE `documentacao` SET idCliente = @idCliente, titulo=@titulo, descricao=@descricao, link=@link WHERE idDocumentacao = {this.IdDocumentacao}";

            }

            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sqlQuery, cn))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", this.IdCliente);
                        cmd.Parameters.AddWithValue("@titulo", this.Titulo);
                        cmd.Parameters.AddWithValue("@descricao", this.Descricao);
                        cmd.Parameters.AddWithValue("@link", this.Link);



                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Exclui a documentação do banco de dados
        /// </summary>
        /// <param name="idDocumentacao">id da documentação a ser excluida</param>
        public void Excluir(int idDocumentacao)
        {
            var sqlQuery = $"DELETE FROM documentacao WHERE idDocumentacao = {idDocumentacao}";
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sqlQuery, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
    }
}

