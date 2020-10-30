using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Chaisse
    {
        String Idstade;
        String Idzone;
        int Numero;
        float X;
        float Y;
        float Espacement;
        float Hauteur;
        public String idstade
        {
            get { return Idstade; }
            set { Idstade = value; }
        }
        public String idzone
        {
            get { return Idzone; }
            set { Idzone = value; }

        }
        public float x
        {
            get { return X; }
            set { X = value; }

        }
        public float y
        {
            get { return Y; }
            set { Y= value; }

        }
        public float espacement
        {
            get { return Espacement; }
            set { Espacement = value; }

        }
        public float hauteur
        {
            get { return Hauteur; }
            set { Hauteur = value; }

        }
        public int numero
        {
            get { return Numero; }
            set { Numero = value; }

        }
        
        
    }
}
