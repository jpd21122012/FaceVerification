namespace FaceVerification
{
    partial class Comparer
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnTakepic = new System.Windows.Forms.Button();
            this.tbalerta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(198, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(367, 260);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 1;
            this.btnEnter.Text = "Entrar";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // btnTakepic
            // 
            this.btnTakepic.Location = new System.Drawing.Point(240, 260);
            this.btnTakepic.Name = "btnTakepic";
            this.btnTakepic.Size = new System.Drawing.Size(75, 23);
            this.btnTakepic.TabIndex = 2;
            this.btnTakepic.Text = "Capturar";
            this.btnTakepic.UseVisualStyleBackColor = true;
            this.btnTakepic.Click += new System.EventHandler(this.BtnTakepic_Click);
            // 
            // tbalerta
            // 
            this.tbalerta.BackColor = System.Drawing.Color.Red;
            this.tbalerta.Location = new System.Drawing.Point(12, 73);
            this.tbalerta.Name = "tbalerta";
            this.tbalerta.Size = new System.Drawing.Size(180, 20);
            this.tbalerta.TabIndex = 3;
            // 
            // Comparer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 473);
            this.Controls.Add(this.tbalerta);
            this.Controls.Add(this.btnTakepic);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Comparer";
            this.Text = "Comparer";
            this.Load += new System.EventHandler(this.Comparer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnTakepic;
        public System.Windows.Forms.TextBox tbalerta;
    }
}