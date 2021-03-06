﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_Project
{
    public partial class FormQuiSuisJe : System.Windows.Forms.Form
    {
        DateTime DateDeNaissance = Convert.ToDateTime("03/11/1996");
        int durationMilliseconds = 3000;

        List<string> LangueElement = new List<string>();

        public int GetAge()
        {

            // Age théorique 
            int age = DateTime.Now.Year - DateDeNaissance.Year;

            // Date de l'anniversaire de cette année 
            DateTime DateAnniv =
            new DateTime(DateTime.Now.Year, DateDeNaissance.Month, DateDeNaissance.Day);

            // Si pas encore passé, retirer 1 an 
            if (DateAnniv > DateTime.Now)
                age--;

            return age;

        }

        public FormQuiSuisJe()
        {
            InitializeComponent();
        }

        private void btnRetourQSJ_Click(object sender, EventArgs e)
        {
            FormIndex FI = (FormIndex)this.MdiParent;

            if (FI.nb == 1) // dehors
            {
                
                FI.SfsfToolStripMenuItem.Enabled = true;
                FI.AfficToolStripMenuItem.Enabled = true;
                FI.CommentÇaMarcheToolStripMenuItem.Enabled = true;
                FI.QuiSommesNousToolStripMenuItem.Enabled = true;

                this.Close();

                FI.QuiSommesNousToolStripMenuItem.BackColor = Color.Transparent;
                
                FI.PictureBox1.Visible = true;
                var pos = FI.PointToScreen(FI.LblCreateur.Location);
                pos = FI.PictureBox1.PointToClient(pos);
                FI.LblCreateur.Parent = FI.PictureBox1;
                FI.LblCreateur.Location = pos;
                FI.LblCreateur.BackColor = Color.Transparent;
            }
            else // dedans
            {
                FI.QuitterToolStripMenuItem.Enabled = true;
                FI.AffichageToolStripMenuItem.Enabled = true;
                FI.AfficToolStripMenuItem.Enabled = true;
                FI.CommentÇaMarcheToolStripMenuItem.Enabled = true;
                FI.QuiSommesNousToolStripMenuItem.Enabled = true;
                FI.SuggestionToolStripMenuItem.Enabled = true;

                if (FI.ListeToolStripMenuItem.Enabled==false)
                {
                    FormListe FL = new FormListe();
                    FL.MdiParent = FI;
                    FL.Show();
                }

                if(FI.MiniaturesToolStripMenuItem.Enabled==false)
                {
                    FormMiniature FM = new FormMiniature();
                    FM.MdiParent = FI;
                    FM.Show();
                }
                
                if(FI.ArborescenceToolStripMenuItem.Enabled==false)
                {
                    FormArborescence FA = new FormArborescence();
                    FA.MdiParent = FI;
                    FA.Show();
                }
                
                this.Close();

                FI.QuiSommesNousToolStripMenuItem.BackColor = Color.Transparent;
                FI.AffichageToolStripMenuItem.BackColor = Color.SandyBrown;
            }
            
        }

        private void FormQuiSuisJe_Load(object sender, EventArgs e)
        {
            LangueElement = Fonction.LangageAppli();
            this.Text = LangueElement[46];
            lblTitreQSJ.Text = LangueElement[46];
            label3.Text = LangueElement[47];
            label4.Text = LangueElement[48];
            label6.Text = LangueElement[49];
            label5.Text = LangueElement[50];
            label7.Text = LangueElement[51];
            label8.Text = LangueElement[52];
            label9.Text = LangueElement[53];
            label10.Text = LangueElement[54];
            label11.Text = LangueElement[55];
            label2.Text = LangueElement[56];
            label18.Text = LangueElement[57];
            label19.Text = LangueElement[58];
            label20.Text = LangueElement[59];
            label17.Text = LangueElement[60];
            label12.Text = LangueElement[61];
            btnRetourQSJ.Text = LangueElement[62];

            label1.Text = LangueElement[63] + GetAge() + LangueElement[64] + "\n" + LangueElement[65] + "\n" + LangueElement[66] + "\n" + LangueElement[67] + "\n" + LangueElement[68] + "\n" + LangueElement[69] + "\n";
            
            radioButton1.Select();

            Fonction.policeTexte(this); // Gestion police
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "https://twitter.com/dimitryrobin";
            p.Start();

            label2.Select();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "https://plus.google.com/u/0/102986982461630863918/posts";
            p.Start();

            label2.Select();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "https://www.facebook.com/dimitry.robin";
            p.Start();

            label2.Select();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "https://www.facebook.com/dimitryrobin.fr/?ref=hl";
            p.Start();

            label2.Select();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "https://www.youtube.com/user/TirdImpact";
            p.Start();

            label2.Select();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "http://dimitryrobin.fr/";
            p.Start();

            label2.Select();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {            
            toolTip1.Show(toolTip1.GetToolTip(pictureBox1), pictureBox1, durationMilliseconds);
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show(toolTip2.GetToolTip(pictureBox6), pictureBox6, durationMilliseconds);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip3.Show(toolTip3.GetToolTip(pictureBox2), pictureBox2, durationMilliseconds);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip4.Show(toolTip4.GetToolTip(pictureBox3), pictureBox3, durationMilliseconds);
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            toolTip5.Show(toolTip5.GetToolTip(pictureBox5), pictureBox5, durationMilliseconds);
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            toolTip6.Show(toolTip6.GetToolTip(pictureBox4), pictureBox4, durationMilliseconds);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "http://dimitryrobin.fr/CV-Developpeur-Application/";
            p.Start();

            label2.Select();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "http://dimitryrobin.fr/Portfolio/";
            p.Start();

            label2.Select();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "https://www.linkedin.com/in/dimitryrobin";
            p.Start();

            label2.Select();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "http://www.viadeo.com/fr/profile/dimitry.robin";
            p.Start();

            label2.Select();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "https://github.com/Dimy49";
            p.Start();

            label2.Select();
        }

        private void FormQuiSuisJe_Enter(object sender, EventArgs e)
        {
            FormIndex form = (FormIndex)this.MdiParent;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormQuiSuisJe_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
