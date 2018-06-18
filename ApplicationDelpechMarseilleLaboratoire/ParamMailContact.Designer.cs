namespace ApplicationDelpechMarseilleLaboratoire
{
    partial class ParamMailContact
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMail1 = new System.Windows.Forms.TextBox();
            this.textBoxMail2 = new System.Windows.Forms.TextBox();
            this.textBoxMail3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Valider = new System.Windows.Forms.Button();
            this.Annuler = new System.Windows.Forms.Button();
            this.Modifier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mail numéro 1";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mail numéro 2";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mail numéro 3";
            // 
            // textBoxMail1
            // 
            this.textBoxMail1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMail1.Enabled = false;
            this.textBoxMail1.Location = new System.Drawing.Point(76, 58);
            this.textBoxMail1.Name = "textBoxMail1";
            this.textBoxMail1.Size = new System.Drawing.Size(166, 20);
            this.textBoxMail1.TabIndex = 4;
            // 
            // textBoxMail2
            // 
            this.textBoxMail2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMail2.Enabled = false;
            this.textBoxMail2.Location = new System.Drawing.Point(76, 115);
            this.textBoxMail2.Name = "textBoxMail2";
            this.textBoxMail2.Size = new System.Drawing.Size(166, 20);
            this.textBoxMail2.TabIndex = 5;
            // 
            // textBoxMail3
            // 
            this.textBoxMail3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMail3.Enabled = false;
            this.textBoxMail3.Location = new System.Drawing.Point(76, 171);
            this.textBoxMail3.Name = "textBoxMail3";
            this.textBoxMail3.Size = new System.Drawing.Size(166, 20);
            this.textBoxMail3.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Le troisième mail est optionnel";
            // 
            // Valider
            // 
            this.Valider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Valider.Location = new System.Drawing.Point(12, 254);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(75, 23);
            this.Valider.TabIndex = 9;
            this.Valider.Text = "Valider";
            this.Valider.UseVisualStyleBackColor = true;
            this.Valider.Visible = false;
            this.Valider.Click += new System.EventHandler(this.button1_Click);
            // 
            // Annuler
            // 
            this.Annuler.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Annuler.Location = new System.Drawing.Point(234, 254);
            this.Annuler.Name = "Annuler";
            this.Annuler.Size = new System.Drawing.Size(75, 23);
            this.Annuler.TabIndex = 10;
            this.Annuler.Text = "Annuler";
            this.Annuler.UseVisualStyleBackColor = true;
            this.Annuler.Visible = false;
            this.Annuler.Click += new System.EventHandler(this.button2_Click);
            // 
            // Modifier
            // 
            this.Modifier.Location = new System.Drawing.Point(120, 254);
            this.Modifier.Name = "Modifier";
            this.Modifier.Size = new System.Drawing.Size(75, 23);
            this.Modifier.TabIndex = 11;
            this.Modifier.Text = "Modifier";
            this.Modifier.UseVisualStyleBackColor = true;
            this.Modifier.Click += new System.EventHandler(this.Modifier_Click);
            // 
            // ParamMailContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 289);
            this.Controls.Add(this.Modifier);
            this.Controls.Add(this.Annuler);
            this.Controls.Add(this.Valider);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxMail3);
            this.Controls.Add(this.textBoxMail2);
            this.Controls.Add(this.textBoxMail1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ParamMailContact";
            this.Text = "Mail à contacter en cas de problème";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMail1;
        private System.Windows.Forms.TextBox textBoxMail2;
        private System.Windows.Forms.TextBox textBoxMail3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Valider;
        private System.Windows.Forms.Button Annuler;
        private System.Windows.Forms.Button Modifier;
    }
}