using Npgsql;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using FaceVerification.Class;

namespace FaceVerification
{
    public class ConexionBD
    {
        public Recognition func;
        public SqlConnection conn;
        public static string identificator;

        public void ConnectToSql()
        {
        conn.ConnectionString = "Data Source=NECROPHAGIAVAIO;Initial Catalog=FaceId;Integrated Security=True";
            try
            { 
                conn.Open();
                MessageBox.Show("Successfull");
                // Insert code to process data.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source");
            }
            finally
            {
                conn.Close();
            }
        }
        public void GuardarInfo(string nombre,int edad, string faceid)
        {
            using (SqlConnection cnn = new SqlConnection("Data Source=NECROPHAGIAVAIO;Initial Catalog=FaceId;Integrated Security=True"))
            {
                
                cnn.Open();
                string query = "INSERT INTO [FaceId].[dbo].[Identificator] ([Name], [Age], [FaceId]) VALUES ('"+nombre+"', '"+edad+"', '"+faceid+"')";
                SqlCommand cmd = new SqlCommand(query, cnn);
                //cmd.Parameters.AddWithValue("@fabricante", );
                //cmd.Parameters.AddWithValue("@matricula", Convert.ToInt32(edad));
                //cmd.Parameters.AddWithValue("@fabricante", );
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
                Console.WriteLine(Recognition.lista[1]);
                cnn.Close();
                myReader.Close();
                cmd.Dispose();
            }
        }
        
    }
}