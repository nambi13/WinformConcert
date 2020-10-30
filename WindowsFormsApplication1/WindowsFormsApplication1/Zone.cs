using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Zone
    {
        String Nom;
        String[] Coordonne;

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
        public String[] coordonne
        {
            get { return Coordonne; }
            set { Coordonne = value; }
        }
    }

}