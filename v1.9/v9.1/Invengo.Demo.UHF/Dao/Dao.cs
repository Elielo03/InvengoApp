using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.IO;
using System.Drawing;


namespace Invengo.Sample.Dao
{

    class Dao
    {
        SQLiteConnection con;
        public Dao()
        {
            Conexion conexion = new Conexion();
            con = conexion.conectar();
            //hola danny
           
        }

        



        public Boolean addFoto(string id_persona, string foto2) {

           
            return false;

        }


        public Boolean addMarcaje(int idPersona,int idEmpresa, string Empresa, string numNomina, string credencial, string esFamiliar)
        {
            //Console.WriteLine("el id es: "+idPersona);
            Boolean respuesta = false;
            string sql = "INSERT INTO marcajeAutobus(marcaje,idPersona,idEmpresa,numNomina,credencial,esFamiliar,Empresa) values(DateTime('now')," + idPersona + "," + idEmpresa + ",'" + numNomina + "','" + credencial + "','" + esFamiliar + "','" + Empresa + "')";
            string conString = @"Data Source=\datoInvengo.s3db";
            SQLiteConnection con1 = new SQLiteConnection(conString);
            SQLiteCommand cmd = new SQLiteCommand(sql, con1);
            con1.Open();   
            try
            {
                cmd.ExecuteNonQuery();
                respuesta = true;
                con1.Close();
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
              
            }
            
            con1.Close();
            return respuesta;
            
        }

