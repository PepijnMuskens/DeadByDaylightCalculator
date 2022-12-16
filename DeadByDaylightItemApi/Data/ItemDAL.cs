using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace Data
{
    public class ItemDAL : Interface.IItemContainer
    {
        private string connectionString = "server=localhost;user=root;database=dbddb2;port=3306;password='';SslMode=none";
        MySqlConnection connection;

        public ItemDAL()
        {
            connection = new MySqlConnection(connectionString);
        }

        public List<Interface.ItemDTO> GetAllItems()
        {
            List<Interface.ItemDTO> itemDTOs = new List<Interface.ItemDTO>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM `item`;";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Interface.ItemDTO itemDTO = new Interface.ItemDTO();
                    itemDTO.Id = reader.GetInt32(0);
                    itemDTO.Name = reader.GetString(1);
                    string type = reader.GetString(2);
                    for (int i = 0; i < 5; i++)
                    {
                        if (itemDTO.Type.ToString() != type)
                        {
                            itemDTO.Type++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    itemDTO.Charges = reader.GetInt32(3);
                    itemDTO.ConsumptionRate = reader.GetInt32(4);
                    itemDTO.SelfHealSpeed = reader.GetDouble(5);
                    itemDTO.HealSpeed = reader.GetDouble(6);
                    itemDTO.RepairSpeed = reader.GetDouble(7);
                    itemDTO.SaboSpeed = reader.GetDouble(8);
                    itemDTO.BlindDuration = reader.GetDouble(9);
                    itemDTO.BlindSpeed = reader.GetDouble(10);
                    itemDTO.BeamRange = reader.GetDouble(11);
                    itemDTO.BeamAngle = reader.GetDouble(12);
                    itemDTO.Aurarange = reader.GetDouble(13);
                    itemDTO.Icon = (byte[])reader.GetValue(14);
                    itemDTOs.Add(itemDTO);
                }
                connection.Close();
            }
            catch(Exception e)
            {
                string error = e.Message;
                Console.WriteLine($"Can not open connection ! \n{error}");
            }
            return itemDTOs;
        }

        public Interface.ItemDTO GetItemById(int itemid)
        {
            Interface.ItemDTO itemDTO = new Interface.ItemDTO();
            try
            {
                connection.Open();
                string query = "SELECT * FROM `item` WHERE `Id` = @itemid";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@itemid", itemid);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    itemDTO.Id = reader.GetInt32(0);
                    itemDTO.Name = reader.GetString(1);
                    string type = reader.GetString(2);
                    for (int i = 0; i < 5; i++)
                    {
                        if (itemDTO.Type.ToString() != type)
                        {
                            itemDTO.Type++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    itemDTO.Charges = reader.GetInt32(3);
                    itemDTO.ConsumptionRate = reader.GetInt32(4);
                    itemDTO.SelfHealSpeed = reader.GetDouble(5);
                    itemDTO.HealSpeed = reader.GetDouble(6);
                    itemDTO.RepairSpeed = reader.GetDouble(7);
                    itemDTO.SaboSpeed = reader.GetDouble(8);
                    itemDTO.BlindDuration = reader.GetDouble(9);
                    itemDTO.BlindSpeed = reader.GetDouble(10);
                    itemDTO.BeamRange = reader.GetDouble(11);
                    itemDTO.BeamAngle = reader.GetDouble(12);
                    itemDTO.Aurarange = reader.GetDouble(13);
                    itemDTO.Icon = (byte[])reader.GetValue(14);
                }
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Can not open connection ! ");
            }
            return itemDTO;
        }

    }
}
