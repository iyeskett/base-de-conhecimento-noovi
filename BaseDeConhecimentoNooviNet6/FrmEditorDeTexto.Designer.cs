namespace BaseDeConhecimentoNooviNet6
{
    partial class FrmEditorDeTexto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditorDeTexto));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.abrirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.salvarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnRedefinir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnFonte = new System.Windows.Forms.Button();
            this.btnNegrito = new System.Windows.Forms.Button();
            this.btnSublinhado = new System.Windows.Forms.Button();
            this.btnItalico = new System.Windows.Forms.Button();
            this.btnCor = new System.Windows.Forms.Button();
            this.btnDiminuir = new System.Windows.Forms.Button();
            this.btnAumentar = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripButton,
            this.salvarToolStripButton,
            this.toolStripSeparator1,
            this.toolStripSeparator});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(667, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // abrirToolStripButton
            // 
            this.abrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.abrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripButton.Image")));
            this.abrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrirToolStripButton.Name = "abrirToolStripButton";
            this.abrirToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.abrirToolStripButton.Text = "&Abrir";
            this.abrirToolStripButton.Click += new System.EventHandler(this.abrirToolStripButton_Click);
            // 
            // salvarToolStripButton
            // 
            this.salvarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.salvarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("salvarToolStripButton.Image")));
            this.salvarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvarToolStripButton.Name = "salvarToolStripButton";
            this.salvarToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.salvarToolStripButton.Text = "&Salvar";
            this.salvarToolStripButton.Click += new System.EventHandler(this.salvarToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 79);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(643, 292);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // btnRedefinir
            // 
            this.btnRedefinir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRedefinir.Location = new System.Drawing.Point(469, 377);
            this.btnRedefinir.Name = "btnRedefinir";
            this.btnRedefinir.Size = new System.Drawing.Size(186, 27);
            this.btnRedefinir.TabIndex = 2;
            this.btnRedefinir.Text = "Redefinir Formatação";
            this.btnRedefinir.UseVisualStyleBackColor = true;
            this.btnRedefinir.Click += new System.EventHandler(this.btnRedefinir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(520, 44);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(135, 29);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnFonte
            // 
            this.btnFonte.Location = new System.Drawing.Point(12, 44);
            this.btnFonte.Name = "btnFonte";
            this.btnFonte.Size = new System.Drawing.Size(75, 29);
            this.btnFonte.TabIndex = 4;
            this.btnFonte.Text = "Fonte";
            this.btnFonte.UseVisualStyleBackColor = true;
            this.btnFonte.Click += new System.EventHandler(this.btnFonte_Click);
            // 
            // btnNegrito
            // 
            this.btnNegrito.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNegrito.Location = new System.Drawing.Point(93, 44);
            this.btnNegrito.Name = "btnNegrito";
            this.btnNegrito.Size = new System.Drawing.Size(75, 29);
            this.btnNegrito.TabIndex = 5;
            this.btnNegrito.Text = "Negrito";
            this.btnNegrito.UseVisualStyleBackColor = true;
            this.btnNegrito.Click += new System.EventHandler(this.btnNegrito_Click);
            // 
            // btnSublinhado
            // 
            this.btnSublinhado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.btnSublinhado.Location = new System.Drawing.Point(174, 44);
            this.btnSublinhado.Name = "btnSublinhado";
            this.btnSublinhado.Size = new System.Drawing.Size(94, 29);
            this.btnSublinhado.TabIndex = 6;
            this.btnSublinhado.Text = "Sublinhado";
            this.btnSublinhado.UseVisualStyleBackColor = true;
            this.btnSublinhado.Click += new System.EventHandler(this.btnSublinhado_Click);
            // 
            // btnItalico
            // 
            this.btnItalico.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnItalico.Location = new System.Drawing.Point(274, 44);
            this.btnItalico.Name = "btnItalico";
            this.btnItalico.Size = new System.Drawing.Size(75, 29);
            this.btnItalico.TabIndex = 7;
            this.btnItalico.Text = "Itálico";
            this.btnItalico.UseVisualStyleBackColor = true;
            this.btnItalico.Click += new System.EventHandler(this.btnItalico_Click);
            // 
            // btnCor
            // 
            this.btnCor.Location = new System.Drawing.Point(355, 44);
            this.btnCor.Name = "btnCor";
            this.btnCor.Size = new System.Drawing.Size(75, 29);
            this.btnCor.TabIndex = 8;
            this.btnCor.Text = "Cor";
            this.btnCor.UseVisualStyleBackColor = true;
            this.btnCor.Click += new System.EventHandler(this.btnCor_Click);
            // 
            // btnDiminuir
            // 
            this.btnDiminuir.Location = new System.Drawing.Point(93, 44);
            this.btnDiminuir.Name = "btnDiminuir";
            this.btnDiminuir.Size = new System.Drawing.Size(33, 29);
            this.btnDiminuir.TabIndex = 9;
            this.btnDiminuir.Text = "-";
            this.btnDiminuir.UseVisualStyleBackColor = true;
            this.btnDiminuir.Click += new System.EventHandler(this.btnDiminuir_Click);
            // 
            // btnAumentar
            // 
            this.btnAumentar.Location = new System.Drawing.Point(135, 44);
            this.btnAumentar.Name = "btnAumentar";
            this.btnAumentar.Size = new System.Drawing.Size(33, 29);
            this.btnAumentar.TabIndex = 10;
            this.btnAumentar.Text = "+";
            this.btnAumentar.UseVisualStyleBackColor = true;
            this.btnAumentar.Click += new System.EventHandler(this.btnAumentar_Click);
            // 
            // FrmEditorDeTexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 409);
            this.Controls.Add(this.btnAumentar);
            this.Controls.Add(this.btnDiminuir);
            this.Controls.Add(this.btnCor);
            this.Controls.Add(this.btnItalico);
            this.Controls.Add(this.btnSublinhado);
            this.Controls.Add(this.btnNegrito);
            this.Controls.Add(this.btnFonte);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnRedefinir);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEditorDeTexto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEditorDeTexto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditorDeTexto_FormClosing);
            this.Load += new System.EventHandler(this.FrmEditorDeTexto_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton abrirToolStripButton;
        private ToolStripButton salvarToolStripButton;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripSeparator toolStripSeparator1;
        private Button btnRedefinir;
        private Button btnSalvar;
        private Button btnFonte;
        private Button btnNegrito;
        private Button btnSublinhado;
        private Button btnItalico;
        private Button btnCor;
        private Button btnDiminuir;
        private Button btnAumentar;
        public RichTextBox richTextBox1;
    }
}