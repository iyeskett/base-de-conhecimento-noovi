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
            dtClientes = ClienteSQLite.GetClientes();
            dgvCliente.DataSource = dtClientes;
            if (dgvCliente.RowCount == 0)
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            ConfigurarGrade();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            this.MinimumSize = new Size(Width, Height);
            BancoSQLite.GetUsuarios();
            lblUsuarios.Text = BancoSQLite.quantidade.ToString();
        }



        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentCell.RowIndex].Cells["idCliente"].Value);

            using (var frm = new frmClientesCadastro(id))
            {
                frm.ShowDialog();
                Inicializar();

            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (var frm = new frmClientesCadastro(0))
            {
                frm.ShowDialog();
                Inicializar();
            }
        }

       

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Program.ShowMenu();
            if (this.WindowState == FormWindowState.Maximized)
            {
                Program.MaximizeMenu();
            }
            Dispose();
        }

        private void btnListarCliente_Click(object sender, EventArgs e)
        {
            dtClientes = ClienteSQLite.GetClientes();
            dgvCliente.DataSource = dtClientes;
            ConfigurarGrade();
            BancoSQLite.GetUsuarios();
            lblUsuarios.Text = BancoSQLite.quantidade.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentCell.RowIndex].Cells["idCliente"].Value);

            using (var frm = new frmClientesCadastro(id, true))
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

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBaseConhecimento_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentCell.RowIndex].Cells["idCliente"].Value);

            FrmDocumentacoes frmDocumentacoes = new FrmDocumentacoes(id);
            frmDocumentacoes.Show();
            Program.VerifyWindowsState(frmDocumentacoes, this.WindowState);
            Dispose();
        }

    }
}
