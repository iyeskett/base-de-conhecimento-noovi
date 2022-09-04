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
        public int IdAcesso;
        public int IdCliente;
        public string? NomeCliente;
        public string? TituloAcesso;
        public string? Login;
        public string? Senha;
        public string? TipoAcesso;


        public void SetAcesso(int idCliente, string tituloAcesso, string login, string senha, string tipoAcesso)
        {
            IdCliente = idCliente;
            TituloAcesso = tituloAcesso;
            Login = login;
            Senha = senha;
            TipoAcesso = tipoAcesso;
        }

        public void SalvarAcesso(int idAcesso)
        {
            var sqlQuery = "INSERT INTO acessos(idCliente, tituloAcesso, login, senha,tipoAcesso) VALUES (@idCliente,@tituloAcesso,@login,@senha,@tipoAcesso)";
            if (this.IdAcesso != 0)
            {
                sqlQuery = $"UPDATE acessos SET idCliente = @idCliente,tituloAcesso = @tituloAcesso, login = @login, senha = @senha,tipoAcesso = @tipoAcesso WHERE idAcesso = {IdAcesso}";
            }

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Conn.strConnSQLite))
                {
                    connection.Open();
                    using (SQLiteCommand command= new SQLiteCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@idCliente", IdCliente);
                        command.Parameters.AddWithValue("@tituloAcesso", TituloAcesso);
                        command.Parameters.AddWithValue("@login", Login);
                        command.Parameters.AddWithValue("@senha", Senha);
                        command.Parameters.AddWithValue("@tipoAcesso", TipoAcesso);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show($"Um erro inesperado ocorreu: {e.Message}");
            }
        }

        public void SelectAcesso(int idAcesso, int idCliente)
        {
            var sqlQuery = $"SELECT * " +
                $"FROM acessos INNER JOIN clientes ON acessos.idCliente == clientes.idCliente WHERE idAcesso = {idAcesso} AND acessos.idCliente = {idCliente}";
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
                        using (dt = new DataTable())
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

        public static void ExcluirAcesso(int idAcesso)
        {
            var sqlQuery = $"DELETE FROM acessos WHERE idAcesso = {idAcesso}";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Conn.strConnSQLite))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(sqlQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception e)
            {

                MessageBox.Show($"Não foi possivel excluir: {e.Message}");
            }
        }
    }
}
