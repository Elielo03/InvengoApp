using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Invengo.Sample
{
    public enum httpVerb { 
    GET,
    POST,
    PUT,
    DELETE
    }
    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public RestClient(){
            
        }
        public string makeRequest() {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method.ToString();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK) {
                    throw new ApplicationException("Error code: " + response.StatusCode.ToString());
                }
                //Process the responder stream (puese ser json,xml,html, etc)

                using (Stream responseStream = response.GetResponseStream()) {

                    if (responseStream != null) {
                        using (StreamReader reader = new StreamReader(responseStream)) {
                            strResponseValue = reader.ReadToEnd();
                        }//end of using StramReader
                    } 

                }// end of using Stream

            }//end using HttpWebResponse

            return strResponseValue;
        }
    }
}
