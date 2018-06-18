using iTextSharp.text;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.Common;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;

namespace ApplicationDelpechMarseilleLaboratoire
{
    public partial class Form1 : Form
    {
        private List<System.Drawing.Image> page = new List<System.Drawing.Image>();
        private BackgroundWorker backgroundWorker1;
        private PrivateFontCollection codeBarre = new PrivateFontCollection();
        //Déclaration des variables de chemin
        public DirectoryInfo cheminImage;
        public DirectoryInfo cheminSauvegarde;
        public DirectoryInfo cheminFaxTraite;
        public DirectoryInfo cheminFaxNonTraite;
        public DirectoryInfo cheminBackup;
        //Variable qui servent au traitement des fichier corompu
        private bool fichierCorompue = false;
        private string NomfichierCorompu;
        private string pathImage;
        private string pathFaxNonTraite;
        private string texte;
        //Déclaration des variables de chemin avec la date
        private string cheminSauvgardeAnneMois;
        private string cheminFaxTraiteAnneMois;
        private string cheminFaxNonTraiteAnneMois;
        //Déclaration des variables a inscrire sur le fax pendant le traitement
        private string NumClient = "";
        private string NumFaxExpediteur = "";
        private int NombreDeFax =0;
        //Information de connection
        MySql.Data.MySqlClient.MySqlConnection connection;
        string server = "localhost";
        string database = "informationfax";
        string uid = "root";
        string password = "";
        string connectionString;
        //Variable des compteurs
        private int CompteurDeFaxToday = 0;
        private int CompteurDeFaxCorrompue = 0;
        private int CompteurFaxBD = 0;
        private int CompteurFaxEnAttente = 0;
        //contient le chemin vers le fax courant (.pdf) 
        private string dernierFax;

        //Déclaration des variables pour le temps
        private DateTime dateTraiter; //Donne la date du fax traité
        private DateTime dateReception; // Donne la date quand un fax est reçu 
        private int interval = 600000;
        private bool traite = false; // vrais si fichier traité faux sinon
        //Variable pour les mails
        string[] adresseMailTo = new string[3];
        string adresseMailFrom;
        string smtp;
        string mdpSmtp;
        string user;
        int port=0;
        int jouractuel = 0;
        int erreurBD = 0; //Sert a envoyé un mail au bout d'une itération de la boucle si le base de donnée est erronée
        int erreurNb = 0; //permet de n'envoyer qu'un seul mail si une erreur se produit au lieu d'en enovyer a chaque fois que l'erreur se produit

