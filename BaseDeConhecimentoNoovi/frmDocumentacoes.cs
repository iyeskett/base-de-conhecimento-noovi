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
    public partial class frmDocumentacoes : Form
    {
        DataTable dtDocumentacoes = new DataTable();
        int IdCliente;

        public frmDocumentacoes(int idCliente = 0)
        {
            this.IdCliente = idCliente;
            InitializeComponent();
            Inicializar();

        }

        private void frmDocumentacoes_Load(object sender, EventArgs e)
        {
            Banco.GetUsuarios();
            lblUsuarios.Text = Banco.quantidade.ToString();
        }

        public void Inicializar()
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
            //dgvDocumentacoes.Columns["nomeCliente"].Width = 130;
            dgvDocumentacoes.Columns["nomeCliente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentacoes.Columns["nomeCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvDocumentacoes.Columns["titulo"].HeaderText = "TITULO";
            // dgvDocumentacoes.Columns["titulo"].Width = 130;
            dgvDocumentacoes.Columns["titulo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentacoes.Columns["titulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDocumentacoes.Columns["descricao"].HeaderText = "DESCRIÇÃO";
            // dgvDocumentacoes.Columns["descricao"].Width = 130;
            dgvDocumentacoes.Columns["descricao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentacoes.Columns["descricao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDocumentacoes.Columns["link"].HeaderText = "LINK";
            // dgvDocumentacoes.Columns["link"].Width = 130;
            dgvDocumentacoes.Columns["link"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentacoes.Columns["link"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDocumentacoes.Sort(dgvDocumentacoes.Columns["titulo"], ListSortDirection.Ascending);
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtDocumentacoes)
            {
                RowFilter = $"TITULO LIKE '%{txtProcurar.Text}%' OR DESCRICAO LIKE '%{txtProcurar.Text}%'"
            };



            dgvDocumentacoes.DataSource = dv;

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
            if (IdCliente > 0)
            {
                frmClientes frm = new frmClientes();
                frm.Show();
            }
            else
            {
                Program.ShowMenu();
            }
            
            Dispose();
        }

        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            dtDocumentacoes = Documentacao.GetDocumentacoes(IdCliente);
            dgvDocumentacoes.DataSource = dtDocumentacoes;
            ConfigurarGrade();
            Banco.GetUsuarios();
            lblUsuarios.Text = Banco.quantidade.ToString();
        }

        private void dgvDocumentacoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDocumentacoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvDocumentacoes.Rows[dgvDocumentacoes.CurrentCell.RowIndex].Cells["idDocumentacao"].Value);

            using (var frm = new frmDocumentacaoCadastro(id, true))
            {
                frm.ShowDialog();
                dgvDocumentacoes.DataSource = Documentacao.GetDocumentacoes(IdCliente);
                Inicializar();

            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (var frm = new frmDocumentacaoCadastro(0))
            {
                frm.ShowDialog();
                if (IdCliente > 0)
                    dgvDocumentacoes.DataSource = Documentacao.GetDocumentacoes(IdCliente);
                else
                    dgvDocumentacoes.DataSource = Documentacao.GetDocumentacoes(0);
                Inicializar();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var idDocumento = Convert.ToInt32(dgvDocumentacoes.Rows[dgvDocumentacoes.CurrentCell.RowIndex].Cells["idDocumentacao"].Value);

            using (var frm = new frmDocumentacaoCadastro(idDocumento))
            {
                frm.ShowDialog();
                if (IdCliente > 0)
                    dgvDocumentacoes.DataSource = Documentacao.GetDocumentacoes(IdCliente);
                else
                    dgvDocumentacoes.DataSource = Documentacao.GetDocumentacoes(0);
                Inicializar();

            }
        }
    }
}
