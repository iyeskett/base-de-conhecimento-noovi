using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNoovi
{
    public partial class frmEditorDeTexto : Form
    {
        int IdDocumentacao;
        bool excluir;
        bool recarregou = false;
        bool EntrouPeloMenu;
        bool atualizar;

        FontDialog fontDialog;
        Font font;
        bool textoImportado = false;
        bool bold = false;
        bool italic = false;
        bool underline = false;

        public frmEditorDeTexto(int idDocumentacao, bool excluir = false, bool entrouPeloMenu = true, bool atualizar = false)
        {
            this.IdDocumentacao = idDocumentacao;
            this.excluir = excluir;
            this.EntrouPeloMenu = entrouPeloMenu;
            this.atualizar = atualizar;
            InitializeComponent();
            DesativarBotoes();
        }

        private void DesativarBotoes()
        {
            btnNegrito.Visible = false;
            btnSublinhado.Visible = false;
            btnItalico.Visible = false;
            btnCor.Visible = false;
        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            SalvarArquivo();
        }

        private void SalvarArquivo()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = @"c:\";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var salvar = true;
                if (dialog.FileName.IndexOf(".") == -1)
                {
                    dialog.FileName += ".rtf";
                    var resposta = MessageBox.Show($"{dialog.FileName} já existe. \nDeseja substituí-lo?"
                        , "Confirmar salvar como", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resposta != DialogResult.Yes)
                    {
                        salvar = false;
                    }

                }

                if (salvar)
                {
                    richTextBox1.SaveFile(dialog.FileName);
                }

            }
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"c:\";
            dialog.Filter = "Arquivos Rich Text Format | *.rtf;*.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName.IndexOf(".rtf") == -1)
                {
                    richTextBox1.Text = File.ReadAllText(dialog.FileName);
                }
                else
                {
                    richTextBox1.LoadFile(dialog.FileName);
                    textoImportado = true;
                }
                
            }

            if (textoImportado)
            {
                GetFonte();
            }
        }

        private void btnFonte_Click(object sender, EventArgs e)
        {
            fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }

        private void btnNegrito_Click(object sender, EventArgs e)
        {
            if (!bold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
                bold = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
                bold = false;
            }
            
        }

        private void btnSublinhado_Click(object sender, EventArgs e)
        {
            if (!underline)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline);
                underline = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
                underline = false;
            }
        }

        private void btnItalico_Click(object sender, EventArgs e)
        {
            if (!italic)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Italic);
                italic = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
                italic = false;
            }

        }

        private void btnCor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();

            if (color.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = color.Color;
            }
            
        }

        public void GetFonte()
        {
            richTextBox1.SelectAll();
            font = richTextBox1.SelectionFont;
            Console.WriteLine(font);
        }

        private void btnRedefinir_Click(object sender, EventArgs e)
        {
            var tamanhoFont = richTextBox1.Font.Size;
            string tempTxt = richTextBox1.Text;
            richTextBox1.Clear();
            richTextBox1.Text = tempTxt;
            richTextBox1.Font = font;
            

            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            frmDocumentacaoCadastro frmDocumentacaoCadastro = new frmDocumentacaoCadastro(IdDocumentacao,excluir,EntrouPeloMenu,atualizar);
            frmDocumentacaoCadastro.rtbDescricao.Text = richTextBox1.Text;
            GetFonte();
            frmDocumentacaoCadastro.rtbDescricao.Font = font;
            Hide();
            frmDocumentacaoCadastro.ShowDialog();
            
        }

        private void frmEditorDeTexto_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            var tamanhoFonte = richTextBox1.SelectionFont.Size;
            tamanhoFonte -= 2;
            richTextBox1.Font = new Font(richTextBox1.Font.Name, tamanhoFonte);
        }

        private void btnAumentar_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            var tamanhoFonte = richTextBox1.SelectionFont.Size;
            tamanhoFonte += 2;
            richTextBox1.Font = new Font(richTextBox1.Font.Name, tamanhoFonte);
        }
    }
}
