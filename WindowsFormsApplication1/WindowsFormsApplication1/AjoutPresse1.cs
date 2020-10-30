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
    public partial class AjoutPresse1 : Form
    {
        String id;
        public AjoutPresse1(String id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void AjoutPresse_Load(object sender, EventArgs e)
        {
            Fonctioncs fonction = new Fonctioncs();
            Object[] tableau = fonction.Select2(new Presse(), null, null, null);
            Presse[] tabl = fonction.objtopresse(tableau);
            for (int i = 0; i < tabl.Length; i++) {
                comboBox1.Items.Add(tabl[i].nom);
            
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fonctioncs fonction = new Fonctioncs();
            Object[]tableau=fonction.Select2(new Presse(),null,null,null);
            Presse[]tab=fonction.objtopresse(tableau);
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            label1.Text = theDate;
            Presse[] teenAgerStudents = tab.Where(s => s.nom ==comboBox1.SelectedItem.ToString()).ToArray();
            fonction.insertionpresse(this.id, teenAgerStudents[0].idpresse, theDate);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
