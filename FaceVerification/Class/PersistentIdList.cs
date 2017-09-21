using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ProjectOxford.Face;
using System.Text;
using Microsoft.ProjectOxford;
using System.Threading.Tasks;
using System.Threading;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace FaceVerification.Class
{
    public class PersistentIdList
    {
        public static string idReturned = "";
        public static double idconfReturned;
        public ConexionBD co = new ConexionBD();
        public async void AddListId(string fileLocation, string subscriptionKey, string name, int edad, string descrip)
        {
            using (var fileStream = File.OpenRead(fileLocation))
            {
                try
                {
                    var client = new FaceServiceClient(subscriptionKey);
                    //var faces1 = await client.DetectAsync(fileStream, true);
                        var faces = await client.AddFaceToFaceListAsync("21122011", fileStream, name);
                    Console.WriteLine(" >> PId: " + faces.PersistedFaceId.ToString());
                    Form1.PID = faces.PersistedFaceId.ToString();
                    //ConexionBD.GuardarInfo(name, edad, descrip, Form1.PID);
                    //Comparer.idActual = faces.PersistedFaceId.ToString();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
                fileStream.Close();
            }
        }
        public static string idlist = "";
        public static string httpidlist = "";
        //metodo 2
        public async void SimilarFinder(string fileLocation, string subscriptionKey, string name, int edad)
        {
            using (var fileStream = File.OpenRead(fileLocation))
            {
                try
                {
                    var client = new FaceServiceClient(subscriptionKey);
                    var faces = await client.DetectAsync(fileStream, true);
                    Console.WriteLine(" > " + faces.Length + " detected.");
                    Console.WriteLine(" >> IdActual: " + faces[0].FaceId.ToString());
                    idlist = faces[0].FaceId.ToString();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
                fileStream.Close();
            }
            Guid guidId = Guid.Parse(idlist);
            Console.WriteLine("Entrando a Find Similar\n" + guidId);
            Thread.Sleep(4000);
            //findsimilar
            using (var fileStream = File.OpenRead(fileLocation))
            {
                try
                {
                    var client = new FaceServiceClient(subscriptionKey);
                    var faces = await client.FindSimilarAsync(guidId, "21122012", 1);
                    Console.WriteLine(" >> PId: " + faces[0].ToString() + faces[1].ToString());
                    //Comparer.idActual = faces.PersistedFaceId.ToString();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
                fileStream.Close();
            }
        }

    }
}
