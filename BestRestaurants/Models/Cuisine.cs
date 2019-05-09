using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BestRestaurants.Models
{

    public class Cuisine
    {
      private int _id;
      private string _name;
      private string _description;

      public Cuisine(string name, string description, int id = 0)
      {
        _name = name;
        _description = description;
        _id = id;
      }

      public int Id{ get => _id; }
      public string Name{ get => _name; set => _name = value; }
      public string Description{ get => _description; set => _description = value; }

      public static void ClearAll()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM cuisines;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }

      public static List<Cuisine> GetAll()
      {
        List<Cuisine> allCuisines = new List<Cuisine> { };
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM cuisines;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int cuisineId = rdr.GetInt32(0);
          string cuisineName = rdr.GetString(1);
          string cuisineDescription = rdr.GetString(2);
          Cuisine newCuisine = new Cuisine(cuisineName, cuisineDescription, cuisineId);
          allCuisines.Add(newCuisine);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allCuisines;
      }

      public override bool Equals(System.Object otherCuisine)
      {
          if (!(otherCuisine is Cuisine))
          {
              return false;
          }
          else
          {
              Cuisine newCuisine = (Cuisine) otherCuisine;
              bool idEquality = this.Id.Equals(newCuisine.Id);
              bool nameEquality = this.Name.Equals(newCuisine.Name);
              bool descriptionEquality = this.Description.Equals(newCuisine.Description);
              return (idEquality && nameEquality && descriptionEquality);
          }
      }

      // public override int GetHashCode()
      // {
      //     return this.Id.GetHashCode();
      // }

      public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO cuisines (name, description) VALUES (@CuisineName, @CuisineDescription);";
        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@CuisineName";
        name.Value = this._name;
        cmd.Parameters.Add(name);
        MySqlParameter description = new MySqlParameter();
        description.ParameterName = "@CuisineDescription";
        description.Value = this._description;
        cmd.Parameters.Add(description);
        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;

         conn.Close();
         if (conn != null)
         {
           conn.Dispose();
         }
      }

       public static Cuisine Find(int id)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM `cuisines` WHERE id = @thisId;";
        MySqlParameter thisId = new MySqlParameter();
        thisId.ParameterName = "@thisId";
        thisId.Value = id;
        cmd.Parameters.Add(thisId);
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int cuisineId = 0;
        string cuisineName = "";
        string cuisineDescription = "";
        while (rdr.Read())
        {
           cuisineId = rdr.GetInt32(0);
           cuisineName = rdr.GetString(1);
           cuisineDescription = rdr.GetString(2);
        }
        Cuisine foundCuisine= new Cuisine(cuisineName, cuisineDescription, cuisineId);  // This line is new!
         conn.Close();
         if (conn != null)
         {
           conn.Dispose();
         }
        return foundCuisine;
      }


    }

}
