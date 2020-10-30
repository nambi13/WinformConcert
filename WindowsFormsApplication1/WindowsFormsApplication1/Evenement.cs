using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Evenement
    {
        String Idevenement;
        String Nom;
        DateTime Dateconcert;
        public String nom
        {
            get { return Nom; }
            set { Nom= value; }
        }
        public String idevenement
        {
            get { return Idevenement; }
            set { Idevenement = value; }

        }
        public DateTime dateconcert {
            get { return Dateconcert; }
            set { Dateconcert = value; }
        
        
        }
    }
}
