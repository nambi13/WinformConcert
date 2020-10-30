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
    public partial class Form1 : Form
    {
        public Form1()
        {
        InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fonctioncs fonction = new Fonctioncs();
          //  Object[] transaction = fonction.Select2(new Mouvements(), null, null, null);
            Object[] tab = fonction.Select2(new Stade(), null, null, null);
            Stade[] tableau = fonction.objtoStade(tab);
            for (int i = 0; i < tableau.Length; i++)
            {
                listBox1.Items.Add(tableau[i].nom);

            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new stade1().Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Countour(this.listBox1.Text).Show();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.label2.Text = this.listBox1.Text;

        }

        private void Evenement_Click(object sender, EventArgs e)
        {
            new Evenement1().Show();
        }
    }
}
