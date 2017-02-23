namespace FaceVerification
{
    partial class Form1
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
            this.btntakepic = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btsaveBD = new System.Windows.Forms.Button();
            this.tbname = new System.Windows.Forms.TextBox();
            this.tbage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(81, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btntakepic
            // 
            this.btntakepic.Location = new System.Drawing.Point(285, 226);
            this.btntakepic.Name = "btntakepic";
            this.btntakepic.Size = new System.Drawing.Size(75, 23);
            this.btntakepic.TabIndex = 1;
            this.btntakepic.Text = "TomarFoto";
            this.btntakepic.UseVisualStyleBackColor = true;
            this.btntakepic.Click += new System.EventHandler(this.btntakepic_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(414, 157);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // btsaveBD
            // 
            this.btsaveBD.Location = new System.Drawing.Point(130, 226);
            this.btsaveBD.Name = "btsaveBD";
            this.btsaveBD.Size = new System.Drawing.Size(75, 23);
            this.btsaveBD.TabIndex = 7;
            this.btsaveBD.Text = "Guardar";
            this.btsaveBD.UseVisualStyleBackColor = true;
            this.btsaveBD.Click += new System.EventHandler(this.btnidorig_Click);
            // 
            // tbname
            // 
            this.tbname.Location = new System.Drawing.Point(414, 71);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(100, 20);
            this.tbname.TabIndex = 8;
            // 
            // tbage
            // 
            this.tbage.Location = new System.Drawing.Point(414, 116);
            this.tbage.Name = "tbage";
            this.tbage.Size = new System.Drawing.Size(100, 20);
            this.tbage.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Edad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Id";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 349);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbage);
            this.Controls.Add(this.tbname);
            this.Controls.Add(this.btsaveBD);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btntakepic);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btntakepic;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btsaveBD;
        private System.Windows.Forms.TextBox tbname;
        private System.Windows.Forms.TextBox tbage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

