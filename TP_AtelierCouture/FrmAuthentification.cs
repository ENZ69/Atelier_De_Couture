using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_AtelierCouture.Model;

namespace TP_AtelierCouture
{
    public partial class FrmAuthentification : Form
    {
        bdGlAtelierEntities db = new bdGlAtelierEntities();
        public FrmAuthentification()
        {
            InitializeComponent();
        }

        private void btnFrmClose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Voulez vous quittez l'application ?", "Attention vous allez fermer l'application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaxisize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btnCreateCompte_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCreationCompte f1 = new FrmCreationCompte();
            f1.Closed += (s, args) => this.Close();
            f1.Show();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == String.Empty || txtMotDePasse.Text == String.Empty)
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Control saisie");
                videChamps();
            }else{

                var gerants = db.Gerant.ToArray();
                var log = txtLogin.Text;
                var mdp = txtMotDePasse.Text;
                int trouv = 0;
                foreach (var g in gerants)
                {
                    if (log == g.identifiantGerant && mdp == g.MotDePasseGerant)
                    {
                        trouv++;
                    }
                    else
                    {

                    }
                }
                if (trouv == 0)
                {
                    MessageBox.Show("Login ou Mot de passe incorrect !", "Control d'authentification");
                    videChamps();
                }
                else
                {
                    videChamps();
                    this.Hide();
                    FrmMainMenu frm = new FrmMainMenu();
                    frm.Closed += (s, args) => this.Close();
                    frm.Show();
                }
            }
        }

        private void videChamps()
        {
            txtLogin.Text = String.Empty;
            txtMotDePasse.Text = String.Empty;

        }

    }
}

