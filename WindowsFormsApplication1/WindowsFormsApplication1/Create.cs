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
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void Create_Load(object sender, EventArgs e)
        {
            Fonctioncs fonction = new Fonctioncs();
            Object[] tab = fonction.Select2(new Stade(), null, null, null);
            Stade[] tableau = fonction.objtoStade(tab);
            for (int i = 0; i < tableau.Length; i++)
            {
                listBox1.Items.Add(tableau[i].nom);

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //label1.Text = dateTimePicker1.Value.Date.ToString("dd/MM/yyyy")
            //label1.Text = label1.Text.Replace(".", "-")
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.label1.Text = dateTimePicker1.Text;
            String x = this.listBox1.Text;

            int id=0;
            Object[] tableu = new Fonctioncs().Select2(new Evenement(), null, null, null);
            if (tableu.Length == 0)
            {
                id = 1;
            }
            else {
                id = tableu.Length + 1;
            }
            this.label2.Text = this.listBox1.Text;
            Fonctioncs fonction = new Fonctioncs();
            fonction.insertEvenement(dateTimePicker1.Text.ToString(),x, id.ToString());



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
