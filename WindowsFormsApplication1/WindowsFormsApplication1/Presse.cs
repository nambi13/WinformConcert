using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Presse
    {
        String Idpresse;
        String Nom;
        float Cout;
        public String idpresse
        {
            get { return Idpresse; }
            set { Idpresse = value; }
        }
        public String nom
        {
            get { return Nom; }
            set { Nom = value; }

        }
        public float cout
        {
            get { return Cout; }
            set { Cout = value; }

        }
    }
}
