using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Chaissee
    {
        int Numero;
        String Idevenement;
        String Idzone;
        int Etat;
        public String idzone
        {
            get { return Idzone; }
            set { Idzone = value; }
        }
        public String idevenement
        {
            get { return Idevenement; }
            set { Idevenement = value; }

        }
        public int etat
        {
            get { return Etat; }
            set { Etat = value; }
        }

        public int numero
        {
            get { return Numero; }
            set { Numero = value; }

        }
    }

}
