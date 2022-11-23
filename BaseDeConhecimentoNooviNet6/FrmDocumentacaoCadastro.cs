using BaseDeConhecimentoNooviNet6.Models;
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
    public partial class FrmDocumentacaoCadastro : Form
    {
        DataTable dtDocumentacoes = new DataTable();
        // Documentacao documentacao = new Documentacao();
        DocumentacaoSQLite documentacaoSQLite = new DocumentacaoSQLite();
        public FrmDocumentacaoCadastro frmDocumentacaoCadastro;

        Documentacao documentacao = new Documentacao();
        bool EntrouPeloMenu;
        bool Excluir;

        public FrmDocumentacaoCadastro(Documentacao documentacao, bool entrouPeloMenu, bool excluir)
        {
            InitializeComponent();
            Inicializar();
            Excluir = excluir;
            EntrouPeloMenu = entrouPeloMenu;

            if (documentacao.IdDocumentacao > 0)
            {
                lblId.Text = documentacao.IdDocumentacao.ToString();
                this.documentacao = DocumentacaoSQLite.GetDocumentacao(documentacao.IdDocumentacao);

                DataTable dtNomeCli = DocumentacaoSQLite.GetNomeCliente(documentacao.IdCliente);
                comboBox1.DataSource = dtNomeCli;
                comboBox1.DisplayMember = "nomeCliente";
                comboBox1.ValueMember = "idCliente";
                if (!entrouPeloMenu)
                {
                    comboBox1.Enabled = false;
                }

            }

            if (this.Excluir)
            {
                TravarControles();
                DataTable dtNomeCli = DocumentacaoSQLite.GetNomeCliente(documentacao.IdCliente);
                comboBox1.DataSource = dtNomeCli;
                comboBox1.DisplayMember = "nomeCLiente";
                comboBox1.ValueMember = "idCLiente";
                txtTitulo.Text = documentacao.Titulo;
                txtLink.Text = documentacao.Link;
                rtbDescricao.Text = documentacao.Descricao;
                btnEditorTexto.Enabled = false;
                btnSalvar.Visible = false;
                btnExcluir.Visible = true;
            }

        }

        public FrmDocumentacaoCadastro(Documentacao documentacao, bool entrouPeloMenu, bool excluir, bool alterar)
        {
            InitializeComponent();
            Inicializar();
            Excluir = excluir;
            EntrouPeloMenu = entrouPeloMenu;

            if (documentacao.IdDocumentacao > 0)
            {
                lblId.Text = documentacao.IdDocumentacao.ToString();
                this.documentacao = DocumentacaoSQLite.GetDocumentacao(documentacao.IdDocumentacao);

                DataTable dtNomeCli = DocumentacaoSQLite.GetNomeCliente(documentacao.IdCliente);
                comboBox1.DataSource = dtNomeCli;
                comboBox1.DisplayMember = "nomeCLiente";
                comboBox1.ValueMember = "idCLiente";
                txtTitulo.Text = documentacao.Titulo;
                rtbDescricao.Text = documentacao.Descricao;
                txtLink.Text = documentacao.Link;
                if (!entrouPeloMenu)
                {
                    comboBox1.Enabled = false;
                }

            }
        }

        private void TravarControles()
        {
            comboBox1.Enabled = false;
            lblId.Enabled = false;
            txtTitulo.Enabled = false;
            rtbDescricao.Enabled = false;
            txtLink.Enabled = false;
        }

        private void Inicializar()
        {
            dtDocumentacoes = DocumentacaoSQLite.GetClienteAlfabeticamente();
            comboBox1.DataSource = dtDocumentacoes;
            comboBox1.DisplayMember = "nomeCliente";
            comboBox1.ValueMember = "idCliente";

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DocumentacaoSQLite.Excluir(documentacao.IdDocumentacao);
            this.Close();
        }

        private bool ValidarForm()
        {
            if (txtTitulo.Text == "")
            {
                MessageBox.Show("Informe o nome da documentação.");
                txtTitulo.Focus();
                return false;
            }
            if (rtbDescricao.Text == "")
            {
                MessageBox.Show("Informe a descrição da documentação.");
                txtTitulo.Focus();
                return false;
            }
            return true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                var idCli = Convert.ToInt32(Convert.ToString(comboBox1.SelectedValue));
                documentacao.IdCliente = idCli;
                documentacao.Titulo = txtTitulo.Text;
                documentacao.Descricao = rtbDescricao.Text;
                documentacao.Link = txtLink.Text;

                DocumentacaoSQLite.SalvarDocumentação(documentacao);
                this.Close();
            }
        }

        private void FrmDocumentacaoCadastro_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void btnEditorTexto_Click(object sender, EventArgs e)
        {
            FrmEditorDeTexto frmEditorDeTexto = new FrmEditorDeTexto(documentacao.IdDocumentacao, Excluir, EntrouPeloMenu);
            frmEditorDeTexto.frmDocumentacaoCadastro = frmDocumentacaoCadastro;
            frmEditorDeTexto.richTextBox1.Text = rtbDescricao.Text;
            frmEditorDeTexto.ShowDialog();
        }

        private void FrmDocumentacaoCadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            dtDocumentacoes = DocumentacaoSQLite.GetClienteAlfabeticamente();
            comboBox1.DataSource = dtDocumentacoes;
            comboBox1.DisplayMember = "nomeCliente";
            comboBox1.ValueMember = "idCliente";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
