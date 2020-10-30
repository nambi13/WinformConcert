using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Zonec{
        String Nom;
        PointF[] Coordonne = new PointF[0];
        Chaisse[] Tableau = new Chaisse[0];

        public String nom
        {
            get { return Nom; }
            set { Nom = value; }
        }
        // public int annee
        //  {
        //    get { return Annee; }
        //   set { Annee = value; }
        // }
        public PointF[]coordonne
        {
            get { return Coordonne; }
            set { Coordonne = value; }
        }
        public Chaisse[]tableau
        {
            get { return Tableau; }
            set { Tableau = value; }
        }
    }
}
