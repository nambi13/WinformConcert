using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class AjoutPresse
    {
        String Idevenement;
        String Idpresse;
        DateTime Dateappel;
        String Idappel;
        public String idevenement
        {
            get { return Idevenement; }
            set { Idevenement = value; }
        }
        public String idpresse
        {
            get { return Idpresse; }
            set { Idpresse = value; }

        }
        public DateTime dateappel
        {
            get { return Dateappel; }
            set { Dateappel = value; }
        }
        public String idappel
        {
            get { return Idappel; }
            set { Idappel = value; }

        }
    }
}