        public Boolean addMarcajeComedor(int idPersona, int idEmpresa, string Empresa, string numNomina, string credencial, string esFamiliar)
        {
            
            Boolean respuesta = false;
            string sql = "INSERT INTO marcajeComedor(marcaje,idPersona,idEmpresa,numNomina,credencial,esFamiliar,Empresa) values((datetime('now','localtime'))," + idPersona + "," + idEmpresa + ",'" + numNomina + "','" + credencial + "','" + esFamiliar + "','" + Empresa + "')";
            string conString = @"Data Source=\datoInvengo.s3db";
            SQLiteConnection con1 = new SQLiteConnection(conString);
            SQLiteCommand cmd = new SQLiteCommand(sql, con1);
            con1.Open();
            try
            {
                cmd.ExecuteNonQuery();
                respuesta = true;
                con1.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            con1.Close();
            return respuesta;

        }

        public Boolean personaExist(string noCtrl)
        {
            Boolean respuesta = false;
            string sql = "SELECT * FROM 'persona' where noControl='"+noCtrl+"'";
            string conString = @"Data Source=\datoInvengo.s3db";
            SQLiteConnection con1 = new SQLiteConnection(conString);
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            con1.Open();   
            //cmd.Parameters.Add(noCtrl);
            try
            {

                SQLiteDataReader rdr = cmd.ExecuteReader();
                try
                {
                    if (rdr.HasRows)
                    {
                        respuesta = true;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    con1.Close();  
                }


            }
            catch (Exception ex)
            {
                con1.Close();  
                throw new Exception(ex.Message);
                

            }
            con1.Close();   
            return respuesta;
        }

        public Boolean addPersona(string idPersona, string nombreCompleto,string Credencial,string numNomina,string habilitado, string id_empresa,string Empresa,string UHF,string idCredencial, string comedor,string TipoPersona) {

            string query = "INSERT INTO persona(idPersona,nombreCompleto,Credencial,numNomina,habilitado,id_empresa,Empresa,UHF,idCredencial,comedor,TipoPersona)"+
            " values(" + idPersona + ",'" + nombreCompleto + "'," + Credencial + "," + numNomina + "," + habilitado + "," + id_empresa + ",'" + Empresa + "','"+UHF +"','"+idCredencial +"',"+comedor + ",'"+TipoPersona +"')";
            string conString = @"Data Source=\datoInvengo.s3db";
            Boolean respuesta = false;
            SQLiteConnection con = new SQLiteConnection(conString);
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (Exception exc)
            {
                con.Close();
                Console.WriteLine(exc.Message);
            }
            con.Close();
            return respuesta;
        }

       


        public Boolean deleteAutobus()
        {
            string query = "DELETE  FROM marcajeAutobus";
            string conString = @"Data Source=\datoInvengo.s3db";
            Boolean respuesta = false;
            SQLiteConnection con = new SQLiteConnection(conString);
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            con.Close();
            return respuesta;
        }



        public Boolean deleteComedor()
        {
            string query = "DELETE  FROM marcajeComedor";
            string conString = @"Data Source=\datoInvengo.s3db";
            Boolean respuesta = false;
            SQLiteConnection con = new SQLiteConnection(conString);
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                respuesta = true;
                con.Open();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            con.Close();
            return respuesta;
        }

        public Boolean deletePersonas()
        {
            string query = "DELETE  FROM persona";
            string conString = @"Data Source=\datoInvengo.s3db";
            Boolean respuesta = false;
            SQLiteConnection con = new SQLiteConnection(conString);
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            con.Close();
            return respuesta;
        }




        public string getPersonaByCtrl(string ctrl)
        {

            int idPersona = 0;
            int idEmpresa = 0;
            string Empresa = "";
            string numNomina = "";
            string credencial = "";
            string esFamiliar = "";

            string noControl = ctrl;
            noControl = noControl.Replace(" ", "");
            string query = "SELECT * FROM persona where credencial='" + noControl + "'";
            
            string conString = @"Data Source=\datoInvengo.s3db";
            string respuesta=null;
            SQLiteConnection con = new SQLiteConnection(conString);
            //variables en caso de que si exista la persona;
            Boolean insertar = false;
         
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            try
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();

                    if (!rdr.HasRows)
                    {
                        respuesta="0";
                       
                    }
                    else
                    {
                       
                        while (rdr.Read())
                        {
                            idPersona = int.Parse(rdr[0].ToString());
                            idEmpresa = int.Parse(rdr[5].ToString());
                            Empresa = rdr[6].ToString();
                            numNomina=rdr[3].ToString();
                            credencial = rdr[2].ToString();
                            esFamiliar=rdr[10].ToString();
                            
                          
                            respuesta = rdr[0]+","+rdr[1].ToString()+","+credencial+","+Empresa;
                            //controla si se realizara la insercion al final de metodo o no
                            insertar = true;
                            
                        }
                    }
               
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                con.Close();
            }
            if(insertar){
                  if (!(addMarcaje(idPersona,idEmpresa,Empresa,numNomina,credencial,esFamiliar)))
            {
                Console.WriteLine("No se inserto el marcaje");
            }
            }
            con.Close();
            return respuesta;
        }


        public string getPersonaByUHF(string ctrl)
        {

            int idPersona = 0;
            int idEmpresa = 0;
            string Empresa = "";
            string numNomina = "";
            string credencial = "";
            string  esFamiliar = "";

            string noControl = ctrl;
            noControl = noControl.Replace(" ", "");
            string query = "SELECT * FROM persona where UHF='" + noControl + "'";

            string conString = @"Data Source=\datoInvengo.s3db";
            string respuesta = null;
            SQLiteConnection con = new SQLiteConnection(conString);
            //variables en caso de que si exista la persona;
            Boolean insertar = false;
            
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            try
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();

                if (!rdr.HasRows)
                {
                    respuesta = "0";
                   
                }
                else
                {

                    while (rdr.Read())
                    {
                        idPersona = int.Parse(rdr[0].ToString());
                        idEmpresa = int.Parse(rdr[5].ToString());
                        Empresa = rdr[6].ToString();
                        numNomina = rdr[3].ToString();
                        credencial = rdr[2].ToString();
                        esFamiliar = rdr[10].ToString();

                        respuesta = rdr[0] + "," + rdr[1].ToString() + "," + credencial + "," + Empresa;
                        //controla si se realizara la insercion al final de metodo o no
                       
                        insertar = true;

                    }
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                con.Close();
            }
            if (insertar)
            {
                if (!(addMarcaje(idPersona, idEmpresa, Empresa, numNomina, credencial, esFamiliar)))
                {
                    Console.WriteLine("No se inserto el marcaje");
                }
            }
            con.Close();
            return respuesta;
        }
        public string getPersonaByUHFComedor(string ctrl)
        {

            int idPersona = 0;
            int idEmpresa = 0;
            string Empresa = "";
            string numNomina = "";
            string credencial = "";
            string esFamiliar = "";
            //string nombre;

            string noControl = ctrl;
            noControl = noControl.Replace(" ", "");
            string query = "SELECT * FROM persona where UHF='" + noControl + "'";

            string conString = @"Data Source=\datoInvengo.s3db";
            string respuesta = null;
            SQLiteConnection con = new SQLiteConnection(conString);
            //variables en caso de que si exista la persona;
            Boolean insertar = false;
           
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            try
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();

                if (!rdr.HasRows)
                {
                    respuesta = "0";
                   
                }
                else
                {

                    while (rdr.Read())
                    {
                        idPersona = int.Parse(rdr[0].ToString());
                        idEmpresa = int.Parse(rdr[5].ToString());
                        Empresa = rdr[6].ToString();
                        numNomina = rdr[3].ToString();
                        credencial = rdr[2].ToString();
                        esFamiliar = rdr[10].ToString();                       
                        respuesta = rdr[0] + "," + rdr[1].ToString() + "," + credencial + "," + Empresa;
                        insertar = true;
                    }
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                con.Close();
            }
            if (insertar)
            {
                if (!(addMarcajeComedor(idPersona, idEmpresa, Empresa, numNomina, credencial, esFamiliar)))
                {
                    Console.WriteLine("No se inserto el marcaje");
                }
            }
            con.Close();
            return respuesta;
        }



        public string getPersonaByCredencial(string ctrl, Boolean comedor)
        {

            int idPersona = 0;
            int idEmpresa = 0;
            string Empresa = "";
            string numNomina = "";
            string credencial = "";
            string esFamiliar = "";

            string noControl = ctrl;
            noControl = noControl.Replace(" ", "");
            string query = "SELECT * FROM persona where Credencial='" + noControl + "'";
            string conString = @"Data Source=\datoInvengo.s3db";
            string respuesta = null;
            SQLiteConnection con = new SQLiteConnection(conString);
            //variables en caso de que si exista la persona;
            Boolean insertar = false;
            //int id=0;
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            try
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    respuesta = "0";
                }
                else
                {
                    while (rdr.Read())
                    {
                        idPersona = int.Parse(rdr[0].ToString());
                        idEmpresa = int.Parse(rdr[5].ToString());
                        Empresa = rdr[6].ToString();
                        numNomina = rdr[3].ToString();
                        credencial = rdr[2].ToString();
                        esFamiliar = rdr[10].ToString();
                        respuesta = rdr[0] + "," + rdr[1].ToString() + "," + credencial + "," + Empresa;
                        //controla si se realizara la insercion al final de metodo o no
                        insertar = true;

                    }
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                con.Close();
            }
            if (insertar)
            {
                //para saber si es de comedor o autobus
                if (comedor)
                {
                    if (!(addMarcajeComedor(idPersona, idEmpresa, Empresa, numNomina, credencial, esFamiliar)))
                    {
                        Console.WriteLine("No se inserto el marcaje (Comedor)\nIntentelo nuevamente!");
                    }
                }
                else
                {
                    if (!(addMarcaje(idPersona, idEmpresa, Empresa, numNomina, credencial, esFamiliar)))
                    {
                        Console.WriteLine("No se inserto el marcaje (Autobus)\nIntentelo nuevamente!");
                    }
                }
            }
            con.Close();
            return respuesta;
        }


