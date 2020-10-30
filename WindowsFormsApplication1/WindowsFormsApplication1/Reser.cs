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
    public partial class Reser : Form
    {
        String Id;
        public Reser(String id)
        {
            this.Id = id;

            InitializeComponent();
        }

        private void Reser_Load(object sender, EventArgs e)
        {
            this.label3.Text = this.Id;
            Fonctioncs fonction = new Fonctioncs();
            String[]colonne=new String[1];
            colonne[0]="idEvenement";
            String[]value=new String[1];
            value[0]=this.Id;
            Object[] tableau = fonction.Select2(new Chaissee(), colonne, value, null);
            Chaissee[]tab=fonction.objtoch(tableau);
            List<String>list=new List<String>();
            for (int i = 0; i < tab.Length; i++) {
                list.Add(tab[i].idzone);
            }
            IEnumerable<String> res = list.AsQueryable().Distinct();
            List<String> asList = res.ToList();
            String[] listestring = asList.ToArray();
            for (int i = 0; i < listestring.Length; i++) {
                comboBox1.Items.Add(listestring[i]);
            }
            for(int i=0;i<listestring.Length;i++){
            Chaissee[] teenAgerStudents = tab.Where(s => s.idzone == listestring[i]).ToArray();
            int x = teenAgerStudents.Length - 1;
            listBox1.Items.Add(listestring[i]+"-"+teenAgerStudents[0].numero + "-" + teenAgerStudents[x].numero);
            }
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fonctioncs fonction = new Fonctioncs();
            String zone = comboBox1.SelectedItem.ToString();
            String reservation = textBox1.Text;
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            try
            {
                fonction.updateBillet(zone, reservation, this.Id, theDate);
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message);
            
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
