using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Coordonne_stade
    {
        String Idstade;
        float X;
        float Y;
        public String idstade
        {
            get { return Idstade; }
            set { Idstade = value; }
        }
        public float x
        {
            get { return X; }
            set { X = value; }

        }
        public float y
        {
            get { return Y; }
            set { Y = value; }

        }
    }
}
