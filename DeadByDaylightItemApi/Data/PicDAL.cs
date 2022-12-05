using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Interface;
namespace Data
{
    public class PicDAL : IPic
    {
        private string connectionString = "server=localhost;user=root;database=dbddb2;port=3306;password='';SslMode=none";
        MySqlConnection connection;
        string query;

        public PicDAL()
        {
            connection = new MySqlConnection(connectionString);
        }

        public List<PicDTO> GetAllPics()
        {
            List<PicDTO> pics = new List<PicDTO>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM `pic` WHERE 1;";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pics.Add(new PicDTO()
                    {
                        Id = reader.GetInt32(0),
                        Pic = (byte[])reader.GetValue(1)
                    });

                    
                }
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Can not open connection ! ");
            }
            return pics;
        }
    }
}
