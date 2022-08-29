using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNooviNet6
{
    public partial class frmClientesCadastro : Form
    {
        int id;
        bool excluir = false;
        // Cliente cliente = new Cliente();
        ClienteSQLite clienteSQLite = new ClienteSQLite();
        public frmClientesCadastro(int id, bool excluir = false)
        {
            InitializeComponent();
            this.id = id;
            this.excluir = excluir;

            if (id > 0)
            {
                clienteSQLite.GetCliente(this.id);
                lblId.Text = id.ToString();
                txtNome.Text = clienteSQLite.NomeCliente;
            }

            if (this.excluir)
            {
                TravarControles();
                btnSalvar.Visible = false;
                btnExcluir.Visible = true;
            }
        }

        private bool ValidarForm()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Informe o nome do cliente.");
                txtNome.Focus();
                return false;
            }
            return true;
        }

        private void TravarControles()
        {
            txtNome.Enabled = false;
        }

        private void frmClientesCadastro_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            BancoSQLite.GetUsuarios();
            lblUsuarios.Text = BancoSQLite.quantidade.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            clienteSQLite.Excluir();
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                if (clienteSQLite.IdCliente > 0)
                {
                    clienteSQLite.IdCliente = int.Parse(lblId.Text);
                }

                clienteSQLite.NomeCliente = txtNome.Text;

                clienteSQLite.SalvarCliente();
                this.Close();
            }
        }

        private void frmClientesCadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }
    }
}
