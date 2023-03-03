using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_AtelierCouture.Model;

namespace TP_AtelierCouture.Forms
{
    public partial class FormCustomers : Form
    {
        bdGlAtelierEntities db = new bdGlAtelierEntities();
        public FormCustomers()
        {
            InitializeComponent();
            LoadTheme();

            dgClient.DataSource = db.Client.ToList();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Personne p = new Personne();
            p.NomPersonne = txtNom.Text;
            p.PrenomPersonne = txtPrenom.Text;
            p.AdressePersonne = txtAdresse.Text;
            p.TelPersonne = txtTel.Text;
            db.Personne.Add(p);
            db.SaveChanges();
            Client c = new Client();
            c.CNIClient = txtCNI.Text;
            c.SexeClient = cbbSexe.Text;
            c.idPersonne = p.idPersonne;
            db.Client.Add(c);
            db.SaveChanges();
            effacer();
        }

        private void effacer()
        {
            txtAdresse.Text = string.Empty;
            txtCNI.Text = string.Empty;
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtTel.Text = string.Empty;
            cbbSexe.Text = string.Empty;
            dgClient.DataSource= db.Client.ToList();
            txtNom.Focus();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgClient.CurrentRow.Cells[0].Value.ToString());
            txtCNI.Text = dgClient.CurrentRow.Cells[1].Value.ToString();
            cbbSexe.Text = dgClient.CurrentRow.Cells[2].Value.ToString();
            var p = db.Personne.Find(id);
            txtNom.Text = p.NomPersonne;
            txtPrenom.Text = p.PrenomPersonne;
            txtAdresse.Text = p.AdressePersonne;
            txtTel.Text = p.TelPersonne;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgClient.CurrentRow.Cells[0].Value.ToString());
            Personne p = db.Personne.Find(id);
            p.NomPersonne = txtNom.Text;
            p.PrenomPersonne = txtPrenom.Text;
            p.AdressePersonne = txtAdresse.Text;
            p.TelPersonne = txtTel.Text;
            Client c = db.Client.Find(id);
            c.CNIClient = txtCNI.Text;
            c.SexeClient = cbbSexe.Text;
            db.SaveChanges();
            effacer();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgClient.CurrentRow.Cells[0].Value.ToString());
            Personne p = db.Personne.Find(id);
            db.Personne.Remove(p);
            Client c = db.Client.Find(id);
            db.Client.Remove(c);
            db.SaveChanges();
            effacer();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            effacer();
        }

        private void btnMesure_Click(object sender, EventArgs e)
        {
            FormMesure f = new FormMesure();
            f.idPersonne = int.Parse(dgClient.CurrentRow.Cells[0].Value.ToString());
            f.sexe = cbbSexe.Text;
            f.Show();
        }
    }
}
