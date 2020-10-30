using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace WindowsFormsApplication1
{
    public partial class stade1 : Form
    {
        public List<PointF> rectangle = new List<PointF>();
        public List<PointF> tableaupolygon = new List<PointF>();
        public List<Chaisse> seza2 = new List<Chaisse>();
        private void m_myTestButton_MouseClick(object sender, MouseEventArgs e)
        {
            PointF add = new PointF(e.X, e.Y);
            tableaupolygon.Add(add);
            listBox1.Items.Add("" + e.X + ";" + e.Y);
            Graphics gr = this.panel1.CreateGraphics();
            gr.Clear(Color.White);
            drawpol(getpoints(listBox1), gr);


        }
        private void drawpol(PointF[] point, Graphics gr)
        {
            if (point.Length > 1)
            {
                gr.DrawPolygon(Pens.Black, point);
            }
        }
        private void Control1_MouseDoubleClick(Object sender, MouseEventArgs e)
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
        public stade1()
        {
            InitializeComponent();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            PointF a = new PointF(0, 0);
            PointF c = new PointF(2, 2);
            PointF h=new PointF(1,1);
            if (h.X<a.X && h.Y<a.Y && h.X>c.X && h.Y>c.Y || h.X>a.X && h.Y>a.Y && h.X<c.X && h.Y<c.Y ) {
                int i = i + 1;
            }
            else if (h.X > a.X && h.Y > a.Y && h.X > c.X && h.Y > c.Y || h.X < a.X && h.Y < a.Y && h.X < c.X && h.Y < c.Y) { 
            
                continue
            }


            */
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            /* PointF[] tableau = this.getpoints(listBox1);
             Graphics gr = this.panel1.CreateGraphics();

             drawpol(getpoints(listBox1), gr);
             this.listBox1.Items.Clear();
             */

            PointF[] tableau = this.getpoints(listBox1);
            String[] transportV = new String[tableau.Length];
            for (int i = 0; i < tableau.Length; i++)
            {
                transportV[i] = tableau[i].X + ";" + tableau[i].Y;
            }
            Countour2 x = new Countour2(tableau);
            x.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void stade_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.tableaupolygon.Clear();
            Graphics gr = this.panel1.CreateGraphics();
            gr.Clear(Color.White);
            listBox1.Items.Clear();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void rect_Click(object sender, EventArgs e)
        {

            Fonctioncs fonction = new Fonctioncs();
            PointF[] tab = fonction.rectangle(this.tableaupolygon);
            for (int i = 0; i < tab.Length; i++) { 
                this.rectangle.Add(tab[i]);
            
            }
            


        }
        public PointF[] CreateTriangle(List<PointF> rectangle)
        {
            PointF[] tableau = rectangle.ToArray();
            float xmin = this.get(tableau, "Xmin");
            float xmax = this.get(tableau, "Xmax");
            float ymin = this.get(tableau, "Ymin");
            float ymax = this.get(tableau, "Ymax");
            PointF[] tab = new PointF[4];
            tab[0] = new PointF(xmin, ymax);
            tab[1] = new PointF(xmin, ymin);
            tab[2] = new PointF(xmax, ymin);
            tab[3] = new PointF(xmax, ymax);
            return tab;
        }
        public float[] tableau(PointF[] tableau, String attribut)
        {
            float[] tarray = new float[tableau.Length];
            if (attribut.Equals("X"))
            {

                for (int i = 0; i < tableau.Length; i++)
                {
                    tarray[i] = tableau[i].X;
                }
            }
            else if (attribut.Equals("Y"))
            {
                for (int i = 0; i < tableau.Length; i++)
                {
                    tarray[i] = tableau[i].Y;
                }
            }
            return tarray;
        }
        public float triage(String zavatrailaina, float[] tab)
        {
            float min = 0;
            if (zavatrailaina.Equals("minimum"))
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    for (int j = i + 1; j < tab.Length; j++)
                    {
                        if (tab[j] < tab[i])
                        {
                            min = tab[j];
                            tab[j] = tab[i];
                            tab[i] = min;
                        }
                    }
                }
                return tab[0];
            }
            else if (zavatrailaina.Equals("maximum"))
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    for (int j = i + 1; j < tab.Length; j++)
                    {
                        if (tab[j] > tab[i])
                        {
                            min = tab[j];
                            tab[j] = tab[i];
                            tab[i] = min;
                        }
                    }
                }
                return tab[0];
            }



            return 0;
        }
        public float get(PointF[] tab, String zavatra)
        {
            float x = 0;
            if (zavatra.Equals("Xmax"))
            {
                float[] tabl = this.tableau(tab, "X");
                x = this.triage("maximum", tabl);

            }
            else if (zavatra.Equals("Xmin"))
            {
                float[] tabl = this.tableau(tab, "X");
                x = this.triage("minimum", tabl);

            }
            else if (zavatra.Equals("Ymin"))
            {
                float[] tabl = this.tableau(tab, "Y");
                x = this.triage("minimum", tabl);

            }
            else if (zavatra.Equals("Ymax"))
            {
                float[] tabl = this.tableau(tab, "Y");
                x = this.triage("maximum", tabl);
            }
            return x;
        }
        public int IsPointInPolygon4(PointF[] polygon, PointF testPoint)
        {
            int vo = 0;
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        vo = 1;
                    }
                }
                j = i;
            }
            return vo;
        }
        public  bool IsPointInPolygon45(PointF[] polygon, PointF testPoint)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
        public int testPolygon(PointF[] tableau, PointF h) {
            int s = 0;
           
            for (int i = 0; i < tableau.Length; i++) {
                for (int j = i + 1; j < tableau.Length; j++) {
                    PointF[] test = new PointF[2];
                    test[0] = tableau[i];
                    test[1] = tableau[j];
                    float xmin = this.get(test, "Xmin");
                    float xmax = this.get(test, "Xmax");
                    float ymin = this.get(test, "Ymin");
                    float ymax = this.get(test, "Ymax");
                    if (h.Y > ymin && h.Y < ymax && h.X < xmin && h.X < xmax || h.Y > ymin && h.Y < ymax && h.X < xmin && h.X >xmax)
                    {
                        s = s + 1;     
                                          
                    }
                        
                    else if (h.Y > ymin && h.Y < ymax && h.X > xmin && h.X < xmax)
                    {
                        continue;
                    }
                    
                    else if (h.Y > ymin && h.Y < ymax && h.X > xmin && h.X > xmax)
                    {
                        continue;
                    }
                    else if (h.Y > ymax)
                    {

                continue;
            }
                 
                    else
                    {

                        continue;
                    }
                
                }
            
            }
            return s;
        
        
        
        
        }
        public PointF[] tr(List<Chaisse> c) {
            
            Chaisse[]tableau=c.ToArray();
            PointF[] tablea = new PointF[tableau.Length];
            for (int i = 0; i < tablea.Length; i++) {
                tablea[i] = new PointF(tableau[i].x,tableau[i].y);
            
            }
            return tablea;
        
        }
        private void seza_Click(object sender, EventArgs e){

            /*
            List<Chaisse> tab = this.fonc(this.rectangle);
            List<PointF> lister = new List<PointF>();

            PointF[] tableau = this.tr(tab);
            PointF[]polygone=this.tableaupolygon.ToArray();
            Graphics gr = this.panel1.CreateGraphics();
          
            bool b = false;
            for (int i = 0; i < tableau.Length; i++) {
                b = this.IsPointInPolygon45(polygone, tableau[i]);
                if (b == true)
                {
                    lister.Add(tableau[i]);
                }
                else {

                    continue;
                }
           
            
            }
            PointF[] fianl = lister.ToArray();
            for (int i = 0; i < fianl.Length; i++)
            {
                float x = fianl[i].X;
                
                gr.DrawEllipse(Pens.Black, fianl[i].X,fianl[i].Y, 5, 5);

            }
                */
            Fonctioncs fonction = new Fonctioncs();
            PointF[] rectangle = fonction.rectangle(this.tableaupolygon);
            List<Chaisse> tab = this.fonc(rectangle.ToList());
            List<PointF> lister = new List<PointF>();
            PointF[] tableau = fonction.tr(tab);
            PointF[]polygone = this.tableaupolygon.ToArray();
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(polygone);
            int b = 0;
            for (int i = 0; i < tableau.Length; i++)
            {
                bool isPointInPolygon = path.IsVisible(tableau[i]);
                if (isPointInPolygon == true)
                {

                    lister.Add(tableau[i]);
                }
                else { continue; }
            }
                


            
            PointF[] fianl = lister.ToArray();
            for (int i = 0; i < fianl.Length; i++)
            {
                float x = fianl[i].X;
                Graphics gr = this.panel1.CreateGraphics();
                gr.DrawEllipse(Pens.Black, fianl[i].X, fianl[i].Y, 5, 5);

            }
        

            
           

        }
        public void tracage(float hauteur, float espacement, List<PointF> rectangle) {

            PointF[] tableau = this.rectangle.ToArray();
            float xmin = this.get(tableau, "Xmin");
            float xmax = this.get(tableau, "Xmax");
            float ymin = this.get(tableau, "Ymin");
            float ymax = this.get(tableau, "Ymax");
            float debut = ymin;
            List<float> y = new List<float>();
            while (debut <= ymax) {
                debut = debut + hauteur;

                y.Add(debut);
            }

        
        
        
        
        
        }
        public List<float> ychaise(float hauteur,PointF[]tableau) {
            float xmin = this.get(tableau, "Xmin");
            float xmax = this.get(tableau, "Xmax");
            float ymin = this.get(tableau, "Ymin");
            float ymax = this.get(tableau, "Ymax");
            float debut = ymin;
            List<float> y = new List<float>();
            while (debut+hauteur <= ymax)
            {
                debut = debut + hauteur;
                y.Add(debut);
            }
            return y;   
        }
      
        public List<float> xchaise(float hauteur, PointF[] tableau)
        {
            float xmin = this.get(tableau, "Xmin");
            float xmax = this.get(tableau, "Xmax");
            float ymin = this.get(tableau, "Ymin");
            float ymax = this.get(tableau, "Ymax");
            float debut = xmin;
            List<float> y = new List<float>();
            while (debut+hauteur <= xmax)
            {
                debut = debut + hauteur;
                y.Add(debut);
            }
            return y;
        }
        public List<Chaisse>fonc(List<PointF>rectangle)
        {
            PointF[] te = this.rectangle.ToArray();
            List<float> y = this.ychaise(40, te);
            List<float> x = this.xchaise(30, te);
            float[] xa = x.ToArray();
            float[] ya = y.ToArray();
            List<Chaisse>list=new List<Chaisse>();
            for (int i = 0; i < ya.Length; i++)
            {
                for (int ii = 0; ii < xa.Length; ii++)
                {
                    PointF F = new PointF(xa[ii], ya[i]);
                    Chaisse chaisse = new Chaisse();
                    chaisse.idstade = "";
                    chaisse.idzone = "";
                    chaisse.hauteur = 40;
                    chaisse.espacement = 30;
                    chaisse.x = F.X;
                    chaisse.y = F.Y;
                    list.Add(chaisse);
                    float xaxis = F.X;
                    float yaxis = F.Y;
                    //    Graphics gr = this.panel1.CreateGraphics();
                    //    gr.DrawEllipse(Pens.Black, xaxis,yaxis, 10, 10);


                }

            }

            return list;

        }

        

    }
}
/*Graphics g = e.Graphics;

          // Create a pen
          Pen greenPen = new Pen(Color.Green, 2);
          Pen redPen = new Pen(Color.Red, 2);

          // Create points for polygon
          PointF pt1 = new PointF(40.0F, 50.0F);
          PointF pt2 = new PointF(60.0F, 70.0F);
          PointF pt3 = new PointF(80.0F, 34.0F);
          PointF pt4 = new PointF(120.0F, 180.0F);
          PointF pt5 = new PointF(200.0F, 150.0F);
          PointF[] ptsArray =
      {
            pt1, pt2, pt3, pt4, pt5
      };
          e.Graphics.DrawPolygon(greenPen, ptsArray);

          // Dispose of object
          greenPen.Dispose();
          redPen.Dispose();
      //tracage cercle
   float radius=50;
          PointF center = new PointF(0, 0);
          float x = center.X;
          float y = center.Y;
          Graphics gr = this.panel1.CreateGraphics();
          gr.DrawEllipse(Pens.Black, x, y,10,10);
 */