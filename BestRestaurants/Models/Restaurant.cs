using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BestRestaurants.Models
{
    public class Restaurant
    {
        private int _id;
        private string _name;
        private string _description;
        private int _cuisineId;

        public Restaurant (string name, string description, int cuisineId, int id = 0)
        {
            _id = id;
            _name = name;
            _description = description;
            _cuisineId = cuisineId;
        }

        public int Id{ get => _id; }
        public string Name{ get => _name; set => _name = value; }
        public string Description{ get => _description; set => _description = value; }
        public int CuisineId{ get => _cuisineId; }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO restaurants (name, description, cuisine_id) VALUES (@name, @description, @cuisine_id);";
            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;
            cmd.Parameters.Add(name);
            MySqlParameter description = new MySqlParameter();
            description.ParameterName = "@description";
            description.Value = this._description;
            cmd.Parameters.Add(description);
            MySqlParameter cuisineId = new MySqlParameter();
            cuisineId.ParameterName = "@cuisine_id";
            cuisineId.Value = this._cuisineId;
            cmd.Parameters.Add(cuisineId);
            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

    }

}
