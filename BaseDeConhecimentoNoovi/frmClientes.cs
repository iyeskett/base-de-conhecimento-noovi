using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNoovi
{
    public partial class frmClientes : Form
    {
        DataTable dtClientes = new DataTable();

        public frmClientes()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            dtClientes = Cliente.GetClientes();
            dgvCliente.DataSource = dtClientes;
            ConfigurarGrade();
        }

        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            dtClientes = Cliente.GetClientes();
            dgvCliente.DataSource = dtClientes;
            ConfigurarGrade();
        }

        private void ConfigurarGrade()
        {
            dgvCliente.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvCliente.DefaultCellStyle.Font = new Font("Arial", 9);
            dgvCliente.RowHeadersWidth = 25;

            dgvCliente.Columns["idCliente"].HeaderText = "ID";
            dgvCliente.Columns["idCliente"].Visible = false;

            dgvCliente.Columns["nomeCliente"].HeaderText = "CLIENTE";
            dgvCliente.Columns["nomeCliente"].Width = 130;
            dgvCliente.Columns["nomeCliente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCliente.Columns["nomeCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCliente.Sort(dgvCliente.Columns["nomeCliente"], ListSortDirection.Ascending);
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentCell.RowIndex].Cells["idCliente"].Value);

            using (var frm = new FrmClientesCadastro(id))
            {
                frm.ShowDialog();
                dgvCliente.DataSource = Cliente.GetClientes();

            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
    
            using (var frm = new FrmClientesCadastro(0))
            {
                frm.ShowDialog();
                dgvCliente.DataSource = Cliente.GetClientes();
            }
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            dtClientes = Cliente.GetClientes(txtProcurar.Text);
            dgvCliente.DataSource = dtClientes;
            ConfigurarGrade();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentCell.RowIndex].Cells["idCliente"].Value);

            using (var frm = new FrmClientesCadastro(id, true))
            {
                frm.ShowDialog();
                dgvCliente.DataSource = Cliente.GetClientes();
                ConfigurarGrade();

            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            Hide();
        }

        private void btnBaseConhecimento_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentCell.RowIndex].Cells["idCliente"].Value);

            frmDocumentacoes frmDocumentacoes = new frmDocumentacoes(id);
            frmDocumentacoes.Show();
            Hide();
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
