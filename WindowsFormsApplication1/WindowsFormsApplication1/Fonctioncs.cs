using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Drawing;



namespace WindowsFormsApplication1
{
    class Fonctioncs
    {

        //tracage_rectangle
        public PointF[] rectangle(List<PointF>rectangle) {
            
            PointF[] tableau = rectangle.ToArray();
            float xmin = this.get(tableau, "Xmin");
            float xmax = this.get(tableau, "Xmax");
            float ymin = this.get(tableau, "Ymin");
            float ymax = this.get(tableau, "Ymax");
            PointF[] tab = new PointF[4];
            tab[0] = new PointF(xmin, ymax);
            tab[1] = new PointF(xmin, ymin);
            tab[2] = new PointF(xmax, ymin);
            tab[3] = new PointF(xmax, ymax);
            return tab;
        }
        //maka maximum sy minimum(x,y)
        public float get(PointF[] tab, String zavatra)
        {
            float x = 0;
            if (zavatra.Equals("Xmax"))
            {
                float[] tabl = this.tableau(tab, "X");
                x = this.triage("maximum", tabl);

            }
            else if (zavatra.Equals("Xmin"))
            {
                float[] tabl = this.tableau(tab, "X");
                x = this.triage("minimum", tabl);

            }
            else if (zavatra.Equals("Ymin"))
            {
                float[] tabl = this.tableau(tab, "Y");
                x = this.triage("minimum", tabl);

            }
            else if (zavatra.Equals("Ymax"))
            {
                float[] tabl = this.tableau(tab, "Y");
                x = this.triage("maximum", tabl);
            }
            return x;
        }
        //triage minimum maximum
        public float triage(String zavatrailaina, float[] tab)
        {
            float min = 0;
            if (zavatrailaina.Equals("minimum"))
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    for (int j = i + 1; j < tab.Length; j++)
                    {
                        if (tab[j] < tab[i])
                        {
                            min = tab[j];
                            tab[j] = tab[i];
                            tab[i] = min;
                        }
                    }
                }
                return tab[0];
            }
            else if (zavatrailaina.Equals("maximum"))
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    for (int j = i + 1; j < tab.Length; j++)
                    {
                        if (tab[j] > tab[i])
                        {
                            min = tab[j];
                            tab[j] = tab[i];
                            tab[i] = min;
                        }
                    }
                }
                return tab[0];
            }



            return 0;
        }
        //maka X float sy Y float
        public float[] tableau(PointF[] tableau, String attribut)
        {
            float[] tarray = new float[tableau.Length];
            if (attribut.Equals("X"))
            {

                for (int i = 0; i < tableau.Length; i++)
                {
                    tarray[i] = tableau[i].X;
                }
            }
            else if (attribut.Equals("Y"))
            {
                for (int i = 0; i < tableau.Length; i++)
                {
                    tarray[i] = tableau[i].Y;
                }
            }
            return tarray;
        }
        //primoridale
        public List<Chaisse> fonc(List<PointF> rectangle)
        {
            PointF[] te = rectangle.ToArray();
            List<float> y = this.ychaise(40, te);
            List<float> x = this.xchaise(30, te);
            float[] xa = x.ToArray();
            float[] ya = y.ToArray();
            List<Chaisse> list = new List<Chaisse>();
            for (int i = 0; i < ya.Length; i++)
            {
                for (int ii = 0; ii < xa.Length; ii++)
                {
                    PointF F = new PointF(xa[ii], ya[i]);
                    Chaisse chaisse = new Chaisse();
                    chaisse.idstade = "";
                    chaisse.idzone = "";
                    chaisse.hauteur = 40;
                    chaisse.espacement = 30;
                    chaisse.x = F.X;
                    chaisse.y = F.Y;
                    list.Add(chaisse);
                    float xaxis = F.X;
                    float yaxis = F.Y;
                    //    Graphics gr = this.panel1.CreateGraphics();
                    //    gr.DrawEllipse(Pens.Black, xaxis,yaxis, 10, 10);


                }

            }

            return list;

        }
        public List<Chaisse> Getchaisse(List<float> xchaise, List<float> ychaise,String direction,String dverticale,String gendirenction) {
            int chiffre=0;
            float[] xa = xchaise.ToArray();
            float[] ya = ychaise.ToArray();
            List<Chaisse> list = new List<Chaisse>();
            //(V)//  
          if (direction.Equals("A gauche vers la droite") && dverticale.Equals("Haut vers le bas") && gendirenction.Equals("Horizontale")) {
                for (int i = 0; i < ya.Length; i++)
                {
                    for (int j = 0; j < xa.Length; j++)
                    {
                        chiffre = chiffre + 1;
                        PointF F = new PointF(xa[j], ya[i]);
                        Chaisse chaisse = new Chaisse();
                        chaisse.idstade = "";
                        chaisse.idzone = "";
                        chaisse.hauteur = 40;
                        chaisse.espacement = 30;
                        chaisse.numero = chiffre;
                        chaisse.x = F.X;
                        chaisse.y = F.Y;
                        list.Add(chaisse);
                        float xaxis = F.X;
                        float yaxis = F.Y;
                        //    Graphics gr = th

                    }
                }
                return list;
            }
              //(V)//
            else if (direction.Equals("A gauche vers la droite") && dverticale.Equals("Bas vers le haut") && gendirenction.Equals("Horizontale")) { 
                int taille=ya.Length-1;
                for (int i=taille; i > -1; i--) {
                    for (int j = 0; j < xa.Length; j++) {
                        chiffre = chiffre + 1;
                        PointF F = new PointF(xa[j], ya[i]);
                        Chaisse chaisse = new Chaisse();
                        chaisse.idstade = "";
                        chaisse.idzone = "";
                        chaisse.hauteur = 40;
                        chaisse.espacement = 30;
                        chaisse.x = F.X;
                        chaisse.y = F.Y;
                        chaisse.numero = chiffre;
                        list.Add(chaisse);
                        float xaxis = F.X;
                        float yaxis = F.Y;
                    }
                
                }
            }
            else if (direction.Equals("A droite vers la gauche") && dverticale.Equals("Haut vers le bas") && gendirenction.Equals("Horizontale"))
            {
          
                for (int i = 0; i < ya.Length; i++)
                {
                    for (int j = xa.Length-1; j > -1; j--)
                    {
                        chiffre = chiffre + 1;
                        PointF F = new PointF(xa[j], ya[i]);
                        Chaisse chaisse = new Chaisse();
                        chaisse.idstade = "";
                        chaisse.idzone = "";
                        chaisse.hauteur = 40;
                        chaisse.espacement = 30;
                        chaisse.x = F.X;
                        chaisse.y = F.Y;
                        chaisse.numero = chiffre;
                        list.Add(chaisse);
                        float xaxis = F.X;
                        float yaxis = F.Y;
                        //    Graphics gr = th

                    }
                }
                return list;
            }
            else if (direction.Equals("A droite vers la gauche") && dverticale.Equals("Bas vers le haut") && gendirenction.Equals("Horizontale"))
            {
                int i = ya.Length-1;
                for (i = ya.Length-1; i > -1; i--)
                {
                    for (int j = xa.Length-1; j > -1; j--)
                    {
                        PointF F = new PointF(xa[j], ya[i]);
                        Chaisse chaisse = new Chaisse();
                        chaisse.idstade = "";
                        chaisse.idzone = "";
                        chaisse.hauteur = 40;
                        chaisse.espacement = 30;
                        chaisse.x = F.X;
                        chaisse.y = F.Y;
                        list.Add(chaisse);
                        float xaxis = F.X;
                        float yaxis = F.Y;
                    }

                }
            }
            else if (direction.Equals("A gauche vers la droite") && dverticale.Equals("Haut vers le bas") && gendirenction.Equals("Vertical"))
            {
                for (int j = 0; j < xa.Length; j++)
                {
                    for (int i = 0; i < ya.Length; i++)
                    {
                        float e = xa[j];
                        PointF F = new PointF(xa[j], ya[i]);
                        Chaisse chaisse = new Chaisse();
                        chaisse.idstade = "";
                        chaisse.idzone = "";
                        chaisse.hauteur = 40;
                        chaisse.espacement = 30;
                        chaisse.x = F.X;
                        chaisse.y = F.Y;
                        list.Add(chaisse);
                        float xaxis = F.X;
                        float yaxis = F.Y;
                        //    Graphics gr = th

                    }
                }
                return list;
            }

            else if (direction.Equals("A gauche vers la droite") && dverticale.Equals("Bas vers le haut") && gendirenction.Equals("Vertical"))
            {
                //int i = ya.Length;
                for (int j = 0; j < xa.Length; j++)
                {
                    for (int i = ya.Length-1; i > -1; i--)
                    {
                        PointF F = new PointF(xa[j], ya[i]);
                        Chaisse chaisse = new Chaisse();
                        chaisse.idstade = "";
                        chaisse.idzone = "";
                        chaisse.hauteur = 40;
                        chaisse.espacement = 30;
                        chaisse.x = F.X;
                        chaisse.y = F.Y;
                        list.Add(chaisse);
                        float xaxis = F.X;
                        float yaxis = F.Y;
                    }

                }
            }
            else if (direction.Equals("A droite vers la gauche") && dverticale.Equals("Haut vers le bas") && gendirenction.Equals("Vertical"))
            {
                int taille = xa.Length-1;
                for (int j = taille; j > -1; j--)
                {
                    for (int i = 0; i < ya.Length; i++)
                    {
                        PointF F = new PointF(xa[j], ya[i]);
                        Chaisse chaisse = new Chaisse();
                        chaisse.idstade = "";
                        chaisse.idzone = "";
                        chaisse.hauteur = 40;
                        chaisse.espacement = 30;
                        chaisse.x = F.X;
                        chaisse.y = F.Y;
                        list.Add(chaisse);
                        float xaxis = F.X;
                        float yaxis = F.Y;
                        //    Graphics gr = th

                    }
                }
                return list;
            }
            else if (direction.Equals("A droite vers la gauche") && dverticale.Equals("Bas vers le haut") && gendirenction.Equals("Vertical"))
            {
                //int i = ya.Length;
                for (int j = xa.Length-1; j > -1; j--)
                {
                    for (int i = ya.Length-1; i > -1; i--)
                    {
                        PointF F = new PointF(xa[j], ya[i]);
                        Chaisse chaisse = new Chaisse();
                        chaisse.idstade = "";
                        chaisse.idzone = "";
                        chaisse.hauteur = 40;
                        chaisse.espacement = 30;
                        chaisse.x = F.X;
                        chaisse.y = F.Y;
                        list.Add(chaisse);
                        float xaxis = F.X;
                        float yaxis = F.Y;
                    }

                }
            }

            


            return list;
        }
        public List<Chaisse>AjouTchaisse(PointF[]Polygone,String Hauteur,String espacement,String dverticale,String dhorizontale,String gendirection,int max)
        {
            PointF[]te = this.rectangle(Polygone.ToList());
            List<float> y = this.ychaise(Int32.Parse(Hauteur), te);
            List<float> x = this.xchaise(Int32.Parse(espacement), te);
            List<Chaisse> list = this.Getchaisse(x, y, dhorizontale, dverticale, gendirection);
            List<Chaisse>final=new List<Chaisse>();
            Chaisse[] table = list.ToArray();
            for (int i = 0; i < table.Length; i++) {
                bool c = this.IsPointInPolygon45(Polygone, new PointF(table[i].x, table[i].y));
                if (c == true)
                {

                    final.Add(table[i]);
                }
                else {

                    continue;
                
                }
            
            }
            Chaisse[] tabl = final.ToArray();
            for (int i = 0; i < tabl.Length; i++) {
                max = max + 1;
                tabl[i].numero = max;
            }
            final = tabl.ToList();


                return final;

        }
        public List<float> ychaise(float hauteur, PointF[] tableau)
        {
            float xmin = this.get(tableau, "Xmin");
            float xmax = this.get(tableau, "Xmax");
            float ymin = this.get(tableau, "Ymin");
            float ymax = this.get(tableau, "Ymax");
            float debut = ymin;
            List<float> y = new List<float>();
            while (debut + hauteur <= ymax)
            {
                debut = debut + hauteur;
                y.Add(debut);
            }
            return y;
        }

        public List<float> xchaise(float hauteur, PointF[] tableau)
        {
            float xmin = this.get(tableau, "Xmin");
            float xmax = this.get(tableau, "Xmax");
            float ymin = this.get(tableau, "Ymin");
            float ymax = this.get(tableau, "Ymax");
            float debut = xmin;
            List<float> y = new List<float>();
            while (debut + hauteur <= xmax)
            {
                debut = debut + hauteur;
                y.Add(debut);
            }
            return y;
        }
        public PointF[]tr(List<Chaisse> c)
        {

            Chaisse[] tableau = c.ToArray();
            PointF[] tablea = new PointF[tableau.Length];
            for (int i = 0; i < tablea.Length; i++)
            {
                tablea[i] = new PointF(tableau[i].x, tableau[i].y);

            }
            return tablea;

        }
        public FieldInfo[] returnfield(object a)
        {
            Type e = a.GetType();
            Console.WriteLine(e.IsClass);
            FieldInfo[] fieldInfo = e.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            return fieldInfo;



        }
        public Object[] Select2(Object a, String[] colonne, String[] value,DBconnection connect)
        {
            Boolean boolean;
            if (connect == null)
            {
                connect = new DBconnection();
                boolean = true;
            }
            else
            {
                boolean = false;
            }

            SqlConnection con = connect.getConex();
            StringBuilder builder = new StringBuilder();
            String requete = "";
            Type e = a.GetType();
            List<Object> tab = new List<Object>();

            String classn = e.Name;
            SqlConnection sql = connect.getConex();

            if (colonne == null && value == null)
            {
                requete = "Select*from " + classn;
            }
            else
            {
                String[] stockage = new String[colonne.Count()];
                for (int i = 0; i < stockage.Count(); i++)
                {
                    stockage[i] = colonne[i] + "='" + value[i] + "'and";
                    builder.Append(stockage[i]);
                    builder.ToString();

                }
                String fs = builder.ToString();
                String request = fs.Substring(0, fs.Count() - 3);
                requete = "Select*from " + classn + " Where " + request;

            }
            //    Console.Write(requete);
            String requ = requete;
            sql.Open();
            SqlCommand req = new SqlCommand(requete, sql);
            FieldInfo[] liste = this.returnfield(a);
            SqlDataReader reader = req.ExecuteReader();



            // MethodInfo method = e.GetMethod("Age", BindingFlags.Instance | BindingFlags.NonPublic);

            while (reader.Read())
            {
                object instance = Activator.CreateInstance(e);
                for (int i = 0; i < liste.Length; i++)
                {

                    MethodInfo method = e.GetMethod("set_" + liste[i].Name.ToLower());
                    if (liste[i].FieldType == typeof(int))
                    {
                        String fsd = liste[i].Name;
                        //  object valeur = reader.GetInt32(reader.GetOrdinal(fsd));
                        int farmsize = Convert.ToInt32(reader[(liste[i].Name)]);
                        method.Invoke(instance, new Object[] { farmsize });

                    }
                    else if (liste[i].FieldType == typeof(String))
                    {
                        String str = reader[liste[i].Name].ToString();
                        method.Invoke(instance, new Object[] { str });


                    }
                    else if (liste[i].FieldType == typeof(DateTime))
                    {
                        DateTime date = (DateTime)reader[liste[i].Name];
                        method.Invoke(instance, new Object[] { date });

                    }
                    else if (liste[i].FieldType == typeof(decimal))
                    {
                        //   decimal recievedDecimal = reader.GetDecimal(reader.GetOrdinal(liste[i].Name));
                        decimal result = Convert.ToDecimal(reader[liste[i].Name]);
                        method.Invoke(instance, new Object[] { result });

                    }
                    else if (liste[i].FieldType == typeof(float))
                    {
                        //   decimal recievedDecimal = reader.GetDecimal(reader.GetOrdinal(liste[i].Name));
                        String x = reader[liste[i].Name].ToString();
                        float result = float.Parse(x);
                        method.Invoke(instance, new Object[] { result });

                    }


                }
                tab.Add(instance);
            }
            if (boolean == true)
            {
                sql.Close();
            }
            Object[] finale = tab.ToArray();
            return finale;
        }
        public void Insert(Object cl)
        {
            StringBuilder builder = new StringBuilder();

            Type e = cl.GetType();
            String classn = e.Name;
            FieldInfo[] liste = this.returnfield(cl);
            String[] stockage = new String[liste.Count()];
            String op = "";
            for (int x = 0; x < liste.Count(); x++)
            {

                ///		str="get"+liste[x].Name.ToLower();
                MethodInfo method = e.GetMethod("get_" + liste[x].Name.ToLower());
                stockage[x] = this.transformation(method, liste[x], cl);
                stockage[x] = "'" + stockage[x] + "'" + ",";
                builder.Append(stockage[x]);
                builder.ToString();


                Console.WriteLine(builder);
            }
            String fs = builder.ToString();
            String requete = fs.Substring(0, fs.Count() - 1);


            String finale = "INSERT INTO " + classn + " Values" + "(" + requete + ")";
            Console.Write(finale);
            DBconnection connect = new DBconnection();
            SqlConnection sql = connect.getConex();

            this.Insert2(finale, sql);
            //   return finale;
        }
        public int Insert2(String requete, SqlConnection connection)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            connection.Open();
            dataAdapter.InsertCommand = new SqlCommand(requete, connection);
            dataAdapter.InsertCommand.ExecuteNonQuery();
            dataAdapter.InsertCommand.Dispose();
            connection.Close();
            return 0;
        }
        public String transformation(MethodInfo a, FieldInfo field, Object clas)
        {
            String s = "";
            if (field.FieldType == typeof(int))
            {
                int nombre = (int)a.Invoke(clas, null);
                s = "" + nombre + "";

            }
            else if (field.FieldType == typeof(String))
            {
                s = (String)a.Invoke(clas, null);
            }
            else if (field.FieldType == typeof(decimal))
            {
                decimal k = (decimal)a.Invoke(clas, null);
                s = "" + k + "";
            }
            else if (field.FieldType == typeof(DateTime))
            {
                DateTime k = (DateTime)a.Invoke(clas, null);
                s = "" + k + "";
            }
            else if (field.FieldType == typeof(float))
            {
                float k = (float)a.Invoke(clas, null);
                s = "" + k + "";
            }

            return s;
        }
        public Stade[]objtoStade(Object[] a)
        {
            List<Stade> pro = new List<Stade>();
            for (int i = 0; i < a.Count(); i++)
            {
                Stade x = new Stade();
                x = (Stade)a[i];
                pro.Add(x);
            }
            Stade[] final = pro.ToArray();
            return final;

        }
        public Mouvements[] objtomouv(Object[] a)
        {
            List<Mouvements> pro = new List<Mouvements>();
            for (int i = 0; i < a.Count(); i++)
            {
                Mouvements x = new Mouvements();
                x = (Mouvements)a[i];
                pro.Add(x);
            }
            Mouvements[] final = pro.ToArray();
            return final;

        }
        public Zone3[] objtozone3(Object[] a)
        {
            List<Zone3> pro = new List<Zone3>();
            for (int i = 0; i < a.Count(); i++)
            {
                Zone3 x = new Zone3();
                x = (Zone3)a[i];
                pro.Add(x);
            }
            Zone3[] final = pro.ToArray();
            return final;

        }
        public Coordonne_stade[] objtoCoordonne(Object[] a)
        {
            List<Coordonne_stade> pro = new List<Coordonne_stade>();
            for (int i = 0; i < a.Count(); i++)
            {
                Coordonne_stade x = new Coordonne_stade();
                x = (Coordonne_stade)a[i];
                pro.Add(x);
            }
            Coordonne_stade[] final = pro.ToArray();
            return final;
        }
        public Coordonne_zone[] objtoCoordonnezone(Object[] a)
        {
            List<Coordonne_zone> pro = new List<Coordonne_zone>();
            for (int i = 0; i < a.Count(); i++)
            {
                Coordonne_zone x = new Coordonne_zone();
                x = (Coordonne_zone)a[i];
                pro.Add(x);
            }
            Coordonne_zone[] final = pro.ToArray();
            return final;
        }
        public Stadecr[] objtocr(Object[] a)
        {
            List<Stadecr> pro = new List<Stadecr>();
            for (int i = 0; i < a.Count(); i++)
            {
                Stadecr x = new Stadecr();
                x = (Stadecr)a[i];
                pro.Add(x);
            }
            Stadecr[] final = pro.ToArray();
            return final;
        }
        public Chaissee[] objtoch(Object[] a)
        {
            List<Chaissee> pro = new List<Chaissee>();
            for (int i = 0; i < a.Count(); i++)
            {
                Chaissee x = new Chaissee();
                x = (Chaissee)a[i];
                pro.Add(x);
            }
            Chaissee[] final = pro.ToArray();
            return final;
        }
        public Chaisse[] objtochai(Object[] a)
        {
            List<Chaisse> pro = new List<Chaisse>();
            for (int i = 0; i < a.Count(); i++)
            {
                Chaisse x = new Chaisse();
                x = (Chaisse)a[i];
                pro.Add(x);
            }
            Chaisse[] final = pro.ToArray();
            return final;
        }
        public Evenement[] objtoEven(Object[] a)
        {
            List<Evenement> pro = new List<Evenement>();
            for (int i = 0; i < a.Count(); i++)
            {
                Evenement x = new Evenement();
                x = (Evenement)a[i];
                pro.Add(x);
            }
            Evenement[] final = pro.ToArray();
            return final;
        }
        public Pourcentage[] objtopr(Object[] a)
        {
            List<Pourcentage> pro = new List<Pourcentage>();
            for (int i = 0; i < a.Count(); i++)
            {
                Pourcentage x = new Pourcentage();
                x = (Pourcentage)a[i];
                pro.Add(x);
            }
            Pourcentage[] final = pro.ToArray();
            return final;
        }
        public Presse[] objtopresse(Object[] a)
        {
            List<Presse> pro = new List<Presse>();
            for (int i = 0; i < a.Count(); i++)
            {
                Presse x = new Presse();
                x = (Presse)a[i];
                pro.Add(x);
            }
            Presse[] final = pro.ToArray();
            return final;
        }
        public AjoutPresse[] objtoaddpresse(Object[] a)
        {
            List<AjoutPresse> pro = new List<AjoutPresse>();
            for (int i = 0; i < a.Count(); i++)
            {
                AjoutPresse x = new AjoutPresse();
                x = (AjoutPresse)a[i];
                pro.Add(x);
            }
            AjoutPresse[] final = pro.ToArray();
            return final;
        }
        public void insertzone(Zonec insert,String idStade,int taille) {
            String x = idStade;
            Zone3 zone = new Zone3();
            zone.nom = insert.nom;
            zone.idstade =idStade;
            zone.idzone = taille.ToString();
            this.Insert(zone);
        }
        public void insertcoorzone(Zonec insert, int taille)
        {
            int leng = insert.coordonne.Length;
            for (int i = 0; i < leng; i++)
            {
                Coordonne_zone coor = new Coordonne_zone();
                coor.idzone = taille.ToString();
                coor.x = insert.coordonne[i].X;
                coor.y = insert.coordonne[i].Y;
                this.Insert(coor);
            }
        }
        public void insertseza(Zonec insert,String idstade,int taille){
            int leng = insert.tableau.Length;
            for (int i = 0; i < leng; i++)
            {
                Chaisse coor = new Chaisse();
                coor.idstade = idstade;
                coor.idzone = taille.ToString();
                coor.x = insert.tableau[i].x;
                coor.y = insert.tableau[i].y;
                coor.numero = insert.tableau[i].numero;
                coor.hauteur = insert.tableau[i].hauteur;
                coor.espacement = insert.tableau[i].espacement;
                this.Insert(coor);
            }
        
        }
        public int chaissenumero(Zonec test) {
            
            
                int x = test.tableau.Length;
                int value = test.tableau[x - 1].numero;
                return value;
        }
        public void testChaisse(List<Zonec>tableau) {
            Zonec[] tab = tableau.ToArray();
            if (tab.Length == 0)
            {
                throw new Exception("Veuillez mettre des zones");
            }
            else{
                for (int i = 0; i < tab.Length; i++)
                {
                    if (tab[i].tableau.Length == 0)
                    {
                        throw new Exception("Veuillez completer les chaise");
                    }
                    else
                    {
                        continue;

                    }
                }
            
            }
        
        
        
        
        }
        public int insertionStade(String stade, PointF[] tableau) {
            int taille=(this.Select2(new Stade(),null,null,null)).Length;
            Stade stade1 = new Stade();
            stade1.idstade = (taille + 1).ToString();
            stade1.nom = stade;
            this.Insert(stade1);
            for (int i = 0; i < tableau.Length; i++) {
                Coordonne_stade coor = new Coordonne_stade();
                coor.idstade = (taille + 1).ToString();
                coor.x = tableau[i].X;
                coor.y = tableau[i].Y;
                this.Insert(coor);
            }


            return taille + 1;
        
        
        }
        public void insertionpresse(String idev, String id, String date) {
            
            AjoutPresse ajout = new AjoutPresse();
            ajout.dateappel = Convert.ToDateTime(date);
            ajout.idpresse = id;
            ajout.idevenement = idev;
            ajout.idappel = "0";
            this.Insert(ajout);
        
        
        
        }
        public void insertEvenement(String Date, String id,String idev) {
            Evenement evenement = new Evenement();
            evenement.idevenement = idev;
            evenement.nom = idev;
            evenement.dateconcert = Convert.ToDateTime(Date);
            this.Insert(evenement);
            String[] colonne = new String[1];
            colonne[0] = "nom";
            String[] valeur = new String[1];
            valeur[0] = id;
            String[] colonne2 = new String[1];
            colonne2[0] = "idstade";
            Object[] stade = this.Select2(new Stade(), colonne, valeur, null);
            Stade[] tableaustade = this.objtoStade(stade);
             String[] valeur2 = new String[1];
             valeur2[0] = tableaustade[0].idstade;
            Object[] zon = this.Select2(new Zone3(), colonne2, valeur2, null);
            Object[] cha = this.Select2(new Chaisse(), null, null, null);
            Zone3[] tableau = this.objtozone3(zon);
            Chaisse[] seza = this.objtochai(cha);
            for (int i = 0; i < tableau.Length; i++)
            {
                //  String e = tableau[i].idzone;
                //  Chaisse[] teenAgerStudents = seza.Where(s => s.idzone == tableau[i].idzone).ToArray();

                for (int j = 0; j < seza.Length; j++)
                {
                    if (seza[j].idzone.Equals(tableau[i].idzone))
                    {
                        Chaissee ins = new Chaissee();
                        ins.idevenement = idev;
                        ins.idzone = tableau[i].idzone;
                        //int x = .numero;
                        ins.numero = seza[j].numero;
                        ins.etat = 0;
                        this.Insert(ins);


                    }
                }


            }
        }
        public void updateBillet(String zone, String numero, String id,String time) {
            DateTime date = Convert.ToDateTime(time);
            DBconnection connect = new DBconnection();
            SqlConnection sql = connect.getConex();
            String[]colonne3=new String[1];
            colonne3[0]="idevenement";
            String[]value3=new String[1];
            value3[0]=id;
            Object[] transaction = this.Select2(new Mouvements(), null, null, null);
            int taille = transaction.Length;
            Object[] prevision = this.Select2(new Pourcentage(), colonne3, value3, null);
            Pourcentage[]tableaupour=this.objtopr(prevision);
            bool res;
            int a;
            res=int.TryParse(numero,out a);
            if (res == true)
            {
                String[] colonne = new String[2];
                colonne[0] = "idevenement";
                colonne[1] = " idzone";
                String[] valeur = new String[2];
                valeur[0] = id;
                valeur[1] = zone;
                Object[] tableauchaise = this.Select2(new Chaissee(), colonne, valeur, null);
                Chaissee[] chaissee = this.objtoch(tableauchaise);
                Chaissee[] tabchaisse = chaissee.Where(s => s.numero == a && s.etat == 1).ToArray();
                if (tabchaisse.Length > 0)
                {
                    throw new Exception("Place deja terminer");
                }
                else
                {
                    taille = taille + 1;
                    Pourcentage[] tabl = tableaupour.Where(s => s.idzone == zone).ToArray();
                    String requete = "Update Chaissee set etat=1 where idevenement='" + id + "' and idzone='" + zone + "' and  numero='" + a + "'";
                    Mouvements tr = new Mouvements();
                    tr.idtransaction = taille.ToString();
                    tr.idevenement = id;
                    tr.idzone = zone;
                    tr.pourcentage = 0;
                    tr.dateachat = date;
                    tr.prix_totale = tabl[0].prix_unitaire;
                    this.Insert(tr);
                    this.Insert2(requete, sql);


                }




            }
            else
            {
                char[] tableau = numero.ToArray();
                for (int i = 0; i < tableau.Length; i++)
                {
                    if (tableau[i] == '-')
                    {
                        String[] nombre = numero.Split('-');
                        int debut = Int32.Parse(nombre[0]);
                        int fin = Int32.Parse(nombre[1]);
                        List<int> liste = new List<int>();
                        for (int j = debut; j < fin + 1; j++)
                        {
                            liste.Add(j);
                        }
                        int[] tab = liste.ToArray();
                        String[] colonne = new String[2];
                        colonne[0] = "idevenement";
                        colonne[1] = " idzone";
                        String[] valeur = new String[2];
                        valeur[0] = id;
                        valeur[1] = zone;
                        Object[] tableauchaise = this.Select2(new Chaissee(), colonne, valeur, null);
                        Chaissee[] chaissee = this.objtoch(tableauchaise);
                        for (int jj = 0; jj < tab.Length; jj++)
                        {
                            Chaissee[] tabchaisse = chaissee.Where(s => s.numero == tab[jj] && s.etat == 1).ToArray();
                            if (tabchaisse.Length > 0)
                            {
                                throw new Exception("Billet");
                            }

                        }
                        for (int ini = 0; ini < tab.Length; ini++)
                        {
                            taille = taille + 1;
                            Pourcentage[] tabl = tableaupour.Where(s => s.idzone == zone).ToArray();
                            String requete = "Update Chaissee set etat=1 where idevenement='" + id + "' and idzone='" + zone + "' and  numero='" + tab[ini] + "'";
                            string bozo = requete;
                            Mouvements tr = new Mouvements();
                            tr.idtransaction = taille.ToString();
                            tr.idevenement = id;
                            tr.idzone = zone;
                            tr.pourcentage = 0;
                            tr.dateachat = date;
                            tr.prix_totale = tabl[0].prix_unitaire;
                            this.Insert(tr);
                            this.Insert2(requete, sql);
                        }




                    }
                    else if (tableau[i] == ',')
                    {
                        String[] nombre = numero.Split(',');
                        int debut = Int32.Parse(nombre[0]);
                        int fin = Int32.Parse(nombre[1]);
                        int[] tab = new int[2];
                        tab[0] = debut;
                        tab[1] = fin;
                        String[] colonne = new String[2];
                        colonne[0] = "idevenement";
                        colonne[1] = " idzone";
                        String[] valeur = new String[2];
                        valeur[0] = id;
                        valeur[1] = zone;
                        Object[] tableauchaise = this.Select2(new Chaissee(), colonne, valeur, null);
                        Chaissee[] chaissee = this.objtoch(tableauchaise);
                        for (int jj = 0; jj < tab.Length; jj++)
                        {
                            Chaissee[] tabchaisse = chaissee.Where(s => s.numero == tab[jj] && s.etat == 1).ToArray();
                            if (tabchaisse.Length > 0)
                            {
                                throw new Exception("Billet");
                            }

                        }
                        for (int ini = 0; ini < tab.Length; ini++)
                        {
                            taille = taille + 1;
                            Pourcentage[] tabl = tableaupour.Where(s => s.idzone == zone).ToArray();
                            String requete = "Update Chaissee set Etat=1 where idevenement='" + id + "' and idzone='" + zone + "' and  numero='" + tab[ini] + "'";
                            Mouvements tr = new Mouvements();
                            tr.idtransaction = taille.ToString();
                            tr.idevenement = id;
                            tr.idzone = zone;
                            tr.pourcentage = 0;
                            tr.dateachat = DateTime.Today;
                            tr.prix_totale = tabl[0].prix_unitaire;
                            this.Insert(tr);
                            this.Insert2(requete, sql);
                        }

                    }

                }
            }
        
        
        
        
        
        
        
        }
        public DateTime[]getdate(String idevenement)
        {
            DBconnection connect = new DBconnection();
            
            SqlConnection sql = connect.getConex();

            String requete = "select distinct dateachat as date where idevenement'=" + idevenement + "'";

            sql.Open();
            SqlCommand req = new SqlCommand(requete, sql);
            SqlDataReader reader = req.ExecuteReader();
            List<DateTime> list = new List<System.DateTime>();
            // MethodInfo me
            while (reader.Read())
            {

                list.Add(Convert.ToDateTime(reader["date"]));
             
            }
           DateTime[] finale = list.ToArray();

            return finale;
        }
        public String[] getidzone(String idevenement)
        {
            DBconnection connect = new DBconnection();

            SqlConnection sql = connect.getConex();

            String requete = "select distinct idzone as date where idevenement'=" + idevenement + "'";
            sql.Open();
            SqlCommand req = new SqlCommand(requete, sql);
            SqlDataReader reader = req.ExecuteReader();
            List<String> list = new List<String>();
            // MethodInfo me
            while (reader.Read())
            {

                list.Add(reader["date"].ToString());

            }
            String[] finale = list.ToArray();

            return finale;
        }
        public void update(String requete)
        {
            DBconnection connect = new DBconnection();
            SqlConnection sql = connect.getConex();

            this.Insert2(requete, sql);
        }
        public double pourcentage(String totalplace, String placeentree) {
            double total = double.Parse(totalplace);
            double place = double.Parse(placeentree);
            double final = (place / total) * 100;
            return final;
        }

        public Mouvements[] pourcentageBillet(String id) {
            
            Object[] pourcentage = this.Select2(new Pourcentage(), null, null, null);
            Pourcentage[] tableau = this.objtopr(pourcentage);
            Pourcentage[] linq = tableau.Where(s => s.idevenement == id.ToString()).ToArray();
            Mouvements[]tab=this.objtomouv(this.Select2(new Mouvements(),null,null,null));
            List<Mouvements> listepourcentage = new List<Mouvements>();
            Chaissee[]tableau2=this.objtoch(this.Select2(new Chaissee(),null,null,null));
            for (int i = 0; i < linq.Length; i++)
            {
                String x = id + "-" + linq[i].idzone;
                Mouvements[] array = tab.Where(s => s.idevenement == id.ToString() && s.idzone == linq[i].idzone).ToArray();
                if (array.Length == 0)
                {
                    Mouvements pour = new Mouvements();
                    pour.idevenement = id;
                    pour.idzone = linq[i].idzone;
                    pour.idtransaction = "0";
                    pour.pourcentage = (float)0;
                    pour.prix_totale = 0;
                    listepourcentage.Add(pour);

                }
                else
                {
                    Chaissee[] tab2 = tableau2.Where(s => s.idevenement == id.ToString() && s.idzone == linq[i].idzone).ToArray();
                    int t = array.Length;
                    double pource = (Convert.ToSingle(t) / Convert.ToSingle(tab2.Length)) * 100;
                    double val = Math.Round(pource, 1);
                    Mouvements pour = new Mouvements();
                    pour.idevenement = id;
                    pour.idzone = linq[i].idzone;
                    pour.idtransaction = "0";
                    pour.pourcentage = (float)val;
                    pour.prix_totale = t * array[0].prix_totale;
                    pour.dateachat = array[t - 1].dateachat;
                    listepourcentage.Add(pour);
                }
            }
            Mouvements[] final = listepourcentage.ToArray();
            return final;
        }
        public Mouvements[] Prevision(String id)
        {

            Object[] pourcentage = this.Select2(new Pourcentage(), null, null, null);
            Pourcentage[] tableau = this.objtopr(pourcentage);
            Pourcentage[] linq = tableau.Where(s => s.idevenement == id.ToString()).ToArray();
            Mouvements[] tab = this.objtomouv(this.Select2(new Mouvements(), null, null, null));
            List<Mouvements> listepourcentage2 = new List<Mouvements>();
            Mouvements[] tableau3 = tab.GroupBy(x => x.dateachat).Select(g => g.FirstOrDefault()).ToArray();
            Chaissee[] tableau2 = this.objtoch(this.Select2(new Chaissee(), null, null, null));
            for (int jj = 0; jj < tableau3.Length;jj++ ){
              
                for (int i = 0; i < linq.Length; i++)
                {
                    String x = id + "-" + linq[i].idzone;
                    Mouvements[] array = tab.Where(s => s.idevenement == id.ToString() && s.idzone == linq[i].idzone && s.dateachat==tableau3[jj].dateachat).ToArray();
                    if (array.Length == 0) {
                        continue;
                    }
                    else{
                        if (listepourcentage2.Capacity == 0)
                        {
                            Chaissee[] tab2 = tableau2.Where(s => s.idevenement == id.ToString() && s.idzone == linq[i].idzone).ToArray();
                            int t = array.Length;
                            double pource = (Convert.ToSingle(t) / Convert.ToSingle(tab2.Length)) * 100;
                            double val = Math.Round(pource, 1);
                            //   Mouvements mouvements=list
                            Mouvements pour = new Mouvements();
                            pour.idevenement = id;
                            pour.idzone = linq[i].idzone;
                            pour.idtransaction = "0";
                            pour.pourcentage = (float)val;
                            pour.prix_totale = t * array[0].prix_totale;
                            pour.dateachat = tableau3[jj].dateachat;
                            listepourcentage2.Add(pour);

                        }
                        else{
                            //1-2
                            int e=listepourcentage2.Capacity;
                            Mouvements test = listepourcentage2.Last();
                            if (test.idzone != linq[i].idzone)
                            {
                                Chaissee[] tab2 = tableau2.Where(s => s.idevenement == id.ToString() && s.idzone == linq[i].idzone).ToArray();
                                int t = array.Length;
                                double pource = (Convert.ToSingle(t) / Convert.ToSingle(tab2.Length)) * 100;
                                double val = Math.Round(pource, 1);
                                //   Mouvements mouvements=list
                                Mouvements pour = new Mouvements();
                                pour.idevenement = id;
                                pour.idzone = linq[i].idzone;
                                pour.idtransaction = "0";
                                pour.pourcentage = (float)val;
                                pour.prix_totale = t * array[0].prix_totale;
                                pour.dateachat = tableau3[jj].dateachat;
                                listepourcentage2.Add(pour);

                            }
                            else
                            {

                                Chaissee[] tab2 = tableau2.Where(s => s.idevenement == id.ToString() && s.idzone == linq[i].idzone).ToArray();
                                decimal koz = test.prix_totale;
                                decimal fako = linq[0].prix_unitaire;
                                int std = decimal.ToInt32(test.prix_totale / linq[0].prix_unitaire);
                                int t = array.Length;
                                double pource = (Convert.ToSingle(t + std) / Convert.ToSingle(tab2.Length)) * 100;
                                double val = Math.Round(pource, 1);
                                //   Mouvements mouvements=list
                                Mouvements pour = new Mouvements();
                                pour.idevenement = id;
                                pour.idzone = linq[i].idzone;
                                pour.idtransaction = "0";
                                pour.pourcentage = (float)val;
                                pour.prix_totale = (t + std) * array[0].prix_totale;
                                pour.dateachat = tableau3[jj].dateachat;
                                listepourcentage2.Add(pour);

                            }
                        }
                        }
                    }
                }

            Mouvements[] final = listepourcentage2.ToArray();
            return final;
            }
           
        
        public Pourcentage[] tableauPourcentage(String id) {
            Object[] pourcentage = this.Select2(new Pourcentage(), null, null, null);
            Pourcentage[] tableau = this.objtopr(pourcentage);
            Pourcentage[] linq = tableau.Where(s => s.idevenement == id.ToString()).ToArray();
            Chaissee[] tableau2 = this.objtoch(this.Select2(new Chaissee(), null, null, null));
            for (int i = 0; i < linq.Length; i++) {
                Chaissee[] tab2 = tableau2.Where(s => s.idevenement == id.ToString() && s.idzone == linq[i].idzone).ToArray();
                linq[i].prix_unitaire = tab2.Length * linq[i].prix_unitaire;     
            }
                return linq;  
        }
        public Clpresse[]clpresse(Clcourbes[]tab,String idevenement){
            Presse[] listepresse = this.objtopresse(this.Select2(new Presse(), null, null, null));
            String[] colonne = new String[1];
            colonne[0] = "idevenement";
            String[] value = new String[1];
            Clpresse cl=new Clpresse();
            List<Clpresse> l = new List<Clpresse>();
            value[0] = idevenement;
            Object[] tabl = this.Select2(new AjoutPresse(), null, null, null);
            AjoutPresse[] tableaupresse = this.objtoaddpresse(tabl);
            for (int i = 0; i < tab.Length; i++) {
                 AjoutPresse[] tab2 =  tableaupresse.Where(s => s.dateappel==Convert.ToDateTime(tab[i].x)).ToArray();
                 if (tab2.Length > 1)
                 {
                     if (tab[i].y % tab2.Length == 0)
                     {
                         int e = tab[i].y / tab2.Length;
                         for (int j = 0; j < tab2.Length; j++)
                         {

                             Clpresse ne = new Clpresse();
                             ne.idpresse = tab2[0].idpresse;
                             ne.nom = "";
                             ne.points = e;
                             l.Add(ne);
                         }
                     }
                     else {
                         int e = tab[i].y / tab2.Length;
                         for (int j = 0; j < tab2.Length; j++) {
                             Clpresse ne = new Clpresse();
                             ne.idpresse = tab2[j].idpresse;
                             ne.nom = "";
                             ne.points = e;
                             l.Add(ne);
                         }
                         int initial = 0;
                         int reste=tab[i].y % tab2.Length;
                         while (initial != reste) {
                             for (int jj = 0; jj < tab2.Length; jj++) {
                                 if (initial == reste)
                                 {
                                     break;
                                 }
                                 else {
                                     Clpresse ne = new Clpresse();
                                     ne.idpresse = tab2[jj].idpresse;
                                     ne.nom = "";
                                     ne.points = 1;
                                     l.Add(ne);
                                     initial = initial+1;
                                 }
                             }
                           
                         }
               
                     }


                 }
                 else {
                     Clpresse ne = new Clpresse();
                     ne.idpresse = tab2[0].idpresse;
                     ne.nom = "";
                     ne.points = tab[i].y;
                     l.Add(ne);
                 }
                
            
            }
            Presse[] info = this.objtopresse(this.Select2(new Presse(), null, null, null));
            List<Clpresse> fin = this.tableau4(l, info);
            Clpresse[] presse = this.tripoinsgen(fin.ToArray());
            return presse;
        
        }
        public Clpresse[] tripoinsgen(Clpresse[] tab)
        {
            Clpresse min = new Clpresse();
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = i + 1; j < tab.Length; j++)
                {
                    if (tab[j].points > tab[i].points)
                    {
                        min = tab[j];
                        tab[j] = tab[i];
                        tab[i] = min;
                    }
                }
            }
            return tab;
        }
        public List<Clpresse>tableau4(List<Clpresse> listes,Presse[]info) {
            Clpresse[] tableau3 = listes.GroupBy(x => x.idpresse).Select(g => g.FirstOrDefault()).ToArray();
            List<Clpresse> list = new List<Clpresse>();
            for (int i = 0; i < tableau3.Length; i++) {
                Clpresse[] tudentArray = listes.Where(s => s.idpresse == tableau3[i].idpresse).ToArray();
                Presse[] nom = info.Where(s => s.idpresse == tableau3[i].idpresse).ToArray();
                if (tudentArray.Length > 1)
                {
                    List<int> stock = new List<int>();
                    for (int j = 0; j < tudentArray.Length; j++)
                    {
                        stock.Add(tudentArray[j].points);
                    }
                    int somme = stock.Sum();
                    Clpresse cl = new Clpresse();
                    cl.points = somme;
                    cl.nom = nom[0].nom;
                    cl.idpresse = tableau3[i].idpresse;
                    list.Add(cl);
                }
                else {
                    Clpresse cl = new Clpresse();
                    cl.points = tudentArray[0].points;
                    cl.nom = nom[0].nom;
                    cl.idpresse = tudentArray[0].idpresse;
                    list.Add(cl);   
                }
            }
            return list;
        
        
        }
        public Clcourbes[]  courbes(String id) {
            Mouvements[]tab= this.objtomouv(this.Select2(new Mouvements(), null, null, null));
            Mouvements[]find= tab.Where(s => s.idevenement ==id).ToArray();
            Mouvements[] tableau2 = find.GroupBy(x => x.dateachat).Select(g => g.FirstOrDefault()).ToArray();
            List<Clcourbes> listes = new List<Clcourbes>();
            for (int i = 0; i < tableau2.Length; i++) {
                int x = find.Where(z => z.dateachat == tableau2[i].dateachat).ToArray().Length;
                Clcourbes cl=new Clcourbes();
                cl.x=tableau2[i].dateachat.ToString();
                cl.y=x;
                DateTime a = tableau2[i].dateachat;
                listes.Add(cl);
            }
            Clcourbes[] tableau3 = listes.ToArray();
            return tableau3;
        }
        public void drawithPointf(PointF[] tableau,Graphics e) {
            e.DrawPolygon(Pens.Black, tableau);
            
            
            
        
        
        
        
        }
        public void dessinerZonesChaisse(Graphics e, List<Zonec> list) {
            Zonec[] tableau = list.ToArray();
            for (int i = 0; i < tableau.Length; i++) {
                this.drawithPointf(tableau[i].coordonne, e);
                List<PointF> listPointF = new List<PointF>();
                for (int ii = 0; ii < tableau[i].tableau.Length; ii++)
                {
                    PointF temp = new PointF(tableau[i].tableau[ii].x, tableau[i].tableau[ii].y);
                    listPointF.Add(temp);

                }
                PointF[] array = listPointF.ToArray();
                for (int ini = 0; ini < array.Length; ini++) {
                    Font font1 = new Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                    float x = array[ini].X;
                    e.DrawString(tableau[i].tableau[ini].numero.ToString(), font1, Brushes.Blue, array[ini]);
                    //     gr.DrawString("Jean", font1, Brushes.Blue, new PointF(0,1));
                    e.DrawEllipse(Pens.Black, array[ini].X, array[ini].Y, 5, 5);
                
                
                
                
                }
            
            
            
            
            
            }
        
        }
        public void effacerChaiser(List<Zonec> lister) {
            for (int i = 0; i < lister.Count; i++)
            {
                lister[i].tableau = new Chaisse[0];
            }
        }
        public void dessinerZoneTab(String id,Graphics gr) {
            Coordonne_zone[] tab = this.objtoCoordonnezone(this.Select2(new Coordonne_zone(), null, null, null));
            Zone3[] tableau = this.objtozone3(this.Select2(new Zone3(), null, null, null));
            Zone3[] teenAgerStudents = tableau.Where(s => s.idstade == id).ToArray();
            for (int i = 0; i < teenAgerStudents.Length; i++) {
                List<PointF>list=new List<PointF>();
                Coordonne_zone[] teenAgerS = tab.Where(s => s.idzone == teenAgerStudents[i].idzone).ToArray();
                for (int jj = 0; jj < teenAgerS.Length; jj++) {
                    list.Add(new PointF(teenAgerS[jj].x, teenAgerS[jj].y));
                }
                gr.DrawPolygon(Pens.Black, list.ToArray());
            }
            Chaisse[] array = this.objtochai(this.Select2(new Chaisse(), null, null, null));
            Chaisse[] seza = array.Where(s => s.idstade == id).ToArray();
            for (int ii = 0; ii < seza.Length; ii++) {
                Font font1 = new Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                gr.DrawString(seza[ii].numero.ToString(), font1, Brushes.Blue,new PointF(seza[ii].x,seza[ii].y));
                //     gr.DrawString("Jean", font1, Brushes.Blue, new PointF(0,1));
                gr.DrawEllipse(Pens.Black, seza[ii].x, seza[ii].y, 5, 5);
            
            
            
            }
    
        
        
        
        
        
        
        }
        public bool IsPointInPolygon45(PointF[] polygon, PointF testPoint)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
    }
}
