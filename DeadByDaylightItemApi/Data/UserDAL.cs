using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Interface;

namespace Data
{
    public class UserDAL : IUeser, IUserContainer
    {
        
        private string connectionString = "server=localhost;user=root;database=dbddb2;port=3306;password='';SslMode=none";
        MySqlConnection connection;
        string query;

        public UserDAL()
        {
            connection = new MySqlConnection(connectionString);
        }

        public int Update(UserDTO userDTO)
        {
            try
            {
                connection.Open();
                string query = "UPDATE `user` SET `UserName`= @username,`Email`= @email,`FirstName`= @firstname, `LastName`= @lastname, Pic = @pic WHERE `Id` = @Id";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", userDTO.Id);
                cmd.Parameters.AddWithValue("@username", userDTO.Username);
                cmd.Parameters.AddWithValue("@email", userDTO.Email);
                cmd.Parameters.AddWithValue("@firstname", userDTO.Steamid);
                cmd.Parameters.AddWithValue("@lastname", userDTO.Lastname);
                cmd.Parameters.AddWithValue("@pic", userDTO.Pic.Id);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
            return 1;
        }


        /// <summary>
        /// adds item to users inventory
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="userid"></param>
        /// <returns>the added item</returns>
        public ItemDTO AddItem(int itemid, int userid)
        {
            try
            {
                connection.Open();
                query = "SELECT `UserId`, `ItemId` FROM `useritem` WHERE `UserId` = @userid AND `ItemId` = @itemid;";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@itemid", itemid);
                if (cmd.ExecuteScalar() == null)
                {
                    query = "INSERT INTO `useritem`(`UserId`, `ItemId`) VALUES (@userid, @itemid)";
                    cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@itemid", itemid);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Item added");
                    connection.Close();
                    ItemDAL itemdal = new ItemDAL();
                    return itemdal.GetItemById(itemid);
                }
                else
                {
                    Console.WriteLine("Item already exists");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return new Interface.ItemDTO();
        }
        public AddonDTO AddAddon(int addonid, int userid)
        {
            try
            {
                connection.Open();
                query = "SELECT `UserId`, `AddonId` FROM `useraddon` WHERE `UserId` = @userid AND `AddonId` = @addonid;";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@addonid", addonid);
                if (cmd.ExecuteScalar() == null)
                {
                    query = "INSERT INTO `useraddon`(`UserId`, `AddonId`) VALUES (@userid, @addonid)";
                    cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@addonid", addonid);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("addon added");

                    connection.Close();
                    AddonDAL addondal = new AddonDAL();
                    return addondal.GetAddonById(addonid);
                }
                else
                {
                    Console.WriteLine("Item already exists");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return new AddonDTO();
        }
        public List<Interface.ItemDTO> GetAllItems(int userid)
        {
            List<Interface.ItemDTO> itemdtos = new List<Interface.ItemDTO>();
            try
            {
               
                connection.Open();
                query = "SELECT * FROM `useritem` WHERE `UserId` = @userid";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userid", userid);
                var reader = cmd.ExecuteReader();
                List<int> itemids = new List<int>();
                while (reader.Read())
                {
                    itemids.Add(reader.GetInt32(1));
                }
                connection.Close();
                foreach(int i in itemids)
                {
                    ItemDAL itemdal = new ItemDAL();
                    itemdtos.Add(itemdal.GetItemById(i));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return (itemdtos);
        }

        public List<AddonDTO> GetAllAddons(int userid)
        {
            List<AddonDTO> addonDTOs = new List<AddonDTO>();
            try
            {

                connection.Open();
                query = "SELECT * FROM `useraddon` WHERE `UserId` = @userid";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userid", userid);
                var reader = cmd.ExecuteReader();
                List<int> addonids = new List<int>();
                while (reader.Read())
                {
                    addonids.Add(reader.GetInt32(1));
                }
                connection.Close();
                AddonDAL addondal = new AddonDAL();
                foreach (int i in addonids)
                {
                    
                    addonDTOs.Add(addondal.GetAddonById(i));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return (addonDTOs);
        }

        public void RemoveItem(int userid, int itemid)
        {
            try
            {
                connection.Open();
                query = "DELETE FROM `useritem` WHERE `UserId` = @userid AND `ItemId` = @itemid";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@itemid", itemid);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void RemoveAddon(int userid, int addonid)
        {
            try
            {
                connection.Open();
                query = "DELETE FROM `useraddon` WHERE `UserId` = @userid AND `AddonId` = @addonid";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@addonid", addonid);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public int AddNewUser(Interface.UserDTO UserDTO)
        {
            try
            {
                connection.Open();
                
                string query = "SELECT MAX(Id) FROM `user`;";
                var cmd = new MySqlCommand(query, connection);
                int id = (int)cmd.ExecuteScalar() + 1;
                query = "INSERT INTO `user`(`Id`, `UserName`, `Email`, `Password`, `FirstName`, `LastName`) VALUES (@id,@username,@email,@password,@firstname,@lastname)";
                cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@username", UserDTO.Username);
                cmd.Parameters.AddWithValue("@email", UserDTO.Email);
                cmd.Parameters.AddWithValue("@password", UserDTO.Password);
                cmd.Parameters.AddWithValue("@firstname", UserDTO.Steamid);
                cmd.Parameters.AddWithValue("@lastname", UserDTO.Lastname);
                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
            return 1;
        }

        public Interface.UserDTO FindUserByUsername(string Username)
        {
            UserDTO user = new UserDTO();
            try
            {
                connection.Open();
                string query = "SELECT * FROM `user` WHERE BINARY `UserName` = @username;";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", Username);
                var reader = cmd.ExecuteReader();
                int pic = 0;
                while (reader.Read())
                {
                    user.Id = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Email = reader.GetString(2);
                    user.Password = reader.GetString(3);
                    user.Steamid = reader.GetString(4);
                    user.Lastname = reader.GetString(5);
                    pic = reader.GetInt32(6);
                }
                connection.Close();

                connection.Open();
                query = "SELECT * FROM `pic` WHERE Id = @picid";
                cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@picid", pic);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user.Pic.Id = reader.GetInt32(0);
                    user.Pic.Pic = (byte[])reader.GetValue(1);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return user;
        }
    }
}
