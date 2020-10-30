using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace WindowsFormsApplication1
{
    public class DBconnection
    {
        SqlConnection connect = new SqlConnection();
        public SqlConnection getConex()
        {
            return connect;
        }
        public DBconnection()
        {
            String chaineConnexion = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Mick\documents\visual studio 2010\Projects\WindowsFormsApplication1\WindowsFormsApplication1\Stade.mdf;Integrated Security=True;User Instance=True";
            connect = new SqlConnection(chaineConnexion);
        }
    }
}