        //Fonction du programme 
        private void LireHDR(string fichierHDR) //Fonction qui permet de lire le fichier HDR pour recuperer des informations utiles 
        {
            try
            {
                string LigneLue;
                // Read the file and display it line by line.  
                System.IO.StreamReader file = new System.IO.StreamReader(fichierHDR);
                while ((LigneLue = file.ReadLine()) != null)
                {
                    if (LigneLue.Length == 25 && !String.IsNullOrWhiteSpace(LigneLue) || LigneLue.Length == 26 && !String.IsNullOrWhiteSpace(LigneLue))
                    {
                        if (LigneLue.Substring(0, 13) == "USED_ADDRESS=")
                        {
                            if (LigneLue.Substring(13, 3) == "+33") //Indicatif France
                            {
                                NumFaxExpediteur = "0" + LigneLue.Substring(16, 9);
                            }
                            else if (LigneLue.Substring(13, 4) == "+377") //Indicatif Monaco
                            {
                                NumFaxExpediteur = "00" + LigneLue.Substring(17, 9);
                            }
                        }
                    }
                }
                file.Close();
            }
            catch (FileNotFoundException ioe)
            {
                Console.WriteLine(ioe); //si fichier non trouvé alors le .hdr n'existe pas pour le même .tif
            }
        }//LireHDR
        private void MySqlInsertBD(string nomFichier, string codeClient, DateTime dateRéception, DateTime dateTraitement, string nomFichierOriginal, string numFaxExpediteur, bool traite) //Fonction qui fait les insertions dans la base de donnée concernant les fax
        {  
            try
            {               
                connection.Open();
                LocalInsertBD();

                MySql.Data.MySqlClient.MySqlCommand inserteFax = connection.CreateCommand();
                MySql.Data.MySqlClient.MySqlCommand nombreFax = connection.CreateCommand();

                nombreFax.CommandText = "SELECT LEFT ('datetraitement',10) AS DT, COUNT(*) FROM FAX GROUP BY DT";

                inserteFax.CommandText = "INSERT INTO fax (nomFichier, codeClient, dateReception, dateTraitement,nomFichierOriginal, numFaxExpediteur, traite) " +
                    " VALUES(@nf, @cd, @dateRecept, @dateTraite, @nfOriginal,@numFaxExp, @traite)";

                inserteFax.Parameters.AddWithValue("@nf", nomFichier);
                inserteFax.Parameters.AddWithValue("@cd", codeClient);
                inserteFax.Parameters.AddWithValue("@dateRecept", dateRéception);
                inserteFax.Parameters.AddWithValue("@dateTraite", dateTraitement);
                inserteFax.Parameters.AddWithValue("@nfOriginal", nomFichierOriginal);
                inserteFax.Parameters.AddWithValue("@numFaxExp", numFaxExpediteur);
                inserteFax.Parameters.AddWithValue("@traite", traite);
                //Insert les éléments dans la base de donnée MySql
                inserteFax.ExecuteNonQuery();
                inserteFax.Connection = connection;

                //Récupere le nombre de fax dans la base
                MySql.Data.MySqlClient.MySqlDataReader dataReader = nombreFax.ExecuteReader();
                if (dataReader.Read())
                {
                    Int32.TryParse(dataReader.GetValue(1).ToString(), out CompteurFaxBD);

                }
            }
            catch (DbException err) //Si une connection est impossible on enregistre les données dans un fichier texte
            {
                ++erreurBD;
                Console.Write(err);
                CompteurFaxEnAttente++;
                texte = texte + (nomFichier + ";" + codeClient + ";" + dateRéception + ";" + dateTraitement + ";" + nomFichierOriginal + ";" + numFaxExpediteur + ";" + traite) + Environment.NewLine;
   
            }
            connection.Close();
        }//MySqlInsertBD
        private void LocalInsertBD()
        {
            string nomFichierLocal = "";
            string codeClientLocal = "";
            string dateRéceptionLocal = "";
            string dateTraitementLocal = "";
            string nomFichierOriginalLocal = "";
            string numFaxExpediteurLocal = "";
            bool traiteLocal = false;
            int i = 0;
            if (File.Exists(cheminBackup + "Backup.txt"))
            {
                foreach (string line in File.ReadAllLines(cheminBackup + "Backup.txt"))
                {
                    string[] parts = line.Split(';');
                    nomFichierLocal = parts[0];
                    codeClientLocal = parts[1];
                    dateRéceptionLocal = parts[2];
                    dateTraitementLocal = parts[3];
                    nomFichierOriginalLocal = parts[4];
                    numFaxExpediteurLocal = parts[5];
                    traiteLocal = Convert.ToBoolean(parts[6]);
                    i++;
                    try
                    {
                        MySql.Data.MySqlClient.MySqlCommand inserteFaxLocal = connection.CreateCommand();
                        inserteFaxLocal.CommandText = "INSERT INTO fax (nomFichier, codeClient, dateReception, dateTraitement,nomFichierOriginal, numFaxExpediteur, traite) " +
                        " VALUES(@nf, @cd, @dateRecept, @dateTraite, @nfOriginal,@numFaxExp, @traite)";
                        //FAX LOCAL
                        inserteFaxLocal.Parameters.AddWithValue("@nf", nomFichierLocal);
                        inserteFaxLocal.Parameters.AddWithValue("@cd", codeClientLocal);
                        inserteFaxLocal.Parameters.AddWithValue("@dateRecept", dateRéceptionLocal);
                        inserteFaxLocal.Parameters.AddWithValue("@dateTraite", dateTraitementLocal);
                        inserteFaxLocal.Parameters.AddWithValue("@nfOriginal", nomFichierOriginalLocal);
                        inserteFaxLocal.Parameters.AddWithValue("@numFaxExp", numFaxExpediteurLocal);
                        inserteFaxLocal.Parameters.AddWithValue("@traite", traiteLocal);
                        inserteFaxLocal.ExecuteNonQuery();
                        inserteFaxLocal.Connection = connection;
                    }
                    catch(DbException e)
                    {
                        //MessageBox.Show(e+"");
                    }
                }
                File.Delete(cheminBackup + "Backup.txt");
            }
        }
        public void OdbcSelectBD() //RécupereW le Numéro Client pour un Numéro émetteur donné
        {
            //Informations pour la connection a la base de donnée 
            OdbcConnection connection;
            string driver = "{Pervasive ODBC Client Interface}";
            string server = "192.168.2.5";
            string database = "EASYPREPST";
            string uid = "Lecteur";
            string password = "lecteur";
            string connectionString;
            string query = "SELECT * FROM eclient WHERE REFNTIERS <> '' AND FAX ='" + NumFaxExpediteur + "'";
            connectionString = "Driver=" + driver + ";" + "ServerName=" + server + ";" + "dbq=" + database + ";" + "UID=" + uid + ";" + "PWD=" + password;
            connection = new OdbcConnection(connectionString);
            //Open connection
            try
            {
                connection.Open();
                OdbcCommand requete = new OdbcCommand(query); //affiche tout les éléments de la base de donnée "fax"
                requete.Connection = connection;
                OdbcDataReader reader = requete.ExecuteReader();
                while (reader.Read()) //tant qu'il y a des données on les récuperes 
                {
                    NumClient = "" + reader.GetValue(0); // NumClient prend les valeurs trouvé pour le tuple s'il y en a
                }
                if (NumFaxExpediteur == "")
                {
                    NumClient = "";
                }
            }
            catch (DbException err)
            {

                MessageBox.Show("La connection a la base de donnée (Pervasive) a échoué, impossible de récuperer les informations concerant le client");
                Console.Write(err);
            }
            connection.Close();
        }//OdbcSelectBD
        private List<System.Drawing.Image> GetAllPages(string file) //Fonction qui permet de récuperer toute les pages d'un fichier d'extension .tiff
        {
            Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile(file);
            int count = bitmap.GetFrameCount(FrameDimension.Page);
            for (int idx = 0; idx < count; idx++)
            {
                // Sauve toute les pages 
                bitmap.SelectActiveFrame(FrameDimension.Page, idx);
                MemoryStream byteStream = new MemoryStream();
                bitmap.Save(byteStream, ImageFormat.Tiff);

                // Creer l'image après les sauver
                page.Add(System.Drawing.Image.FromStream(byteStream));
            }
            return page;
        }//GetAllPages
        private System.Drawing.Image RedimImage(System.Drawing.Image img)
        {
            //Une feuille A4 a pour dimmension H * L = 1024*768
            //En centimètre : Largeur: 21cm  hauteur: 29.7cm
            //En pixel : Largeur: 672 Hauteur: 950-- > en 1024x768
            const int largeurA4 = 672;
            const int hauteurA4 = 950;
            int largeur = 0;
            int hauteur = 0;
            Bitmap bitmap = (Bitmap)img;
            if (img.Width > 672 && img.Height > 1024)
            {
                largeur = largeurA4;
                hauteur = (hauteurA4 * 99) / 100;
            }
            else if (img.Width > 672)
            {
                largeur = largeurA4;
                hauteur = (hauteurA4 * 99) / 100;
            }
            else if (img.Height > 1024)
            {
                hauteur = hauteurA4;
                largeur = largeurA4;
            }
            else
            {
                return img;
            }
            Size size = new Size(largeur, hauteur);

            return (System.Drawing.Image)(new Bitmap(img, size)); //renvoi l'image avec une taille réduite de 95%
        }//RedimImage
        void AddLogo(XGraphics gfx, PdfSharp.Pdf.PdfPage page, System.Drawing.Image image, int xPosition, int yPosition)
        {
            XImage xImage = XImage.FromGdiPlusImage(image);
            gfx.DrawImage(xImage, xPosition, yPosition);
        }
        private void SaveToPDF(System.Drawing.Image image)
        {       
            string derniereImage; //contient le chemin vers le fax courant (.tif)
            string nomFichier = "Fax_Received_From_" + NumFaxExpediteur + "_Client_ " + NumClient + "_Fax_" + CompteurDeFaxToday; //Nomination de tout les fichiers similaire 
            try
            {
                dernierFax = cheminSauvgardeAnneMois + nomFichier + ".pdf";
                derniereImage = cheminSauvegarde + nomFichier + ".tif";
                NombreDeFax++;
                PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
                PdfSharp.Pdf.PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont codeBarre = new XFont("c39hrp24dhtt", 35);
                XFont arial = new XFont("Arial", 10);
                
                AddLogo(gfx, page, RedimImage(image), 20,20);
                string temps = NombreDeFax + "";
                String.Format("{0,20}", temps);

                gfx.DrawString("Exp", arial, XBrushes.Black, new XRect(-270, 380, page.Width, page.Height), XStringFormats.Center);
                gfx.DrawString("*"+NumFaxExpediteur+"*", codeBarre, XBrushes.Black, new XRect(-180, 380, page.Width,page.Height), XStringFormats.Center);
                
                gfx.DrawString("Client", arial, XBrushes.Black, new XRect(-50, 380, page.Width,page.Height), XStringFormats.Center);
                gfx.DrawString("*"+NumClient+"*", codeBarre, XBrushes.Black, new XRect(10, 380, page.Width,page.Height), XStringFormats.Center);

                gfx.DrawString("Fax", arial, XBrushes.Black, new XRect(130, 380, page.Width,page.Height), XStringFormats.Center);
                gfx.DrawString("*"+ temps.PadLeft(7, '0') + "*", codeBarre, XBrushes.Black, new XRect(200, 380, page.Width,page.Height), XStringFormats.Center);

                
                document.Save(dernierFax);
                //Libere les ressources utilisé 
                document.Close();
                document.Dispose();
                ////Information sur l'impression du document

                ProcessStartInfo info = new ProcessStartInfo(dernierFax);
                info.Verb = "Print";
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(info);

                //// Récupere la date de l'image une fois traité
                dernierFax = derniereImage;
                dateTraiter = DateTime.Now;

                //Supprime l'image édité une fois l'opération et le PDF terminé
                File.Delete(derniereImage);
                traite = true;
            }
            catch (DocumentException de)
            {
                MessageBox.Show("Impossible de créer le PDF, érreur d'écriture/Lecture");
                Console.Error.WriteLine(de.Message);

            }
            catch (PdfSharp.PdfSharpException ioe)
            {
                MessageBox.Show("Erreur lors de la lecture du document, le fichier est peut être corompue ou inexistant" + ioe);
                Console.Error.WriteLine(ioe.Message);
                traite = false;
            }
        }//SaveToPDF
        private void EnvoiMail(string message)
        {
            try
            {
                MailMessage mM = new MailMessage();
                //Mail Address
                mM.From = new MailAddress(adresseMailFrom);
                for (int i = 0; i < 3; i++)
                {
                    if (adresseMailTo[i] != "")
                    {
                        mM.To.Add(adresseMailTo[i]);
                    }
                }
                //receiver email id
                //subject of the email
                mM.Subject = "Rapport sur le logiciel de traitement de fax";
                //add the body of the email
                mM.Body = message;
                mM.IsBodyHtml = true;
                //SMTP client
                SmtpClient sC = new SmtpClient(smtp);
                //port number for Hot mail
                sC.Port = port;
                //credentials to login in to hotmail account
                //sC.Credentials = new NetworkCredential(adresseMailFrom, mdpSmtp);
                sC.Credentials = new NetworkCredential(adresseMailFrom, mdpSmtp);
                //enabled SSL
                sC.EnableSsl = true;
                //Send an email
     
                sC.Send(mM);
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("Les adresses de réception du mail contenant un avertissement sur le dysfonctionnement du logiciel ne sont pas configuré " );
            }
            catch (SmtpException e)
            {
                MessageBox.Show("Une erreur est survenue dans l'authentification de l'email source, verifier vos identifiants et mot de passe ");         
            }
            catch(Exception e)
            {
                MessageBox.Show(e + "");
            }
        }
        private void EnvoiMail(string message, string file)
        {
            try
            {
                Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                MailMessage mM = new MailMessage();
                //Mail Address
                mM.From = new MailAddress(adresseMailFrom);
                for (int i = 0; i < 3; i++)
                {
                    if (adresseMailTo[i] != "")
                    {
                        mM.To.Add(adresseMailTo[i]);
                    }
                }
                //receiver email id
                //subject of the email
                mM.Subject = "Rapport sur le logiciel de traitement de fax";
                //add the body of the email
                mM.Body = message;
                mM.IsBodyHtml = true;
                mM.Attachments.Add(data);
                //SMTP client
                SmtpClient sC = new SmtpClient(smtp);
                //port number for Hot mail
                sC.Port = port;
                //credentials to login in to hotmail account
                //sC.Credentials = new NetworkCredential(adresseMailFrom, mdpSmtp);
                sC.Credentials = new NetworkCredential(adresseMailFrom, mdpSmtp);
                //enabled SSL
                sC.EnableSsl = true;
                //Send an email

                sC.Send(mM);
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("Les adresses de réception du mail contenant un avertissement sur le dysfonctionnement du logiciel ne sont pas configuré ");
            }
            catch (SmtpException e)
            {
                MessageBox.Show("Une erreur est survenue dans l'authentification de l'email source, verifier vos identifiants et mot de passe ");
            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
            }
        }
        private void Lancer_Click(object sender, EventArgs e) //Bouton Start, lance le traitement avec le timer
        {
            this.Lancer.Enabled = false;
            this.Stopper.Enabled = true;
            resultlabel.Text = "En cours de traitement";
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            timer1.Start();
        }
        private void Stopper_Click(object sender, EventArgs e) //Bouton Stop, fini le traitement en cours et suspend l'opération
        {
            // Cancel the asynchronous operation.
            backgroundWorker1.CancelAsync();
            // Disable the Cancel button.
            Stopper.Enabled = false;
        }
        //Travail en tache de fond 
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
     
