using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationDelpechMarseilleLaboratoire
{
    public partial class FormParamChemin : Form
    {
        private void InitializePath() //Initialise les chemins depuis le fichier de configuration
        {
            textBoxFaxRecu.Text = ConfigurationManager.AppSettings["cheminImage"] + @"\";
            textBoxFaxTraite.Text = ConfigurationManager.AppSettings["cheminFaxTraite"] + @"\";
            textBoxFaxSauver.Text = ConfigurationManager.AppSettings["cheminSauvegarde"] + @"\";
            textBoxFaxNonTraite.Text = ConfigurationManager.AppSettings["cheminFaxNonTraite"] + @"\";
            textBoxBackup.Text = ConfigurationManager.AppSettings["cheminBackup"] + @"\";
        }
        public FormParamChemin()
        {
           
            InitializeComponent();
            InitializePath();
        }
        public DirectoryInfo cheminImage;
        public DirectoryInfo cheminSauvegarde;
        public DirectoryInfo cheminFaxTraite;
        public DirectoryInfo cheminFaxNonTraite;
        public DirectoryInfo cheminBackup;
        private void button1_Click(object sender, EventArgs e) // Fax Recu
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    cheminImage = new DirectoryInfo(@fbd.SelectedPath);
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    configuration.AppSettings.Settings.Remove("cheminImage");
                    configuration.AppSettings.Settings.Add("cheminImage", @fbd.SelectedPath);
                    configuration.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    textBoxFaxRecu.Text = fbd.SelectedPath;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e) //Fax traité
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    cheminFaxTraite = new DirectoryInfo(@fbd.SelectedPath);
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    configuration.AppSettings.Settings.Remove("cheminFaxTraite");
                    configuration.AppSettings.Settings.Add("cheminFaxTraite", @fbd.SelectedPath);
                    configuration.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    textBoxFaxTraite.Text = fbd.SelectedPath;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e) // Fax Sauvé
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    cheminSauvegarde = new DirectoryInfo(@fbd.SelectedPath);
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    configuration.AppSettings.Settings.Remove("cheminSauvegarde");
                    configuration.AppSettings.Settings.Add("cheminSauvegarde", @fbd.SelectedPath);
                    configuration.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    textBoxFaxSauver.Text = fbd.SelectedPath;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e) //Fax non traité
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    cheminFaxNonTraite = new DirectoryInfo(@fbd.SelectedPath);
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    configuration.AppSettings.Settings.Remove("cheminFaxNonTraite");
                    configuration.AppSettings.Settings.Add("cheminFaxNonTraite", @fbd.SelectedPath);
                    configuration.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    textBoxFaxNonTraite.Text = fbd.SelectedPath;
                }
            }
        }
        private void button5_Click(object sender, EventArgs e) //Backup
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    cheminBackup = new DirectoryInfo(@fbd.SelectedPath);
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    configuration.AppSettings.Settings.Remove("cheminBackup");
                    configuration.AppSettings.Settings.Add("cheminBackup", @fbd.SelectedPath);
                    configuration.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    textBoxBackup.Text = fbd.SelectedPath;
                }
            }
        }
        private void button6_Click(object sender, EventArgs e) //Exit
        {
            this.Close();
        }
    }
}
