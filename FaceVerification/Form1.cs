using System;
using RestSharp;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using FaceVerification.Class;

namespace FaceVerification
{
    public partial class Form1 : Form
    {
        private Capture captar;
        Recognition rec = new Recognition();
        ConexionBD bd = new ConexionBD();
        private Image<Bgr, Byte> imgOriginal;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
            Application.Idle += processFrameAndUpdateGUI;
        }
        void processFrameAndUpdateGUI(object sender, EventArgs arg)//Metodo para actualizar la imagen que captura la camara
        {
            imgOriginal = captar.QueryFrame().ToImage<Bgr, Byte>();; //Asignación de la imagen capturasa al objeto imgOriginal 
            if (imgOriginal == null)
            {
                MessageBox.Show("unable to read frame from webcam " + "exiting program");
                Environment.Exit(0);
                return;
            }
            Image img = imgOriginal.ToBitmap();
            pictureBox1.Image =img; //Asignación de la imagen como atributo de la forma (imageBox)
        }

        private void btntakepic_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("Image.jpg");
        }

        private void btnidorig_Click(object sender, EventArgs e)
        {
             rec.DetecFacesAndDisplayResult("Image.jpg","5fc4f455ea874e91ab731db2b97120e1",tbname.Text,Convert.ToInt32(tbage.Text));
            tbage.Text = "";
            tbname.Text = "";
        }

    }
}
