using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwndImages
{
    class NorthwndImages
    {
        private const string ConnetionString = "Server=.;Database=Northwnd;Integrated Security=true;";

        private static byte[] ExtractDbImage(int imageId)
        {
            SqlConnection connection = new SqlConnection(ConnetionString);
            connection.Open();
            byte[] image;
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT Picture FROM Categories " +
                    "WHERE CategoryId = @id", connection);
                SqlParameter idParameter = new SqlParameter("@id", imageId);
                command.Parameters.Add(idParameter);

                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    if (reader.Read())
                    {
                        image = (byte[])reader["Picture"];
                    }
                    else
                    {
                        throw new Exception(String.Format("Invalid image ID={0}.", idParameter));
                    }
                }
            }
            return image;
        }

        private static void InsertImageToDB(byte[] image)
        {
            SqlConnection connection = new SqlConnection(ConnetionString);
            connection.Open();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Categories (CategoryName, Description, Picture)" + 
                    "VALUES (@categoryName, @description, @picture)",
                    connection
                );

                SqlParameter category = new SqlParameter("@categoryName", SqlDbType.NVarChar);
                SqlParameter description = new SqlParameter("@description", SqlDbType.NText);
                SqlParameter picture = new SqlParameter("@picture", SqlDbType.Image);
                category.Value = "New category";
                description.Value = "Some description";
                picture.Value = image;
                command.Parameters.AddRange(new SqlParameter[] { category, description, picture });
                command.ExecuteNonQuery();
            }
        }

        static void WriteBinaryFile(string fileName, byte[] content)
        { 
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(content, 0, content.Length);
            }
        }

        private static byte[] ReadBinaryFile(string fileName)
        {
            FileStream stream = File.OpenRead(fileName);
            using (stream)
            {
                int pos = 0;
                int length = (int)stream.Length;
                byte[] buf = new byte[length];
                while (true)
                {
                    int bytesRead = stream.Read(buf, pos, length - pos);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    pos += bytesRead;
                }
                return buf;
            }
        }

        static void Main(string[] args)
        {
            byte[] inputImage = ReadBinaryFile(@"..\..\input.jpg");
            InsertImageToDB(inputImage);

            int CategoryID = 12; //CHANGE Category ID
            byte[] outputImage = ExtractDbImage(CategoryID);
            WriteBinaryFile(@"..\..\output.jpg", outputImage);
        }
  
    }
}