        public Boolean syncMarcaje()
        {
            Boolean del = false;
            string query = "SELECT  strftime('%Y-%m-%d %H:%M:%S', marcaje) as fecha, idPersona,idEmpresa,numNomina,credencial,esFamiliar,idx  FROM marcajeAutobus";

            string conString = @"Data Source=\datoInvengo.s3db";
            Boolean respuesta = false;
            SQLiteConnection con = new SQLiteConnection(conString);
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            try
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();

                if (!rdr.HasRows)
                {
                    respuesta = false;
                    
                    Console.WriteLine("No hay datos para sincronizar");
                    con.Close();
                }
                else
                {
                    try
                    {

                        RestClient restClient = new RestClient();
                        while (rdr.Read())
                        {
                            string marcaje = rdr[0].ToString();

                            int idPersona = int.Parse(rdr[1].ToString());
                            int idEmpresa = int.Parse(rdr[2].ToString());
                            string numNomina = rdr[3].ToString();
                            string credencial = rdr[4].ToString();
                            string esFamiliar = rdr[5].ToString();
                            string fecha = rdr[0].ToString();
                            
                            string urldatos = "&marcaje=" + marcaje + "&idPersona=" + idPersona + "&idEmpresa=" + idEmpresa + "&numNomina=" + numNomina + "&credencial=" + credencial + "&esFamiliar=" + esFamiliar;
                            restClient.endPoint = "http://192.168.40.21/Invengo/Controller/ControllerInvengo.php?OPC=4" + urldatos;
                        
                            string strResponse = string.Empty;
                            strResponse = restClient.makeRequest();
                            if (strResponse.Equals("0"))
                            {
                                Console.WriteLine("Marcaje no sincronizado (marcaje autobus)\nAsegurate de tener conexion a internet e intentalo mas tarde!");
                                con.Close();
                                //break;
                                
                            }
                            else {
                                Console.Write(urldatos);
                            }
                           

                        }
                        deleteAutobus();
                        Console.WriteLine("\nSincronizacion finalizada (Autobus)!");
                        
                    }
                    catch (Exception ex) {
                        Console.WriteLine("No se puede conectar al servidor\nIntentalo mas tarde!(1)");
                    }

                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                con.Close();
            }
           
            con.Close();
           



            return respuesta;
        }


