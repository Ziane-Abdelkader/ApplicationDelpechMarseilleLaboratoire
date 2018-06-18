using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationDelpechMarseilleLaboratoire
{
    public partial class ParamMailContact : Form
    {
        public ParamMailContact()
        {
            InitializeComponent();
            textBoxMail1.Text = ConfigurationManager.AppSettings["adresse0"];
            textBoxMail2.Text = ConfigurationManager.AppSettings["adresse1"];
            textBoxMail3.Text = ConfigurationManager.AppSettings["adresse2"];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxMail1.Text  != "" && textBoxMail2.Text != "")
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(textBoxMail1.Text);
                Match match2 = regex.Match(textBoxMail2.Text);
                if (!match.Success || !match2.Success)
                {
                    MessageBox.Show("Format de mail mauvais ");
                }
                else
                {
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    configuration.AppSettings.Settings.Remove("adresse0");
                    configuration.AppSettings.Settings.Remove("adresse1");
                    configuration.AppSettings.Settings.Remove("adresse2");
                    configuration.AppSettings.Settings.Add("adresse0", textBoxMail1.Text);
                    configuration.AppSettings.Settings.Add("adresse1", textBoxMail2.Text);
                    configuration.AppSettings.Settings.Add("adresse2", textBoxMail3.Text);
                    configuration.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    this.Close();
                }           
            }
            else
            {
                MessageBox.Show("Veuillez renseigner les 2 premier champs au moins");
            }       
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            Annuler.Visible = true;
            Valider.Visible = true;
            textBoxMail1.Enabled = true;
            textBoxMail2.Enabled = true;
            textBoxMail3.Enabled = true;
        }
    }
}
