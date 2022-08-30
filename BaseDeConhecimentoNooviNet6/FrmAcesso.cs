using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNooviNet6
{
    public partial class FrmAcesso : Form
    {
        AcessosCliente AcessosCliente = new AcessosCliente();
        string Origem;
        int IdAcesso;

        public FrmAcesso(string origem, int idAcesso)
        {
            Origem = origem;
            IdAcesso = idAcesso;
            InitializeComponent();
        }

        private void FrmAcesso_Load(object sender, EventArgs e)
        {
            Inicializar();
            switch (Origem)
            {
                case "doubleClique":
                    btnSair.Text = "Voltar";
                    txtCliente.ReadOnly = true;
                    txtCliente.BackColor = Color.White;
                    txtTitulo.ReadOnly = true;
                    txtTitulo.BackColor = Color.White;
                    txtLogin.ReadOnly = true;
                    txtLogin.BackColor = Color.White;
                    txtSenha.ReadOnly = true;
                    txtSenha.BackColor = Color.White;
                    txtTipoAcesso.ReadOnly = true;
                    txtTipoAcesso.BackColor = Color.White;
                    break;
                case "adicionar":
                case "alterar":
                    btnSair.Text = "Salvar";
                    break;
                case "excluir":
                    btnSair.Text = "Excluir";
                    break;
                default:
                    break;
            }
        }

        private void Inicializar()
        {
            MinimumSize = new Size(705, 497);
            AcessosCliente.SelectAcesso(IdAcesso);
            txtCliente.Text = AcessosCliente.NomeCliente;
            txtTitulo.Text = AcessosCliente.TituloAcesso;
            txtLogin.Text = AcessosCliente.Login;
            txtSenha.Text = AcessosCliente.Senha;
            txtTipoAcesso.Text = AcessosCliente.TipoAcesso;
            IniciarAplicativos();
        }

        private void IniciarAplicativos()
        {
            var tipoAcesso = txtTipoAcesso.Text;

            if (tipoAcesso.ToString().ToUpper() == "SSH")
            {
                btnAplicativo.Text = "Abrir Putty";
                btnWinSCP.Visible = true;
            }
            else if (tipoAcesso.ToString().ToUpper() == "RDP")
            {
                btnAplicativo.Text = "Abrir RDP";
                btnWinSCP.Visible = false;
            }
        }

        private void btnAplicativo_Click(object sender, EventArgs e)
        {
            var tipoAcesso = txtTipoAcesso.Text;

            if (tipoAcesso.ToString().ToUpper() == "SSH")
            {
                Process.Start(@$"C:\Users\{Program.GetUser()}\Desktop\putty.exe");
            }
            else if (tipoAcesso.ToString().ToUpper() == "RDP")
            {
                Process.Start("mstsc.exe");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (btnSair.Text == "Voltar")
            {
                Dispose();
            }
        }

        private void btnWinSCP_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files (x86)\WinSCP\WinSCP.exe");
        }
    }
}
