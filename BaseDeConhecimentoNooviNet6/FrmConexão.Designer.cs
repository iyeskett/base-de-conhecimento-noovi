namespace BaseDeConhecimentoNooviNet6
{
    partial class FrmConexão
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
            this.lblConexao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblConexao
            // 
            this.lblConexao.AutoSize = true;
            this.lblConexao.Font = new System.Drawing.Font("Arial Narrow", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConexao.ForeColor = System.Drawing.Color.Black;
            this.lblConexao.Location = new System.Drawing.Point(12, 9);
            this.lblConexao.Name = "lblConexao";
            this.lblConexao.Size = new System.Drawing.Size(0, 40);
            this.lblConexao.TabIndex = 1;
            // 
            // FrmConexão
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(394, 67);
            this.Controls.Add(this.lblConexao);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConexão";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmConexão";
            this.Load += new System.EventHandler(this.FrmConexão_Load);
            this.Shown += new System.EventHandler(this.FrmConexão_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblConexao;
    }
}