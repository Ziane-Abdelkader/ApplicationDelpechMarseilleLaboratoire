namespace ApplicationDelpechMarseilleLaboratoire
{
    partial class FormParamMail
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.textBoxMdp = new System.Windows.Forms.TextBox();
            this.textBoxMdpVerif = new System.Windows.Forms.TextBox();
            this.textBoxSmtp = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxMailDefaut = new System.Windows.Forms.CheckBox();
            this.buttonValider = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.buttonValideChoix = new System.Windows.Forms.Button();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supprimer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adresse Mail ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mot de passe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vérification mot de passe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Smtp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Port";
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(266, 48);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(153, 20);
            this.textBoxMail.TabIndex = 5;
            // 
            // textBoxMdp
            // 
            this.textBoxMdp.Location = new System.Drawing.Point(266, 102);
            this.textBoxMdp.Name = "textBoxMdp";
            this.textBoxMdp.PasswordChar = '*';
            this.textBoxMdp.Size = new System.Drawing.Size(153, 20);
            this.textBoxMdp.TabIndex = 6;
            // 
            // textBoxMdpVerif
            // 
            this.textBoxMdpVerif.Location = new System.Drawing.Point(266, 159);
            this.textBoxMdpVerif.Name = "textBoxMdpVerif";
            this.textBoxMdpVerif.PasswordChar = '*';
            this.textBoxMdpVerif.Size = new System.Drawing.Size(153, 20);
            this.textBoxMdpVerif.TabIndex = 7;
            // 
            // textBoxSmtp
            // 
            this.textBoxSmtp.Location = new System.Drawing.Point(266, 211);
            this.textBoxSmtp.Name = "textBoxSmtp";
            this.textBoxSmtp.Size = new System.Drawing.Size(100, 20);
            this.textBoxSmtp.TabIndex = 8;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(266, 262);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(28, 20);
            this.textBoxPort.TabIndex = 9;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(490, 48);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(153, 20);
            this.textBoxUser.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(487, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nom d\'utilisateur";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(487, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 26);
            this.label7.TabIndex = 14;
            this.label7.Text = "Le nom d\'utilisateur correspond a \r\nl\'adresse mail si le champ est laissé vide";
            // 
            // checkBoxMailDefaut
            // 
            this.checkBoxMailDefaut.AutoSize = true;
            this.checkBoxMailDefaut.Location = new System.Drawing.Point(490, 265);
            this.checkBoxMailDefaut.Name = "checkBoxMailDefaut";
            this.checkBoxMailDefaut.Size = new System.Drawing.Size(136, 17);
            this.checkBoxMailDefaut.TabIndex = 15;
            this.checkBoxMailDefaut.Text = "Adresse mail par défaut";
            this.checkBoxMailDefaut.UseVisualStyleBackColor = true;
            // 
            // buttonValider
            // 
            this.buttonValider.Location = new System.Drawing.Point(12, 333);
            this.buttonValider.Name = "buttonValider";
            this.buttonValider.Size = new System.Drawing.Size(75, 23);
            this.buttonValider.TabIndex = 16;
            this.buttonValider.Text = "Valider";
            this.buttonValider.UseVisualStyleBackColor = true;
            this.buttonValider.Click += new System.EventHandler(this.Valider_Click);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Location = new System.Drawing.Point(613, 333);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(75, 23);
            this.buttonAnnuler.TabIndex = 17;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            this.buttonAnnuler.Click += new System.EventHandler(this.Annuler_Click);
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(29, 78);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUser.Sorted = true;
            this.comboBoxUser.TabIndex = 19;
            // 
            // buttonValideChoix
            // 
            this.buttonValideChoix.Location = new System.Drawing.Point(46, 156);
            this.buttonValideChoix.Name = "buttonValideChoix";
            this.buttonValideChoix.Size = new System.Drawing.Size(75, 23);
            this.buttonValideChoix.TabIndex = 20;
            this.buttonValideChoix.Text = "Choisir";
            this.buttonValideChoix.UseVisualStyleBackColor = true;
            this.buttonValideChoix.Click += new System.EventHandler(this.Choisir_Click);
            // 
            // buttonModifier
            // 
            this.buttonModifier.Location = new System.Drawing.Point(46, 210);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(75, 21);
            this.buttonModifier.TabIndex = 21;
            this.buttonModifier.Text = "Modifier";
            this.buttonModifier.UseVisualStyleBackColor = true;
            this.buttonModifier.Click += new System.EventHandler(this.Modifier_Clik);
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Location = new System.Drawing.Point(46, 259);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(75, 23);
            this.buttonAjouter.TabIndex = 22;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = true;
            this.buttonAjouter.Click += new System.EventHandler(this.Ajouter_Click);
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(ApplicationDelpechMarseilleLaboratoire.Program);
            // 
            // supprimer
            // 
            this.supprimer.Location = new System.Drawing.Point(271, 333);
            this.supprimer.Name = "supprimer";
            this.supprimer.Size = new System.Drawing.Size(75, 23);
            this.supprimer.TabIndex = 23;
            this.supprimer.Text = "Supprimer";
            this.supprimer.UseVisualStyleBackColor = true;
            this.supprimer.Click += new System.EventHandler(this.supprimer_Click);
            // 
            // FormParamMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 368);
            this.Controls.Add(this.supprimer);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.buttonModifier);
            this.Controls.Add(this.buttonValideChoix);
            this.Controls.Add(this.comboBoxUser);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonValider);
            this.Controls.Add(this.checkBoxMailDefaut);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxSmtp);
            this.Controls.Add(this.textBoxMdpVerif);
            this.Controls.Add(this.textBoxMdp);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormParamMail";
            this.Text = "Ajouter une fiche utilisateur";
            this.Load += new System.EventHandler(this.FormParamMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.TextBox textBoxMdp;
        private System.Windows.Forms.TextBox textBoxMdpVerif;
        private System.Windows.Forms.TextBox textBoxSmtp;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxMailDefaut;
        private System.Windows.Forms.Button buttonValider;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.Button buttonValideChoix;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.Button supprimer;
    }
}