using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Clpresse
    {
        String Idpresse;
        String Nom;
        int Points;
        public int points     
        {
            get { return Points; }
            set { Points = value; }
        }
        public String nom
        {
            get { return Nom; }
            set { Nom = value; }

        }
        public String idpresse
        {
            get { return Idpresse; }
            set { Idpresse = value; }

        }
    }
}
