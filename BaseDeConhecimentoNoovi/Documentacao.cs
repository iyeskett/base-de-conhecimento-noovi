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
        Cliente cliente = new Cliente();
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Link { get; set; }

        public void GetDocumentacao(int id)
        {
            var sqlQuery = $"SELECT clientes.nomeCliente, titulo, descricao, link FROM documentacao INNER JOIN clientes ON clientes.ID = documentacao.idCliente WHERE idCliente = {id}; ";
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
                                    //this.Cliente.IdCliente = Convert.ToInt32(dr["idDocumentacao"]);
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

        public static DataTable GetDocumentacoes(int id, string procurar = "")
        {
            DataTable dt = new DataTable();
            var sqlQuery = "";

            if (procurar != "")
            {
                sqlQuery += $"SELECT * from documentacao INNER JOIN clientes ON clientes.idCliente = documentacao.idCliente WHERE documentacao.titulo LIKE '%{procurar}%' OR documentacao.descricao LIKE '%{procurar}%'";
                ;
            }
            else
            {
                sqlQuery = $"SELECT * from documentacao INNER JOIN clientes ON clientes.idCliente = documentacao.idCliente WHERE documentacao.idCliente ={id}";


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
    }
}