        public Boolean syncMarcajeComedor()
        {

            Boolean del = false;
            string query = "SELECT  strftime('%Y-%m-%d %H:%M:%S', marcaje) as fecha, idPersona,idEmpresa,numNomina,credencial,esFamiliar,idx  FROM marcajeComedor";
            string conString = @"Data Source=\datoInvengo.s3db";
            Boolean respuesta = false;
            SQLiteConnection con = new SQLiteConnection(conString);
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            try
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();

                if (!rdr.HasRows)
                {
                    respuesta = false;
                    Console.WriteLine("No hay datos para sincronizar");
                    con.Close();
                }
                else
                {
                    try
                    {
                        RestClient restClient = new RestClient();
                        while (rdr.Read())
                        {
                            string marcaje = rdr[0].ToString();

                            int idPersona = int.Parse(rdr[1].ToString());
                            int idEmpresa = int.Parse(rdr[2].ToString());
                            string numNomina = rdr[3].ToString();
                            string credencial = rdr[4].ToString();
                            string esFamiliar = rdr[5].ToString();
                            string fecha = rdr[0].ToString();
                            string urldatos = "&marcaje=" + marcaje + "&idPersona=" + idPersona + "&idEmpresa=" + idEmpresa + "&numNomina=" + numNomina + "&credencial=" + credencial + "&esFamiliar=" + esFamiliar;
                            restClient.endPoint = "http://192.168.40.21/Invengo/Controller/ControllerInvengo.php?OPC=5" + urldatos;
                            string strResponse = string.Empty;
                            strResponse = restClient.makeRequest();
                            if (strResponse.Equals("0"))
                            {
                                Console.WriteLine("Marcaje no sincronizado (marcaje comedor)\nAsegurate de tener conexion a internet e intentalo mas tarde!");
                                con.Close();
                                //break;

                            }
                            else {
                                Console.Write(urldatos);
                            }
                          
                                
                           
                        }
                       
                        deleteComedor();
                        Console.WriteLine("\nSincronizacion finalizada (Comedor)!");
                       
                    }

                    catch (Exception ex) {
                        Console.WriteLine("No se puede conectar al servidor\nIntentalo mas tarde! (2)");
                    }

                    
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                con.Close();
            }

            con.Close();




            return respuesta;
        }
    }

    
}
