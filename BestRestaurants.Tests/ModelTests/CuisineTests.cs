using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using BestRestaurants.Models;

namespace BestRestaurants.Tests
{
  [TestClass]
  public class CuisineTests
  {
    [TestMethod]
    public void CuisineConstructor_CreatesInstanceOfCuisine_Cuisine()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("thai", "spicy SE Asian");

      //Assert
      Assert.AreEqual(typeof(Cuisine), newCuisine.GetType());
    }

    [TestMethod]
    public void Name_ReturnName_String()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("thai", "spicy SE Asian");

      //Act
      string result = newCuisine.Name;

      //Assert
      Assert.AreEqual(result, "thai");
    }

    [TestMethod]
    public void Description_ReturnDescription_String()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("thai", "spicy SE Asian");

      //Act
      string result = newCuisine.Description;

      //Assert
      Assert.AreEqual(result, "spicy SE Asian");
    }

    [TestMethod]
    public void Name_SetName_String()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("thai", "spicy SE Asian");
      string newName = "barbecue";

      //Act
      string result = newCuisine.Name = newName;

      //Assert
      Assert.AreEqual(result, "barbecue");
    }

    [TestMethod]
    public void Description_SetDescription_String()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("thai", "spicy SE Asian");
      string newDescription = "Southern eatin'";
      //Act
      string result = newCuisine.Description = newDescription;

      //Assert
      Assert.AreEqual(result, "Southern eatin'");
    }

  }

  

}
