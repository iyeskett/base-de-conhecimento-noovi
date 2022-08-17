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
    public partial class frmDocumentacoes : Form
    {
        DataTable dtDocumentacoes = new DataTable();
        int IdCliente;
        public frmDocumentacoes(int id)
        {
            this.IdCliente = id;
            InitializeComponent();
            Inicializar();
            
        }

        private void frmDocumentacoes_Load(object sender, EventArgs e)
        {

        }

        private void Inicializar()
        {
            dtDocumentacoes = Documentacao.GetDocumentacoes(IdCliente);
            dgvDocumentacoes.DataSource = dtDocumentacoes;
            ConfigurarGrade();
        }

        private void ConfigurarGrade()
        {
            dgvDocumentacoes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvDocumentacoes.DefaultCellStyle.Font = new Font("Arial", 9);
            dgvDocumentacoes.RowHeadersWidth = 25;

            dgvDocumentacoes.Columns["idCliente"].HeaderText = "ID";
            dgvDocumentacoes.Columns["idCliente"].Visible = false;

            dgvDocumentacoes.Columns["idCliente1"].HeaderText = "ID";
            dgvDocumentacoes.Columns["idCliente1"].Visible = false;

            dgvDocumentacoes.Columns["idDocumentacao"].HeaderText = "ID";
            dgvDocumentacoes.Columns["idDocumentacao"].Visible = false;

            dgvDocumentacoes.Columns["nomeCliente"].HeaderText = "CLIENTE";
            dgvDocumentacoes.Columns["nomeCliente"].DisplayIndex = 0;
            dgvDocumentacoes.Columns["nomeCliente"].Width = 130;
            dgvDocumentacoes.Columns["nomeCliente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentacoes.Columns["nomeCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvDocumentacoes.Columns["titulo"].HeaderText = "TITULO";
            dgvDocumentacoes.Columns["titulo"].Width = 130;
            dgvDocumentacoes.Columns["titulo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentacoes.Columns["titulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDocumentacoes.Columns["descricao"].HeaderText = "DESCRIÇÃO";
            dgvDocumentacoes.Columns["descricao"].Width = 130;
            dgvDocumentacoes.Columns["descricao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentacoes.Columns["descricao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDocumentacoes.Columns["link"].HeaderText = "LINK";
            dgvDocumentacoes.Columns["link"].Width = 130;
            dgvDocumentacoes.Columns["link"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentacoes.Columns["link"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDocumentacoes.Sort(dgvDocumentacoes.Columns["titulo"], ListSortDirection.Ascending);
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            dtDocumentacoes = Documentacao.GetDocumentacoes(this.IdCliente, txtProcurar.Text);
            dgvDocumentacoes.DataSource = dtDocumentacoes;
            ConfigurarGrade();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.Show();
            Hide();
        }

        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            dtDocumentacoes = Documentacao.GetDocumentacoes(IdCliente);
            dgvDocumentacoes.DataSource = dtDocumentacoes;
            ConfigurarGrade();
        }
    }
}
