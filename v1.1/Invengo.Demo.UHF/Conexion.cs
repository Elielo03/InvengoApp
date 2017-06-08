using System;

using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Invengo.Sample
{
    class Conexion
    {
        public SQLiteConnection conectar() {
            string conString = @"Data Source=\InvengoDb.s3db";
            SQLiteConnection con = new SQLiteConnection(conString);
            try
            {
                
                con.Open();
            }
            catch (Exception ex)
            {

                
                Console.WriteLine(ex.Message);
                con = null;
            }
            return con;
            
           
        }

       
    }
}
