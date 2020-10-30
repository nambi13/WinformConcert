using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Courb : Form
    {
        String Id;
        public Courb(String id)
        {
            this.Id = id;
            InitializeComponent();
        }

        private void Courb_Load(object sender, EventArgs e)
        {

        }


  private void button1_Click(object sender, EventArgs e)
{
   /* String[] x = new String[] {"13","14","15","16","17", "18" };
    int[] y = new int[] {0, 1, 2, 3, 4, 5 };
   

//    chart1.Series["test1"].Points.AddXY(0, 0);

 //   chart1.Series["test1"].Points.AddXY(1, 1);
    chart1.Series["test1"].Points.DataBindXY(x, y);
                
    chart1.Series["test1"].ChartType = SeriesChartType.FastLine;
    chart1.Series["test1"].Color = Color.Red;
   */ Clcourbes[]tab=new Fonctioncs().courbes(this.Id);
      String[]xaxis = new String[tab.Length];
      int[] yaxis = new int[tab.Length];
        xaxis[0]=tab[0].x;
        yaxis[0] = tab[0].y;
      for (int i = 1; i < tab.Length; i++) {
          yaxis[i] = tab[i].y+tab[i-1].y;
          xaxis[i] = tab[i].x;
         
      }
     // chart1.Series["test1"].Points.AddXY(0, 0);

      //   chart1.Series["test1"].Points.AddXY(1, 1);
      chart1.Series["test1"].Points.DataBindXY(xaxis, yaxis);

      chart1.Series["test1"].ChartType = SeriesChartType.FastLine;
      chart1.Series["test1"].Color = Color.Red;
      Clpresse[] fin = new Fonctioncs().clpresse(tab, this.Id);
      for (int i = 0; i < fin.Length; i++) {
          listBox1.Items.Add(i+1 + "-" + fin[i].nom + "-" + fin[i].points);
      
      }

}

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
