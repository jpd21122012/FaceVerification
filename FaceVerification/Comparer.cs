using System;
using RestSharp;
using Emgu.CV;
using Microsoft.ProjectOxford.Face;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using FaceVerification.Class;
using System.IO;
using System.Threading;

namespace FaceVerification
{
    public partial class Comparer : Form
    {
        private Capture captar;
        public static string idActual = "";
        //private Recognition rec= new Recognition();
        Recognition rec = new Recognition();
        private Image<Bgr, Byte> imgOriginal;
       // ConexionBD bd = new ConexionBD();

        public Comparer()
        {
            InitializeComponent();
            tbalerta.Visible=false;
        }


        private void BtnTakepic_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("Image1.jpg");
        }
        public void SetAlert(string nombre, string edad, string desc)
        {
            tbalerta.Visible = true;
            tbalerta.Text = "Nombre: " + nombre + "Edad: " + edad + "Descripcion: " + desc;
        }
        private void 
            BtnEnter_Click(object sender, EventArgs e)
        {
            //bd.Comparator();//1
            //DetecFacesAndDisplayResult("Image1.jpg", "12476023b4c349939778c49e5db321d6","",0);//1
            //Similar Finder
            //pil.SimilarFinder("Image1.jpg", "12476023b4c349939778c49e5db321d6", "", 0);//1.1
            rec.HttpFindSimilarAsync("Image1.jpg");//2

        }
        public async void DetecFacesAndDisplayResult(string fileLocation, string subscriptionKey, string name, int edad)
        {
            using (var fileStream = File.OpenRead(fileLocation))
            {
                try
                {
                    var client = new FaceServiceClient(subscriptionKey);
                    var faces = await client.DetectAsync(fileStream, true,false,null);
                    Thread.Sleep(1000);
                    while (faces.Length!=1)
                    {
                        Console.WriteLine("Imprimiendo id " + faces.Length);
                    }
                    if (faces.Length!=0)
                    {
                        Console.WriteLine(" > " + faces.Length + " detected.");
                        Console.WriteLine(" >> Id: " + faces[0].FaceId.ToString());
                        idActual = faces[0].FaceId.ToString();
                    }
                    else
                    {
                        Console.WriteLine("No se detectaron rostros");
                    }
                    Console.WriteLine("Estas en Comparer y el id: " + idActual);
                    //rec.Evaluate(idActual);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
            }
        }
        private void Comparer_Load(object sender, EventArgs e)
        {
            {
                try
                {
                    captar = new Capture(0); // Creación de una nueva instancia de la clase capture, usa la camara con el índice cero
                }
                catch (Exception ex)
                {
                    MessageBox.Show("unable to read from webcam, error: " + Environment.NewLine + ex.Message + "\nexiting program");
                    Environment.Exit(0);
                    return;
                }
                Application.Idle += ProcessFrameAndUpdateGUI;
            }
        }
            void ProcessFrameAndUpdateGUI(object sender, EventArgs arg)//Metodo para actualizar la imagen que captura la camara
        {
            imgOriginal = captar.QueryFrame().ToImage<Bgr, Byte>(); ; //Asignación de la imagen capturasa al objeto imgOriginal 
            if (imgOriginal == null)
            {
                MessageBox.Show("unable to read frame from webcam " + "exiting program");
                Environment.Exit(0);
                return;
            }
            Image img = imgOriginal.ToBitmap();
            pictureBox1.Image = img; //Asignación de la imagen como atributo de la forma (imageBox)
        }

    }
    }
