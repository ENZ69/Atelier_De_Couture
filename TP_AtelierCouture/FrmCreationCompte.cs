using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_AtelierCouture.Forms;
using TP_AtelierCouture.Model;

namespace TP_AtelierCouture
{
    public partial class FrmCreationCompte : Form
    {
        bdGlAtelierEntities db = new bdGlAtelierEntities();
        public FrmCreationCompte()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Voulez vous quittez l'application ?", "Attention vous allez fermer l'application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDejaCompte_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAuthentification frm = new FrmAuthentification();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtAdresse.Text == String.Empty || txtConfMdp.Text == String.Empty || txtMdp.Text == String.Empty
                || txtNom.Text == String.Empty || txtPrenom.Text == String.Empty || txtTelephone.Text == String.Empty)
            {
                MessageBox.Show("Tous les champs sont obligatoires !", "Control saisie");
            }
            else
            {
                Personne p1 = new Personne();
                Gerant g = new Gerant();
                String date = DateTime.Now.Year.ToString();
                p1.NomPersonne = txtNom.Text;
                p1.PrenomPersonne = txtPrenom.Text;
                p1.AdressePersonne = txtAdresse.Text;
                p1.TelPersonne = txtTelephone.Text;
                g.MotDePasseGerant = txtConfMdp.Text;
                if (txtMdp.Text != txtConfMdp.Text)
                {
                    MessageBox.Show("Le mot de passe ne correspond pas !", "saisissez le même mot de passe dans les deux champs");
                }
                else
                {
                    db.Personne.Add(p1);
                    db.SaveChanges();
                    g.idPersonne = p1.idPersonne;
                    String id = g.idPersonne.ToString();
                    if (txtPrenom.Text.Length < 2)
                    {
                        g.identifiantGerant = id + txtPrenom.Text.Substring(0, 1).ToUpper() + "#" + txtNom.Text.Substring(0, 2).ToUpper() + date;

                    }
                    else
                    {
                        g.identifiantGerant = id + txtPrenom.Text.Substring(0, 2).ToUpper() + txtNom.Text.Substring(0, 2).ToUpper() + date;

                    }
                    db.Gerant.Add(g);
                    db.SaveChanges();
                    videChamps();
                    this.Hide();
                    FrmAuthentification frm = new FrmAuthentification();
                    frm.Closed += (s, args) => this.Close();
                    frm.Show();
                    MessageBox.Show("Votre identifiant est : " + g.identifiantGerant + ".", "Compte créé avec succès !");
                }
            }

        }

        private void videChamps()
        {
            txtAdresse.Text = String.Empty;
            txtConfMdp.Text = String.Empty;
            txtMdp.Text = String.Empty;
            txtNom.Text = String.Empty;
            txtPrenom.Text = String.Empty;
            txtTelephone.Text = String.Empty;
            txtNom.Focus();
        }
    }
}
