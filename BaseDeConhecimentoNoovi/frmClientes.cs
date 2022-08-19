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

        public void Inicializar()
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
            Banco.GetUsuarios();
            lblUsuarios.Text = Banco.quantidade.ToString();
        }

        private void ConfigurarGrade()
        {
            dgvCliente.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvCliente.DefaultCellStyle.Font = new Font("Arial", 9);
            dgvCliente.RowHeadersWidth = 25;

            dgvCliente.Columns["idCliente"].HeaderText = "ID";
            dgvCliente.Columns["idCliente"].Visible = false;

            dgvCliente.Columns["nomeCliente"].HeaderText = "CLIENTE";
            // dgvCliente.Columns["nomeCliente"].Width = 130;
            dgvCliente.Columns["nomeCliente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCliente.Columns["nomeCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCliente.Sort(dgvCliente.Columns["nomeCliente"], ListSortDirection.Ascending);
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            Banco.GetUsuarios();
            lblUsuarios.Text = Banco.quantidade.ToString();

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
                Inicializar();

            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            using (var frm = new FrmClientesCadastro(0))
            {
                frm.ShowDialog();
                Inicializar();
            }
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtClientes)
            {
                RowFilter = $"nomeCLiente LIKE '%{txtProcurar.Text}%'"
            };



            dgvCliente.DataSource = dv;

            ConfigurarGrade();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentCell.RowIndex].Cells["idCliente"].Value);

            using (var frm = new FrmClientesCadastro(id, true))
            {
                frm.ShowDialog();
                Inicializar();

            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Program.ShowMenu();
            Dispose();
        }

        private void btnBaseConhecimento_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentCell.RowIndex].Cells["idCliente"].Value);

            frmDocumentacoes frmDocumentacoes = new frmDocumentacoes(id);
            frmDocumentacoes.Show();
            Dispose();
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
