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
    public partial class FrmDocumentacoes : Form
    {
        DataTable dtDocumentacoes = new DataTable();
        int IdCliente;
        bool entrouPeloMenu;
        bool Excluir;


        /// <summary>
        /// Abre as documentações do cliente
        /// </summary>
        /// <param name="idCliente">id do Cliente para buscar suas documentações</param>
        public FrmDocumentacoes(int idCliente)
        {
            this.IdCliente = idCliente;
            InitializeComponent();
            Inicializar();
        }

        /// <summary>
        /// Abre as documentações de todos os cliente
        /// </summary>
        public FrmDocumentacoes()
        {
            this.IdCliente = 0;
            InitializeComponent();
            Inicializar();
        }

        public void EntrouPeloMenu()
        {
            this.entrouPeloMenu = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Excluir = false;
            var idDocumento = Convert.ToInt32(dgvDocumentacoes.Rows[dgvDocumentacoes.CurrentCell.RowIndex].Cells["idDocumentacao"].Value);

            using (var frm = new FrmDocumentacaoCadastro(idDocumento, entrouPeloMenu, Excluir, true))
            {
                frm.ShowDialog();
                if (IdCliente > 0)
                    dgvDocumentacoes.DataSource = Documentacao.GetDocumentacoes(IdCliente);
                else
                    dgvDocumentacoes.DataSource = Documentacao.GetDocumentacoes(0);
                Inicializar();

            }
        }

        public void Inicializar()
        {
            dtDocumentacoes = Documentacao.GetDocumentacoes(IdCliente);
            dgvDocumentacoes.DataSource = dtDocumentacoes;

            /* 
                Verifica se o DataGridView está vazio, se estiver desativa os botões de alterar e excluir
                para evitar erros.
            */
            if (dgvDocumentacoes.RowCount == 0)
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            else
            {
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
            }
            ConfigurarGrade();
        }

        /// <summary>
        /// Configura os dados da DataGridView
        /// </summary>
        private void ConfigurarGrade()
        {
            // Selecionando o tipo de fonte da DGV
            dgvDocumentacoes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvDocumentacoes.DefaultCellStyle.Font = new Font("Arial", 9);
            dgvDocumentacoes.RowHeadersWidth = 25;

            // Desativando o idCliente do select
            dgvDocumentacoes.Columns["idCliente"].HeaderText = "ID";
            dgvDocumentacoes.Columns["idCliente"].Visible = false;

            // Desativando o idCliente do select
            dgvDocumentacoes.Columns["idCliente1"].HeaderText = "ID";
            dgvDocumentacoes.Columns["idCliente1"].Visible = false;

            // Desativando o id da documentãção do select
            dgvDocumentacoes.Columns["idDocumentacao"].HeaderText = "ID";
            dgvDocumentacoes.Columns["idDocumentacao"].Visible = false;


            // Passando o nome do cliente para a DGV
            dgvDocumentacoes.Columns["nomeCliente"].HeaderText = "CLIENTE";
            dgvDocumentacoes.Columns["nomeCliente"].DisplayIndex = 0;
            //dgvDocumentacoes.Columns["nomeCliente"].Width = 130;
            dgvDocumentacoes.Columns["nomeCliente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentacoes.Columns["nomeCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // Passando o titulo da documentação para a DGV
            dgvDocumentacoes.Columns["titulo"].HeaderText = "TITULO";
            // dgvDocumentacoes.Columns["titulo"].Width = 130;
            dgvDocumentacoes.Columns["titulo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentacoes.Columns["titulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Passando a descrição da documentação para a DGV
            dgvDocumentacoes.Columns["descricao"].HeaderText = "DESCRIÇÃO";
            // dgvDocumentacoes.Columns["descricao"].Width = 130;
            dgvDocumentacoes.Columns["descricao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentacoes.Columns["descricao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Passando o link da documentação para a DGV
            dgvDocumentacoes.Columns["link"].HeaderText = "LINK";
            // dgvDocumentacoes.Columns["link"].Width = 130;
            dgvDocumentacoes.Columns["link"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentacoes.Columns["link"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ordenando a documentação por titulo de forma alfabetia e crescente(A-Z)
            dgvDocumentacoes.Sort(dgvDocumentacoes.Columns["titulo"], ListSortDirection.Ascending);
        }

        private void FrmDocumentacoes_Load(object sender, EventArgs e)
        {
            Banco.GetUsuarios();
            lblUsuarios.Text = Banco.quantidade.ToString();
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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Excluir = false;
            var idDocumentacao = 0;
            if (dgvDocumentacoes.Rows.Count != 0)
            {
                idDocumentacao = Convert.ToInt32(dgvDocumentacoes.Rows[dgvDocumentacoes.CurrentCell.RowIndex].Cells["idDocumentacao"].Value);

            }
            using (var frm = new FrmDocumentacaoCadastro(idDocumentacao, entrouPeloMenu, Excluir))
            {
                frm.ShowDialog();
                if (IdCliente > 0)
                {
                    dgvDocumentacoes.DataSource = Documentacao.GetDocumentacoes(IdCliente);
                }
                else
                    dgvDocumentacoes.DataSource = Documentacao.GetDocumentacoes(0);
                Inicializar();

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvDocumentacoes.Rows[dgvDocumentacoes.CurrentCell.RowIndex].Cells["idDocumentacao"].Value);
            Excluir = true;

            using (var frm = new FrmDocumentacaoCadastro(id, entrouPeloMenu, Excluir))
            {
                frm.ShowDialog();
                dgvDocumentacoes.DataSource = Documentacao.GetDocumentacoes(IdCliente);
                Inicializar();

            }
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

        private void btnListarDocumentacao_Click(object sender, EventArgs e)
        {
            dtDocumentacoes = Documentacao.GetDocumentacoes(IdCliente);
            dgvDocumentacoes.DataSource = dtDocumentacoes;
            ConfigurarGrade();
            Banco.GetUsuarios();
            lblUsuarios.Text = Banco.quantidade.ToString();
        }

        private void FrmDocumentacoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
