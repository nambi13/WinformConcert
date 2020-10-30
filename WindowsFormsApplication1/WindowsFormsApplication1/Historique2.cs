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
    public partial class Historique2 : Form
    {
        String id;
        public Historique2(String id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Historique2_Load(object sender, EventArgs e)
        {
            Fonctioncs fonction = new Fonctioncs();
            Mouvements[] tableau = fonction.Prevision(this.id);
            
            for (int i = 0; i < tableau.Length; i++) {
                listBox1.Items.Add("zone"+tableau[i].idzone + "              " + tableau[i].pourcentage+"%" + "                                   " + tableau[i].prix_totale+"                                   "+tableau[i].dateachat);
                
            }
            Pourcentage[] tab = fonction.tableauPourcentage(this.id);
            for (int i = 0; i < tab.Length; i++) {
                listBox2.Items.Add("Zone" + tab[i].idzone + "          " + tab[i].prevision + "%                              "+ tab[i].prix_unitaire);
            
            
            }
        }
      

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
