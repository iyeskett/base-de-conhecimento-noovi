using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNoovi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conectar();
        }

        private bool Conectar()
        {
            var result = false;
            statusBanco.Text = "Conectando, aguarde... ";

            try
            {
                using(var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    result = true;
                    statusBanco.Text = "Conexão bem sucedida";
                }
            }
            catch (Exception e)
            {
                statusBanco.Text = "Falha na conexão";
                result = false;
                MessageBox.Show("Falha: " + e.Message);
            }

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            statusBanco.Text = "";
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes clientes = new frmClientes();
            clientes.Show();
            Hide();
        }
    }
}
