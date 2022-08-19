using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNoovi
{
    public class Documentacao
    {
        public int IdDocumentacao { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Link { get; set; }
        public int IdCliente { get; set; }

        public void GetDocumentacao(int id)
        {
            var sqlQuery = $"SELECT * FROM documentacao INNER JOIN clientes ON documentacao.idCliente = clientes.idCliente WHERE documentacao.idDocumentacao = {id} ";
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

        public static DataTable GetNomeCliente(int id)
        {
            DataTable dt = new DataTable();
            var sqlQuery = $"SELECT clientes.idCliente, clientes.nomeCliente from clientes INNER JOIN documentacao ON clientes.IdCliente = documentacao.idCliente WHERE clientes.idCliente = {id}";

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

        public static DataTable GetDocumentacoes(int id, string procurar = "")
        {
            DataTable dt = new DataTable();
            var sqlQuery = "";

            if (id > 0)
            {
                if (procurar != "")
                    sqlQuery += $"SELECT * from documentacao INNER JOIN clientes ON clientes.idCliente = documentacao.idCliente WHERE documentacao.idCliente = {id} AND (documentacao.titulo LIKE '%{procurar}%' OR documentacao.descricao LIKE '%{procurar}%')";

                else
                    sqlQuery = $"SELECT * from documentacao INNER JOIN clientes ON clientes.idCliente = documentacao.idCliente WHERE documentacao.idCliente ={id}";

            }
            else
            {
                sqlQuery += $"SELECT * from documentacao INNER JOIN clientes ON clientes.idCliente = documentacao.idCliente WHERE documentacao.titulo LIKE '%{procurar}%' OR documentacao.descricao LIKE '%{procurar}%'";


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

        public static DataTable GetClienteIdDocumentacoes()
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

