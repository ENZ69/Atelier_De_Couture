using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_AtelierCouture.Forms
{
    public partial class FormMesure : Form
    {
        public int idPersonne;
        public string sexe;
        public FormMesure()
        {
            InitializeComponent();
        }

        private void FormMesure_Load(object sender, EventArgs e)
        {
            pnFemme.Visible = sexe == "Femme" ? true : false;
        }
    }
}
