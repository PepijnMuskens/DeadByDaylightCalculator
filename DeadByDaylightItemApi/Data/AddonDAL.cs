using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Data
{
    public class AddonDAL : Interface.IAddonContainer
    {
        private string connectionString = "server=sql7.freesqldatabase.com;user=sql7585399;database=sql7585399;port=3306;password='guWYYxITAN';SslMode=none";
        private string connectionStringlocal = "server=localhost;user=root;database=dbddb2;port=3306;password='';SslMode=none";
        MySqlConnection connection;

        public AddonDAL()
        {
            connection = new MySqlConnection(connectionStringlocal);
        }

        public List<Interface.AddonDTO> GetAllAddons()
        {
            List<Interface.AddonDTO> addonDTOs = new List<Interface.AddonDTO>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM `addon`;";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    Interface.AddonDTO addonDTO = new Interface.AddonDTO();
                    addonDTO.Id = reader.GetInt32(0);
                    addonDTO.Name = reader.GetString(1);
                    string type = reader.GetString(2);
                    for (int i = 0; i < 5; i++)
                    {
                        if (addonDTO.Type.ToString() != type)
                        {
                            addonDTO.Type++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    addonDTO.Charges = reader.GetInt32(3);
                    addonDTO.ConsumptionRate = reader.GetDouble(4);
                    addonDTO.SelfHealSpeed = reader.GetDouble(5);
                    addonDTO.HealSpeed = reader.GetDouble(6);
                    addonDTO.RepairSpeed = reader.GetDouble(7);
                    addonDTO.SaboSpeed = reader.GetDouble(8);
                    addonDTO.BlindDuration = reader.GetDouble(9);
                    addonDTO.BlindSpeed = reader.GetDouble(10);
                    addonDTO.BeamRange = reader.GetDouble(11);
                    addonDTO.BeamAngle = reader.GetDouble(12);
                    addonDTO.Aurarange = reader.GetDouble(13);
                    addonDTO.Icon = (byte[])reader.GetValue(14);
                    addonDTOs.Add(addonDTO);
                }
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Can not open connection ! ");
            }
            return addonDTOs;
        }

        

        public List<Interface.AddonDTO> GetAllAddons(string type)
        {
            List<Interface.AddonDTO> addonDTOs = new List<Interface.AddonDTO>();
            try
            {
                connection.Open();
                string query = $"SELECT * FROM `addon` WHERE `Type` = '{type}';";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Interface.AddonDTO addonDTO = new Interface.AddonDTO();
                    addonDTO.Id = reader.GetInt32(0);
                    addonDTO.Name = reader.GetString(1);
                    for (int i = 0; i < 5; i++)
                    {
                        if (addonDTO.Type.ToString() != type)
                        {
                            addonDTO.Type++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    addonDTO.Charges = reader.GetInt32(3);
                    addonDTO.ConsumptionRate = reader.GetDouble(4);
                    addonDTO.SelfHealSpeed = reader.GetDouble(5);
                    addonDTO.HealSpeed = reader.GetDouble(6);
                    addonDTO.RepairSpeed = reader.GetDouble(7);
                    addonDTO.SaboSpeed = reader.GetDouble(8);
                    addonDTO.BlindDuration = reader.GetDouble(9);
                    addonDTO.BlindSpeed = reader.GetDouble(10);
                    addonDTO.BeamRange = reader.GetDouble(11);
                    addonDTO.BeamAngle = reader.GetDouble(12);
                    addonDTO.Aurarange = reader.GetDouble(13);
                    addonDTO.Icon = (byte[])reader.GetValue(14);
                    addonDTOs.Add(addonDTO);
                }
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Can not open connection ! ");
            }
            return addonDTOs;
        }
        public Interface.AddonDTO GetAddonById(int addonid)
        {
            Interface.AddonDTO addonDTO = new Interface.AddonDTO();
            try
            {
                connection.Open();
                string query = "SELECT * FROM `addon` WHERE `Id` = @addonid";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@addonid", addonid);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    addonDTO.Id = reader.GetInt32(0);
                    addonDTO.Name = reader.GetString(1);
                    string type = reader.GetString(2);
                    for (int i = 0; i < 5; i++)
                    {
                        if (addonDTO.Type.ToString() != type)
                        {
                            addonDTO.Type++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    addonDTO.Charges = reader.GetInt32(3);
                    addonDTO.ConsumptionRate = reader.GetDouble(4);
                    addonDTO.SelfHealSpeed = reader.GetDouble(5);
                    addonDTO.HealSpeed = reader.GetDouble(6);
                    addonDTO.RepairSpeed = reader.GetDouble(7);
                    addonDTO.SaboSpeed = reader.GetDouble(8);
                    addonDTO.BlindDuration = reader.GetDouble(9);
                    addonDTO.BlindSpeed = reader.GetDouble(10);
                    addonDTO.BeamRange = reader.GetDouble(11);
                    addonDTO.BeamAngle = reader.GetDouble(12);
                    addonDTO.Aurarange = reader.GetDouble(13);
                    addonDTO.Icon = (byte[])reader.GetValue(14);
                }
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Can not open connection ! ");
            }
            return addonDTO;
        }
    }
}
