using BaseDeConhecimentoNooviNet6.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeConhecimentoNooviNet6
{
    public class AcessosClienteSQLite
    {

        public static void SalvarAcesso(Acesso acesso)
        {
            var sqlQuery = "INSERT INTO acessos(idCliente, tituloAcesso, login, senha,tipoAcesso) VALUES (@idCliente,@tituloAcesso,@login,@senha,@tipoAcesso)";
            if (acesso.IdAcesso != 0)
            {
                sqlQuery = $"UPDATE acessos SET idCliente = @idCliente,tituloAcesso = @tituloAcesso, login = @login, senha = @senha,tipoAcesso = @tipoAcesso WHERE idAcesso = {acesso.IdAcesso}";
            }

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Conn.strConnSQLite))
                {
                    connection.Open();
                    using (SQLiteCommand command= new SQLiteCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@idCliente", acesso.IdCliente);
                        command.Parameters.AddWithValue("@tituloAcesso", acesso.TituloAcesso);
                        command.Parameters.AddWithValue("@login", acesso.Login) ;
                        command.Parameters.AddWithValue("@senha", acesso.Senha);
                        command.Parameters.AddWithValue("@tipoAcesso", acesso.TipoAcesso);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show($"Um erro inesperado ocorreu: {e.Message}");
            }
        }

        public static Acesso SelectAcesso(int idAcesso, int idCliente)
        {
            Acesso acesso = new Acesso();
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
                                    acesso.IdCliente = Convert.ToInt32(reader["idCliente"]);
                                    acesso.NomeCliente = Convert.ToString(reader["nomeCliente"]);
                                    acesso.IdAcesso = Convert.ToInt32(reader["idAcesso"]);
                                    acesso.TituloAcesso = Convert.ToString(reader["tituloAcesso"]);
                                    acesso.Login = Convert.ToString(reader["login"]);
                                    acesso.Senha = Convert.ToString(reader["senha"]);
                                    acesso.TipoAcesso = Convert.ToString(reader["tipoAcesso"]);

                                }
                            }
                        }
                    }
                }
                return acesso;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ocorreu um erro inesperado: {e.Message}");
                return null;
            }
        }

        public static DataTable SelectAcessos()
        {
            var sqlQuery = "SELECT * FROM acessos INNER JOIN clientes ON acessos.idCliente = clientes.idCliente ORDER BY nomeCliente";
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
