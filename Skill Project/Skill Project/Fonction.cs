﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_Project
{
    class Fonction
    {
        static List<string> LangueElement = new List<string>();

        //  Call this function to remove the key from memory after use for security
        [System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        public static string fileName2 = @"C:\SkillProject\Preferences_SkillProject.txt";
        public static string family = "Palatino Linotype";
        public static string FichierLangue = "";

        public static void ecrireFichier(string transparence, string BoiteMessage, string Police, string InformationsDefilantes, string Langue, string Tutoriel, string provenance, string dateprovenance)
        {
            // On récupère tout
            StreamReader reader = File.OpenText(fileName2);
            string ligne;

            List<string> listeElement = new List<string>();
            while (!reader.EndOfStream)
            {
                ligne = reader.ReadLine();
                listeElement.Add(ligne);
            }
            reader.Close();

            //// Debut MAJ \\\\

            // Gestion recents
            if (provenance != "")
            {
                if (provenance != listeElement[6])
                {
                    listeElement[11] = listeElement[9];
                    listeElement[10] = listeElement[8];
                    listeElement[9] = listeElement[7];
                    listeElement[8] = listeElement[6];
                    listeElement[7] = dateprovenance;
                    listeElement[6] = provenance;
                }
            }

            // Gestion transparence
            if (transparence != "")
            {
                listeElement[0] = transparence;
            }

            // Gestion des boites de messages
            if (BoiteMessage != "")
            {
                listeElement[1] = BoiteMessage;
            }

            // Gestion de la police
            if (Police != "")
            {
                listeElement[2] = Police;
            }

            // Gestion des Informations Defilantes
            if (InformationsDefilantes != "")
            {
                listeElement[3] = InformationsDefilantes;
            }

            // Gestion de la Langue
            if (Langue != "")
            {
                listeElement[4] = Langue;
            }

            // Gestion du Tutoriel
            if (Tutoriel != "")
            {
                listeElement[5] = Tutoriel;
            }


            //// Fin MAJ \\\\

            // on renvoie tout

            StreamWriter writer = new StreamWriter(fileName2);

            foreach (var item in listeElement)
            {
                writer.WriteLine(item);
            }
            writer.Close();

        }

        public static List<string> Preference() // Retourne toutes les préférences sous form List
        {
            StreamReader reader = File.OpenText(fileName2);
            string ligne;

            List<string> listeElement = new List<string>();
            while (!reader.EndOfStream)
            {
                ligne = reader.ReadLine();
                listeElement.Add(ligne);
            }
            reader.Close();

            if (listeElement[4] == "Francais")
            {
                listeElement[4] = "Francais.txt";
            }

            if (listeElement[4] == "Anglais")
            {
                listeElement[4] = "Anglais.txt";
            }

            return listeElement;
        }

        public static List<string> LectureProjet() // Retourne les lignes du fichier de langue choisit pour les projets 
        {
            List<string> ListeProjet = new List<string>();
            List<string> Langue = new List<string>();

            Langue = Preference();
            string name = "Projet" + Langue[4];

            // string fileName = @"Langage\Projet\"+ name; // Une fois publié
            string fileName = @"..\..\Langage\Projet\" + name;

            StreamReader reader = File.OpenText(fileName);
            string ligne;

            while (!reader.EndOfStream)
            {
                ligne = reader.ReadLine();
                ListeProjet.Add(ligne);
            }
            reader.Close();

            return ListeProjet;
        }

        public static void creationFichier() // Créé fichier si existe pas
        {
            string folderName = @"c:\";
            string pathString = System.IO.Path.Combine(folderName, "SkillProject");
            System.IO.Directory.CreateDirectory(pathString);
            string fileName = "Preferences_SkillProject.txt";
            pathString = System.IO.Path.Combine(pathString, fileName);


            Console.WriteLine("Path to my file: {0}\n", pathString);


            using (System.IO.FileStream fs = new System.IO.FileStream(pathString, FileMode.Append))
            {

                for (byte i = 0; i < 100; i++)
                {
                    fs.WriteByte(i);
                }

            }

            try
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
                foreach (byte b in readBuffer)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }

            string[] lines = { "1", "True", "Palatino Linotype", "False", "Francais", "True", "Aucun", "jj/mm/aaaa", "Aucun", "jj/mm/aaaa", "Aucun", "jj/mm/aaaa" };
            System.IO.File.WriteAllLines(@"C:\SkillProject\Preferences_SkillProject.txt", lines);
        }

        public static string[] lireFichier() // Lit les préférences et retourne sous form string
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\SkillProject\Preferences_SkillProject.txt");

            return lines;
        }

        public static int InputBox(string title, string promptText) // Affichage de boîte information qui se ferme toute seule
        {
            Form form = new Form();
            LinkLabel texte = new LinkLabel();
            ProgressBar Progress = new ProgressBar();

            Progress.Minimum = 0;
            Progress.Maximum = 100;

            form.Text = title;
            texte.Text = promptText;
            texte.SetBounds(9, 20, 372, 13);
            Progress.SetBounds(9, 30, 372, 20);

            texte.AutoSize = true;
            Progress.Anchor = Progress.Anchor | AnchorStyles.Right;

            form.ClientSize = new Size(396, 91);
            form.Controls.AddRange(new Control[] { texte, Progress });
            form.ClientSize = new Size(Math.Max(300, texte.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            Progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;

            form.Show();

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10); // --> Timer au tick

                Progress.Value += 1;
                form.Show();
            }

            int Res = Progress.Value;
            if (Res == 100)
                form.Close();

            return Res;
        }

        public static void policeTexte(System.Windows.Forms.Form Frm) // Gestion de la police de l'appli
        {
            List<string> Policetext = new List<string>();
            Policetext = Preference();

            if (Policetext[2] != family)
            {
                try
                {
                    foreach (Control x in Frm.Controls)
                    {
                        // MessageBox.Show(x.ToString());

                        if (x is TextBox || x is RichTextBox || x is Label || x is Button || x is GroupBox || x is ListBox || x is DataGridView || x is ComboBox || x is CheckBox
                            || x is RadioButton || x is TreeView || x is NumericUpDown)
                        {
                            x.Font = new Font(Policetext[2], x.Font.SizeInPoints, x.Font.Style);
                        }

                        // Panel
                        if (x is Panel)
                        {
                            foreach (Control c in x.Controls)
                            {
                                c.Font = new Font(Policetext[2], c.Font.SizeInPoints, c.Font.Style);
                            }
                        }

                        // GroupBox
                        if (x is GroupBox)
                        {
                            foreach (Control c in x.Controls)
                            {
                                c.Font = new Font(Policetext[2], c.Font.SizeInPoints, c.Font.Style);
                            }
                        }

                    }
                }
                catch
                {
                    foreach (Control x in Frm.Controls)
                    {
                        if (x is TextBox || x is RichTextBox || x is Label || x is Button || x is GroupBox || x is ListBox || x is DataGridView || x is ComboBox || x is CheckBox
                            || x is RadioButton || x is TreeView || x is NumericUpDown)
                        {
                            x.Font = new Font(family, x.Font.SizeInPoints, x.Font.Style);
                        }

                        // Panel
                        if (x is Panel)
                        {
                            foreach (Control c in x.Controls)
                            {
                                c.Font = new Font(family, c.Font.SizeInPoints, c.Font.Style);
                            }
                        }

                        // GroupBox
                        if (x is GroupBox)
                        {
                            foreach (Control c in x.Controls)
                            {
                                c.Font = new Font(family, c.Font.SizeInPoints, c.Font.Style);
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Control x in Frm.Controls)
                {
                    if (x is TextBox || x is RichTextBox || x is Label || x is Button || x is GroupBox || x is ListBox || x is DataGridView || x is ComboBox || x is CheckBox
                            || x is RadioButton || x is TreeView || x is NumericUpDown)
                    {
                        x.Font = new Font(family, x.Font.SizeInPoints, x.Font.Style);
                    }

                    // Panel
                    if (x is Panel)
                    {
                        foreach (Control c in x.Controls)
                        {
                            c.Font = new Font(family, c.Font.SizeInPoints, c.Font.Style);
                        }
                    }

                    // GroupBox
                    if (x is GroupBox)
                    {
                        foreach (Control c in x.Controls)
                        {
                            c.Font = new Font(family, c.Font.SizeInPoints, c.Font.Style);
                        }
                    }
                }
            }

            /*
            // Récupération de toutes les "forms" de l'application
            Assembly asm = Assembly.GetExecutingAssembly();
            
            // Parcours de tous les types de l'assembly
            foreach (Type t in asm.GetTypes())
            {
                // Il s'agit d'une form
                if (t.BaseType == typeof(Form))
                {
                    
                }
            }
            */
        }

        public static List<string> LangageAppli() // Retourne une liste contenant toutes les lignes du fichier de langue approprié
        {
            List<string> listeElement = new List<string>();
            listeElement = Preference();

            List<string> LangueElement = new List<string>();

            // string fileName = @"Langage\"+ listeElement[4]; // Une fois publié
            string fileName3 = @"..\..\Langage\" + listeElement[4];


            StreamReader reader = File.OpenText(fileName3);
            string ligne;

            while (!reader.EndOfStream)
            {
                ligne = reader.ReadLine();
                LangueElement.Add(ligne);
            }
            reader.Close();

            return (LangueElement);
        }

        public static DialogResult InputBoxLogin(string title, string promptText, ref string value, ref bool check) // MessageBox nom joueur
        {
            LangueElement = LangageAppli();

            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            CheckBox cb1 = new CheckBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            cb1.Checked = check;

            cb1.Text = LangueElement[166];
            buttonOk.Text = LangueElement[167];
            buttonCancel.Text = LangueElement[168];
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            cb1.SetBounds(12, 56, 372, 20);
            buttonOk.SetBounds(228, 86, 75, 23);
            buttonCancel.SetBounds(309, 86, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            cb1.Anchor = cb1.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 117);
            form.Controls.AddRange(new Control[] { label, textBox, cb1, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            check = cb1.Checked;
            return dialogResult;
        }

        public static List<string> LireStatsProjetJeu(string destination) // Renvoie les stats du projet
        {
            // On récupère tout
            StreamReader reader = File.OpenText(destination);
            string ligne;

            List<string> listeElement = new List<string>();
            while (!reader.EndOfStream)
            {
                ligne = reader.ReadLine();
                //// DEBUT DECRYPTAGE  \\\\

                string decrypted1 = Decrypt(ligne, "p@ssw0rd");

                //// FIN DECRYPTAGE  \\\\

                // MessageBox.Show(decrypted1);

                listeElement.Add(decrypted1);
            }
            reader.Close();

            return listeElement;
        }

        public static void ecrireFichierProjetJeu(string destination, string joueur, string victoireOudefaite) // Enregistrement stats par joueur
        {
            string filename3 = @"..\..\FormsCompetence\" + destination;

            List<string> listeElement = new List<string>();
            listeElement = LireStatsProjetJeu(filename3);
            


            //// Debut MAJ \\\\

            int i = 0;
            int duplicate = 0;
            int victoire = 0;
            int defaite = 0;
            Decimal ratio = 0;

            string JExiste = "NON";

            foreach (var item in listeElement)
            {
                string[] result = Regex.Split(item, @"\|");

                if (result[0] == joueur)
                {
                    JExiste = result[0];

                    /*
                    MessageBox.Show("Joueur : " + result[0]);
                    MessageBox.Show("Victoire : " + result[1]);
                    MessageBox.Show("Défaite : " + result[2]);
                    MessageBox.Show("Ratio : " + result[3]);
                    */

                    victoire = Convert.ToInt32(result[1]);
                    defaite = Convert.ToInt32(result[2]);

                    if (victoireOudefaite == "Defaite")
                    {
                        defaite++;
                    }

                    if (victoireOudefaite == "Victoire")
                    {
                        victoire++;
                    }

                    victoire = victoire * 100;

                    if (defaite == 0)
                    {
                        ratio = victoire;
                    }
                    else
                    {
                        ratio = victoire / defaite;
                    }

                    ratio = ratio / 100;
                    victoire = victoire / 100;
                    duplicate = i;
                }

                i++;
            }

            if (JExiste == "NON")
            {
                if (victoireOudefaite == "Defaite")
                {
                    defaite++;
                }

                if (victoireOudefaite == "Victoire")
                {
                    victoire++;
                }

                victoire = victoire * 100;

                if (defaite == 0)
                {
                    ratio = victoire;
                }
                else
                {
                    ratio = victoire / defaite;
                }

                ratio = ratio / 100;
                victoire = victoire / 100;

                listeElement.Add(joueur + "|" + victoire + "|" + defaite + "|" + ratio);
            }
            else
            {
                listeElement[duplicate] = joueur + "|" + victoire + "|" + defaite + "|" + ratio;
            }

            //// Fin MAJ \\\\




            


            //// DEBUT CRYPTAGE  \\\\

            List<string> listeElement2 = new List<string>();

            foreach (var item in listeElement)
            {
                string encrypted = Encrypt(item, "p@ssw0rd");
                listeElement2.Add(encrypted);
            }

            //// FIN CRYPTAGE  \\\\






            // on renvoie tout

            StreamWriter writer = new StreamWriter(filename3);

            foreach (var item in listeElement2)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }

        /// <summary>
        /// Crypte une chaine en utilisant un chiffreur symétrique
        /// </summary>
        /// <param name="plainText">Chaine à crypter</param>
        /// <param name="pass">Mot de passe utilisé pour dériver la clé</param>
        /// <returns>Chaine cryptée</returns>
        private static string Encrypt(string plainText, string pass)
        {
            string result = string.Empty;

            System.Security.Cryptography.TripleDESCryptoServiceProvider des =
                    new System.Security.Cryptography.TripleDESCryptoServiceProvider();
            des.IV = new byte[8];

            System.Security.Cryptography.PasswordDeriveBytes pdb =
                    new System.Security.Cryptography.PasswordDeriveBytes(pass, new byte[0]);

            des.Key = pdb.CryptDeriveKey("RC2", "SHA1", 128, new byte[8]);

            using (MemoryStream ms = new MemoryStream(plainText.Length * 2))
            {
                using (System.Security.Cryptography.CryptoStream encStream = new
                    System.Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(),
                    System.Security.Cryptography.CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    encStream.Write(plainBytes, 0, plainBytes.Length);
                    encStream.FlushFinalBlock();
                    byte[] encryptedBytes = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(encryptedBytes, 0, (int)ms.Length);
                    encStream.Close();
                    ms.Close();
                    result = Convert.ToBase64String(encryptedBytes);
                }
            }
            return result;
        }

        /// <summary>
        /// Décrypte une chaine cryptée à partir d'un chiffreur symétrique
        /// </summary>
        /// <param name="base64String">chaine cryptée</param>
        /// <param name="pass">Mot de passe utilisé pour dériver la clé</param>
        /// <returns>Chaine décryptée</returns>
        private static string Decrypt(string base64String, string pass)
        {
            string result = string.Empty;

            System.Security.Cryptography.TripleDESCryptoServiceProvider des =
                new System.Security.Cryptography.TripleDESCryptoServiceProvider();
            des.IV = new byte[8];
            System.Security.Cryptography.PasswordDeriveBytes pdb =
                new System.Security.Cryptography.PasswordDeriveBytes(pass, new byte[0]);
            des.Key = pdb.CryptDeriveKey("RC2", "SHA1", 128, new byte[8]);
            byte[] encryptedBytes = Convert.FromBase64String(base64String);

            using (MemoryStream ms = new MemoryStream(base64String.Length))
            {
                using (System.Security.Cryptography.CryptoStream decStream =
                    new System.Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(),
                        System.Security.Cryptography.CryptoStreamMode.Write))
                {
                    decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                    decStream.FlushFinalBlock();
                    byte[] plainBytes = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(plainBytes, 0, (int)ms.Length);
                    result = Encoding.UTF8.GetString(plainBytes);
                }
            }
            return result;
        }

        public static string[] lireCodeProjet(string destination) // Lit le code du projet et le renvoie
        {
            string fileName3 = @"..\..\FormsCompetence\" + destination;

            string[] lines = System.IO.File.ReadAllLines(fileName3);

            return lines;
        }


    }
}
