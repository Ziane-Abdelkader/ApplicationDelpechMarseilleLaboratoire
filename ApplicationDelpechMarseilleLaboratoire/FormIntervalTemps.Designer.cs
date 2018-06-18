namespace ApplicationDelpechMarseilleLaboratoire
{
    partial class FormIntervalTemps
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
            this.textBoxIntervalle = new System.Windows.Forms.TextBox();
            this.Modifier = new System.Windows.Forms.Button();
            this.Valider = new System.Windows.Forms.Button();
            this.Annuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saisir l\'interval entre chaque traitement du logiciel ";
            // 
            // textBoxIntervalle
            // 
            this.textBoxIntervalle.Enabled = false;
            this.textBoxIntervalle.Location = new System.Drawing.Point(55, 50);
            this.textBoxIntervalle.Name = "textBoxIntervalle";
            this.textBoxIntervalle.Size = new System.Drawing.Size(218, 20);
            this.textBoxIntervalle.TabIndex = 1;
            // 
            // Modifier
            // 
            this.Modifier.Location = new System.Drawing.Point(129, 85);
            this.Modifier.Name = "Modifier";
            this.Modifier.Size = new System.Drawing.Size(75, 23);
            this.Modifier.TabIndex = 2;
            this.Modifier.Text = "Modifier";
            this.Modifier.UseVisualStyleBackColor = true;
            this.Modifier.Click += new System.EventHandler(this.Modifier_Click);
            // 
            // Valider
            // 
            this.Valider.Location = new System.Drawing.Point(12, 124);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(75, 23);
            this.Valider.TabIndex = 3;
            this.Valider.Text = "Valider";
            this.Valider.UseVisualStyleBackColor = true;
            this.Valider.Visible = false;
            this.Valider.Click += new System.EventHandler(this.Valider_Click);
            // 
            // Annuler
            // 
            this.Annuler.Location = new System.Drawing.Point(255, 124);
            this.Annuler.Name = "Annuler";
            this.Annuler.Size = new System.Drawing.Size(75, 23);
            this.Annuler.TabIndex = 4;
            this.Annuler.Text = "Annuler";
            this.Annuler.UseVisualStyleBackColor = true;
            this.Annuler.Visible = false;
            this.Annuler.Click += new System.EventHandler(this.Annuler_Click);
            // 
            // FormIntervalTemps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 159);
            this.Controls.Add(this.Annuler);
            this.Controls.Add(this.Valider);
            this.Controls.Add(this.Modifier);
            this.Controls.Add(this.textBoxIntervalle);
            this.Controls.Add(this.label1);
            this.Name = "FormIntervalTemps";
            this.Text = "Intervalle de traitement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIntervalle;
        private System.Windows.Forms.Button Modifier;
        private System.Windows.Forms.Button Valider;
        private System.Windows.Forms.Button Annuler;
    }
}