            connectionString = "Server=" + server + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Pwd=" + password + ";";
            connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            backgroundWorker1.WorkerSupportsCancellation = true;
            BackgroundWorker worker = sender as BackgroundWorker;
            //Traitement principal de l'application
        
            List<string> tabFichier = new List<string>();

            string pathFaxTraite;

            string pathHDRTraiter;
            string fichierHDR;
            string nomFichier;

            System.Drawing.Image image = null;
            FileStream file = null;

            //Parcours tous les fichiers d'extension .tif
            foreach (var fichier in cheminImage.GetFiles("*.tif"))
            {

                tabFichier.Add(fichier.Name);
            }
            string annee = DateTime.Now.Year.ToString();
            string mois = DateTime.Now.Month.ToString();
            //Créer les répertoires avec la date 
            if (!Directory.Exists(cheminSauvegarde + @"\" + annee))
            {
                Directory.CreateDirectory(cheminSauvegarde + @"\" + annee);
            }
            if (!Directory.Exists(cheminSauvegarde + @"\" + annee + @"\" + mois))
            {
                Directory.CreateDirectory(cheminSauvegarde + @"\" + annee + @"\" + mois);
            }

            if (!Directory.Exists(cheminFaxTraite + @"\" + annee))
            {
                Directory.CreateDirectory(cheminFaxTraite + @"\" + annee);
            }
            if (!Directory.Exists(cheminFaxTraite + @"\" + annee + @"\" + mois))
            {
                Directory.CreateDirectory(cheminFaxTraite + @"\" + annee + @"\" + mois);
            }

            if (!Directory.Exists(cheminFaxNonTraite + @"\" + annee))
            {
                Directory.CreateDirectory(cheminFaxNonTraite + @"\" + annee);
            }
            if (!Directory.Exists(cheminFaxNonTraite + @"\" + annee + @"\" + mois))
            {
                Directory.CreateDirectory(cheminFaxNonTraite + @"\" + annee + @"\" + mois);
            }
            //Stocke les chemins 
            cheminSauvgardeAnneMois = cheminSauvegarde + @"\" + annee + @"\" + mois + @"\";
            cheminFaxTraiteAnneMois = cheminFaxTraite + @"\" + annee + @"\" + mois + @"\";
            cheminFaxNonTraiteAnneMois = cheminFaxNonTraite + @"\" + annee + @"\" + mois + @"\";
            //Parcours tous les fichiers d'extension .tif
            foreach (string fichier in tabFichier)
            {
                //Initialise toutes mes variables
                NumFaxExpediteur = "";
                NumClient = "";
                dateReception = DateTime.Now;//Récupere la date de la lecture du fichier 
                nomFichier = "Fax_Received_From_" + NumFaxExpediteur + "_Client_ " + NumClient + "_Fax_" + CompteurDeFaxToday;
                pathImage = cheminImage  + fichier;
                pathFaxTraite = cheminFaxTraiteAnneMois + @"\" + fichier;
                pathFaxNonTraite = cheminFaxNonTraiteAnneMois + @"\" + fichier;
                pathHDRTraiter = cheminFaxTraiteAnneMois + Path.GetFileNameWithoutExtension(fichier) + ".hdr";
                if (jouractuel != DateTime.Now.Day)
                {
                    CompteurDeFaxToday=0;
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    configuration.AppSettings.Settings.Remove("nbFax");
                    configuration.AppSettings.Settings.Add("nbFax", CompteurDeFaxToday+"");
                    configuration.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    jouractuel = DateTime.Now.Day;
                }
                CompteurDeFaxToday++;
                //Importe l'image
                try
                {
                    file = new FileStream(pathImage, FileMode.Open);
                    image = System.Drawing.Image.FromStream(file);
                    file.Dispose(); //Libère la ressource une fois l'image chargé
                    fichierCorompue = false;
                }

                catch (ArgumentException f) //Fichier impossible a lire
                {

                    traite = false;
                    fichierCorompue = true;
                    NomfichierCorompu = pathImage;
                    CompteurDeFaxCorrompue++;
                   
                    if (file != null)
                    {
                        file.Close();
                    }
                    if (File.Exists(pathFaxNonTraite))
                    {
                        File.Delete(pathFaxNonTraite);
                        File.Move(NomfichierCorompu, pathFaxNonTraite);
                        EnvoiMail("Le fichier " + NomfichierCorompu + " est corompue et n'a donc pas été traité, erreur survenue le " + Environment.NewLine + DateTime.Now, pathFaxNonTraite);
                    }
                    else
                    {
                        File.Move(pathImage, pathFaxNonTraite);
                        EnvoiMail("Le fichier " + NomfichierCorompu + " est corompue et n'a donc pas été traité, erreur survenue le " + Environment.NewLine + DateTime.Now, pathFaxNonTraite);
                    }
                }
                if (fichierCorompue)
                {
                    MySqlInsertBD(pathImage, NumClient, dateReception, dateTraiter, fichier, NumFaxExpediteur, traite);         
                }
                else
                {
                    //Cherche le .HDR correspondant a l'image et recupere les informations dans la base de donnée
                    fichierHDR = cheminImage + Path.GetFileNameWithoutExtension(fichier) + ".hdr";
                    LireHDR(fichierHDR);
                    OdbcSelectBD();
                    //Traitement de l'image
                    image = RedimImage(image); //Redimensione l'image

                    SaveToPDF(image); // Sauvegarde l'image au format PDF
                    image.Dispose(); // Libère les ressources utilisé par l'image

                    //Récupere les dates de traitement et de reception
                   

                    try
                    {
                        if (!File.Exists(pathFaxTraite) && !File.Exists(pathHDRTraiter))
                        {
                            File.Move(pathImage, pathFaxTraite);   // Deplace le fichier vers le dossier "FaxTraité"
                            File.Move(fichierHDR, pathHDRTraiter); // Deplace le hdr vers le dossier "FaxTraité"
                        }
                        else
                        {
                            File.Delete(pathFaxTraite);
                            File.Delete(pathHDRTraiter);
                            File.Move(pathImage, pathFaxTraite);
                            File.Move(fichierHDR, pathHDRTraiter);
                        }
                    }
                    catch (FileNotFoundException f)
                    {
                        //Ingore les fichier .hdr manquant
                    }
                    //Insere dans la base de donnée les informations du fax reçu
  
                    MySqlInsertBD("Fax_Received_From_" + NumFaxExpediteur + "_Client_ " + NumClient + "_Fax_" + CompteurDeFaxToday + ".pdf", NumClient, dateReception, dateTraiter, fichier, NumFaxExpediteur, traite);
            
                    //Si le bouton stop est pressé on envoie un signal d'arrêt

                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                    }
                    file.Dispose();
                }

            }//ForEach1

        }//backgroundWorker1_DoWork
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
         
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                resultlabel.Text = "En Pause";
                timer1.Stop();

            }
            else
            {
                resultlabel.Text = "Traitement terminé";
                backgroundWorker1.Dispose();
                textBoxDernierFax.Text = dateTraiter.ToString() + "\n" + dernierFax;
                NbFaxToday.Text = "" + CompteurDeFaxToday;
                faxnontraite.Text = "" + CompteurDeFaxCorrompue;
                NbFaxBD.Text = "" + CompteurFaxBD;
                textBoxDernierFaxCorompu.Text = NomfichierCorompu;

                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings.Remove("nbFax");
                configuration.AppSettings.Settings.Add("nbFax", CompteurDeFaxToday + "");
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                if (erreurBD == 1)
                {
                    EnvoiMail("Il y a une erreur dans la lecture de la base de donnée ou alors les données sont dupliqué, les fichiers seront enregistré en local et demande une vérification de la part de l'administrateur.");
                    erreurBD = 2;
                }
                if (erreurNb == 1)
                {
                    EnvoiMail("Le nombre de fax traité ne correspond au nombre de fax dans la base de donnée.L'erreur s'est produite le" + DateTime.Now);
                    erreurNb = 2;
                }
                if (texte != "")
                {
                    System.IO.File.WriteAllText(cheminBackup + "Backup.txt", texte);
                }
                if (CompteurFaxBD == CompteurDeFaxToday || (CompteurFaxBD == 0 && CompteurDeFaxToday == 0))
                {
                    isOkLabel.Text = "Ok !";
                    CompteurFaxEnAttente = 0;
                }
                else
                {
                    ++erreurNb;
                    isOkLabel.Text = "Erreur";

                }
                LabelFaxAttente.Text = CompteurFaxEnAttente + "";
            }
            Lancer.Enabled = true;
            Stopper.Enabled = false;
        }//backgroundWorker1_RunWorkerCompleted     
        //Change les parametres par défaut
        //Intialisateur du programme
        private void InitializePath() //Initialise les chemins depuis le fichier de configuration
        {
            cheminImage = new DirectoryInfo(@ConfigurationManager.AppSettings["cheminImage"] + @"\");
            cheminFaxTraite = new DirectoryInfo(@ConfigurationManager.AppSettings["cheminFaxTraite"] + @"\");
            cheminSauvegarde = new DirectoryInfo(@ConfigurationManager.AppSettings["cheminSauvegarde"] + @"\");
            cheminFaxNonTraite = new DirectoryInfo(@ConfigurationManager.AppSettings["cheminFaxNonTraite"] + @"\");
            cheminBackup = new DirectoryInfo(@ConfigurationManager.AppSettings["cheminBackup"] + @"\");
        }
        private void InitializeMail()
        {
            adresseMailFrom = ConfigurationManager.AppSettings["adresseSourceDefaut"];
            
            for (int i = 0; i < 3; ++i)
            {
                adresseMailTo[i] = ConfigurationManager.AppSettings["adresse" + i];
            }

            smtp= ConfigurationManager.AppSettings["smtpDefaut"];
            user= ConfigurationManager.AppSettings["userDefaut"];
            mdpSmtp = ConfigurationManager.AppSettings["mdpDefaut"];
            if(ConfigurationManager.AppSettings["portDefaut"] != null)
            {
                port = Int32.Parse(ConfigurationManager.AppSettings["portDefaut"]);
            }       
            labelUser.Text = user;
        }
        private void InitializeBackgroundWorker()//Initialise le traitement en tache de fond
        {
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);
        }
        private void InitializeTimer()
        {
            Int32.TryParse(ConfigurationManager.AppSettings["interval"], out interval);
            if (interval == 0)
            {
                interval = 30;
                labelInterval.Text = interval + "";
                interval = 30 * 1000;
            }
            timer1.Tick += Lancer_Click; // Chaque 10 secondes mon évènement se déclenche.
            timer1.Interval = interval; // Interval en milliseconde 600 000 = 10 minutes  
            labelInterval.Text = interval/1000 + "";

        }//Initialise le time
        //Main
        public Form1()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            jouractuel = dateTime.Day;
            codeBarre.AddFontFile("c39hrp24dhtt.ttf");
            codeBarre.AddFontFile("Code39.ttf");
            InitializePath();
            InitializeComponent();
            InitializeMail();
            Int32.TryParse(ConfigurationManager.AppSettings["nbFax"], out CompteurDeFaxToday);
            NbFaxToday.Text = "" + CompteurDeFaxToday;

            InitializeBackgroundWorker();
            InitializeTimer();
        }
        private void IntervalDeTraitementToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Form FormIntervalleTemps = new FormIntervalTemps();
            Stopper_Click(sender, e);
            FormIntervalleTemps.ShowDialog();
            Int32.TryParse(ConfigurationManager.AppSettings["interval"], out interval);
            labelInterval.Refresh();
            labelInterval.Text = interval/1000 + "";
            
        } //TIMER
        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormParamChemin = new FormParamChemin();
            Stopper_Click(sender, e);
            FormParamChemin.ShowDialog();
            cheminImage = new DirectoryInfo(@ConfigurationManager.AppSettings["cheminImage"] + @"\");
            cheminFaxTraite = new DirectoryInfo(@ConfigurationManager.AppSettings["cheminFaxTraite"] + @"\");
            cheminSauvegarde = new DirectoryInfo(@ConfigurationManager.AppSettings["cheminSauvegarde"] + @"\");
            cheminFaxNonTraite = new DirectoryInfo(@ConfigurationManager.AppSettings["cheminFaxNonTraite"] + @"\");
            cheminBackup = new DirectoryInfo(@ConfigurationManager.AppSettings["cheminBackup"] + @"\");
        }
        private void ajouterUnUtilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormParamMail = new FormParamMail();
            Stopper_Click(sender, e);
            FormParamMail.ShowDialog();
            
            user = ConfigurationManager.AppSettings["userDefaut"];
            labelUser.Text = user;
        }
        private void mailAContacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormParamContact = new ParamMailContact();
            FormParamContact.ShowDialog();
            Stopper_Click(sender, e);
        }
    }//Form1
}//ApplicationLaboratoire