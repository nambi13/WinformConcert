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
    public partial class Countour : Form
    {
        String id;
        Coordonne_stade[] tableau;
        List<Zonec> tableauZ = new List<Zonec>();
        
        PointF[] Polygon;
        public Countour(String idStade)
        {
           this.id = idStade;
            
            InitializeComponent();
           
        }
        private void Countour_Load(object sender, EventArgs e)
        {
            

            

        }
        private void m_myTestButton_MouseClick(object sender, MouseEventArgs e)
        {
            PointF add = new PointF(e.X, e.Y);
          //  tableaupolygon.Add(add);
            listBox1.Items.Add("" + e.X + ";" + e.Y);
            Graphics gr = this.panel1.CreateGraphics();
            gr.Clear(Color.White);
            gr.DrawPolygon(Pens.Black, this.Polygon);
            Zonec[] array = this.tableauZ.ToArray();
          
            if (array.Length > 0)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    PointF[] listes = new PointF[array[j].coordonne.Length];
                    for (int ii = 0; ii < array[j].coordonne.Length; ii++)
                    {
                        listes[ii] = new PointF(array[j].coordonne[ii].X, array[j].coordonne[ii].Y);

                    }
                    gr.DrawPolygon(Pens.Black, listes);

                }
            }
            drawpol(getpoints(listBox1), gr);
        }
        private void drawpol(PointF[] point, Graphics gr)
        {
            if (point.Length > 1)
            {
                gr.DrawPolygon(Pens.Black, point);
            }
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            this.label1.Text = this.id;
            Fonctioncs fonction = new Fonctioncs();
            Graphics gr = this.panel1.CreateGraphics();
            this.label1.Text = this.id;
            String[] colonne = new String[1];
            colonne[0] = "idstade";
            String[] value = new String[1];
            value[0] = this.id;
            Object[] table = fonction.Select2(new Stadecr(), null, null, null);

            List<Stadecr> list = fonction.objtocr(table).ToList();
            Stadecr[] Stadecr = list.Where(s => s.nom == this.id.ToString()).ToArray();
            int x = Stadecr.Length;
            List<PointF> stad = new List<PointF>();
            fonction.dessinerZoneTab(Stadecr[0].idstade, gr);
            for (int i = 0; i < Stadecr.Length; i++)
            {
                PointF p = new PointF(Stadecr[i].x, Stadecr[i].y);
                stad.Add(p);
            }
            PointF[] tabl = stad.ToArray();
            this.Polygon = tabl;
            gr.DrawPolygon(Pens.Black, tabl);
            Zonec[] array = this.tableauZ.ToArray();
            if (array.Length > 0)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    PointF[] listes = new PointF[array[j].coordonne.Length];
                    for (int ii = 0; ii < array[j].coordonne.Length; ii++)
                    {
                        listes[ii] = new PointF(array[j].coordonne[ii].X, array[j].coordonne[ii].Y);

                    }
                    gr.DrawPolygon(Pens.Black, listes);

                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = this.id;

        }

        private void Countour_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int max;
            Fonctioncs fonction=new Fonctioncs();
            String dhorizontale = listBox2.Text;
            String dverticale = listBox3.Text;
            String direction = listBox5.Text;
            String espacement = textBox1.Text;
            String hauteur = textBox2.Text;
            int chiffre = this.tableauZ.FindIndex(x => x.nom == listBox4.Text);

            Zonec[] teenAgerStudents = this.tableauZ.Where(s => s.nom ==listBox4.Text).ToArray();
            int xy = teenAgerStudents.Length;
            this.label1.Text = textBox1.Text;
            if (chiffre == 0)
            {
                max = 0;

            }
            else {
                max = fonction.chaissenumero(this.tableauZ[chiffre - 1]);
            
            }
            List<Chaisse> aj = fonction.AjouTchaisse(teenAgerStudents[0].coordonne, hauteur, espacement, dverticale, dhorizontale, direction,max);
            PointF[] fianl = fonction.tr(aj);
            Chaisse[] table = aj.ToArray();
            this.tableauZ[chiffre].tableau = table;
            for (int i = 0; i < fianl.Length; i++)
            {
                Font font1 = new Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                float x = fianl[i].X;
                Graphics gr = this.panel1.CreateGraphics();
                gr.DrawString(table[i].numero.ToString(), font1,Brushes.Blue, fianl[i]);
           //     gr.DrawString("Jean", font1, Brushes.Blue, new PointF(0,1));
                gr.DrawEllipse(Pens.Black, fianl[i].X, fianl[i].Y, 5, 5);

            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Graphics gr = this.panel1.CreateGraphics();
            gr.Clear(Color.White);
            gr.DrawPolygon(Pens.Black, this.Polygon);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = this.tableauZ.ToArray().Length + 1;
            Zonec zone = new Zonec();
            zone.nom = i.ToString();
            PointF[] tabl = this.getpoints(listBox1);
            zone.coordonne = tabl;
            this.tableauZ.Add(zone);
            listBox4.Items.Add(zone.nom);
            listBox1.Items.Clear();
          
            
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Enregistrement_Click(object sender, EventArgs e)
        {

           Fonctioncs fonction=new Fonctioncs();
           Object[] table = fonction.Select2(new Stadecr(), null, null, null);

           List<Stadecr> list = fonction.objtocr(table).ToList();
           Stadecr[] Stadecr = list.Where(s => s.nom == this.id.ToString()).ToArray();

            Object[] tab = fonction.Select2(new Zone3(), null, null, null);
           int taille = tab.Length;
           if(taille==0){
           taille=1;
           }
           Zonec[] array = this.tableauZ.ToArray();
           for (int i = 0; i < array.Length; i++) {
               fonction.insertzone(array[i], Stadecr[0].idstade, taille);
               fonction.insertcoorzone(array[i], taille);
               fonction.insertseza(array[i], Stadecr[0].idstade, taille);
               taille = taille + 1;
           
           }
        }
    }
}
