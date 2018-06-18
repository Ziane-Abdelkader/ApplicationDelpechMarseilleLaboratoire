namespace ApplicationDelpechMarseilleLaboratoire
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.NbFaxToday = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalDeTraitementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnUtilisateurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailAContacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Lancer = new System.Windows.Forms.Button();
            this.Stopper = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.resultlabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.faxnontraite = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NbFaxBD = new System.Windows.Forms.Label();
            this.isOkLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LabelFaxAttente = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxDernierFax = new System.Windows.Forms.TextBox();
            this.textBoxDernierFaxCorompu = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labeldate2 = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // NbFaxToday
            // 
            this.NbFaxToday.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NbFaxToday.AutoSize = true;
            this.NbFaxToday.Location = new System.Drawing.Point(383, 327);
            this.NbFaxToday.Name = "NbFaxToday";
            this.NbFaxToday.Size = new System.Drawing.Size(13, 13);
            this.NbFaxToday.TabIndex = 7;
            this.NbFaxToday.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dernier Fax reçu : ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre de fax reçu aujourd\' hui : ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.intervalDeTraitementToolStripMenuItem,
            this.configurationMailToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(481, 24);
            this.menuStrip1.TabIndex = 20;
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(162, 20);
            this.optionToolStripMenuItem.Text = "Configuration des chemins";
            this.optionToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // intervalDeTraitementToolStripMenuItem
            // 
            this.intervalDeTraitementToolStripMenuItem.Name = "intervalDeTraitementToolStripMenuItem";
            this.intervalDeTraitementToolStripMenuItem.Size = new System.Drawing.Size(192, 20);
            this.intervalDeTraitementToolStripMenuItem.Text = "Configurer Interval de traitement";
            this.intervalDeTraitementToolStripMenuItem.Click += new System.EventHandler(this.IntervalDeTraitementToolStripMenuItem_Click);
            // 
            // configurationMailToolStripMenuItem
            // 
            this.configurationMailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUnUtilisateurToolStripMenuItem,
            this.mailAContacerToolStripMenuItem});
            this.configurationMailToolStripMenuItem.Name = "configurationMailToolStripMenuItem";
            this.configurationMailToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.configurationMailToolStripMenuItem.Text = "Configuration Mail";
            // 
            // ajouterUnUtilisateurToolStripMenuItem
            // 
            this.ajouterUnUtilisateurToolStripMenuItem.Name = "ajouterUnUtilisateurToolStripMenuItem";
            this.ajouterUnUtilisateurToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.ajouterUnUtilisateurToolStripMenuItem.Text = "Gérer une fiche utilisateur";
            this.ajouterUnUtilisateurToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnUtilisateurToolStripMenuItem_Click);
            // 
            // mailAContacerToolStripMenuItem
            // 
            this.mailAContacerToolStripMenuItem.Name = "mailAContacerToolStripMenuItem";
            this.mailAContacerToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.mailAContacerToolStripMenuItem.Text = "Mail à contacter en cas de panne";
            this.mailAContacerToolStripMenuItem.Click += new System.EventHandler(this.mailAContacerToolStripMenuItem_Click);
            // 
            // Lancer
            // 
            this.Lancer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lancer.Location = new System.Drawing.Point(559, 492);
            this.Lancer.Name = "Lancer";
            this.Lancer.Size = new System.Drawing.Size(125, 60);
            this.Lancer.TabIndex = 27;
            this.Lancer.Text = "Lancer ";
            this.Lancer.UseVisualStyleBackColor = true;
            this.Lancer.Click += new System.EventHandler(this.Lancer_Click);
            // 
            // Stopper
            // 
            this.Stopper.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Stopper.Location = new System.Drawing.Point(15, 492);
            this.Stopper.Name = "Stopper";
            this.Stopper.Size = new System.Drawing.Size(125, 60);
            this.Stopper.TabIndex = 28;
            this.Stopper.Text = "Stopper";
            this.Stopper.UseVisualStyleBackColor = true;
            this.Stopper.Click += new System.EventHandler(this.Stopper_Click);
            // 
            // resultlabel
            // 
            this.resultlabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resultlabel.AutoSize = true;
            this.resultlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultlabel.Location = new System.Drawing.Point(155, 500);
            this.resultlabel.Name = "resultlabel";
            this.resultlabel.Size = new System.Drawing.Size(159, 33);
            this.resultlabel.TabIndex = 29;
            this.resultlabel.Text = "Lancement";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Nombre de fax corompue ou non traité :";
            // 
            // faxnontraite
            // 
            this.faxnontraite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.faxnontraite.AutoSize = true;
            this.faxnontraite.ForeColor = System.Drawing.Color.Red;
            this.faxnontraite.Location = new System.Drawing.Point(254, 116);
            this.faxnontraite.Name = "faxnontraite";
            this.faxnontraite.Size = new System.Drawing.Size(13, 13);
            this.faxnontraite.TabIndex = 31;
            this.faxnontraite.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Nombre de fax reçu  aujourd\'hui dans la base de donnée: ";
            // 
            // NbFaxBD
            // 
            this.NbFaxBD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NbFaxBD.AutoSize = true;
            this.NbFaxBD.Location = new System.Drawing.Point(383, 374);
            this.NbFaxBD.Name = "NbFaxBD";
            this.NbFaxBD.Size = new System.Drawing.Size(13, 13);
            this.NbFaxBD.TabIndex = 32;
            this.NbFaxBD.Text = "0";
            // 
            // isOkLabel
            // 
            this.isOkLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.isOkLabel.AutoSize = true;
            this.isOkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isOkLabel.Location = new System.Drawing.Point(248, 400);
            this.isOkLabel.Name = "isOkLabel";
            this.isOkLabel.Size = new System.Drawing.Size(0, 24);
            this.isOkLabel.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(340, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Dernier fichier corompu :";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(236, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Fax en attente d\'entrer dans la base de donnée :";
            // 
            // LabelFaxAttente
            // 
            this.LabelFaxAttente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelFaxAttente.AutoSize = true;
            this.LabelFaxAttente.BackColor = System.Drawing.SystemColors.Control;
            this.LabelFaxAttente.ForeColor = System.Drawing.Color.Red;
            this.LabelFaxAttente.Location = new System.Drawing.Point(254, 209);
            this.LabelFaxAttente.Name = "LabelFaxAttente";
            this.LabelFaxAttente.Size = new System.Drawing.Size(13, 13);
            this.LabelFaxAttente.TabIndex = 42;
            this.LabelFaxAttente.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label12.AutoSize = true;
            this.label12.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label12.Location = new System.Drawing.Point(341, 230);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 13);
            this.label12.TabIndex = 43;
            this.label12.Text = "Le logicel traite tout les :";
            // 
            // labelInterval
            // 
            this.labelInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelInterval.AutoSize = true;
            this.labelInterval.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelInterval.Location = new System.Drawing.Point(507, 231);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(13, 13);
            this.labelInterval.TabIndex = 44;
            this.labelInterval.Text = "0";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label13.AutoSize = true;
            this.label13.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label13.Location = new System.Drawing.Point(556, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "secondes";
            // 
            // textBoxDernierFax
            // 
            this.textBoxDernierFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBoxDernierFax.Location = new System.Drawing.Point(343, 189);
            this.textBoxDernierFax.Multiline = true;
            this.textBoxDernierFax.Name = "textBoxDernierFax";
            this.textBoxDernierFax.ReadOnly = true;
            this.textBoxDernierFax.Size = new System.Drawing.Size(266, 20);
            this.textBoxDernierFax.TabIndex = 46;
            // 
            // textBoxDernierFaxCorompu
            // 
            this.textBoxDernierFaxCorompu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBoxDernierFaxCorompu.Location = new System.Drawing.Point(343, 113);
            this.textBoxDernierFaxCorompu.Multiline = true;
            this.textBoxDernierFaxCorompu.Name = "textBoxDernierFaxCorompu";
            this.textBoxDernierFaxCorompu.ReadOnly = true;
            this.textBoxDernierFaxCorompu.Size = new System.Drawing.Size(266, 20);
            this.textBoxDernierFaxCorompu.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(428, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Connecté en tant que :";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(568, 34);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(29, 13);
            this.labelUser.TabIndex = 49;
            this.labelUser.Text = "User";
            // 
            // labeldate2
            // 
            this.labeldate2.AutoSize = true;
            this.labeldate2.Location = new System.Drawing.Point(479, 80);
            this.labeldate2.Name = "labeldate2";
            this.labeldate2.Size = new System.Drawing.Size(10, 13);
            this.labeldate2.TabIndex = 50;
            this.labeldate2.Text = " ";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(479, 156);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(10, 13);
            this.labelDate.TabIndex = 51;
            this.labelDate.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(734, 568);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labeldate2);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxDernierFaxCorompu);
            this.Controls.Add(this.textBoxDernierFax);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.LabelFaxAttente);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.isOkLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NbFaxBD);
            this.Controls.Add(this.faxnontraite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resultlabel);
            this.Controls.Add(this.Stopper);
            this.Controls.Add(this.Lancer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NbFaxToday);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Delpech Laboratoire";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem intervalDeTraitementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationMailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnUtilisateurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mailAContacerToolStripMenuItem;
        private System.Windows.Forms.Label NbFaxToday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button Lancer;
        private System.Windows.Forms.Button Stopper;
        private System.Windows.Forms.Label resultlabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label faxnontraite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label NbFaxBD;
        private System.Windows.Forms.Label isOkLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LabelFaxAttente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxDernierFax;
        private System.Windows.Forms.TextBox textBoxDernierFaxCorompu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labeldate2;
        private System.Windows.Forms.Label labelDate;
    }
}

