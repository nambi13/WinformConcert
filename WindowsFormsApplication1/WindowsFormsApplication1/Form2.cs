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
    public partial class Form2 : Form
    {
        String Idzone;
        PointF[] Tableau;
        public PointF[]tableau
        {
            get { return Tableau; }
            set { Tableau = value; }
        }
        public String idzone
        {
            get { return Idzone; }
            set { Idzone = value; }

        }
        public Form2()
        {
            InitializeComponent();
        }
      

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
