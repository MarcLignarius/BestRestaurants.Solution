using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BestRestaurants.Models
{

    public class Cuisine
    {
      private string _name;
      private string _description;

      public Cuisine(string name, string description)
      {
        _name = name;
        _description = description;
      }

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
          // Line below now only provides one argument!
          Cuisine newCuisine = new Cuisine(cuisineName, cuisineDescription);
          allCuisines.Add(newCuisine);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allCuisines;
      }

      // public override bool Equals(System.Object otherCuisine)
      // {
      //     if (!(otherCuisine is Cuisine))
      //     {
      //         return false;
      //     }
      //     else
      //     {
      //         Cuisine newCuisine = (Cuisine) otherCuisine;
      //         bool idEquality = this.GetId().Equals(newCuisine.GetId());
      //         bool nameEquality = this.GetName().Equals(newCuisine.GetName());
      //         return (idEquality && nameEquality);
      //     }
      // }

      public void Save()
      {

      }

      // public override int GetHashCode()
      // {
      //     return this.GetId().GetHashCode();
      // }


    }

}
