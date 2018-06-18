namespace ApplicationDelpechMarseilleLaboratoire
{
    partial class FormParamChemin
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
            this.textBoxFaxRecu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxFaxTraite = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxFaxSauver = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBoxFaxNonTraite = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBoxBackup = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFaxRecu
            // 
            this.textBoxFaxRecu.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxFaxRecu.Enabled = false;
            this.textBoxFaxRecu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxFaxRecu.Location = new System.Drawing.Point(12, 30);
            this.textBoxFaxRecu.Multiline = true;
            this.textBoxFaxRecu.Name = "textBoxFaxRecu";
            this.textBoxFaxRecu.ReadOnly = true;
            this.textBoxFaxRecu.Size = new System.Drawing.Size(593, 21);
            this.textBoxFaxRecu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chemin des fax reçu";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(613, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chemin des fax sauvegardé en pdf";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Chemin des fax traité";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Chemin des fax non traité";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(527, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Chemin vers le fichier backup (Qui enregistre les fax dans un fichier texte si la" +
    " base de donnée est indisponible)";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(613, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 21);
            this.button2.TabIndex = 15;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxFaxTraite
            // 
            this.textBoxFaxTraite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxFaxTraite.Enabled = false;
            this.textBoxFaxTraite.Location = new System.Drawing.Point(12, 129);
            this.textBoxFaxTraite.Multiline = true;
            this.textBoxFaxTraite.Name = "textBoxFaxTraite";
            this.textBoxFaxTraite.ReadOnly = true;
            this.textBoxFaxTraite.Size = new System.Drawing.Size(593, 21);
            this.textBoxFaxTraite.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(613, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 21);
            this.button3.TabIndex = 17;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxFaxSauver
            // 
            this.textBoxFaxSauver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxFaxSauver.Enabled = false;
            this.textBoxFaxSauver.Location = new System.Drawing.Point(12, 78);
            this.textBoxFaxSauver.Multiline = true;
            this.textBoxFaxSauver.Name = "textBoxFaxSauver";
            this.textBoxFaxSauver.ReadOnly = true;
            this.textBoxFaxSauver.Size = new System.Drawing.Size(593, 21);
            this.textBoxFaxSauver.TabIndex = 16;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Location = new System.Drawing.Point(613, 179);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(39, 21);
            this.button4.TabIndex = 19;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBoxFaxNonTraite
            // 
            this.textBoxFaxNonTraite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxFaxNonTraite.Enabled = false;
            this.textBoxFaxNonTraite.Location = new System.Drawing.Point(12, 179);
            this.textBoxFaxNonTraite.Multiline = true;
            this.textBoxFaxNonTraite.Name = "textBoxFaxNonTraite";
            this.textBoxFaxNonTraite.ReadOnly = true;
            this.textBoxFaxNonTraite.Size = new System.Drawing.Size(593, 21);
            this.textBoxFaxNonTraite.TabIndex = 18;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.Location = new System.Drawing.Point(613, 227);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(39, 21);
            this.button5.TabIndex = 21;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBoxBackup
            // 
            this.textBoxBackup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxBackup.Enabled = false;
            this.textBoxBackup.Location = new System.Drawing.Point(12, 227);
            this.textBoxBackup.Multiline = true;
            this.textBoxBackup.Name = "textBoxBackup";
            this.textBoxBackup.ReadOnly = true;
            this.textBoxBackup.Size = new System.Drawing.Size(593, 21);
            this.textBoxBackup.TabIndex = 20;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.Location = new System.Drawing.Point(281, 260);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 22;
            this.button6.Text = "Valider";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // FormParamChemin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 295);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBoxBackup);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBoxFaxNonTraite);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBoxFaxSauver);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxFaxTraite);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFaxRecu);
            this.Name = "FormParamChemin";
            this.Text = "Paramètre des répertoires";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFaxRecu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxFaxTraite;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxFaxSauver;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBoxFaxNonTraite;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBoxBackup;
        private System.Windows.Forms.Button button6;
    }
}