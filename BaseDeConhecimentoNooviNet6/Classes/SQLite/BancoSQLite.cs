using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNooviNet6
{
   
    public class BancoSQLite
    {
        public static int quantidade;

        /// <summary>
        /// Traz a quantidade de usuários conectados
        /// </summary>
        public static void GetUsuarios()
        {
            var sqlQuery = $"SELECT usuarios FROM usuarios_online WHERE id = 1";
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
                                    quantidade = Convert.ToInt32(dr["usuarios"]);

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
        /// Adiciona o usuário nas lista de usuários online
        /// </summary>
        public static void AdicionarUsuario()
        {
            var sqlQuery = $"UPDATE usuarios_online SET usuarios = usuarios+1 WHERE id = 1";
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

        /// <summary>
        /// Remove o usuário da lista de usuários online
        /// </summary>
        public static void RemoverUsuario()
        {
            var sqlQuery = $"UPDATE usuarios_online SET usuarios = usuarios-1 WHERE id = 1";
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
