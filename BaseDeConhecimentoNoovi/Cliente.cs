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
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }

        public void GetCliente(int id)
        {
            var sqlQuery = $"SELECT * FROM clientes WHERE idCliente = {id}";
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
                                    this.IdCliente = Convert.ToInt32(dr["idCliente"]);
                                    this.NomeCliente = Convert.ToString(dr["nomeCliente"]);

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

        public void SalvarCliente()
        {
            var sqlQuery = "";
            if (this.IdCliente == 0)
            {
                sqlQuery = "INSERT INTO clientes(nomeCliente) VALUES (@nomeCliente)";
            }
            else
            {
                sqlQuery = $"UPDATE clientes SET idCliente= @idCliente,nomeCliente= @nomeCliente WHERE idCliente = {this.IdCliente}";

            }

            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sqlQuery, cn))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", this.IdCliente);
                        cmd.Parameters.AddWithValue("@nomeCLiente", this.NomeCliente);


                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public void Excluir()
        {
            var sqlQuery = $"DELETE FROM clientes WHERE idCliente = {this.IdCliente}";
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
