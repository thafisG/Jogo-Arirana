namespace WindowsFormsApp18
{
    partial class Escolha
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
            this.btnNao = new System.Windows.Forms.Button();
            this.btnSim = new System.Windows.Forms.Button();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNao
            // 
            this.btnNao.Location = new System.Drawing.Point(58, 54);
            this.btnNao.Name = "btnNao";
            this.btnNao.Size = new System.Drawing.Size(197, 65);
            this.btnNao.TabIndex = 0;
            this.btnNao.Text = "AFASTAMENTO";
            this.btnNao.UseVisualStyleBackColor = true;
            this.btnNao.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // btnSim
            // 
            this.btnSim.Location = new System.Drawing.Point(58, 125);
            this.btnSim.Name = "btnSim";
            this.btnSim.Size = new System.Drawing.Size(197, 65);
            this.btnSim.TabIndex = 0;
            this.btnSim.Text = "APROXIMAÇÃO";
            this.btnSim.UseVisualStyleBackColor = true;
            this.btnSim.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Location = new System.Drawing.Point(66, 18);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(93, 13);
            this.lblMensagem.TabIndex = 1;
            this.lblMensagem.Text = "lblMensagem.Text";
            // 
            // Escolha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 196);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.btnSim);
            this.Controls.Add(this.btnNao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Escolha";
            this.Text = "Escolha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNao;
        private System.Windows.Forms.Button btnSim;
        private System.Windows.Forms.Label lblMensagem;
    }
}