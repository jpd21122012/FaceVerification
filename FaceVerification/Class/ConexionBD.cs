using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using FaceVerification.Class;
using System.Data.SqlClient;

namespace FaceVerification
{
    public class ConexionBD
    {
        public SqlConnection conn;
        //Comparer comp = new Comparer();
        public static string identificator;
        public void ConectTest()
        {
            SqlConnection cnn = new SqlConnection("Data Source=uptjpd.database.windows.net;Initial Catalog=FaceIdRecognition;Integrated Security=False;User ID=jpd21122012;Password=000pipo.182;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {
                cnn.Open();
                MessageBox.Show("Successfull");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect to data source");
            }
            finally
            {
                cnn.Close();
            }
        }

        public void ConnectToSql()
        {
            conn.ConnectionString = "Data Source=uptjpd.database.windows.net;Initial Catalog=FaceIdRecognition;Integrated Security=False;User ID=jpd21122012;Password=000pipo.182;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                conn.Open();
                MessageBox.Show("Successfull");
                // Insert code to process data.
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect to data source");
            }
            finally
            {
                conn.Close();
            }
        }
        public static void GuardarInfo(string nombre, int edad, string description, string persistentId)
        {
            using (SqlConnection cnn = new SqlConnection("Data Source=uptjpd.database.windows.net;Initial Catalog=FaceIdRecognition;Integrated Security=False;User ID=jpd21122012;Password=000pipo.182;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Open();
                string query = "INSERT INTO [FaceIdRecognition].[dbo].[UsersUPT] ([Nombre],[Edad],[Descripcion],[PID]) VALUES ('" + nombre + "','" + edad + "','" + description + "','" + persistentId + "')";
                SqlCommand cmd = new SqlCommand(query, cnn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Se agregaron los datos!!!");
                }
                else
                {
                    MessageBox.Show("Transaccion incompleta");
                }
                cnn.Close();
                cmd.Dispose();
            }
        }
        public void VisualizarInfo(string persistentId)
        {
            string name = "", age = "", desc = "";
            Console.WriteLine("Estas en visualizar");
            using (SqlConnection cnn = new SqlConnection("Data Source=uptjpd.database.windows.net;Initial Catalog=FaceIdRecognition;Integrated Security=False;User ID=jpd21122012;Password=000pipo.182;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Open();
                Console.WriteLine("Conexion abierta\npid: " + persistentId + "\n");
                string query = "SELECT * FROM [Data] WHERE PID='" + persistentId + "'";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine("Data+ " + myReader);
                    name = myReader[1].ToString();
                    age = myReader[2].ToString();
                    desc = myReader[3].ToString();
                }
                //comp.SetAlert(name,age,desc);
                MessageBox.Show("Nombre: " + name + "\nEdad: " + age + "\nDescripcion:" + desc);
                Console.WriteLine("Se termino el metodo");
                cnn.Close();
                cmd.Dispose();
            }
        }

        public void Comparator()
        {
            using (SqlConnection cnn = new SqlConnection("Data Source=NECROPHAGIAVAIO;Initial Catalog=FaceId;Integrated Security=True"))
            {
                cnn.Open();
                string query = "SELECT dbo.Identificator.FaceId FROM dbo.Identificator";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine(myReader[0]);
                    Recognition.lista.Add(myReader[0].ToString());

                }
                Console.WriteLine(Recognition.lista[0]);
                //Console.WriteLine(Recognition.lista[1]);
                cnn.Close();
                myReader.Close();
                cmd.Dispose();
            }
        }

    }
}