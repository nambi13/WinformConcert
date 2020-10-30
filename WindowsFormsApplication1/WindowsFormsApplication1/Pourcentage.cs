using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Pourcentage
    {
        String Idzone;
        int Prevision;
        String Idevenement;
        decimal Prix_unitaire;
        public decimal prix_unitaire
        {
            get { return Prix_unitaire; }
            set { Prix_unitaire = value; }

        }
        public String idzone
        {
            get { return Idzone; }
            set { Idzone = value; }

        }
        public int  prevision
        {
            get { return Prevision; }
            set { Prevision = value; }

        }
        public String idevenement
        {
            get { return Idevenement; }
            set { Idevenement = value; }

        }
    }
}
