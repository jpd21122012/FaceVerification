using Microsoft.ProjectOxford.Face;
using System;
using System.IO;
using FaceVerification;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace FaceVerification.Class { 
public class Recognition
{
        public static string idlist = "";
        public static string httpidlist = "";
        public static string idReturned = "";
        public static double idconfReturned;
        ConexionBD bd = new ConexionBD();
        public async void HttpFindSimilarAsync(string fileLocation)
        {
            using (var fileStream = File.OpenRead(fileLocation))
            {
                try
                {
                    var client1 = new FaceServiceClient("12476023b4c349939778c49e5db321d6");
                    var faces = await client1.DetectAsync(fileStream, true);
                    Console.WriteLine(" > " + faces.Length + " detected.");
                    Console.WriteLine(" >> IdActual: " + faces[0].FaceId.ToString());
                    httpidlist = faces[0].FaceId.ToString();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
                fileStream.Close();
            }
            var client = new RestClient("https://westus.api.cognitive.microsoft.com/face/v1.0/findsimilars?");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("ocp-apim-subscription-key", "12476023b4c349939778c49e5db321d6");
            request.AddParameter("application/json", "{\"faceId\":\"" + httpidlist + "\",\"faceListId\":\"21122012\",\"maxNumOfCandidatesReturned\":1,\"mode\": \"matchPerson\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content.Trim('[').Trim(']'));
            JObject o = JObject.Parse(response.Content.Trim('[').Trim(']'));
            string responsejson = ((string)o["persistedFaceId"]);
            double responseconf = ((double)o["confidence"]);
            Console.WriteLine("Se encontro: " + responsejson);
            idReturned = responsejson;
            idconfReturned = responseconf;
            //Evaluar si es mayor a .7 entonces regresa los datos de la persona
            if (idconfReturned >= .67)
            {
                MessageBox.Show("Usuario encontrado");
                // busqueda en la base de datos
                Console.WriteLine("Entrando a metodo bd.visualizar info de sujeto \n");
                bd.VisualizarInfo(idReturned);
            }
        }

        //PersistentIdList pil = new PersistentIdList();
        //    public async void DetecFacesAndDisplayResult(string fileLocation, string subscriptionKey,string name,int edad)
        //{
        //    using (var fileStream = File.OpenRead(fileLocation))
        //    {
        //        try
        //        {
        //            var client = new FaceServiceClient(subscriptionKey);
        //            var faces = await client.DetectAsync(fileStream, true);
        //            Console.WriteLine(" > " + faces.Length + " detected.");
        //                  Console.WriteLine(" >> Id: " + faces[0].FaceId.ToString());
        //                GuardarInfo(name,edad, faces[0].FaceId.ToString());
        //                Comparer.idActual = faces[0].FaceId.ToString();
        //            }
        //            catch (Exception exception)
        //        {
        //            Console.WriteLine(exception.ToString());
        //        }
        //            fileStream.Close();
        //        }
        //       // pil.AddListId("Image.jpg", "12476023b4c349939778c49e5db321d6", name, edad);
        //    }
        public void Evaluate(string persistident)
        {
            Console.WriteLine("El id a comparar es: "+persistident);
            bool x;
            foreach (string element in Recognition.lista)
            {
                x = FaceVerification(element,persistident);
                Console.WriteLine(x);
                if (x == true)
                {
                    MessageBox.Show("Ingreso Correcto");
                    break;
                }
                else
                {
                    MessageBox.Show("Ingreso Incorrecto");
                }
            }
        }
        public static List<string> lista = new List<string>();


        public bool FaceVerification(string id2,string id1)
        {
            Console.WriteLine(id1);
            var client = new RestClient("https://api.projectoxford.ai/face/v1.0/verify?isIdentical");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("ocp-apim-subscription-key", "12476023b4c349939778c49e5db321d6");
            request.AddParameter("application/json", "{\"faceId1\":\""+id1+"\", \"faceId2\":\""+id2+"\"}", ParameterType.RequestBody);
            Console.WriteLine("Tu id es: "+id1);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            JObject o = JObject.Parse(response.Content);
            bool responsejson = ((bool)o["isIdentical"]);
            Console.WriteLine(responsejson);
            return responsejson;
        }
    }
}