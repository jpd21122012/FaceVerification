using Microsoft.ProjectOxford.Face;
using System;
using System.IO;
using FaceVerification;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace FaceVerification.Class { 
public class Recognition:ConexionBD
{

        public async void DetecFacesAndDisplayResult(string fileLocation, string subscriptionKey,string name,int edad)
    {
        using (var fileStream = File.OpenRead(fileLocation))
        {
            try
            {
                var client = new FaceServiceClient(subscriptionKey);
                var faces = await client.DetectAsync(fileStream, true);
                Console.WriteLine(" > " + faces.Length + " detected.");
               
                    //foreach (var face in faces)
                    //{
                      Console.WriteLine(" >> Id: " + faces[0].FaceId.ToString());
                    //}
                 //  GuardarInfo(name,edad, faces[0].FaceId.ToString());

                }
                catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
        }
    }
        public void Evaluate(string identificat)
        {
            Console.WriteLine(identificat);
            bool x;
            foreach (string element in Recognition.lista)
            {
                x = FaceVerification(element,identificat);
                Console.WriteLine(x);
                if (x == true)
                {
                    MessageBox.Show("Ingreso Correcto");
                }
            }
        }
        public static List<string> lista = new List<string>();
        public string iiid;
        public async void id(string fileLocation, string subscriptionKey)
        {
            using (var fileStream = File.OpenRead(fileLocation))
            {
                try
                {
                    var client = new FaceServiceClient(subscriptionKey);
                    var faces = await client.DetectAsync(fileStream, true);
                    Console.WriteLine(" > " + faces.Length + " detected.");
                     iiid=(faces[0].FaceId.ToString());
                    identificator = iiid;   
                    Console.WriteLine("Tu id actual es: "+identificator);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
            }
        }

        public bool FaceVerification(string id2,string id1)
        {
            Console.WriteLine(id1);
            var client = new RestClient("https://api.projectoxford.ai/face/v1.0/verify?isIdentical");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("ocp-apim-subscription-key", "a639336dacb84a6f9e52216d6a376f62");
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