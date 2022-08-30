using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNooviNet6
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(Width, Height);
            BancoSQLite.GetUsuarios();
            lblUsuarios.Text = BancoSQLite.quantidade.ToString();
            statusBanco.Text = "";
        }

        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            TestarConexao();
            BancoSQLite.GetUsuarios();
            lblUsuarios.Text = BancoSQLite.quantidade.ToString();
        }

        public async void TestarConexao()
        {
            FrmConexão frmConexão = new FrmConexão("ping");
            frmConexão.ShowDialog();
            statusBanco.Text = frmConexão.Resultado;
        }

        private bool Conectar()
        {
            var result = false;
            statusBanco.Text = "Conectando, aguarde... ";
            

            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
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

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes frmClientes = new frmClientes();
            frmClientes.Show();
            Program.VerifyWindowsState(frmClientes, this.WindowState);
            this.WindowState = FormWindowState.Normal;
            Hide();
        }

        private void btnBaseConhecimento_Click(object sender, EventArgs e)
        {
            FrmDocumentacoes frmDocumentacoes = new FrmDocumentacoes();
            frmDocumentacoes.EntrouPeloMenu();
            frmDocumentacoes.Show();
            Program.VerifyWindowsState(frmDocumentacoes, this.WindowState);
            this.WindowState = FormWindowState.Normal;
            Hide();
        }

        private void btnPutty_Click(object sender, EventArgs e)
        {
            Process.Start(@$"C:\Users\{Program.GetUser()}\Desktop\putty.exe");
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAcessos_Click(object sender, EventArgs e)
        {
            FrmAcessos frmAcessos = new FrmAcessos();
            frmAcessos.Show();
            Program.VerifyWindowsState(frmAcessos, this.WindowState);
            this.WindowState = FormWindowState.Normal;
            Hide();
        }

        private void btnRDP_Click(object sender, EventArgs e)
        {
            Process.Start("mstsc.exe");
        }

        private void btnWinSCP_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files (x86)\WinSCP\WinSCP.exe");

        }
    }
}
