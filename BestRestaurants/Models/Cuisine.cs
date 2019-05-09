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

    }

}
