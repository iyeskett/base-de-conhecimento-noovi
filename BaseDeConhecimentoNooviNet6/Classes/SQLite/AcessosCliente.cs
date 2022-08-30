using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeConhecimentoNooviNet6
{
    public class AcessosCliente
    {
        public int IdCliente;
        public int IdAcesso;
        public string? NomeCliente;
        public string? TituloAcesso;
        public string? Login;
        public string? Senha;
        public string? TipoAcesso;

        public void SelectAcesso(int idAcesso)
        {
            var sqlQuery = $"SELECT * " +
                $"FROM acessos INNER JOIN clientes ON acessos.idCliente WHERE idAcesso = {idAcesso}";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Conn.strConnSQLite))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(sqlQuery, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    IdCliente = Convert.ToInt32(reader["idCliente"]);
                                    NomeCliente = Convert.ToString(reader["nomeCliente"]);
                                    IdAcesso = Convert.ToInt32(reader["idAcesso"]);
                                    TituloAcesso = Convert.ToString(reader["tituloAcesso"]);
                                    Login = Convert.ToString(reader["login"]);
                                    Senha = Convert.ToString(reader["senha"]);
                                    TipoAcesso = Convert.ToString(reader["tipoAcesso"]);

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ocorreu um erro inesperado: {e.Message}");
            }
        }

        public static DataTable SelectAcessos()
        {
            var sqlQuery = "SELECT * FROM acessos INNER JOIN clientes ON acessos.idCliente = clientes.idCliente";
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Conn.strConnSQLite))
                {
                    connection.Open();
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sqlQuery, connection))
                    {
                        using (dt = new DataTable())
                        {
                            dataAdapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception e)
            {

                MessageBox.Show($"Ocorreu um erro inesperado: {e.Message}");
                return dt;
            }
        }

        public static DataTable SelectAcessos(int idCliente)
        {
            var sqlQuery = $"SELECT * " +
                $"FROM acessos INNER JOIN clientes ON acessos.idCliente = clientes.idCliente WHERE acessos.idCliente = {idCliente}";
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Conn.strConnSQLite))
                {
                    connection.Open();
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sqlQuery, connection))
                    {
                        using (dt = new DataTable())
                        {
                            dataAdapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception e)
            {

                MessageBox.Show($"Ocorreu um erro inesperado: {e.Message}");
                return dt;
            }
        }

        public static DataTable SelectAcessosPesquisa(string pesquisa)
        {
            DataTable dt = new DataTable();
            var sqlQuery = $"SELECT * " +
                $"FROM acessos INNER JOIN clientes ON acessos.idCliente = clientes.idCliente " +
                $"WHERE tituloAcesso OR clientes.nomeCliente LIKE '%{pesquisa}%'";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Conn.strConnSQLite))
                {
                    connection.Open();
                    using (SQLiteDataAdapter reader = new SQLiteDataAdapter(sqlQuery, connection))
                    {
                        using(dt = new DataTable())
                        {
                            reader.Fill(dt);
                        }
                    }
                }
                return dt;

            }
            catch (Exception e)
            {

                MessageBox.Show($"Ocorreu um erro inesperado: {e.Message}");
                return dt;
            }

        }

        public static DataTable SelectClientesAlfabeticamente()
        {
            DataTable dt = new DataTable();
            var sqlQuery = "SELECT idCliente, nomeCliente FROM clientes ORDER BY nomeCliente";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Conn.strConnSQLite))
                {
                    connection.Open();
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sqlQuery, connection))
                    {
                        using (dt = new DataTable())
                        {
                            dataAdapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception e)
            {

                MessageBox.Show($"Ocorreu um erro inesperado: {e.Message}");
                return dt;
            }
        }
    }
}
