using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationDelpechMarseilleLaboratoire
{
    public partial class FormIntervalTemps : Form
    {
        public FormIntervalTemps()
        {
            
            InitializeComponent();

            string temps = ConfigurationManager.AppSettings["interval"];
            int interval;
            Int32.TryParse(temps, out interval);
            interval = interval/ 1000;
            textBoxIntervalle.Text = interval + "";

        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            textBoxIntervalle.Enabled = true;
            Valider.Visible = true;
            Annuler.Visible = true;
        }

        private void Valider_Click(object sender, EventArgs e)
        {
            int interval;
            Int32.TryParse(textBoxIntervalle.Text, out interval);
            interval = interval * 1000;
            if (interval <= 0)
            {
                MessageBox.Show("l'interval doit être positif et non nul");
            }
            else if (interval < 30000)
            {
                MessageBox.Show("L'intervalle doit au moins être de 30 secondes");
            }
            else
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings.Remove("interval");
                configuration.AppSettings.Settings.Add("interval", interval + "");
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                textBoxIntervalle.Text = interval + "";
                textBoxIntervalle.Enabled = false;
                Valider.Visible = false;
                Annuler.Visible = false;
                this.Close();
            }
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
