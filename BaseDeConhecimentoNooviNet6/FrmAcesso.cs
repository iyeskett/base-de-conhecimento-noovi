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
        AcessosCliente acessosCliente = new AcessosCliente();
        string Origem;
        int IdAcesso;
        int IdCliente;

        public FrmAcesso(string origem, int idAcesso, int idCliente)
        {
            Origem = origem;
            IdAcesso = idAcesso;
            IdCliente = idCliente;
            InitializeComponent();
        }

        private void FrmAcesso_Load(object sender, EventArgs e)
        {
            Inicializar();
            switch (Origem)
            {
                case "doubleClique":
                    btnSair.Text = "Voltar";
                    ReadOnly();
                    break;
                case "adicionar":
                case "alterar":
                    btnSair.Text = "Salvar";
                    break;
                case "excluir":
                    btnSair.Text = "Excluir";
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

        private void Inicializar()
        {
            MinimumSize = new Size(705, 497);
            acessosCliente.SelectAcesso(IdAcesso, IdCliente);
            DataTable dt = new DataTable();
            dt = AcessosCliente.SelectClientesAlfabeticamente();
            cmbClientes.DataSource = dt;
            cmbClientes.ValueMember = "idCliente";
            cmbClientes.DisplayMember = "nomeCliente";
            txtTitulo.Text = acessosCliente.TituloAcesso;
            txtLogin.Text = acessosCliente.Login;
            txtSenha.Text = acessosCliente.Senha;
            txtTipoAcesso.Text = acessosCliente.TipoAcesso;
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
            switch (Origem)
            {
                case "doubleClique":
                    Dispose();
                    break;
                case "adicionar":
                    idCli = Convert.ToInt32(Convert.ToString(cmbClientes.SelectedValue));
                    acessosCliente.SetAcesso(idCli, txtTitulo.Text, txtLogin.Text, txtSenha.Text, txtTipoAcesso.Text);
                    acessosCliente.SalvarAcesso(0);
                    Dispose();
                    break;
                case "alterar":
                    idCli = Convert.ToInt32(Convert.ToString(cmbClientes.SelectedValue));
                    acessosCliente.SetAcesso(idCli, txtTitulo.Text, txtLogin.Text, txtSenha.Text, txtTipoAcesso.Text);
                    acessosCliente.SalvarAcesso(IdAcesso);
                    Dispose();
                    break;
                case "excluir":
                    AcessosCliente.ExcluirAcesso(IdAcesso);
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
