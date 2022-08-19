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
    public partial class FrmClientesCadastro : Form
    {
        int id;
        bool excluir = false;
        Cliente cliente = new Cliente();

        public FrmClientesCadastro(int id, bool excluir = false)
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

        private void FrmClientesCadastro_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            Banco.GetUsuarios();
            lblUsuarios.Text = Banco.quantidade.ToString();
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            cliente.Excluir();
            this.Close();
        }

        private void FrmClientesCadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
