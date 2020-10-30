using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Mouvements
    {
        String Idtransaction;
        String Idevenement;
        String Idzone;
        float Pourcentage;
        DateTime Dateachat;
        decimal Prix_totale;
        public String idtransaction
        {
            get { return Idtransaction; }
            set { Idtransaction = value; }
        }
        public String idzone
        {
            get { return Idzone; }
            set { Idzone = value; }

        }
        public float pourcentage
        {
            get { return Pourcentage; }
            set { Pourcentage = value; }

        }
        public decimal prix_totale
        {
            get { return Prix_totale; }
            set { Prix_totale = value; }

        }
        public String idevenement
        {
            get { return Idevenement; }
            set { Idevenement = value; }

        }
        public DateTime dateachat
        {
            get { return Dateachat; }
            set { Dateachat = value; }

        }
        
    }
}
