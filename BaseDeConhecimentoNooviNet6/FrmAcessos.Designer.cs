namespace BaseDeConhecimentoNooviNet6
{
    partial class FrmAcessos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcessos));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtProcurar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnListarDocumentacao = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dgvAcessos = new System.Windows.Forms.DataGridView();
            this.btnAplicativo = new System.Windows.Forms.Button();
            this.btnWinSCP = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcessos)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txtProcurar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 65);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(801, 27);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // txtProcurar
            // 
            this.txtProcurar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProcurar.Location = new System.Drawing.Point(148, 3);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.Size = new System.Drawing.Size(650, 27);
            this.txtProcurar.TabIndex = 2;
            this.txtProcurar.TextChanged += new System.EventHandler(this.txtProcurar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pesquisar Acesso";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(818, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 28);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnListarDocumentacao
            // 
            this.btnListarDocumentacao.Location = new System.Drawing.Point(11, 14);
            this.btnListarDocumentacao.Name = "btnListarDocumentacao";
            this.btnListarDocumentacao.Size = new System.Drawing.Size(94, 29);
            this.btnListarDocumentacao.TabIndex = 11;
            this.btnListarDocumentacao.Text = "Atualizar";
            this.btnListarDocumentacao.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.btnExcluir, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnAdicionar, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnAlterar, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnVoltar, 3, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(11, 460);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(989, 42);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(297, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(132, 36);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(159, 3);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(132, 36);
            this.btnAdicionar.TabIndex = 1;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(3, 3);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(150, 36);
            this.btnAlterar.TabIndex = 0;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVoltar.Location = new System.Drawing.Point(854, 3);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(132, 36);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // dgvAcessos
            // 
            this.dgvAcessos.AllowUserToAddRows = false;
            this.dgvAcessos.AllowUserToDeleteRows = false;
            this.dgvAcessos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAcessos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAcessos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcessos.Location = new System.Drawing.Point(11, 104);
            this.dgvAcessos.Name = "dgvAcessos";
            this.dgvAcessos.ReadOnly = true;
            this.dgvAcessos.RowHeadersWidth = 51;
            this.dgvAcessos.RowTemplate.Height = 29;
            this.dgvAcessos.Size = new System.Drawing.Size(890, 350);
            this.dgvAcessos.TabIndex = 8;
            this.dgvAcessos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAcessos_CellClick);
            this.dgvAcessos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAcessos_CellContentClick);
            this.dgvAcessos.SelectionChanged += new System.EventHandler(this.dgvAcessos_SelectionChanged);
            this.dgvAcessos.DoubleClick += new System.EventHandler(this.dgvAcessos_DoubleClick);
            // 
            // btnAplicativo
            // 
            this.btnAplicativo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicativo.Location = new System.Drawing.Point(907, 104);
            this.btnAplicativo.Name = "btnAplicativo";
            this.btnAplicativo.Size = new System.Drawing.Size(99, 73);
            this.btnAplicativo.TabIndex = 17;
            this.btnAplicativo.Text = "Nenhum Aplicativo Disponível";
            this.btnAplicativo.UseVisualStyleBackColor = true;
            this.btnAplicativo.Click += new System.EventHandler(this.btnAplicativo_Click);
            // 
            // btnWinSCP
            // 
            this.btnWinSCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWinSCP.Location = new System.Drawing.Point(907, 183);
            this.btnWinSCP.Name = "btnWinSCP";
            this.btnWinSCP.Size = new System.Drawing.Size(99, 73);
            this.btnWinSCP.TabIndex = 18;
            this.btnWinSCP.Text = "Abrir WinSCP";
            this.btnWinSCP.UseVisualStyleBackColor = true;
            this.btnWinSCP.Visible = false;
            this.btnWinSCP.Click += new System.EventHandler(this.btnWinSCP_Click);
            // 
            // FrmAcessos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 516);
            this.Controls.Add(this.btnWinSCP);
            this.Controls.Add(this.btnAplicativo);
            this.Controls.Add(this.dgvAcessos);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnListarDocumentacao);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAcessos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acessos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAcessos_FormClosing);
            this.Load += new System.EventHandler(this.FrmAcessos_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcessos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtProcurar;
        private Label label1;
        private ComboBox comboBox1;
        private Button btnListarDocumentacao;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnExcluir;
        private Button btnAdicionar;
        private Button btnAlterar;
        private Button btnVoltar;
        private DataGridView dgvAcessos;
        private Button btnAplicativo;
        private Button btnWinSCP;
    }
}