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
    public partial class Menu : Form
    {

        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conectar();
            Banco.GetUsuarios();
            lblUsuarios.Text = Banco.quantidade.ToString();
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
            Banco.GetUsuarios();
            lblUsuarios.Text = Banco.quantidade.ToString();
            statusBanco.Text = "";

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes frmClientes = new frmClientes();
            frmClientes.Show();
            Hide();
        }

        private void btnBaseConhecimento_Click(object sender, EventArgs e)
        {
            frmDocumentacoes frmDocumentacoes = new frmDocumentacoes(0, true);
            frmDocumentacoes.Show();
            Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
