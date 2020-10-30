using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
using System.Web;


namespace WindowsFormsApplication1
{
    public partial class Evenement1 : Form
    {
        public Evenement1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String x = comboBox1.Items.ToString();
            new AccueilEve(comboBox1.SelectedItem.ToString()).Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Create().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Evenement1_Load(object sender, EventArgs e)
        {
            Fonctioncs fonction = new Fonctioncs();
            Object[] tableau = fonction.Select2(new Evenement(), null, null, null);
            Evenement[] tab = fonction.objtoEven(tableau);
            for (int i = 0; i < tab.Length; i++)
            {
                comboBox1.Items.Add(tab[i].nom);
            }
            Evenement objClass = tab[0];
           // Session["user"] = objClass;
            
        }
    }
}
