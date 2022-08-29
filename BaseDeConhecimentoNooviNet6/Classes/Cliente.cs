//using MySql.Data.MySqlClient;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace BaseDeConhecimentoNooviNet6
//{
//    /// <summary>
//    /// Classe para manipular a tabela de clientes
//    /// </summary>
//    public class Cliente
//    {
//        public int IdCliente { get; set; }
//        public string NomeCliente { get; set; }

//        /// <summary>
//        /// Traz as informações do cliente
//        /// </summary>
//        /// <param name="id">id do cliente</param>
//        public void GetCliente(int id)
//        {
//            var sqlQuery = $"SELECT * FROM clientes WHERE idCliente = {id}";
//            try
//            {
//                using (var cn = new MySqlConnection(Conn.strConn))
//                {
//                    cn.Open();

//                    using (var cmd = new MySqlCommand(sqlQuery, cn))
//                    {
//                        using (var dr = cmd.ExecuteReader())
//                        {
//                            if (dr.HasRows)
//                            {
//                                if (dr.Read())
//                                {
//                                    this.IdCliente = Convert.ToInt32(dr["idCliente"]);
//                                    this.NomeCliente = Convert.ToString(dr["nomeCliente"]);

//                                }
//                            }
//                        }
//                    }
//                }


//            }
//            catch (Exception e)
//            {
//                MessageBox.Show("Falha: " + e.Message);
//            }
//        }

//        /// <summary>
//        /// Traz todos os clientes
//        /// </summary>
//        /// <param name="procurar">Nome do cliente que deseja procurar, por padrão fica sem conteudo para 
//        /// trazer todos os clientes.</param>
//        /// <returns></returns>
//        public static DataTable GetClientes(string procurar = "")
//        {
//            DataTable dt = new DataTable();
//            var sqlQuery = "";

//            if (procurar != "")
//            {
//                sqlQuery += $"SELECT * FROM clientes WHERE nomeCliente LIKE '%{procurar}%'";
//            }
//            else
//            {
//                sqlQuery = "SELECT * FROM clientes ORDER BY idCliente";

//            }

//            try
//            {
//                using (var cn = new MySqlConnection(Conn.strConn))
//                {
//                    cn.Open();

//                    using (MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, cn))
//                    {
//                        using (dt = new DataTable())
//                        {
//                            da.Fill(dt);
//                        }
//                    }
//                }
//                return dt;


//            }
//            catch (Exception e)
//            {
//                MessageBox.Show("Falha: " + e.Message);
//            }
//            return dt;

//        }

//        /// <summary>
//        /// Salva o cliente no banco de dados, caso o id seja maior que zero, faz o update do cliente.
//        /// </summary>
//        public void SalvarCliente()
//        {
//            var sqlQuery = "";
//            if (this.IdCliente == 0)
//            {
//                sqlQuery = "INSERT INTO clientes(nomeCliente) VALUES (@nomeCliente)";
//            }
//            else
//            {
//                sqlQuery = $"UPDATE clientes SET idCliente= @idCliente,nomeCliente= @nomeCliente WHERE idCliente = {this.IdCliente}";

//            }

//            try
//            {
//                using (var cn = new MySqlConnection(Conn.strConn))
//                {
//                    cn.Open();
//                    using (var cmd = new MySqlCommand(sqlQuery, cn))
//                    {
//                        cmd.Parameters.AddWithValue("@idCliente", this.IdCliente);
//                        cmd.Parameters.AddWithValue("@nomeCLiente", this.NomeCliente);


//                        cmd.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch (Exception e)
//            {

//                MessageBox.Show(e.Message);
//            }
//        }

//        /// <summary>
//        /// Exclui o cliente do banco de dados
//        /// </summary>
//        public void Excluir()
//        {
//            var sqlQuery = $"DELETE FROM clientes WHERE idCliente = {this.IdCliente}";
//            try
//            {
//                using (var cn = new MySqlConnection(Conn.strConn))
//                {
//                    cn.Open();
//                    using (var cmd = new MySqlCommand(sqlQuery, cn))
//                    {
//                        cmd.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch (Exception e)
//            {

//                MessageBox.Show(e.Message);
//            }
//        }
//    }
//}
