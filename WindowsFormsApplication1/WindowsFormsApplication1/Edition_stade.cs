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
    public partial class Edition_stade : Form
    {
        List<Zone1> listzone = new List<Zone1>();
        PointF[] coor;
        List<Zone> zone = new List<Zone>();
        int i = 0;
        public Edition_stade(PointF[]kozy)
        {
            
            this.coor = kozy;

            InitializeComponent();
         
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.panel1.CreateGraphics();
            gr.DrawPolygon(Pens.Black,this.coor);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public PointF[] tableau { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public PointF[] tabl(String[] tableau)
        {
            PointF[] pointFs = new PointF[tableau.Length];
            for (int i = 0; i < pointFs.Length; i++)
            {
                String[] coord = tableau[i].Split(';');
                float x = float.Parse(coord[0]);
                float y = float.Parse(coord[1]);
                pointFs[i] = new PointF(x, y);

            }
            return pointFs;



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void m_myTestButton_MouseClick(object sender, MouseEventArgs e)
        {
            listBox1.Items.Add("" + e.X + ";" + e.Y);
            Graphics gr = this.panel1.CreateGraphics();

        }
        private void drawpol(PointF[] point, Graphics gr)
        {
           
        }
        private PointF[] getpoints(ListBox listboxCoordonnes)
        {
            PointF[] pointFs = new PointF[listboxCoordonnes.Items.Count];
            for (int i = 0; i < pointFs.Length; i++)
            {
                String[] coord = listboxCoordonnes.Items[i].ToString().Split(';');
                float x = float.Parse(coord[0]);
                float y = float.Parse(coord[1]);
                pointFs[i] = new PointF(x, y);

            }
            return pointFs;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.i = this.i + 1;
            Graphics gr = this.panel1.CreateGraphics();
            PointF[] tableay = this.getpoints(listBox1);
            Zone1 zone = new Zone1();
            zone.idzone = i.ToString();
            zone.tableau = tableay;
            this.listzone.Add(zone);
            Zone temp = new Zone();
            temp.nom = this.i.ToString();
            temp.coordonne = PointFtoString(tableay);
            this.zone.Add(temp);
           listBox2.Items.Add(temp.nom);
            gr.DrawPolygon(Pens.Black, tableay);
            listBox1.Items.Clear();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Text = listBox2.Text;
            Graphics gr = this.panel1.CreateGraphics();
            gr.Clear(Color.White);
            gr.DrawPolygon(Pens.Black, this.coor);
            
           List<Zone> list = this.zone.Where(s => s.nom != Text).ToList();
            
            this.zone = list;

            Zone[] tab = this.zone.ToArray();
           // Zone[] tab = this.zone.ToArray();
           
            for (int i = 0; i < tab.Length; i++)
            {
                PointF[] coordonnes = new PointF[tab[i].coordonne.Length];
                for (int j = 0; j < tab[i].coordonne.Length; j++)
                {
                    String[] coord = tab[i].coordonne[j].Split(';');
                    float xaxis = float.Parse(coord[0]);
                    float y = float.Parse(coord[1]);
                    coordonnes[i] = new PointF(xaxis, y);
                    gr.DrawPolygon(Pens.Black, coordonnes);

                }
                //gr.DrawPolygon(Pens.Black, coordonnes);

            }
             

            label1.Text = tab.Length.ToString();



        }
        public String[] PointFtoString(PointF[] tableau) {
            String[] table = new String[tableau.Length];
            for (int i = 0; i < table.Length; i++) { 
                table[i]=tableau[i].X+";"+tableau[i].Y;
            }
            return table;
        
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
