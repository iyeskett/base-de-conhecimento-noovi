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
    public partial class frmDocumentacaoCadastro : Form
    {
        DataTable dtDocumentacoes = new DataTable();
        Documentacao documentacao = new Documentacao();

        int IdDocumentacao;
        bool excluir;
        bool recarregou = false;
        bool EntrouPeloMenu;
        bool atualizar;
        public frmDocumentacaoCadastro(int idDocumentacao, bool excluir = false, bool entrouPeloMenu = true, bool atualizar = false)
        {
            InitializeComponent();
            Inicializar();
            this.IdDocumentacao = idDocumentacao;
            this.excluir = excluir;
            this.EntrouPeloMenu = entrouPeloMenu;
            this.atualizar = atualizar;

            if (idDocumentacao > 0)
            {
                lblId.Text = idDocumentacao.ToString();
                documentacao.GetDocumentacao(IdDocumentacao);

                Console.WriteLine(comboBox1.Text);
                DataTable dtNomeCli = Documentacao.GetNomeCliente(documentacao.IdCliente);
                comboBox1.DataSource = dtNomeCli;
                comboBox1.DisplayMember = "nomeCLiente";
                comboBox1.ValueMember = "idCLiente";
                txtTitulo.Text = documentacao.Titulo;
                rtbDescricao.Text = documentacao.Descricao;
                txtLink.Text = documentacao.Link;
            }
            

            if (this.excluir)
            {
                TravarControles();
                DataTable dtNomeCli = Documentacao.GetNomeCliente(documentacao.IdCliente);
                comboBox1.DataSource = dtNomeCli;
                comboBox1.DisplayMember = "nomeCLiente";
                comboBox1.ValueMember = "idCLiente";
                btnSalvar.Visible = false;
                btnExcluir.Visible = true;
            }

        }

        //public frmDocumentacaoCadastro(int idDocumentacao, bool entrouPeloMenu = true, bool atualizar = false)
        //{
        //    InitializeComponent();
        //    Inicializar();
        //    this.IdDocumentacao = idDocumentacao;
        //    this.EntrouPeloMenu = entrouPeloMenu;

        //    if (idDocumentacao > 0 && atualizar)
        //    {


        //        lblId.Text = idDocumentacao.ToString();
        //        documentacao.GetDocumentacao(IdDocumentacao);

        //        Console.WriteLine(comboBox1.Text);
        //        DataTable dtNomeCli = Documentacao.GetNomeCliente(documentacao.IdCliente);
        //        comboBox1.DataSource = dtNomeCli;
        //        comboBox1.DisplayMember = "nomeCLiente";
        //        comboBox1.ValueMember = "idCLiente";
        //        comboBox1.Enabled = false;
        //        txtTitulo.Text = documentacao.Titulo;
        //        txtDescricao.Text = documentacao.Descricao;
        //        txtLink.Text = documentacao.Link;


        //    }
        //}

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
            dtDocumentacoes = Documentacao.GetClienteIdDocumentacoes();
            comboBox1.DataSource = dtDocumentacoes;
            comboBox1.DisplayMember = "nomeCliente";
            comboBox1.ValueMember = "idCliente";

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            documentacao.Excluir(IdDocumentacao);
            this.Close();
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                if (documentacao.IdDocumentacao > 0)
                {
                    documentacao.IdDocumentacao = int.Parse(lblId.Text);
                }

                var idCli = Convert.ToInt32(Convert.ToString(comboBox1.SelectedValue));
                documentacao.IdCliente = idCli;
                documentacao.Titulo = txtTitulo.Text;
                documentacao.Descricao = rtbDescricao.Text;
                documentacao.Link = txtLink.Text;

                documentacao.SalvarDocumento();
                this.Close();
            }

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            if (!recarregou)
            {
                Inicializar();
                recarregou = true;
            }

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (!EntrouPeloMenu)
            {
                var idCli = Convert.ToInt32(Convert.ToString(comboBox1.SelectedValue));
                documentacao.IdCliente = idCli;
                Console.WriteLine(idCli);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frmDocumentacaoCadastro_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            Banco.GetUsuarios();
            lblUsuarios.Text = Banco.quantidade.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEditorDeTexto frmEditorDeTexto = new frmEditorDeTexto(IdDocumentacao, excluir, EntrouPeloMenu,atualizar);
            frmEditorDeTexto.richTextBox1.Text = rtbDescricao.Text;
            Hide();
            frmEditorDeTexto.ShowDialog();
            

        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
