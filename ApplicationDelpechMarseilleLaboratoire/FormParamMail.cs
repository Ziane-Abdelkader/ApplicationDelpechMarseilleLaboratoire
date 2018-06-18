using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ApplicationDelpechMarseilleLaboratoire
{
    public partial class FormParamMail : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        string connectionString;
        string email;
        public FormParamMail()
        {
            InitializeComponent();
            InitBD();
            SelecQuery("Select * From Mail");

        }
        public void InitBD()
        {
            connectionString = "Data Source= Mail.db;Version=3;";
            sql_con = new SQLiteConnection(connectionString);       
        }

       private void SelecQuery(string txtQuery)
        {
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxUser.Items.Add(reader["adresseSource"] + "");
            }
            reader.Close();
            sql_con.Close();
        }
        private void InsertQuery (string adresse,string mdp, string mdpverif, string smtp, int port , string user)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    string query = @"INSERT INTO Mail (adresseSource, mdp, mdpverif, smtp, port , user) VALUES (@adresseSource,@mdp,@mdpverif,@smtp,@port, @user)";
                    using (var commande = new SQLiteCommand(query, con))
                    {
                        commande.Connection.Open();
                        commande.Parameters.Add(new SQLiteParameter("@adresseSource", adresse));
                        commande.Parameters.Add(new SQLiteParameter("@mdp", mdp));
                        commande.Parameters.Add(new SQLiteParameter("@mdpverif", mdpverif));
                        commande.Parameters.Add(new SQLiteParameter("@smtp", smtp));
                        commande.Parameters.Add(new SQLiteParameter("@port", port));
                        commande.Parameters.Add(new SQLiteParameter("@user", user));
                        commande.ExecuteNonQuery();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        bool buttonModifierPressed = false ;
        bool buttonAjouterPressed = false;

        private void Valider_Click(object sender, EventArgs e)
        {
            
            email = textBoxMail.Text;
            if (textBoxMail.Text != "" && textBoxMdp.Text != "" && textBoxMdpVerif.Text != "" && textBoxPort.Text != "" && textBoxSmtp.Text != "")
            {
                if (textBoxMdp.Text != textBoxMdpVerif.Text)
                {
                    MessageBox.Show("Mot de passe différent");

                }
                else if (!IsValid(email)) 
                {
                    MessageBox.Show("Format de mail invalide ");
                }
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (buttonAjouterPressed)
                {
                    int port = 0;
                    Int32.TryParse(textBoxPort.Text, out port);
                    InsertQuery(textBoxMail.Text, textBoxMdp.Text, textBoxMdpVerif.Text, textBoxSmtp.Text, port, textBoxUser.Text);
                    comboBoxUser.Items.Add(email);
                    comboBoxUser.Refresh();
                    MessageBox.Show("Ajout effectué avec succès");
                    this.Close();
                }
                else if (buttonModifierPressed)//NE marche pas actuellement 
                {
                    try
                    {
                        using (SQLiteConnection con = new SQLiteConnection(connectionString))
                        {
                            string query = @"UPDATE mail SET adresseSource = @adresseSource, mdp=@mdp, mdpverif = @mdpverif, smtp = @smtp , port = @port, user = @user WHERE adresseSource=" + "'" + email + "'";
                            using (var commande = new SQLiteCommand(query, con))
                            {
                                commande.Connection.Open();
                                commande.Parameters.Add(new SQLiteParameter("@adresseSource", textBoxMail.Text));
                                commande.Parameters.Add(new SQLiteParameter("@mdp", textBoxMdp.Text));
                                commande.Parameters.Add(new SQLiteParameter("@mdpverif", textBoxMdpVerif.Text));
                                commande.Parameters.Add(new SQLiteParameter("@smtp", textBoxSmtp.Text));
                                commande.Parameters.Add(new SQLiteParameter("@port", textBoxPort.Text));
                                commande.Parameters.Add(new SQLiteParameter("@user", textBoxUser.Text));
                                commande.ExecuteNonQuery();
                            }

                        }
                        MessageBox.Show("Modification enregistrée");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex + "");
                    }
                }
                if (checkBoxMailDefaut.Checked)
                {
                    configuration.AppSettings.Settings.Remove("adresseSourceDefaut");
                    configuration.AppSettings.Settings.Remove("mdpDefaut");
                    configuration.AppSettings.Settings.Remove("smtpDefaut");
                    configuration.AppSettings.Settings.Remove("portDefaut");
                    configuration.AppSettings.Settings.Remove("mdpVerifDefaut");
                    configuration.AppSettings.Settings.Remove("userDefaut");

                    configuration.AppSettings.Settings.Add("adresseSourceDefaut", textBoxMail.Text);
                    configuration.AppSettings.Settings.Add("mdpDefaut", textBoxMdp.Text);
                    configuration.AppSettings.Settings.Add("mdpVerifDefaut", textBoxMdpVerif.Text);
                    configuration.AppSettings.Settings.Add("smtpDefaut", textBoxSmtp.Text);
                    configuration.AppSettings.Settings.Add("portDefaut", textBoxPort.Text + "");
                    configuration.AppSettings.Settings.Add("userDefaut", textBoxUser.Text + "");

                    configuration.Save(ConfigurationSaveMode.Modified);

                    ConfigurationManager.RefreshSection("appSettings");
                    this.Close();
                }
                buttonAjouter.Show();
                buttonAjouter.Enabled = true;
            }
            else
            {
                MessageBox.Show("Remplie bien les champs");
            }
        }
        private void Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormParamMail_Load(object sender, EventArgs e)
        {
            

            comboBoxUser.DropDownStyle = ComboBoxStyle.DropDownList;
            textBoxMail.Enabled = false;
            textBoxUser.Enabled = false;
            textBoxMdp.Enabled = false;
            textBoxMdpVerif.Enabled = false;
            textBoxPort.Enabled = false;
            textBoxSmtp.Enabled = false;
            checkBoxMailDefaut.Enabled = false;
            buttonValider.Visible = false;
            buttonAnnuler.Visible = false;
            buttonModifier.Visible = false;
            supprimer.Visible = false;
        }
        private void Choisir_Click(object sender, EventArgs e)
        {

            email = comboBoxUser.Text;           
            buttonModifier.Enabled = true;
            textBoxMail.Enabled = false;
            textBoxUser.Enabled = false;
            textBoxMdp.Enabled = false;
            textBoxMdpVerif.Enabled = false;
            textBoxPort.Enabled = false;
            textBoxSmtp.Enabled = false;
            checkBoxMailDefaut.Enabled = false;
            buttonValider.Visible = false;
            buttonAnnuler.Visible = false;
            buttonAjouter.Enabled = true;
            supprimer.Visible = true;
            if (email != "")
            {
                buttonModifier.Visible = true;
            }
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    SQLiteDataReader reader;
                    string query = @"select * from mail where adresseSource = @email";

                    using (var commande = new SQLiteCommand(query, con))
                    {
                        commande.Connection.Open();
                        commande.Parameters.Add(new SQLiteParameter("@email", email));
                        reader = commande.ExecuteReader();
                        while (reader.Read())
                        {

                            textBoxMail.Text = reader["adresseSource"] + "";
                            textBoxMdp.Text = reader["mdp"] + "";
                            textBoxMdpVerif.Text = reader["mdpverif"] + "";
                            textBoxSmtp.Text = reader["smtp"] + "";
                            textBoxPort.Text = reader["port"] + "";
                            textBoxUser.Text = reader["user"] + "";
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        private void Modifier_Clik(object sender, EventArgs e)
        {
            buttonAjouterPressed = false;
            textBoxMail.Enabled = true;
            textBoxUser.Enabled = true;
            textBoxMdp.Enabled = true;
            textBoxMdpVerif.Enabled = true;
            textBoxPort.Enabled = true;
            textBoxSmtp.Enabled = true;
            checkBoxMailDefaut.Enabled = true;
            buttonValider.Visible = true;
            buttonAnnuler.Visible = true;
            buttonModifierPressed = true;
            buttonAjouter.Enabled = false;
            supprimer.Visible = false;
            

        }
        private void Ajouter_Click(object sender, EventArgs e)
        {
            buttonModifierPressed = false;
            textBoxMail.Enabled = true;
            textBoxUser.Enabled = true;
            textBoxMdp.Enabled = true;
            textBoxMdpVerif.Enabled = true;
            textBoxPort.Enabled = true;
            textBoxSmtp.Enabled = true;
            checkBoxMailDefaut.Enabled = true;
            buttonValider.Visible = true;
            buttonAnnuler.Visible = true;
            buttonModifier.Enabled = false;
            textBoxMail.Clear();
            textBoxUser.Clear();
            textBoxMdp.Clear();
            textBoxMdpVerif.Clear();
            textBoxPort.Clear();
            textBoxSmtp.Clear();
            comboBoxUser.ResetText();
            buttonAjouter.Hide();
            buttonAjouterPressed = true;


        }
        private void supprimer_Click(object sender, EventArgs e)
        {
            
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string emailDefaut;
                emailDefaut = ConfigurationManager.AppSettings["adresseSourceDefaut"];
                if(email == emailDefaut)
                {
                    MessageBox.Show("Avant de supprimer ce compte vous devez chosir un autre compte par défaut");
                }
                else
                {
                    try
                    {
                        using (SQLiteConnection con = new SQLiteConnection(connectionString))
                        {
                            string query = @"Delete from mail where adresseSource = @adresseSource";
                            using (var commande = new SQLiteCommand(query, con))
                            {
                                commande.Connection.Open();
                                commande.Parameters.Add(new SQLiteParameter("@adresseSource", email));     
                                commande.ExecuteNonQuery();
                            }

                        }
                        MessageBox.Show("Compte supprimé");
                        buttonModifier.Visible = false;
                        comboBoxUser.Items.Remove(email);
                        textBoxMail.ResetText();
                        textBoxMdp.ResetText();
                        textBoxMdpVerif.ResetText();
                        textBoxSmtp.ResetText();
                        textBoxPort.ResetText();
                        textBoxUser.ResetText();
                        comboBoxUser.Refresh();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex + "");
                    }
                    
                }
            }
            else
            {
                // If 'No', do something here.
            }
        }
    }
}
