using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace Data
{
    public class EffectDAL : Interface.IEffectContainer
    {
        private string connectionString = "server=localhost;user=root;database=dbddb2;port=3306;password='';SslMode=none";
        MySqlConnection connection;

        public EffectDAL()
        {
            connection = new MySqlConnection(connectionString);
        }

        public List<Interface.EffectDTO> GetAllEffects()
        {
            List<Interface.EffectDTO> effectDTOs = new List<Interface.EffectDTO>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM `effect`;";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Interface.EffectDTO effectDTO = new Interface.EffectDTO();
                    effectDTO.Id = reader.GetInt32(0);
                    effectDTO.Name = reader.GetString(1);
                    effectDTO.HealSpeedMultiplier = reader.GetDouble(2);
                    effectDTO.RepairSpeedMultiplier = reader.GetDouble(3);
                    effectDTO.SaboSpeedMultiplier = reader.GetDouble(4);
                    effectDTO.ItemEffMultiplier = reader.GetDouble(5);
                    effectDTO.ChargesMultiplier = reader.GetDouble(6);
                    effectDTO.Stacks = reader.GetInt32(7);
                    effectDTO.KillerEffect = reader.GetBoolean(8);
                    effectDTO.Condition = reader.GetString(9);
                    effectDTOs.Add(effectDTO);
                }
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Can not open connection ! ");
            }
            return effectDTOs;
        }
    }
}
