using System;

public class Class1
{
    public Class1()
    {
     
        private static async void DetecFacesAndDisplayResult(string fileLocation, string subscriptionKey)
        {
            using (var fileStream = File.OpenRead(fileLocation))
            {
                try
                {
                    var client = new FaceServiceClient(subscriptionKey);
                    var faces = await client.DetectAsync(fileStream, true);
                    Console.WriteLine(" > " + faces.Length + " detected.");
                    foreach (var face in faces)
                    {
                            Console.WriteLine(" >> Id: " + face.FaceId);
                    }
                }
                catch (Exception exception)
                {
                Console.WriteLine(exception.ToString());
            }
        }
    }
}

