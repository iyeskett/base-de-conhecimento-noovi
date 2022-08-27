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
        Cliente cliente = new Cliente();
        public frmClientesCadastro(int id, bool excluir = false)
        {
            InitializeComponent();
            this.id = id;
            this.excluir = excluir;

            if (id > 0)
            {
                cliente.GetCliente(this.id);
                lblId.Text = id.ToString();
                txtNome.Text = cliente.NomeCliente;
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
            Banco.GetUsuarios();
            lblUsuarios.Text = Banco.quantidade.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            cliente.Excluir();
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                if (cliente.IdCliente > 0)
                {
                    cliente.IdCliente = int.Parse(lblId.Text);
                }

                cliente.NomeCliente = txtNome.Text;

                cliente.SalvarCliente();
                this.Close();
            }
        }

        private void frmClientesCadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }
    }
}
