using BaseDeConhecimentoNooviNet6.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaseDeConhecimentoNooviNet6
{
    public partial class FrmAcesso : Form
    {
        AcessosClienteSQLite acessosCliente = new AcessosClienteSQLite();
        string Origem;
        Acesso acesso = new Acesso();
        Cliente cliente = new Cliente();

        public FrmAcesso(string origem, Acesso acesso)
        {
            Origem = origem;
            this.acesso = acesso;
            InitializeComponent();
        }

        private void FrmAcesso_Load(object sender, EventArgs e)
        {
            DataTable dtNomeCli;
            Inicializar(acesso);
            switch (Origem)
            {
                case "doubleClique":
                    btnSair.Text = "Voltar";
                    dtNomeCli = DocumentacaoSQLite.GetNomeCliente(acesso.IdCliente);
                    cmbClientes.DataSource = dtNomeCli;
                    cmbClientes.DisplayMember = "nomeCLiente";
                    cmbClientes.ValueMember = "idCLiente";
                    ReadOnly();
                    break;
                case "adicionar":
                case "alterar":
                    btnSair.Text = "Salvar";
                    break;
                case "excluir":
                    btnSair.Text = "Excluir";
                    dtNomeCli = DocumentacaoSQLite.GetNomeCliente(acesso.IdCliente);
                    cmbClientes.DataSource = dtNomeCli;
                    cmbClientes.DisplayMember = "nomeCLiente";
                    cmbClientes.ValueMember = "idCLiente";
                    Disable();
                    break;
                default:
                    break;
            }
        }

        private void ReadOnly()
        {
            cmbClientes.Enabled = false;
            txtTitulo.ReadOnly = true;
            txtTitulo.BackColor = Color.White;
            txtLogin.ReadOnly = true;
            txtLogin.BackColor = Color.White;
            txtSenha.ReadOnly = true;
            txtSenha.BackColor = Color.White;
            txtTipoAcesso.ReadOnly = true;
            txtTipoAcesso.BackColor = Color.White;
        }

        private void Disable()
        {
            cmbClientes.Enabled = false;
            txtTitulo.Enabled = false;
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
            txtTipoAcesso.Enabled = false;
        }

        private void Inicializar(Acesso acesso)
        {
            MinimumSize = new Size(705, 497);
            AcessosClienteSQLite.SelectAcesso(acesso.IdAcesso, acesso.IdCliente);
            DataTable dt = new DataTable();
            dt = AcessosClienteSQLite.SelectClientesAlfabeticamente();
            cmbClientes.DataSource = dt;
            cmbClientes.ValueMember = "idCliente";
            cmbClientes.DisplayMember = "nomeCliente";
            txtTitulo.Text = this.acesso.TituloAcesso;
            txtLogin.Text = this.acesso.Login;
            txtSenha.Text = this.acesso.Senha;
            txtTipoAcesso.Text = this.acesso.TipoAcesso;
            btnAplicativo.Visible = false;
            if (Origem == "doubleClique")
            {

                IniciarAplicativos();
            }
        }

        private void IniciarAplicativos()
        {
            btnAplicativo.Visible = true;
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
            int idCli;
            string nomeCliente;
            Acesso acesso;
            switch (Origem)
            {
                case "doubleClique":
                    Dispose();
                    break;
                case "adicionar":
                    idCli = Convert.ToInt32(Convert.ToString(cmbClientes.SelectedValue));
                    nomeCliente = ClienteSQLite.GetCliente(idCli).NomeCliente;
                    acesso = new Acesso(0, idCli, nomeCliente, txtTitulo.Text, txtLogin.Text, txtSenha.Text, txtTipoAcesso.Text);
                    AcessosClienteSQLite.SalvarAcesso(acesso);
                    Dispose();
                    break;
                case "alterar":
                    idCli = Convert.ToInt32(Convert.ToString(cmbClientes.SelectedValue));
                    nomeCliente = ClienteSQLite.GetCliente(idCli).NomeCliente;
                    acesso = new Acesso(0, idCli, nomeCliente, txtTitulo.Text, txtLogin.Text, txtSenha.Text, txtTipoAcesso.Text);
                    acesso.IdAcesso = this.acesso.IdAcesso;
                    AcessosClienteSQLite.SalvarAcesso(acesso);
                    Dispose();
                    break;
                case "excluir":
                    AcessosClienteSQLite.ExcluirAcesso(this.acesso.IdAcesso);
                    Dispose();
                    break;
                default:
                    break;
            }
        }

        private void btnWinSCP_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files (x86)\WinSCP\WinSCP.exe");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
