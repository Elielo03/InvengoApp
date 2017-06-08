using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

using LinqBridge;
using CodeBetter.Json;
using System.Net;
using System.IO;






namespace Invengo.Sample
{
    public partial class FrConexion : Form
    {
        string[] datos =new string[12];
        
        public FrConexion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            syncPhoto();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                RestClient restClient = new RestClient();
                restClient.endPoint = "http://192.168.40.21/Invengo/Controller/ControllerInvengo.php?OPC=1";

                string strResponse = string.Empty;
                strResponse = restClient.makeRequest();
                Dao.Dao dao = new Dao.Dao();
                string come = null;
                string strResponseLast = strResponse.Remove(strResponse.Length - 1, 1);
                int last = strResponse.Length;
                string json = strResponseLast.Substring(1);

                string[] columna = null;
                string[] fila = json.Split('{');
                if (dao.deletePersonas())
                {
                    foreach (string data1 in fila)
                    {

                        columna = data1.Split(',');
                        Console.WriteLine("Linea: " + data1 + "\n");
                        int i = 0;

                        foreach (string data2 in columna)
                        {
                            if (i == 9 || i == 0)
                            {
                                this.datos[i] = data2.ToString().Replace('\"', ' ');
                            }
                            else
                            {
                                this.datos[i] = data2.ToString();
                            }

                            i++;

                        }

                        if (!dao.addPersona(this.datos[0], this.datos[2], this.datos[1], this.datos[3], this.datos[4], this.datos[5], this.datos[6], this.datos[7], this.datos[8], this.datos[9]))
                        {
                            Console.WriteLine("Error al insertar persona");
                            //break;
                        }
                        Console.WriteLine("Sincronizacion Finalizada!");
                    }
                }
                else
                {
                    Console.WriteLine("Error al eliminar la tabla de personas");
                }







            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede conectar con el servidor\nIntentalo mas tarde!");
            }
            
           
                //this.label2.Text = registros[0][3];
            }

        public void syncPhoto(){
            try
            {
                //Vamos a borrar la carpeta y crearla de nuevo
                string path = @"\Storage Card\Img";
                if (Directory.Exists(path))
                {
                    System.IO.Directory.Delete(path, true);

                    System.IO.Directory.CreateDirectory(path);
                  
                }
                else
                {
                    System.IO.Directory.CreateDirectory(path);
                   
                }
                //aqui vamos a obtener un listado de todos los ids para las fotos
                RestClient restClient = new RestClient();
                restClient.endPoint = "http://192.168.40.21/Invengo/Controller/ControllerInvengo.php?OPC=3";
                string strResponse = string.Empty;
                strResponse = restClient.makeRequest();
                Dao.Dao dao = new Dao.Dao();
                string strResponseLast = strResponse.Remove(strResponse.Length - 1, 1);
                string json = strResponseLast.Substring(1);
                string[] fila = json.Split(',');
                foreach (string id in fila)
                {
                    try
                    {
                        //aqui va a descargar la img
                        Console.WriteLine("Imagen Sincronizada : " + id + ".jpg");
                        string imageUrl = @"http://192.168.40.21/Invengo/Img/" + id + ".jpg";
                        string saveLocation = @"\Storage Card\Img\" + id + ".jpg";
                        byte[] imageBytes;
                        HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
                        WebResponse imageResponse = imageRequest.GetResponse();
                        Stream responseStream = imageResponse.GetResponseStream();
                        using (BinaryReader br = new BinaryReader(responseStream))
                        {
                            imageBytes = br.ReadBytes(300000);
                            br.Close();
                        }
                        responseStream.Close();
                        imageResponse.Close();

                        FileStream fs = new FileStream(saveLocation, FileMode.Create);
                        BinaryWriter bw = new BinaryWriter(fs);
                        try
                        {
                            bw.Write(imageBytes);
                        }
                        catch (Exception ex)
                        {
                           Console.Write("Intermitencia en la señal\n " + ex.Message);
                           // break;
                        }
                        finally
                        {
                            fs.Close();
                            bw.Close();
                        }

                    }
                    catch (Exception exp)
                    {
                        Console.Write("Imagen no sincronizada : " + id + ".jpg\n itermitencia en la señal\n Por favor reinicia la sincronización!");

                    }


                }
            }
            catch (Exception e) {
                MessageBox.Show("No es Posible Conectar con el servidor\nIntentelo mas tarde!");
            }

            
        
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Dao.Dao dao = new Dao.Dao();
            dao.syncMarcaje();
            dao.syncMarcajeComedor();
        }
        }
    }