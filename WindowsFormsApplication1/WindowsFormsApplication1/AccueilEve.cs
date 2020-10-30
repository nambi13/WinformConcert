using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class AccueilEve : Form
    {
        String Id;
        public AccueilEve(String id)
        {
            this.Id = id;
            InitializeComponent();
        }

        private void AccueilEve_Load(object sender, EventArgs e)
        {

        }

        private void Reservation_Click(object sender, EventArgs e)
        {
            new Reser(this.Id).Show();
        }

        private void Utiliser_Presse_Click(object sender, EventArgs e)
        {
            new AjoutPresse1(this.Id).Show();

        }

        private void Historique_Click(object sender, EventArgs e)
        {
            new Historique2(this.Id).Show();
        }

        private void Courbe_Click(object sender, EventArgs e)
        {
            new Courb(this.Id).Show();
        }
    }
}
