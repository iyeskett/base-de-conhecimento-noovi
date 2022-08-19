namespace BaseDeConhecimentoNoovi
{
    partial class frmEditorDeTexto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditorDeTexto));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.abrirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.salvarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.imprimirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFonte = new System.Windows.Forms.Button();
            this.btnNegrito = new System.Windows.Forms.Button();
            this.btnSublinhado = new System.Windows.Forms.Button();
            this.btnItalico = new System.Windows.Forms.Button();
            this.btnCor = new System.Windows.Forms.Button();
            this.btnRedefinir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnDiminuir = new System.Windows.Forms.Button();
            this.btnAumentar = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 64);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(872, 421);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripButton,
            this.salvarToolStripButton,
            this.imprimirToolStripButton,
            this.toolStripSeparator,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(896, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // abrirToolStripButton
            // 
            this.abrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.abrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripButton.Image")));
            this.abrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrirToolStripButton.Name = "abrirToolStripButton";
            this.abrirToolStripButton.Size = new System.Drawing.Size(29, 28);
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
            // imprimirToolStripButton
            // 
            this.imprimirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imprimirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("imprimirToolStripButton.Image")));
            this.imprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imprimirToolStripButton.Name = "imprimirToolStripButton";
            this.imprimirToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.imprimirToolStripButton.Text = "&Imprimir";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnFonte
            // 
            this.btnFonte.Location = new System.Drawing.Point(12, 30);
            this.btnFonte.Name = "btnFonte";
            this.btnFonte.Size = new System.Drawing.Size(75, 28);
            this.btnFonte.TabIndex = 2;
            this.btnFonte.Text = "Fonte";
            this.btnFonte.UseVisualStyleBackColor = true;
            this.btnFonte.Click += new System.EventHandler(this.btnFonte_Click);
            // 
            // btnNegrito
            // 
            this.btnNegrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNegrito.Location = new System.Drawing.Point(93, 30);
            this.btnNegrito.Name = "btnNegrito";
            this.btnNegrito.Size = new System.Drawing.Size(75, 28);
            this.btnNegrito.TabIndex = 3;
            this.btnNegrito.Text = "Negrito";
            this.btnNegrito.UseVisualStyleBackColor = true;
            this.btnNegrito.Click += new System.EventHandler(this.btnNegrito_Click);
            // 
            // btnSublinhado
            // 
            this.btnSublinhado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSublinhado.Location = new System.Drawing.Point(174, 30);
            this.btnSublinhado.Name = "btnSublinhado";
            this.btnSublinhado.Size = new System.Drawing.Size(90, 28);
            this.btnSublinhado.TabIndex = 4;
            this.btnSublinhado.Text = "Sublinhado";
            this.btnSublinhado.UseVisualStyleBackColor = true;
            this.btnSublinhado.Click += new System.EventHandler(this.btnSublinhado_Click);
            // 
            // btnItalico
            // 
            this.btnItalico.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItalico.Location = new System.Drawing.Point(270, 30);
            this.btnItalico.Name = "btnItalico";
            this.btnItalico.Size = new System.Drawing.Size(75, 28);
            this.btnItalico.TabIndex = 5;
            this.btnItalico.Text = "Itálico";
            this.btnItalico.UseVisualStyleBackColor = true;
            this.btnItalico.Click += new System.EventHandler(this.btnItalico_Click);
            // 
            // btnCor
            // 
            this.btnCor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCor.Location = new System.Drawing.Point(351, 30);
            this.btnCor.Name = "btnCor";
            this.btnCor.Size = new System.Drawing.Size(75, 28);
            this.btnCor.TabIndex = 6;
            this.btnCor.Text = "Cor";
            this.btnCor.UseVisualStyleBackColor = true;
            this.btnCor.Click += new System.EventHandler(this.btnCor_Click);
            // 
            // btnRedefinir
            // 
            this.btnRedefinir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRedefinir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRedefinir.Location = new System.Drawing.Point(715, 483);
            this.btnRedefinir.Name = "btnRedefinir";
            this.btnRedefinir.Size = new System.Drawing.Size(169, 30);
            this.btnRedefinir.TabIndex = 7;
            this.btnRedefinir.Text = "Redefinir Formatação";
            this.btnRedefinir.UseVisualStyleBackColor = true;
            this.btnRedefinir.Click += new System.EventHandler(this.btnRedefinir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(749, 30);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(135, 28);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnDiminuir
            // 
            this.btnDiminuir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiminuir.Location = new System.Drawing.Point(93, 30);
            this.btnDiminuir.Name = "btnDiminuir";
            this.btnDiminuir.Size = new System.Drawing.Size(33, 28);
            this.btnDiminuir.TabIndex = 9;
            this.btnDiminuir.Text = "-";
            this.btnDiminuir.UseVisualStyleBackColor = true;
            this.btnDiminuir.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAumentar
            // 
            this.btnAumentar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAumentar.Location = new System.Drawing.Point(135, 30);
            this.btnAumentar.Name = "btnAumentar";
            this.btnAumentar.Size = new System.Drawing.Size(33, 28);
            this.btnAumentar.TabIndex = 10;
            this.btnAumentar.Text = "+";
            this.btnAumentar.UseVisualStyleBackColor = true;
            this.btnAumentar.Click += new System.EventHandler(this.btnAumentar_Click);
            // 
            // frmEditorDeTexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 514);
            this.Controls.Add(this.btnAumentar);
            this.Controls.Add(this.btnDiminuir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnRedefinir);
            this.Controls.Add(this.btnCor);
            this.Controls.Add(this.btnItalico);
            this.Controls.Add(this.btnSublinhado);
            this.Controls.Add(this.btnNegrito);
            this.Controls.Add(this.btnFonte);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "frmEditorDeTexto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de Texto";
            this.Load += new System.EventHandler(this.frmEditorDeTexto_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton abrirToolStripButton;
        private System.Windows.Forms.ToolStripButton salvarToolStripButton;
        private System.Windows.Forms.ToolStripButton imprimirToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnFonte;
        private System.Windows.Forms.Button btnNegrito;
        private System.Windows.Forms.Button btnSublinhado;
        private System.Windows.Forms.Button btnItalico;
        private System.Windows.Forms.Button btnCor;
        private System.Windows.Forms.Button btnRedefinir;
        private System.Windows.Forms.Button btnSalvar;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnDiminuir;
        private System.Windows.Forms.Button btnAumentar;
    }
}