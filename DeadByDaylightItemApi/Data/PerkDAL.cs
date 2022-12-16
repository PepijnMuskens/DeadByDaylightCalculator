using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Data
{
    public class PerkDAL : Interface.IPerkContainer
    {
        private string connectionString = "server=localhost;user=root;database=dbddb2;port=3306;password='';SslMode=none";
        MySqlConnection connection;

        public PerkDAL()
        {
            connection = new MySqlConnection(connectionString);
        }

        public List<Interface.PerkDTO> GetAllPerks()
        {
            List<Interface.PerkDTO> perkDTOs = new List<Interface.PerkDTO>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM `perk`;";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Interface.PerkDTO perkDTO = new Interface.PerkDTO();
                    perkDTO.Id = reader.GetInt32(0);
                    perkDTO.Name = reader.GetString(1);
                    perkDTO.SelfHealSpeedMultiplier = reader.GetDouble(2);
                    perkDTO.HealSpeedMultiplier = reader.GetDouble(3);
                    perkDTO.MedkitEffMultiplier = reader.GetDouble(4);
                    perkDTO.ItemEffMultiplier = reader.GetDouble(5);
                    perkDTO.ChargesMultiplier = reader.GetDouble(6);
                    perkDTO.SaboSpeedMultiplier = reader.GetDouble(7);
                    perkDTO.RepairSpeedMultiplier = reader.GetDouble(8);
                    perkDTO.AuraRange = reader.GetInt32(9);
                    perkDTO.TimeWasted = reader.GetInt32(10);
                    perkDTO.Stacks = reader.GetInt32(11);
                    perkDTO.Condition = reader.GetString(12);
                    perkDTOs.Add(perkDTO);
                }
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Can not open connection ! ");
            }
            return perkDTOs;
        }
    }
}
