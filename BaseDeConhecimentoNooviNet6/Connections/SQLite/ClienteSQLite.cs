using MySql.Data.MySqlClient;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseDeConhecimentoNooviNet6.Models;

namespace BaseDeConhecimentoNooviNet6
{
    /// <summary>
    /// Classe para manipular a tabela de clientes
    /// </summary>
    public class ClienteSQLite
    {

        /// <summary>
        /// Busca e retorna um cliente do banco de dados
        /// </summary>
        /// <param name="id">id do cliente</param>
        public static Cliente GetCliente(int id)
        {
            Cliente cliente = new Cliente();
            var sqlQuery = $"SELECT * FROM clientes WHERE idCliente = {id}";
            try
            {
                using (var cn = new SQLiteConnection(Conn.strConnSQLite))
                {
                    cn.Open();

                    using (var cmd = new SQLiteCommand(sqlQuery, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    cliente.IdCliente = Convert.ToInt32(dr["idCliente"]);
                                    cliente.NomeCliente = Convert.ToString(dr["nomeCliente"]);

                                }
                            }
                        }
                    }
                }
                return cliente;

            }
            catch (Exception e)
            {
                MessageBox.Show("Falha: " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Traz todos os clientes
        /// </summary>
        /// <param name="procurar">Nome do cliente que deseja procurar, por padrão fica sem conteudo para 
        /// trazer todos os clientes.</param>
        /// <returns></returns>
        public static DataTable GetClientes(string procurar = "")
        {
            DataTable dt = new DataTable();
            var sqlQuery = "";

            if (procurar != "")
            {
                sqlQuery += $"SELECT * FROM clientes WHERE nomeCliente LIKE '%{procurar}%'";
            }
            else
            {
                sqlQuery = "SELECT * FROM clientes ORDER BY idCliente";

            }

            try
            {
                using (var cn = new SQLiteConnection(Conn.strConnSQLite))
                {
                    cn.Open();

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(sqlQuery, cn))
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
        /// Salva o cliente no banco de dados, caso o id seja maior que zero, faz o update do cliente.
        /// </summary>
        public static void SalvarCliente(Cliente cliente)
        {
            var sqlQuery = "";
            if (cliente.IdCliente == 0)
            {
                sqlQuery = "INSERT INTO clientes(nomeCliente) VALUES (@nomeCliente)";
            }
            else
            {
                sqlQuery = $"UPDATE clientes SET idCliente= @idCliente,nomeCliente= @nomeCliente WHERE idCliente = {cliente.IdCliente}";

            }

            try
            {
                using (var cn = new SQLiteConnection(Conn.strConnSQLite))
                {
                    cn.Open();
                    using (var cmd = new SQLiteCommand(sqlQuery, cn))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
                        cmd.Parameters.AddWithValue("@nomeCLiente", cliente.NomeCliente);


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
        /// Exclui o cliente do banco de dados
        /// </summary>
        public static void Excluir(Cliente cliente)
        {
            var sqlQuery = $"DELETE FROM clientes WHERE idCliente = {cliente.IdCliente}";
            try
            {
                using (var cn = new SQLiteConnection(Conn.strConnSQLite))
                {
                    cn.Open();
                    using (var cmd = new SQLiteCommand(sqlQuery, cn))
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
